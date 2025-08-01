# Prompts para Implementación del Sistema de Biblioteca Digital

## Fase 1: Backend con C# y MySQL

### Prompt 1: Estructura Base del Proyecto

```
Crear la estructura base de un proyecto de API REST en C# .NET 8 para un sistema de gestión de biblioteca digital. Incluir:

1. Configuración del proyecto con las siguientes dependencias:
   - Entity Framework Core para MySQL
   - AutoMapper para mapeo de DTOs
   - JWT para autenticación
   - Swagger para documentación

2. Estructura de carpetas organizada por capas:
   - Controllers
   - Services/Business Logic
   - Data/Repositories
   - Models/Entities
   - DTOs
   - Middlewares

3. Configuración inicial en Program.cs y appsettings.json para:
   - Conexión a MySQL
   - CORS
   - JWT
   - Logging

Proporcionar el código completo con comentarios explicativos.
```

### Prompt 2: Modelos y Base de Datos

```
Crear los modelos de Entity Framework y configuración de base de datos para el sistema de biblioteca digital con las siguientes entidades:

1. **Usuario** (Id, Nombre, Email, Password, TipoUsuario, FechaRegistro, Activo)
2. **Libro** (Id, Titulo, Autor, ISBN, Categoria, Descripcion, FormatoDigital, Disponible, FechaAdicion)
3. **Prestamo** (Id, UsuarioId, LibroId, FechaPrestamo, FechaVencimiento, FechaDevolucion, Estado)
4. **Reserva** (Id, UsuarioId, LibroId, FechaReserva, FechaExpiracion, Estado)
5. **Multa** (Id, UsuarioId, PrestamoId, Monto, Motivo, FechaGeneracion, Pagada)

Incluir:
- Configuración de relaciones entre entidades
- Validaciones y restricciones
- DbContext configurado
- Migrations iniciales
- Seed data para testing

Generar el código completo con configuraciones de Fluent API.
```

### Prompt 3: Repositorios y Servicios Base

```
Implementar el patrón Repository y Unit of Work para el sistema de biblioteca digital:

1. **IRepository genérico** con operaciones CRUD base
2. **Repositorios específicos** para cada entidad (Usuario, Libro, Prestamo, Reserva, Multa)
3. **Unit of Work** para manejo de transacciones
4. **Servicios de negocio** que implementen la lógica específica:
   - UsuarioService (registro, autenticación, gestión de perfiles)
   - LibroService (catálogo, búsqueda, disponibilidad)
   - PrestamoService (crear préstamo, renovación, devolución)
   - ReservaService (crear reserva, gestión de colas)

Incluir:
- Interfaces para todos los servicios
- Manejo de excepciones personalizado
- DTOs para transferencia de datos
- AutoMapper profiles para mapeo

Proporcionar código completo con inyección de dependencias configurada.
```

### Prompt 4: Sistema de Autenticación y Autorización

```
Implementar sistema completo de autenticación y autorización JWT con roles para el sistema de biblioteca:

1. **AuthController** con endpoints:
   - POST /auth/login
   - POST /auth/register
   - POST /auth/refresh-token
   - POST /auth/logout

2. **JWT Service** que maneje:
   - Generación de tokens
   - Validación de tokens
   - Refresh tokens
   - Claims personalizados (rol, permisos)

3. **Middleware de autorización** que valide:
   - Roles (Estudiante, Profesor, Bibliotecario)
   - Permisos específicos por endpoint
   - Expiración de tokens

4. **Password hashing** con BCrypt

Incluir configuración de políticas de autorización y manejo de errores de autenticación. Proporcionar código completo con ejemplos de uso.
```

### Prompt 5: Controllers y Endpoints Principales

```
Crear los controllers principales para el sistema de biblioteca digital con todos los endpoints necesarios:

1. **LibrosController**:
   - GET /api/libros (búsqueda con filtros y paginación)
   - GET /api/libros/{id}
   - POST /api/libros (solo bibliotecarios)
   - PUT /api/libros/{id} (solo bibliotecarios)
   - DELETE /api/libros/{id} (solo bibliotecarios)

2. **PrestamosController**:
   - GET /api/prestamos/mis-prestamos
   - POST /api/prestamos
   - PUT /api/prestamos/{id}/devolver
   - PUT /api/prestamos/{id}/renovar

3. **ReservasController**:
   - GET /api/reservas/mis-reservas
   - POST /api/reservas
   - DELETE /api/reservas/{id}

4. **UsuariosController**:
   - GET /api/usuarios/perfil
   - PUT /api/usuarios/perfil
   - GET /api/usuarios/{id}/historial

Incluir:
- Validación de datos con Data Annotations
- Manejo de errores con try-catch
- Responses consistentes
- Documentación Swagger
- Logging de operaciones

Proporcionar código completo con todas las validaciones de negocio.
```

### Prompt 6: Lógica de Negocio Avanzada

```
Implementar la lógica de negocio compleja para el sistema de biblioteca:

1. **Servicio de Préstamos** que maneje:
   - Validación de límites por tipo de usuario (3 libros estudiantes, 10 profesores)
   - Verificación de disponibilidad
   - Cálculo automático de fechas de vencimiento
   - Renovación automática si no hay reservas pendientes
   - Generación de multas por retraso

2. **Servicio de Reservas** que implemente:
   - Cola de espera FIFO
   - Notificaciones cuando el libro esté disponible
   - Expiración automática de reservas (48 horas)
   - Conversión automática de reserva a préstamo

3. **Servicio de Notificaciones** para:
   - Recordatorios de vencimiento
   - Alertas de disponibilidad
   - Notificaciones de multas

4. **Background Services** para:
   - Proceso diario de verificación de vencimientos
   - Limpieza de reservas expiradas
   - Generación de reportes automáticos

Incluir manejo de transacciones, logging y configuración de tareas programadas.
```

---

## Fase 2: Frontend con React

### Prompt 7: Estructura Base del Frontend

```
Crear la estructura base de una aplicación React para el sistema de biblioteca digital:

1. **Configuración inicial** con:
   - Create React App o Vite
   - TypeScript habilitado
   - Routing con React Router
   - Estado global con Context API o Redux Toolkit
   - Axios para llamadas HTTP
   - Material-UI o Tailwind CSS para UI

2. **Estructura de carpetas**:
   - components/ (componentes reutilizables)
   - pages/ (páginas principales)
   - services/ (servicios HTTP)
   - hooks/ (custom hooks)
   - context/ (contextos globales)
   - types/ (tipos TypeScript)
   - utils/ (utilidades)

3. **Configuración de**:
   - Variables de entorno
   - Interceptores de Axios
   - Rutas protegidas
   - Manejo de errores global

Proporcionar código completo con configuración inicial y estructura de archivos.
```

### Prompt 8: Sistema de Autenticación Frontend

```
Implementar el sistema de autenticación completo en React para conectar con el backend del sistema de biblioteca:

1. **AuthContext** que maneje:
   - Estado de autenticación global
   - Login/logout
   - Refresh de tokens
   - Persistencia en localStorage
   - Roles y permisos del usuario

2. **Componentes de autenticación**:
   - LoginForm con validación
   - RegisterForm para nuevos usuarios
   - ProtectedRoute para rutas privadas
   - RoleBasedComponent para mostrar contenido por rol

3. **Custom hooks**:
   - useAuth para acceder al contexto
   - useApi para llamadas autenticadas
   - usePermissions para verificar permisos

4. **Servicios HTTP**:
   - authService con métodos login, register, refresh
   - Interceptores para manejo automático de tokens
   - Redirección automática en caso de token expirado

Incluir TypeScript types, manejo de errores y loading states. Proporcionar código completo.
```

### Prompt 9: Componentes de Catálogo y Búsqueda

```
Crear los componentes para el catálogo de libros y sistema de búsqueda en React:

1. **LibroCard** - Componente para mostrar información de cada libro:
   - Imagen, título, autor, categoría
   - Estado de disponibilidad
   - Botones de acción (reservar/prestar)
   - Rating y reseñas

2. **CatalogoLibros** - Lista principal de libros:
   - Grid responsive de LibroCard
   - Paginación
   - Loading states y skeleton loaders
   - Empty states

3. **FiltrosBusqueda** - Panel de filtros:
   - Búsqueda por texto
   - Filtros por categoría, autor, disponibilidad
   - Ordenamiento (título, fecha, popularidad)
   - Botón de limpiar filtros

4. **BarraBusqueda** - Componente de búsqueda principal:
   - Autocompletado con sugerencias
   - Búsqueda en tiempo real con debounce
   - Historial de búsquedas

5. **Custom hooks**:
   - useDebounce para optimizar búsquedas
   - usePaginacion para manejo de páginas
   - useLibros para operaciones CRUD

Incluir responsive design, accessibility y optimización de rendimiento.
```

### Prompt 10: Gestión de Préstamos y Reservas

```
Implementar los componentes para la gestión de préstamos y reservas en React:

1. **MisPrestamos** - Dashboard de préstamos del usuario:
   - Lista de préstamos activos
   - Fechas de vencimiento con indicadores visuales
   - Botones de renovación y devolución
   - Historial de préstamos anteriores

2. **MisReservas** - Gestión de reservas:
   - Lista de reservas activas
   - Estado en cola de espera
   - Tiempo restante para confirmar reserva
   - Botón para cancelar reserva

3. **DetalleLibro** - Página de detalles de libro:
   - Información completa del libro
   - Estado de disponibilidad en tiempo real
   - Botón contextual (prestar/reservar/en cola)
   - Lista de espera si aplica

4. **ModalConfirmacion** - Para acciones importantes:
   - Confirmación de préstamo/reserva
   - Confirmación de devolución
   - Advertencias de multas o restricciones

5. **NotificacionesPanel** - Sistema de notificaciones:
   - Alertas de vencimientos próximos
   - Confirmaciones de acciones
   - Notificaciones de disponibilidad

Incluir manejo de estados asíncronos, validaciones y feedback visual.
```

### Prompt 11: Panel de Administración para Bibliotecarios

```
Crear el panel de administración completo para bibliotecarios en React:

1. **DashboardAdmin** - Panel principal:
   - Estadísticas en tiempo real (libros prestados, usuarios activos, multas pendientes)
   - Gráficos de uso y tendencias
   - Accesos rápidos a funciones principales

2. **GestionLibros** - CRUD completo de libros:
   - Tabla con filtros y ordenamiento
   - Modal para agregar/editar libros
   - Carga masiva de libros (CSV/Excel)
   - Preview de archivos digitales

3. **GestionUsuarios** - Administración de usuarios:
   - Lista de usuarios con filtros por rol/estado
   - Edición de perfiles y permisos
   - Gestión de multas y sanciones
   - Generación de reportes de usuario

4. **ReportesAnalytics** - Sistema de reportes:
   - Reportes predefinidos (más prestados, usuarios activos)
   - Generador de reportes personalizados
   - Exportación a PDF/Excel
   - Gráficos interactivos con Chart.js o Recharts

5. **ConfiguracionSistema** - Configuraciones generales:
   - Políticas de préstamo por tipo de usuario
   - Configuración de multas y sanciones
   - Parámetros del sistema

Incluir tablas con DataTable, formularios complejos, y visualizaciones de datos.
```

### Prompt 12: Optimización y Características Avanzadas

```
Implementar características avanzadas y optimizaciones para la aplicación React del sistema de biblioteca:

1. **Performance**:
   - Implementar React.memo y useMemo para componentes pesados
   - Lazy loading para páginas y componentes
   - Infinite scroll para el catálogo de libros
   - Service Worker para cache de recursos

2. **UX/UI Avanzada**:
   - Tema claro/oscuro con Context
   - Animaciones suaves con Framer Motion
   - Skeleton loaders para mejor perceived performance
   - Toast notifications para feedback

3. **PWA Features**:
   - Configuración de PWA para uso offline
   - Push notifications para recordatorios
   - Instalación como app nativa

4. **Testing**:
   - Test unitarios con Jest y React Testing Library
   - Tests de integración para flujos críticos
   - Configuración de CI/CD básica

5. **Accessibility**:
   - ARIA labels y roles
   - Navegación por teclado
   - Contraste de colores adecuado
   - Screen reader compatibility

6. **Estado Global Avanzado**:
   - Implementar Redux Toolkit para estado complejo
   - RTK Query para cache de datos
   - Middleware para logging y debugging

Proporcionar código completo con mejores prácticas y documentación.
```

---

## Guía de Uso

### Recomendaciones para la Implementación:

1. **Usar los prompts secuencialmente** - Cada prompt construye sobre el anterior
2. **Probar cada fase** antes de continuar con la siguiente
3. **Usar Claude web** para generar código extenso y mantener contexto
4. **Configurar un entorno local** con Visual Studio/VS Code y MySQL
5. **Versionar el código** con Git desde el inicio

### Herramientas Necesarias:

- **Backend:** Visual Studio 2022 o VS Code, .NET 8 SDK, MySQL Server
- **Frontend:** Node.js, VS Code, extensiones de React/TypeScript
- **Base de Datos:** MySQL Workbench o similar
- **Testing:** Postman para APIs, browser dev tools para frontend
- **Control de Versiones:** Git

### Flujo de Trabajo Sugerido:

1. Configurar entorno de desarrollo
2. Ejecutar prompts 1-6 para backend completo
3. Probar APIs con Postman
4. Ejecutar prompts 7-12 para frontend
5. Integrar y probar aplicación completa
6. Optimizar y desplegar

---
