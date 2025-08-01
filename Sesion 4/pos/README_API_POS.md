# API Sistema POS - Documentación Completa

## 🚀 Información General

**URL Base:** `http://localhost:8000/pos`  
**Versión:** 1.0.0  
**Documentación Interactiva:** `http://localhost:8000/docs`  
**ReDoc:** `http://localhost:8000/redoc`

## 📋 Endpoints Disponibles

### 🔍 Información
- `GET /pos` - Información general de la API
- `GET /pos/health` - Verificar estado de la API

### 📦 Productos
- `GET /pos/productos/` - Obtener todos los productos
- `POST /pos/productos/` - Crear un nuevo producto
- `GET /pos/productos/{producto_id}` - Obtener un producto específico
- `PUT /pos/productos/{producto_id}` - Actualizar un producto
- `DELETE /pos/productos/{producto_id}` - Eliminar un producto

### 👥 Clientes
- `GET /pos/clientes/` - Obtener todos los clientes
- `POST /pos/clientes/` - Crear un nuevo cliente
- `GET /pos/clientes/{cliente_id}` - Obtener un cliente específico
- `PUT /pos/clientes/{cliente_id}` - Actualizar un cliente
- `DELETE /pos/clientes/{cliente_id}` - Eliminar un cliente

### 💰 Ventas
- `GET /pos/ventas/` - Obtener todas las ventas
- `POST /pos/ventas/` - Crear una nueva venta
- `GET /pos/ventas/{venta_id}` - Obtener una venta específica
- `GET /pos/ventas/cliente/{cliente_id}` - Obtener ventas por cliente

### 📊 Reportes
- `GET /pos/reportes/ventas-totales` - Reporte de ventas totales
- `GET /pos/reportes/productos-populares` - Reporte de productos populares

## 🛠️ Cómo Iniciar la API

### 1. Instalar Dependencias
```bash
pip install -r requirements.txt
```

### 2. Generar Datos de Prueba
```bash
# Generar datos básicos
python3 generate_test_data.py

# Agregar datos adicionales (opcional)
python3 generate_more_test_data.py

# Ver estadísticas
python3 show_database_stats.py
```

### 3. Iniciar el Servidor
```bash
python3 -m uvicorn app.main:app --reload --host 0.0.0.0 --port 8000
```

### 4. Acceder a la Documentación
- **Swagger UI:** http://localhost:8000/docs
- **ReDoc:** http://localhost:8000/redoc

## 🧪 Ejemplos de Uso

### Obtener Información de la API
```bash
curl http://localhost:8000/pos/
```

### Obtener Productos
```bash
curl http://localhost:8000/pos/productos/
```

### Crear un Producto
```bash
curl -X POST http://localhost:8000/pos/productos/ \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Nuevo Producto",
    "precio": 99.99,
    "stock": 10,
    "categoria": "Electrónicos"
  }'
```

### Obtener Clientes
```bash
curl http://localhost:8000/pos/clientes/
```

### Crear una Venta
```bash
curl -X POST http://localhost:8000/pos/ventas/ \
  -H "Content-Type: application/json" \
  -d '{
    "cliente_id": "63d7846d-c36b-4c13-aade-b25eb4195892",
    "items": [
      {
        "producto_id": "16b435b6-4f7b-4a92-a235-9b8a6aa3c57d",
        "cantidad": 2,
        "precio_unitario": 899.99
      }
    ]
  }'
```

### Obtener Reportes
```bash
# Reporte de ventas totales
curl http://localhost:8000/pos/reportes/ventas-totales

# Productos más populares
curl http://localhost:8000/pos/reportes/productos-populares
```

## 📊 Datos de Prueba Disponibles

### Productos (22 total)
- **Categorías:** Gaming, Oficina, Red, Seguridad, Electrónicos, Accesorios, Componentes, Audio, Cables, Video, Almacenamiento
- **Precio promedio:** $167.13
- **Rango:** $12.99 - $899.99

### Clientes (13 total)
- **Individuales:** 8 clientes
- **Empresariales:** 5 empresas (universidad, clínica, restaurante, etc.)

### Ventas (35 total)
- **Estados:** Completada, Pendiente, Cancelada
- **Venta promedio:** $1,044.60
- **Ingresos totales:** $36,560.86

## 🔧 Estructura del Proyecto

```
pos/
├── app/
│   ├── __init__.py
│   ├── config.py          # Configuraciones
│   ├── database.py        # Manejo de base de datos
│   ├── main.py           # Aplicación principal
│   ├── models.py         # Modelos Pydantic
│   ├── services.py       # Lógica de negocio
│   ├── utils.py          # Utilidades
│   └── routers/          # Endpoints de la API
│       ├── __init__.py
│       ├── productos.py
│       ├── clientes.py
│       ├── ventas.py
│       └── reportes.py
├── pos_database.json     # Base de datos JSON
├── openapi.yaml          # Documentación OpenAPI (YAML)
├── openapi.json          # Documentación OpenAPI (JSON)
├── generate_test_data.py # Generador de datos de prueba
├── show_database_stats.py # Estadísticas de la base de datos
└── requirements.txt      # Dependencias
```

## 📚 Documentación Adicional

- **README_DATOS_PRUEBA.md** - Información sobre datos de prueba
- **README_OPENAPI.md** - Guía completa de OpenAPI
- **openapi.yaml** - Especificación OpenAPI en YAML
- **openapi.json** - Especificación OpenAPI en JSON

## 🚀 Características Principales

### ✅ Implementadas
- ✅ CRUD completo para productos
- ✅ CRUD completo para clientes
- ✅ Gestión de ventas con múltiples productos
- ✅ Reportes de ventas y productos populares
- ✅ Documentación OpenAPI completa
- ✅ Datos de prueba realistas
- ✅ Prefijo `/pos` en todas las rutas
- ✅ Validación de datos con Pydantic
- ✅ Manejo de errores HTTP
- ✅ CORS configurado

### 🔄 Próximas Mejoras
- 🔄 Autenticación y autorización
- 🔄 Paginación en listados
- 🔄 Filtros y búsqueda avanzada
- 🔄 Logs y monitoreo
- 🔄 Tests automatizados
- 🔄 Docker y despliegue

## 🛡️ Seguridad

- **CORS:** Configurado para desarrollo
- **Validación:** Todos los inputs validados con Pydantic
- **Errores:** Manejo seguro de errores sin exponer información sensible

## 📞 Soporte

Para soporte técnico o preguntas sobre la API:
- **Email:** soporte@pos-api.com
- **Documentación:** http://localhost:8000/docs
- **GitHub:** https://github.com/tu-usuario/pos-api

---

**¡La API está lista para usar!** 🎉 