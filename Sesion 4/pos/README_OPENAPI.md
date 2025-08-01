# Documentación OpenAPI - Sistema POS

Este proyecto incluye documentación completa de la API en formato OpenAPI 3.0, que permite una integración fácil con herramientas de desarrollo y testing.

## 📁 Archivos de Documentación

### `openapi.yaml`
Especificación OpenAPI en formato YAML (más legible para humanos)

### `openapi.json`
Especificación OpenAPI en formato JSON (más compatible con herramientas)

## 🛠️ Cómo Usar la Documentación OpenAPI

### 1. Visualización Interactiva

#### Swagger UI (incluido en FastAPI)
```bash
# Inicia el servidor
python3 -m uvicorn app.main:app --reload

# Abre en tu navegador
http://localhost:8000/docs
```

#### ReDoc (alternativa)
```bash
# Abre en tu navegador
http://localhost:8000/redoc
```

### 2. Herramientas Externas

#### Swagger Editor Online
1. Ve a [editor.swagger.io](https://editor.swagger.io)
2. Copia y pega el contenido de `openapi.yaml`
3. Visualiza y edita la documentación

#### Postman
1. Abre Postman
2. Ve a **Import** → **Link**
3. Pega la URL: `http://localhost:8000/openapi.json`
4. Importa todos los endpoints automáticamente

#### Insomnia
1. Abre Insomnia
2. Ve a **Create** → **Import from URL**
3. Pega la URL: `http://localhost:8000/openapi.json`

### 3. Generación de Código

#### Generar Cliente TypeScript
```bash
# Instalar openapi-generator-cli
npm install @openapitools/openapi-generator-cli -g

# Generar cliente TypeScript
openapi-generator-cli generate \
  -i openapi.yaml \
  -g typescript-axios \
  -o ./generated/typescript-client
```

#### Generar Cliente Python
```bash
# Generar cliente Python
openapi-generator-cli generate \
  -i openapi.yaml \
  -g python \
  -o ./generated/python-client
```

#### Generar Cliente JavaScript
```bash
# Generar cliente JavaScript
openapi-generator-cli generate \
  -i openapi.yaml \
  -g javascript \
  -o ./generated/javascript-client
```

## 📋 Endpoints Documentados

### Información
- `GET /pos` - Información de la API
- `GET /pos/health` - Verificar estado de la API

### Productos
- `GET /pos/productos` - Obtener todos los productos
- `POST /pos/productos` - Crear un nuevo producto
- `GET /pos/productos/{producto_id}` - Obtener un producto específico
- `PUT /pos/productos/{producto_id}` - Actualizar un producto
- `DELETE /pos/productos/{producto_id}` - Eliminar un producto

### Clientes
- `GET /pos/clientes` - Obtener todos los clientes
- `POST /pos/clientes` - Crear un nuevo cliente
- `GET /pos/clientes/{cliente_id}` - Obtener un cliente específico
- `PUT /pos/clientes/{cliente_id}` - Actualizar un cliente
- `DELETE /pos/clientes/{cliente_id}` - Eliminar un cliente

### Ventas
- `GET /pos/ventas` - Obtener todas las ventas
- `POST /pos/ventas` - Crear una nueva venta
- `GET /pos/ventas/{venta_id}` - Obtener una venta específica
- `GET /pos/ventas/cliente/{cliente_id}` - Obtener ventas por cliente

### Reportes
- `GET /pos/reportes/ventas-totales` - Reporte de ventas totales
- `GET /pos/reportes/productos-populares` - Reporte de productos populares

## 🔧 Esquemas de Datos

### Producto
```yaml
Producto:
  type: object
  properties:
    id: string (UUID)
    nombre: string
    precio: number
    stock: integer
    categoria: string
    fecha_creacion: string (date-time)
```

### Cliente
```yaml
Cliente:
  type: object
  properties:
    id: string (UUID)
    nombre: string
    email: string (email)
    telefono: string
    fecha_registro: string (date-time)
```

### Venta
```yaml
Venta:
  type: object
  properties:
    id: string (UUID)
    cliente_id: string (UUID)
    items: array of VentaItem
    total: number
    fecha: string (date-time)
    estado: string (enum: completada, pendiente, cancelada)
```

## 🧪 Testing con OpenAPI

### 1. Pruebas Automáticas con Newman (Postman CLI)
```bash
# Instalar Newman
npm install -g newman

# Ejecutar colección
newman run pos-api-collection.json
```

### 2. Pruebas con REST Client (VS Code)
```bash
# Crear archivo .rest
# Ejemplo de prueba:
GET http://localhost:8000/pos/productos
Content-Type: application/json

###

POST http://localhost:8000/pos/productos
Content-Type: application/json

{
  "nombre": "Producto de Prueba",
  "precio": 99.99,
  "stock": 10,
  "categoria": "Pruebas"
}
```

### 3. Pruebas con curl
```bash
# Obtener productos
curl -X GET "http://localhost:8000/pos/productos" \
  -H "accept: application/json"

# Crear producto
curl -X POST "http://localhost:8000/pos/productos" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Producto de Prueba",
    "precio": 99.99,
    "stock": 10,
    "categoria": "Pruebas"
  }'
```

## 🔄 Actualización de la Documentación

### Actualizar desde FastAPI
La documentación se genera automáticamente desde los modelos Pydantic y docstrings de FastAPI. Para actualizar:

1. Modifica los modelos en `app/models.py`
2. Actualiza los docstrings en los routers
3. Reinicia el servidor
4. La documentación se actualiza automáticamente

### Actualizar manualmente
Si necesitas modificar la documentación manualmente:

1. Edita `openapi.yaml` o `openapi.json`
2. Valida la sintaxis con [editor.swagger.io](https://editor.swagger.io)
3. Actualiza ambos archivos para mantener consistencia

## 📚 Recursos Adicionales

### Herramientas Recomendadas
- **Swagger UI**: Visualización interactiva
- **Postman**: Testing y desarrollo
- **Insomnia**: Alternativa a Postman
- **OpenAPI Generator**: Generación de código cliente

### Enlaces Útiles
- [OpenAPI Specification](https://swagger.io/specification/)
- [FastAPI Documentation](https://fastapi.tiangolo.com/)
- [Swagger Editor](https://editor.swagger.io/)
- [OpenAPI Generator](https://openapi-generator.tech/)

## 🚀 Próximos Pasos

1. **Integración con CI/CD**: Automatizar la generación de documentación
2. **Validación de Esquemas**: Implementar validación automática de requests
3. **Autenticación**: Agregar esquemas de autenticación cuando sea necesario
4. **Versionado**: Implementar versionado de la API
5. **Rate Limiting**: Documentar límites de uso

---

La documentación OpenAPI está lista para ser utilizada con cualquier herramienta compatible con la especificación OpenAPI 3.0. 