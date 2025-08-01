## Instrucciones de Uso

### Cómo usar estos prompts:

1. **Copia el prompt específico** que quieras usar
2. **Pégalo en tu herramienta de IA favorita** (ChatGPT, Claude, etc.)
3. **Ajusta los detalles** según tus necesidades específicas
4. **Solicita el formato Mermaid** explícitamente si no está incluido

### Tips adicionales:

- **Combina prompts:** Puedes usar múltiples diagramas para una vista completa
- **Personaliza:** Modifica entidades, procesos o componentes según tu proyecto
- **Itera:** Pide modificaciones específicas después del primer resultado
- **Valida:** Revisa que el diagrama refleje correctamente tus requerimientos

### Orden recomendado para el curso:

1. Diagrama ER (base de datos)
2. Casos de uso (funcionalidad)
3. Diagramas de flujo (procesos)
4. Diagramas de secuencia (interacciones)
5. Arquitectura del sistema (vista general)


# Prompts para Generar Diagramas Mermaid
## Sistema de Gestión de Biblioteca Universitaria

### 1. Prompt para Diagrama Entidad-Relación (ERD)

```
Crea un diagrama Mermaid ER (Entity Relationship) para el Sistema de Gestión de Biblioteca Universitaria con las siguientes entidades y sus relaciones:

ENTIDADES Y ATRIBUTOS:
- Usuario (id_usuario PK, numero_identificacion, nombre, apellido, email, tipo_usuario, estado)
- Libro (id_libro PK, isbn, titulo, autor, editorial, categoria, estado)
- Copia_Libro (id_copia PK, id_libro FK, codigo_copia, estado_copia)
- Prestamo (id_prestamo PK, id_usuario FK, id_copia FK, fecha_prestamo, fecha_vencimiento, estado_prestamo)
- Reserva (id_reserva PK, id_usuario FK, id_libro FK, fecha_reserva, estado_reserva)
- Multa (id_multa PK, id_usuario FK, id_prestamo FK, monto, estado_multa)
- Notificacion (id_notificacion PK, id_usuario FK, tipo_notificacion, mensaje, leida)

RELACIONES:
- Usuario (1) -----> (N) Prestamo
- Usuario (1) -----> (N) Reserva  
- Usuario (1) -----> (N) Multa
- Usuario (1) -----> (N) Notificacion
- Libro (1) -----> (N) Copia_Libro
- Libro (1) -----> (N) Reserva
- Copia_Libro (1) -----> (N) Prestamo
- Prestamo (1) -----> (1) Multa

Incluye los tipos de datos principales y marca las claves primarias y foráneas claramente.
```

### 2. Prompt para Diagrama de Casos de Uso

```
Genera un diagrama Mermaid de casos de uso para el Sistema de Gestión de Biblioteca Universitaria que incluya:

ACTORES:
- Estudiante
- Profesor  
- Bibliotecario
- Administrador

CASOS DE USO PRINCIPALES:
- Buscar libros
- Realizar reserva
- Consultar préstamos personales
- Registrar préstamo (solo Bibliotecario)
- Procesar devolución (solo Bibliotecario)
- Gestionar usuarios (solo Bibliotecario)
- Gestionar inventario (solo Bibliotecario)
- Generar reportes (Bibliotecario y Administrador)
- Configurar sistema (solo Administrador)
- Gestionar multas (solo Bibliotecario)

RELACIONES:
- Estudiante y Profesor heredan capacidades básicas de consulta
- Bibliotecario tiene acceso a funciones administrativas
- Administrador tiene acceso completo al sistema

Utiliza el formato de diagrama flowchart de Mermaid para representar las relaciones actor-caso de uso.
```

### 3. Prompt para Diagrama de Flujo - Proceso de Préstamo

```
Crea un diagrama de flujo Mermaid que represente el proceso completo de "Realizar Préstamo de Libro" con las siguientes etapas:

INICIO: Bibliotecario inicia proceso de préstamo

PASOS DEL PROCESO:
1. Escanear carnet del usuario
2. Verificar estado del usuario (activo/inactivo)
3. Verificar si tiene multas pendientes
4. Si tiene multas -> Mostrar error y terminar
5. Escanear código del libro
6. Verificar disponibilidad del libro
7. Si no disponible -> Ofrecer reserva
8. Verificar límites de préstamo del usuario (3 libros estudiantes, 5 profesores)
9. Si excede límite -> Mostrar error
10. Registrar préstamo en sistema
11. Actualizar estado del libro a "prestado"
12. Calcular fecha de vencimiento (14 días estudiantes, 30 profesores)
13. Generar comprobante
14. Enviar notificación al usuario

PUNTOS DE DECISIÓN:
- Usuario activo? (Sí/No)
- Tiene multas? (Sí/No)  
- Libro disponible? (Sí/No)
- Excede límite? (Sí/No)

FIN: Préstamo completado exitosamente o proceso cancelado

Usa formas diferentes para inicio/fin, procesos, decisiones y documentos.
```

### 4. Prompt para Diagrama de Secuencia - Búsqueda de Libros

```
Genera un diagrama de secuencia Mermaid para el caso de uso "Buscar y Reservar Libro" con los siguientes participantes y mensajes:

PARTICIPANTES:
- Usuario (Estudiante/Profesor)
- Interfaz Web
- Controlador de Búsqueda
- Base de Datos
- Servicio de Reservas
- Servicio de Notificaciones

SECUENCIA DE MENSAJES:
1. Usuario ingresa criterios de búsqueda en Interfaz Web
2. Interfaz Web envía solicitud a Controlador de Búsqueda
3. Controlador consulta Base de Datos con criterios
4. Base de Datos retorna resultados de libros
5. Controlador procesa y filtra resultados por disponibilidad
6. Interfaz Web muestra resultados al Usuario
7. Usuario selecciona libro específico
8. Si libro no disponible: Usuario solicita reserva
9. Interfaz Web envía solicitud de reserva a Servicio de Reservas
10. Servicio de Reservas valida usuario y límites
11. Servicio de Reservas registra reserva en Base de Datos
12. Servicio de Reservas notifica a Servicio de Notificaciones
13. Servicio de Notificaciones envía confirmación al Usuario

NOTAS:
- Incluir bucles para múltiples criterios de búsqueda
- Incluir condiciones alternativas (libro disponible vs no disponible)
- Mostrar activaciones de participantes
```

### 5. Prompt para Diagrama de Arquitectura del Sistema

```
Crea un diagrama Mermaid que muestre la arquitectura completa del Sistema de Gestión de Biblioteca Universitaria con los siguientes componentes:

CAPA DE PRESENTACIÓN:
- Aplicación Web (React/Vue.js)
- Aplicación Móvil (opcional)
- Panel de Administración

CAPA DE SERVICIOS:
- API Gateway
- Servicio de Autenticación
- Servicio de Gestión de Usuarios
- Servicio de Catálogo de Libros
- Servicio de Préstamos
- Servicio de Reservas
- Servicio de Notificaciones
- Servicio de Reportes

CAPA DE DATOS:
- Base de Datos Principal (PostgreSQL)
- Cache Redis
- Almacenamiento de Archivos
- Sistema de Backup

SERVICIOS EXTERNOS:
- Servicio de Email (SMTP)
- Sistema de Autenticación Universitario (LDAP/SSO)
- Servicio de SMS (opcional)

CONEXIONES:
- Aplicaciones web/móvil se conectan a API Gateway
- API Gateway distribuye a microservicios
- Servicios acceden a base de datos y cache
- Integración con servicios externos para notificaciones

Usa el formato de diagrama de arquitectura (graph TD) con diferentes formas para cada tipo de componente.
```

### 6. Prompt para Diagrama de Estados - Ciclo de Vida del Libro

```
Genera un diagrama de estados Mermaid que represente el ciclo de vida completo de un libro en el sistema de biblioteca:

ESTADOS DEL LIBRO:
- Nuevo (estado inicial)
- Disponible
- Prestado
- Reservado
- En Mantenimiento
- Perdido
- Dado de Baja (estado final)

TRANSICIONES Y EVENTOS:
- Nuevo -> Disponible: [Registro completado]
- Disponible -> Prestado: [Préstamo realizado]
- Disponible -> Reservado: [Reserva activa]
- Prestado -> Disponible: [Devolución normal]
- Prestado -> Perdido: [Reportado como perdido]
- Reservado -> Prestado: [Usuario retira reserva]
- Reservado -> Disponible: [Reserva vencida/cancelada]
- Cualquier estado -> En Mantenimiento: [Requiere reparación]
- En Mantenimiento -> Disponible: [Mantenimiento completado]
- En Mantenimiento -> Dado de Baja: [No reparable]
- Perdido -> Dado de Baja: [Confirmación definitiva]

CONDICIONES:
- Desde Prestado solo se puede ir a Disponible o Perdido
- Desde Reservado se puede cancelar o convertir en Préstamo
- El estado Dado de Baja es irreversible

Incluye las condiciones de transición y eventos que disparan cada cambio de estado.
```

### 7. Prompt para Diagrama de Flujo - Proceso de Notificaciones

```
Crea un diagrama de flujo Mermaid para el sistema automático de notificaciones que incluya:

PROCESO PRINCIPAL:
- Inicio: Tarea programada (diaria a las 8:00 AM)
- Consultar préstamos próximos a vencer (3 días antes)
- Consultar préstamos vencidos
- Consultar reservas disponibles para recoger
- Para cada préstamo próximo a vencer:
  * Generar notificación de recordatorio
  * Enviar email al usuario
  * Registrar notificación en sistema
- Para cada préstamo vencido:
  * Generar notificación de vencimiento
  * Calcular multa correspondiente
  * Registrar multa en sistema
  * Enviar notificación de multa
- Para cada reserva disponible:
  * Verificar si han pasado más de 48 horas
  * Si han pasado -> Cancelar reserva y notificar
  * Si no -> Enviar recordatorio de disponibilidad

PUNTOS DE DECISIÓN:
- ¿Hay préstamos por vencer?
- ¿Hay préstamos vencidos?
- ¿Hay reservas disponibles?
- ¿Reserva excede 48 horas?
- ¿Usuario tiene email válido?

SUBPROCESOS:
- Generación de contenido de notificación
- Envío de email
- Registro en base de datos
- Manejo de errores de envío

FIN: Proceso completado, próxima ejecución programada
```

### 8. Prompt para Diagrama de Clases (Orientado a Objetos)

```
Genera un diagrama de clases Mermaid para el Sistema de Gestión de Biblioteca con las siguientes clases y relaciones:

CLASES PRINCIPALES:

Usuario:
- Atributos: id, numeroIdentificacion, nombre, apellido, email, tipoUsuario, estado
- Métodos: validarCredenciales(), puedePrestar(), calcularLimitePrestamo()

Libro:
- Atributos: id, isbn, titulo, autor, editorial, categoria, estado
- Métodos: buscarPorCriterio(), estaDisponible(), obtenerCopias()

CopiaLibro:
- Atributos: id, idLibro, codigoCopia, estadoCopia
- Métodos: prestar(), devolver(), marcarDañada()

Prestamo:
- Atributos: id, idUsuario, idCopia, fechaPrestamo, fechaVencimiento, estado
- Métodos: calcularFechaVencimiento(), renovar(), procesar Devolucion()

Reserva:
- Atributos: id, idUsuario, idLibro, fechaReserva, estado
- Métodos: crearReserva(), cancelar(), convertirAPrestamo()

GestorPrestamos:
- Métodos: realizarPrestamo(), procesarDevolucion(), verificarDisponibilidad()

GestorReservas:
- Métodos: crearReserva(), procesarReservasVencidas(), notificarDisponibilidad()

ServicioNotificaciones:
- Métodos: enviarNotificacion(), generarRecordatorios(), procesarVencimientos()

RELACIONES:
- Usuario "1" ---> "0..*" Prestamo
- Usuario "1" ---> "0..*" Reserva
- Libro "1" ---> "1..*" CopiaLibro
- CopiaLibro "1" ---> "0..*" Prestamo
- GestorPrestamos usa Usuario, CopiaLibro, Prestamo
- GestorReservas usa Usuario, Libro, Reserva

Incluye visibilidad de atributos y métodos (+, -, #).
```

### 9. Prompt para Diagrama de Componentes

```
Crea un diagrama de componentes Mermaid que muestre la descomposición modular del Sistema de Gestión de Biblioteca:

MÓDULOS PRINCIPALES:

Módulo de Autenticación:
- Componente: AuthController
- Componente: AuthService  
- Interfaces: IAuthProvider, IUserValidator

Módulo de Gestión de Usuarios:
- Componente: UserController
- Componente: UserService
- Componente: UserRepository
- Interfaces: IUserService, IUserRepository

Módulo de Catálogo:
- Componente: BookController
- Componente: BookService
- Componente: SearchEngine
- Componente: BookRepository
- Interfaces: IBookService, ISearchEngine

Módulo de Préstamos:
- Componente: LoanController
- Componente: LoanService
- Componente: LoanRepository
- Interfaces: ILoanService, ILoanValidator

Módulo de Reservas:
- Componente: ReservationController
- Componente: ReservationService
- Componente: ReservationRepository

Módulo de Notificaciones:
- Componente: NotificationService
- Componente: EmailProvider
- Componente: SMSProvider
- Interfaces: INotificationProvider

Módulo de Reportes:
- Componente: ReportController
- Componente: ReportGenerator
- Componente: DataAnalyzer

DEPENDENCIAS:
- Controllers dependen de Services
- Services dependen de Repositories
- Todos los módulos dependen del módulo de Autenticación
- Módulo de Préstamos usa Módulo de Notificaciones
- Módulo de Reportes accede a todos los repositorios

Muestra las interfaces, implementaciones y dependencias entre componentes.
```

### 10. Prompt para Diagrama de Despliegue

```
Genera un diagrama de despliegue Mermaid que muestre la infraestructura y distribución de componentes del Sistema de Gestión de Biblioteca:

NODOS DE INFRAESTRUCTURA:

Servidor Web:
- Aplicación React (Frontend)
- Nginx (Servidor web/Proxy reverso)
- SSL/TLS Certificates

Servidor de Aplicaciones:
- API REST (Node.js/Express)
- Servicios de Negocio
- Middleware de Autenticación
- Sistema de Logs

Servidor de Base de Datos:
- PostgreSQL (Base de datos principal)
- Redis (Cache y sesiones)
- Backup automático

Servidor de Archivos:
- Almacenamiento de documentos
- Imágenes de libros
- Logs del sistema
- Backups

Servicios Externos:
- Servidor SMTP (Email)
- Servicio SMS
- Sistema LDAP Universitario

CONEXIONES Y PROTOCOLOS:
- Cliente -> Servidor Web: HTTPS
- Servidor Web -> Servidor App: HTTP interno
- Servidor App -> Base de Datos: TCP/5432
- Servidor App -> Redis: TCP/6379
- Servidor App -> SMTP: TCP/587
- Servidor App -> LDAP: LDAPS/636

ESPECIFICACIONES:
- Balanceador de Carga (opcional)
- Firewall y seguridad
- Monitoreo y alertas
- Backup y recuperación

Incluye puertos, protocolos y especificaciones técnicas relevantes.
```

---

