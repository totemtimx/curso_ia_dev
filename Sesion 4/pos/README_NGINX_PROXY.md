# Configuración de Nginx para API POS

## 🚨 Problema Común

Cuando usas Nginx como proxy reverso con la ruta `/pos`, la documentación de Swagger UI no funciona correctamente porque:

1. **Rutas absolutas**: FastAPI genera rutas absolutas que no funcionan con el proxy
2. **Archivos estáticos**: Swagger UI no puede cargar sus recursos CSS/JS
3. **Headers faltantes**: Faltan headers importantes para el proxy

## ✅ Solución Implementada

### 1. Configuración de FastAPI

Se agregó `root_path="/pos"` en la configuración de FastAPI:

```python
app = FastAPI(
    title=settings.APP_NAME,
    description=settings.APP_DESCRIPTION,
    version=settings.APP_VERSION,
    docs_url="/docs",
    redoc_url="/redoc",
    # Configuración para proxy reverso
    root_path="/pos"
)
```

### 2. Configuración de Nginx

#### Configuración Simple (Recomendada)

```nginx
server {
    listen 80;
    server_name tu-dominio.com;
    
    # Configuración principal para la API POS
    location /pos/ {
        # Proxy directo - FastAPI maneja el root_path
        proxy_pass http://127.0.0.1:8000/;
        
        # Headers esenciales
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Host $host;
        proxy_set_header X-Forwarded-Prefix /pos;
        
        # Configuración para WebSockets
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
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
        proxy_pass http://127.0.0.1:8000/docs;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Host $host;
        proxy_set_header X-Forwarded-Prefix /pos;
    }
    
    location /pos/redoc {
        proxy_pass http://127.0.0.1:8000/redoc;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Host $host;
        proxy_set_header X-Forwarded-Prefix /pos;
    }
    
    # Archivos estáticos de Swagger UI
    location /pos/openapi.json {
        proxy_pass http://127.0.0.1:8000/openapi.json;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Host $host;
        proxy_set_header X-Forwarded-Prefix /pos;
    }
}
```

## 🛠️ Instalación Automática

### Usar el Script de Configuración

```bash
# Dar permisos de ejecución
chmod +x setup-nginx-proxy.sh

# Ejecutar como root
sudo bash setup-nginx-proxy.sh tu-dominio.com 8000
```

### Configuración Manual

1. **Copiar configuración**:
   ```bash
   sudo cp nginx-pos-api-simple.conf /etc/nginx/sites-available/pos-api
   ```

2. **Crear enlace simbólico**:
   ```bash
   sudo ln -s /etc/nginx/sites-available/pos-api /etc/nginx/sites-enabled/
   ```

3. **Verificar configuración**:
   ```bash
   sudo nginx -t
   ```

4. **Reiniciar Nginx**:
   ```bash
   sudo systemctl restart nginx
   ```

## 🔧 Configuración del Servicio

### Crear Servicio Systemd

```bash
# Crear archivo de servicio
sudo nano /etc/systemd/system/pos-api.service
```

Contenido:
```ini
[Unit]
Description=POS API Service
After=network.target

[Service]
Type=simple
User=www-data
Group=www-data
WorkingDirectory=/ruta/a/tu/proyecto/pos
Environment=PATH=/ruta/a/tu/proyecto/pos/venv/bin
ExecStart=/ruta/a/tu/proyecto/pos/venv/bin/python -m uvicorn app.main:app --host 0.0.0.0 --port 8000
Restart=always
RestartSec=10

[Install]
WantedBy=multi-user.target
```

### Habilitar y Iniciar Servicio

```bash
# Habilitar servicio
sudo systemctl enable pos-api

# Iniciar servicio
sudo systemctl start pos-api

# Verificar estado
sudo systemctl status pos-api
```

## 🌐 URLs de Acceso

Con la configuración correcta, podrás acceder a:

- **API Principal**: `http://tu-dominio.com/pos/`
- **Documentación Swagger**: `http://tu-dominio.com/pos/docs`
- **Documentación ReDoc**: `http://tu-dominio.com/pos/redoc`
- **Especificación OpenAPI**: `http://tu-dominio.com/pos/openapi.json`

## 🔍 Troubleshooting

### Problemas Comunes

#### 1. Error 502 Bad Gateway
```bash
# Verificar que la API esté corriendo
sudo systemctl status pos-api

# Verificar logs
sudo journalctl -u pos-api -f
```

#### 2. Documentación no carga
```bash
# Verificar configuración de Nginx
sudo nginx -t

# Verificar logs de Nginx
sudo tail -f /var/log/nginx/pos-api-error.log
```

#### 3. Rutas no funcionan
```bash
# Verificar que el root_path esté configurado
curl http://tu-dominio.com/pos/

# Verificar headers
curl -I http://tu-dominio.com/pos/docs
```

### Comandos de Diagnóstico

```bash
# Verificar estado de servicios
sudo systemctl status nginx pos-api

# Ver logs en tiempo real
sudo tail -f /var/log/nginx/pos-api-error.log
sudo journalctl -u pos-api -f

# Probar endpoints
curl http://tu-dominio.com/pos/
curl http://tu-dominio.com/pos/health
curl http://tu-dominio.com/pos/productos/

# Verificar configuración de Nginx
sudo nginx -T | grep -A 20 "location /pos"
```

## 🔒 Configuración de Seguridad

### Headers de Seguridad

```nginx
# Agregar en la configuración de Nginx
add_header X-Frame-Options "SAMEORIGIN" always;
add_header X-XSS-Protection "1; mode=block" always;
add_header X-Content-Type-Options "nosniff" always;
add_header Referrer-Policy "no-referrer-when-downgrade" always;
```

### Configuración SSL (HTTPS)

```nginx
server {
    listen 443 ssl http2;
    server_name tu-dominio.com;
    
    ssl_certificate /path/to/certificate.crt;
    ssl_certificate_key /path/to/private.key;
    
    # Misma configuración que HTTP pero con SSL
    location /pos/ {
        proxy_pass http://127.0.0.1:8000/;
        # ... resto de configuración
    }
}
```

## 📊 Monitoreo

### Logs Importantes

- **Nginx Access**: `/var/log/nginx/pos-api-access.log`
- **Nginx Error**: `/var/log/nginx/pos-api-error.log`
- **API Service**: `sudo journalctl -u pos-api`

### Métricas Útiles

```bash
# Verificar conexiones activas
sudo netstat -tlnp | grep :8000

# Verificar uso de memoria
ps aux | grep uvicorn

# Verificar logs de acceso
tail -f /var/log/nginx/pos-api-access.log | grep -v "health"
```

---

**¡Con esta configuración, la API POS funcionará perfectamente con Nginx y la documentación será accesible!** 🎉 