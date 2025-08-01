# Procesador de Mensajes con OpenAI

Este proyecto es una API web que procesa mensajes utilizando la API de OpenAI (ChatGPT) para clasificar y responder automáticamente a diferentes tipos de consultas.

## Características

- **Clasificación automática de mensajes**: Utiliza OpenAI para clasificar mensajes en tres categorías:
  - Creación de Usuario
  - Información de Producto
  - Otros

- **Extracción de información**: Extrae nombres de usuario de mensajes de creación de cuentas

- **Validación de información**: Verifica si los mensajes contienen la información necesaria

- **Almacenamiento de datos**: Guarda usuarios y mensajes pendientes en archivos locales

## Configuración

### 1. Configurar OpenAI API Key

Edita el archivo `appsettings.json` y agrega tu API key de OpenAI:

```json
{
  "OpenAI": {
    "ApiKey": "tu-api-key-de-openai-aqui",
    "Model": "gpt-3.5-turbo"
  }
}
```

### 2. Obtener API Key de OpenAI

1. Ve a [OpenAI Platform](https://platform.openai.com/)
2. Crea una cuenta o inicia sesión
3. Ve a la sección "API Keys"
4. Crea una nueva API key
5. Copia la key y agrégala al archivo de configuración

## Instalación y Ejecución

### Prerrequisitos

- .NET 7.0 o superior
- API Key de OpenAI

### Pasos

1. Clona el repositorio
2. Configura tu API key en `appsettings.json`
3. Ejecuta los siguientes comandos:

```bash
dotnet restore
dotnet build
dotnet run
```

La API estará disponible en `https://localhost:7000` (o el puerto configurado).

## Uso de la API

### Endpoint Principal

**POST** `/api/message`

**Body:**
```json
{
  "message": "Quiero crear un usuario llamado Juan Pérez"
}
```

**Respuesta:**
```json
{
  "response": "Usuario Juan Pérez creado exitosamente.",
  "category": "Creación de Usuario",
  "success": true
}
```

### Ejemplos de Mensajes

#### Creación de Usuario
- "Quiero crear un usuario llamado Juan Pérez"
- "Necesito una cuenta para María"
- "Registrarme como Ana María López"

#### Información de Producto
- "Información sobre el iPhone 15"
- "Detalles del servicio de hosting"
- "Precios de laptops"

#### Otros
- "¿Cuál es el horario de atención?"
- "Tengo una queja sobre el servicio"
- "Sugerencias para mejorar"

## Estructura del Proyecto

```
├── Controllers/
│   └── MessageController.cs          # Controlador principal de la API
├── Models/
│   ├── MessageRequest.cs             # Modelo de solicitud
│   ├── MessageResponse.cs            # Modelo de respuesta
│   └── MessageCategory.cs            # Enumeración de categorías
├── Services/
│   ├── IOpenAIService.cs             # Interfaz del servicio OpenAI
│   ├── OpenAIService.cs              # Implementación del servicio OpenAI
│   ├── IFileService.cs               # Interfaz del servicio de archivos
│   ├── FileService.cs                # Implementación del servicio de archivos
│   ├── IMessageProcessorService.cs   # Interfaz del procesador de mensajes
│   └── MessageProcessorService.cs    # Implementación del procesador
└── Data/
    ├── Users/                        # Archivos de usuarios creados
    └── Pendientes/                   # Mensajes pendientes de procesar
```

## Tecnologías Utilizadas

- **.NET 7**: Framework de desarrollo
- **OpenAI API**: Para procesamiento de lenguaje natural
- **Microsoft Semantic Kernel**: Para orquestación de funciones
- **Swagger/OpenAPI**: Para documentación de la API

## Notas Importantes

- Asegúrate de tener créditos suficientes en tu cuenta de OpenAI
- Los archivos se guardan localmente en la carpeta `Data/`
- La API utiliza el modelo `gpt-3.5-turbo` por defecto, pero puedes cambiarlo en la configuración
- Los logs se guardan en la consola para debugging

## Migración desde Gemini

Este proyecto fue migrado desde Google Gemini a OpenAI. Los principales cambios incluyen:

- Cambio de `GeminiService` a `OpenAIService`
- Actualización de la configuración de API
- Modificación de las llamadas a la API para usar el formato de OpenAI
- Actualización de las dependencias del proyecto 