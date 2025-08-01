# Procesador de Mensajes con Semantic Kernel y Gemini

Este proyecto es una API REST que utiliza Semantic Kernel y la API de Google Gemini para procesar y clasificar mensajes automáticamente.

## Funcionalidades

- **Clasificación de Mensajes**: Utiliza Gemini para clasificar mensajes en tres categorías:
  - Creación de Usuario
  - Información de Producto
  - Otros

- **Validación Inteligente**: 
  - Valida si falta información esencial para crear usuarios
  - Valida si faltan detalles específicos para información de productos
  - Solicita información faltante de manera amigable

- **Procesamiento Automático**: 
  - Si es creación de usuario: Extrae el nombre del mensaje y lo guarda en la carpeta `Data/Users`
  - Si es información de producto: Responde con mensaje de confirmación
  - Si es otra categoría: Guarda en `Data/Pendientes` con timestamp
  - Si falta información: Solicita los datos necesarios

## Configuración

1. **Obtener API Key de Gemini**:
   - Ve a [Google AI Studio](https://makersuite.google.com/app/apikey)
   - Crea una nueva API key
   - Copia la key

2. **Configurar la API Key**:
   - Abre `appsettings.json`
   - Reemplaza `"TU_API_KEY_DE_GEMINI_AQUI"` con tu API key real

## Ejecutar el Proyecto

```bash
# Restaurar dependencias
dotnet restore

# Ejecutar el proyecto
dotnet run
```

La API estará disponible en: `https://localhost:7000` (o el puerto que se muestre)

**Nota**: Es normal ver warnings sobre paquetes de .NET 8 durante la compilación, pero el proyecto funciona correctamente con .NET 7.

## Endpoints

### POST /api/message/process
Procesa un mensaje y lo clasifica automáticamente.

**Request Body:**
```json
{
  "message": "Quiero crear un usuario llamado Juan Pérez"
}
```

**Response:**
```json
{
  "response": "Usuario Juan Pérez creado exitosamente.",
  "category": "Creación de Usuario",
  "success": true
}
```

**Response cuando falta información:**
```json
{
  "response": "Para crear un usuario necesito que me proporciones el nombre. Por favor, indícame el nombre completo o email del usuario que deseas crear.",
  "category": "Solicitud de Información",
  "success": true
}
```

### GET /api/message/health
Verifica el estado de la API.

## Estructura del Proyecto

```
GeminiMessageProcessor/
├── Controllers/
│   └── MessageController.cs          # Controlador REST
├── Models/
│   ├── MessageRequest.cs             # Modelo de solicitud
│   ├── MessageResponse.cs            # Modelo de respuesta
│   └── MessageCategory.cs            # Enum de categorías
├── Services/
│   ├── IGeminiService.cs             # Interfaz del servicio Gemini
│   ├── GeminiService.cs              # Implementación de Gemini
│   ├── IFileService.cs               # Interfaz del servicio de archivos
│   ├── FileService.cs                # Implementación de archivos
│   ├── IMessageProcessorService.cs   # Interfaz del procesador principal
│   └── MessageProcessorService.cs    # Implementación principal con Semantic Kernel
├── Data/
│   ├── Users/                        # Carpeta para usuarios creados
│   └── Pendientes/                   # Carpeta para mensajes pendientes
├── Examples/
│   └── test-requests.http            # Ejemplos de requests para probar
└── Program.cs                        # Configuración de la aplicación
```

## Ejemplos de Uso

### Creación de Usuario - Información Completa
```json
{
  "message": "Necesito crear una cuenta para María García"
}
```

### Creación de Usuario - Falta Información
```json
{
  "message": "Quiero crear un usuario"
}
```
**Respuesta:** Solicitará el nombre del usuario

### Creación de Usuario con Email
```json
{
  "message": "Registrarme como juan.perez@email.com"
}
```

### Información de Producto - Específico
```json
{
  "message": "Me gustaría obtener información sobre el iPhone 15"
}
```

### Información de Producto - Falta Detalles
```json
{
  "message": "Necesito información de productos"
}
```
**Respuesta:** Solicitará detalles específicos del producto

### Otros Mensajes
```json
{
  "message": "Tengo una pregunta general sobre el servicio"
}
```

## Cómo Funciona

1. **Recepción del Mensaje**: La API recibe un mensaje a través del endpoint REST
2. **Clasificación con Gemini**: Usa la API de Gemini para clasificar el mensaje en una de las tres categorías
3. **Validación de Información**: 
   - Para creación de usuario: Verifica si se proporcionó un nombre
   - Para información de producto: Verifica si se especificó el producto
4. **Solicitud de Información Faltante**: Si falta información, solicita los datos necesarios
5. **Extracción de Información**: Si es creación de usuario, extrae automáticamente el nombre del mensaje
6. **Procesamiento con Semantic Kernel**: 
   - Si es creación de usuario: Usa una actividad de Semantic Kernel para guardar el nombre extraído
   - Si es información de producto: Responde directamente
   - Si es otro tipo: Usa una actividad de Semantic Kernel para guardar el mensaje pendiente
7. **Respuesta**: Devuelve una respuesta apropiada según la categoría y validación

## Tecnologías Utilizadas

- **.NET 7**: Framework de desarrollo
- **ASP.NET Core**: Framework web
- **Semantic Kernel**: Para orquestar actividades y funciones nativas
- **Google Gemini API**: Para clasificación, validación y extracción de información
- **Swagger**: Documentación de la API
- **HTTP Client**: Para comunicarse con la API de Gemini

## Pruebas

Puedes usar el archivo `Examples/test-requests.http` para probar la API con diferentes tipos de mensajes usando herramientas como:
- Visual Studio Code con la extensión REST Client
- Postman
- curl 