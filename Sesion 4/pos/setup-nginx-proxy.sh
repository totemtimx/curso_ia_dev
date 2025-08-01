#!/bin/bash

# Script de configuración para Nginx con API POS
# Ejecutar como root: sudo bash setup-nginx-proxy.sh

set -e

echo "🚀 Configurando Nginx para API POS..."

# Variables de configuración
DOMAIN=${1:-"localhost"}
BACKEND_PORT=${2:-"8000"}
CONFIG_FILE="/etc/nginx/sites-available/pos-api"

# Verificar si se ejecuta como root
if [ "$EUID" -ne 0 ]; then
    echo "❌ Este script debe ejecutarse como root (sudo)"
    exit 1
fi

# Verificar si Nginx está instalado
if ! command -v nginx &> /dev/null; then
    echo "📦 Instalando Nginx..."
    apt update
    apt install -y nginx
fi

# Crear configuración de Nginx
echo "📝 Creando configuración de Nginx..."

cat > $CONFIG_FILE << EOF
# Configuración de Nginx para API POS
# Generado automáticamente por setup-nginx-proxy.sh

server {
    listen 80;
    server_name $DOMAIN;
    
    # Configuración principal para la API POS
    location /pos/ {
        # Proxy directo - FastAPI maneja el root_path
        proxy_pass http://127.0.0.1:$BACKEND_PORT/;
        
        # Headers esenciales
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
        proxy_set_header X-Forwarded-For \$proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto \$scheme;
        proxy_set_header X-Forwarded-Host \$host;
        proxy_set_header X-Forwarded-Prefix /pos;
        
        # Configuración para WebSockets
        proxy_http_version 1.1;
        proxy_set_header Upgrade \$http_upgrade;
        proxy_set_header Connection "upgrade";
        
        # Timeouts
        proxy_connect_timeout 60s;
        proxy_send_timeout 60s;
        proxy_read_timeout 60s;
        
        # Buffers
        proxy_buffering off;
        proxy_request_buffering off;
    }
    
    # Configuración específica para documentación
    location /pos/docs {
        proxy_pass http://127.0.0.1:$BACKEND_PORT/docs;
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
        proxy_set_header X-Forwarded-For \$proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto \$scheme;
        proxy_set_header X-Forwarded-Host \$host;
        proxy_set_header X-Forwarded-Prefix /pos;
    }
    
    location /pos/redoc {
        proxy_pass http://127.0.0.1:$BACKEND_PORT/redoc;
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
        proxy_set_header X-Forwarded-For \$proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto \$scheme;
        proxy_set_header X-Forwarded-Host \$host;
        proxy_set_header X-Forwarded-Prefix /pos;
    }
    
    # Archivos estáticos de Swagger UI
    location /pos/openapi.json {
        proxy_pass http://127.0.0.1:$BACKEND_PORT/openapi.json;
        proxy_set_header Host \$host;
        proxy_set_header X-Real-IP \$remote_addr;
        proxy_set_header X-Forwarded-For \$proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto \$scheme;
        proxy_set_header X-Forwarded-Host \$host;
        proxy_set_header X-Forwarded-Prefix /pos;
    }
    
    # Headers de seguridad
    add_header X-Frame-Options "SAMEORIGIN" always;
    add_header X-XSS-Protection "1; mode=block" always;
    add_header X-Content-Type-Options "nosniff" always;
    
    # Logs
    access_log /var/log/nginx/pos-api-access.log;
    error_log /var/log/nginx/pos-api-error.log;
}
EOF

# Crear enlace simbólico
echo "🔗 Creando enlace simbólico..."
ln -sf $CONFIG_FILE /etc/nginx/sites-enabled/

# Verificar configuración de Nginx
echo "🔍 Verificando configuración de Nginx..."
nginx -t

if [ $? -eq 0 ]; then
    echo "✅ Configuración de Nginx válida"
    
    # Reiniciar Nginx
    echo "🔄 Reiniciando Nginx..."
    systemctl restart nginx
    
    # Verificar estado
    if systemctl is-active --quiet nginx; then
        echo "✅ Nginx está ejecutándose correctamente"
    else
        echo "❌ Error al iniciar Nginx"
        exit 1
    fi
else
    echo "❌ Error en la configuración de Nginx"
    exit 1
fi

# Crear script de inicio para la API
echo "📝 Creando script de inicio para la API..."

cat > /usr/local/bin/start-pos-api.sh << 'EOF'
#!/bin/bash

# Script de inicio para API POS
cd /path/to/your/pos/project  # Cambiar por la ruta real del proyecto

# Activar entorno virtual si existe
if [ -d "venv" ]; then
    source venv/bin/activate
fi

# Iniciar la API
python3 -m uvicorn app.main:app --host 0.0.0.0 --port 8000
EOF

chmod +x /usr/local/bin/start-pos-api.sh

# Crear servicio systemd
echo "🔧 Creando servicio systemd..."

cat > /etc/systemd/system/pos-api.service << EOF
[Unit]
Description=POS API Service
After=network.target

[Service]
Type=simple
User=www-data
Group=www-data
WorkingDirectory=/path/to/your/pos/project  # Cambiar por la ruta real
Environment=PATH=/path/to/your/pos/project/venv/bin  # Cambiar por la ruta real
ExecStart=/usr/local/bin/start-pos-api.sh
Restart=always
RestartSec=10

[Install]
WantedBy=multi-user.target
EOF

echo "📋 Configuración completada!"
echo ""
echo "🎯 Próximos pasos:"
echo "1. Editar /usr/local/bin/start-pos-api.sh y cambiar la ruta del proyecto"
echo "2. Editar /etc/systemd/system/pos-api.service y cambiar la ruta del proyecto"
echo "3. Habilitar el servicio: sudo systemctl enable pos-api"
echo "4. Iniciar el servicio: sudo systemctl start pos-api"
echo ""
echo "🌐 URLs de acceso:"
echo "   - API: http://$DOMAIN/pos/"
echo "   - Documentación: http://$DOMAIN/pos/docs"
echo "   - ReDoc: http://$DOMAIN/pos/redoc"
echo ""
echo "📊 Comandos útiles:"
echo "   - Ver logs de Nginx: sudo tail -f /var/log/nginx/pos-api-error.log"
echo "   - Ver estado del servicio: sudo systemctl status pos-api"
echo "   - Reiniciar API: sudo systemctl restart pos-api"
echo "   - Reiniciar Nginx: sudo systemctl restart nginx" 