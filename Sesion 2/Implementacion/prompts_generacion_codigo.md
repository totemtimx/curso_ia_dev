## Generación de Modelos y DTOs

### Ejemplo 1: Generación de Entidades desde Especificaciones

**Especificación de Negocio:**
```
Sistema de gestión de biblioteca digital:
- Los usuarios pueden tener múltiples roles (Admin, Librarian, Member)
- Los libros tienen información básica, categorías y disponibilidad
- Los préstamos tienen fechas, multas y estados
- Las reservas permiten apartar libros
- Auditoría completa de operaciones
```

**Prompt para Generación de Modelos:**
```
Como arquitecto .NET senior, genera un modelo de dominio completo en C# para el sistema descrito.

**REQUERIMIENTOS:**
1. **Entidades de Dominio** con:
   - Propiedades con tipos apropiados y nullable reference types
   - Constructores que garanticen invariantes de negocio
   - Métodos de dominio para lógica de negocio
   - Validaciones usando Data Annotations y FluentValidation
   - Navegation properties para EF Core

2. **Value Objects** para:
   - Email, ISBN, Money, DateRange
   - Implementar equality comparison
   - Ser inmutables

3. **Enums** para estados y tipos con:
   - Descripciones localizables
   - Valores explícitos
   - Métodos de extensión útiles

4. **DTOs y Mappers** para:
   - Request/Response models
   - AutoMapper profiles
   - Validation attributes

5. **Interfaces y Abstracciones**:
   - Repository patterns
   - Domain services
   - Unit of Work

**PATRONES A APLICAR:**
- Domain-Driven Design (DDD)
- Clean Architecture
- CQRS patterns
- Repository pattern
- Specification pattern

**FRAMEWORKS:**
- .NET 8
- Entity Framework Core 8
- FluentValidation
- AutoMapper
- MediatR

Genera código production-ready con:
- XML documentation completa
- Unit tests usando xUnit
- Realistic data examples
- Error handling robusto

[ESPECIFICACIÓN DE NEGOCIO]
```

### Código Generado (Ejemplo de respuesta esperada):

```csharp
// Domain/Entities/User.cs
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LibrarySystem.Domain.ValueObjects;
using LibrarySystem.Domain.Enums;

namespace LibrarySystem.Domain.Entities
{
    /// <summary>
    /// Representa un usuario del sistema de biblioteca
    /// </summary>
    public class User : BaseEntity
    {
        private readonly List<Loan> _loans = new();
        private readonly List<Reservation> _reservations = new();

        /// <summary>
        /// Constructor para Entity Framework
        /// </summary>
        private User() { }

        /// <summary>
        /// Constructor para crear un nuevo usuario
        /// </summary>
        /// <param name="email">Email único del usuario</param>
        /// <param name="firstName">Nombre del usuario</param>
        /// <param name="lastName">Apellido del usuario</param>
        /// <param name="role">Rol inicial del usuario</param>
        /// <exception cref="ArgumentException">Cuando los parámetros son inválidos</exception>
        public User(Email email, string firstName, string lastName, UserRole role)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            FirstName = !string.IsNullOrWhiteSpace(firstName) 
                ? firstName.Trim() 
                : throw new ArgumentException("First name cannot be empty", nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) 
                ? lastName.Trim() 
                : throw new ArgumentException("Last name cannot be empty", nameof(lastName));
            Role = role;
            Status = UserStatus.Active;
            MembershipDate = DateTime.UtcNow;
            LibraryCardNumber = GenerateLibraryCardNumber();
        }

        /// <summary>
        /// Identificador único del usuario
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Email único del usuario
        /// </summary>
        public Email Email { get; private set; } = null!;

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [Required, MaxLength(50)]
        public string FirstName { get; private set; } = null!;

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        [Required, MaxLength(50)]
        public string LastName { get; private set; } = null!;

        /// <summary>
        /// Número de tarjeta de biblioteca único
        /// </summary>
        [Required, MaxLength(20)]
        public string LibraryCardNumber { get; private set; } = null!;

        /// <summary>
        /// Rol del usuario en el sistema
        /// </summary>
        public UserRole Role { get; private set; }

        /// <summary>
        /// Estado actual del usuario
        /// </summary>
        public UserStatus Status { get; private set; }

        /// <summary>
        /// Fecha de registro en el sistema
        /// </summary>
        public DateTime MembershipDate { get; private set; }

        /// <summary>
        /// Información de contacto opcional
        /// </summary>
        public ContactInfo? ContactInfo { get; private set; }

        /// <summary>
        /// Préstamos activos del usuario
        /// </summary>
        public IReadOnlyCollection<Loan> Loans => _loans.AsReadOnly();

        /// <summary>
        /// Reservas activas del usuario
        /// </summary>
        public IReadOnlyCollection<Reservation> Reservations => _reservations.AsReadOnly();

        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Indica si el usuario puede tomar préstamos
        /// </summary>
        /// <returns>True si puede tomar préstamos</returns>
        public bool CanBorrowBooks()
        {
            if (Status != UserStatus.Active) return false;
            
            var activeLoans = _loans.Count(l => l.Status == LoanStatus.Active);
            var maxLoans = Role switch
            {
                UserRole.Member => 5,
                UserRole.Librarian => 10,
                UserRole.Admin => 20,
                _ => 0
            };

            return activeLoans < maxLoans && !HasOverdueBooks();
        }

        /// <summary>
        /// Verifica si el usuario tiene libros vencidos
        /// </summary>
        /// <returns>True si tiene libros vencidos</returns>
        public bool HasOverdueBooks()
        {
            return _loans.Any(l => l.Status == LoanStatus.Active && l.IsOverdue);
        }

        /// <summary>
        /// Calcula la multa total pendiente
        /// </summary>
        /// <returns>Monto total de multas</returns>
        public Money CalculateTotalFines()
        {
            return _loans
                .Where(l => l.Fine != null)
                .Aggregate(Money.Zero("USD"), (total, loan) => total + loan.Fine!.Amount);
        }

        /// <summary>
        /// Actualiza el rol del usuario
        /// </summary>
        /// <param name="newRole">Nuevo rol</param>
        public void UpdateRole(UserRole newRole)
        {
            if (Role == newRole) return;
            
            Role = newRole;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Suspende al usuario
        /// </summary>
        /// <param name="reason">Razón de la suspensión</param>
        public void Suspend(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Suspension reason is required", nameof(reason));

            Status = UserStatus.Suspended;
            UpdatedAt = DateTime.UtcNow;
            
            // Domain event para notificaciones
            AddDomainEvent(new UserSuspendedEvent(Id, reason));
        }

        /// <summary>
        /// Reactiva al usuario
        /// </summary>
        public void Reactivate()
        {
            if (Status == UserStatus.Active) return;
            
            Status = UserStatus.Active;
            UpdatedAt = DateTime.UtcNow;
            
            AddDomainEvent(new UserReactivatedEvent(Id));
        }

        private static string GenerateLibraryCardNumber()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var random = new Random().Next(1000, 9999);
            return $"LIB{timestamp % 100000:D5}{random}";
        }
    }
}

// Domain/ValueObjects/Email.cs
using System.Text.RegularExpressions;

namespace LibrarySystem.Domain.ValueObjects
{
    /// <summary>
    /// Value object para representar direcciones de email válidas
    /// </summary>
    public sealed class Email : IEquatable<Email>
    {
        private static readonly Regex EmailRegex = new(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Valor del email
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Crea una nueva instancia de Email
        /// </summary>
        /// <param name="value">Dirección de email</param>
        /// <exception cref="ArgumentException">Cuando el email es inválido</exception>
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty", nameof(value));

            var normalizedEmail = value.Trim().ToLowerInvariant();
            
            if (!EmailRegex.IsMatch(normalizedEmail))
                throw new ArgumentException($"Invalid email format: {value}", nameof(value));

            Value = normalizedEmail;
        }

        /// <summary>
        /// Intenta crear un Email desde un string
        /// </summary>
        /// <param name="value">Valor del email</param>
        /// <param name="email">Email creado si es válido</param>
        /// <returns>True si el email es válido</returns>
        public static bool TryCreate(string value, out Email? email)
        {
            try
            {
                email = new Email(value);
                return true;
            }
            catch
            {
                email = null;
                return false;
            }
        }

        /// <summary>
        /// Obtiene el dominio del email
        /// </summary>
        /// <returns>Dominio del email</returns>
        public string GetDomain()
        {
            return Value.Split('@')[1];
        }

        /// <summary>
        /// Obtiene la parte local del email
        /// </summary>
        /// <returns>Parte local del email</returns>
        public string GetLocalPart()
        {
            return Value.Split('@')[0];
        }

        public bool Equals(Email? other)
        {
            return other is not null && Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Email);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        public static explicit operator Email(string value)
        {
            return new Email(value);
        }
    }
}

// Domain/Enums/UserRole.cs
using System.ComponentModel;

namespace LibrarySystem.Domain.Enums
{
    /// <summary>
    /// Roles disponibles para usuarios del sistema
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Miembro regular de la biblioteca
        /// </summary>
        [Description("Member")]
        Member = 1,

        /// <summary>
        /// Bibliotecario con permisos administrativos limitados
        /// </summary>
        [Description("Librarian")]
        Librarian = 2,

        /// <summary>
        /// Administrador del sistema con todos los permisos
        /// </summary>
        [Description("Administrator")]
        Admin = 3
    }

    /// <summary>
    /// Métodos de extensión para UserRole
    /// </summary>
    public static class UserRoleExtensions
    {
        /// <summary>
        /// Obtiene la descripción del rol
        /// </summary>
        /// <param name="role">Rol del usuario</param>
        /// <returns>Descripción del rol</returns>
        public static string GetDescription(this UserRole role)
        {
            var field = role.GetType().GetField(role.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? role.ToString();
        }

        /// <summary>
        /// Verifica si el rol tiene permisos administrativos
        /// </summary>
        /// <param name="role">Rol a verificar</param>
        /// <returns>True si tiene permisos administrativos</returns>
        public static bool HasAdminPrivileges(this UserRole role)
        {
            return role is UserRole.Admin or UserRole.Librarian;
        }

        /// <summary>
        /// Obtiene el límite máximo de préstamos para el rol
        /// </summary>
        /// <param name="role">Rol del usuario</param>
        /// <returns>Número máximo de préstamos</returns>
        public static int GetMaxLoanLimit(this UserRole role)
        {
            return role switch
            {
                UserRole.Member => 5,
                UserRole.Librarian => 10,
                UserRole.Admin => 20,
                _ => 0
            };
        }
    }
}

// Application/DTOs/UserDtos.cs
using System.ComponentModel.DataAnnotations;
using LibrarySystem.Domain.Enums;

namespace LibrarySystem.Application.DTOs
{
    /// <summary>
    /// DTO para crear un nuevo usuario
    /// </summary>
    public record CreateUserRequest
    {
        /// <summary>
        /// Email del usuario (requerido y único)
        /// </summary>
        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; init; } = null!;

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [Required, MaxLength(50)]
        public string FirstName { get; init; } = null!;

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        [Required, MaxLength(50)]
        public string LastName { get; init; } = null!;

        /// <summary>
        /// Rol inicial del usuario
        /// </summary>
        [Required, EnumDataType(typeof(UserRole))]
        public UserRole Role { get; init; }

        /// <summary>
        /// Teléfono opcional
        /// </summary>
        [Phone, MaxLength(20)]
        public string? Phone { get; init; }

        /// <summary>
        /// Dirección opcional
        /// </summary>
        [MaxLength(200)]
        public string? Address { get; init; }
    }

    /// <summary>
    /// DTO para actualizar información de usuario
    /// </summary>
    public record UpdateUserRequest
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [Required, MaxLength(50)]
        public string FirstName { get; init; } = null!;

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        [Required, MaxLength(50)]
        public string LastName { get; init; } = null!;

        /// <summary>
        /// Teléfono opcional
        /// </summary>
        [Phone, MaxLength(20)]
        public string? Phone { get; init; }

        /// <summary>
        /// Dirección opcional
        /// </summary>
        [MaxLength(200)]
        public string? Address { get; init; }
    }

    /// <summary>
    /// DTO de respuesta con información del usuario
    /// </summary>
    public record UserResponse
    {
        /// <summary>
        /// ID único del usuario
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Email del usuario
        /// </summary>
        public string Email { get; init; } = null!;

        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string FullName { get; init; } = null!;

        /// <summary>
        /// Número de tarjeta de biblioteca
        /// </summary>
        public string LibraryCardNumber { get; init; } = null!;

        /// <summary>
        /// Rol del usuario
        /// </summary>
        public string Role { get; init; } = null!;

        /// <summary>
        /// Estado del usuario
        /// </summary>
        public string Status { get; init; } = null!;

        /// <summary>
        /// Fecha de registro
        /// </summary>
        public DateTime MembershipDate { get; init; }

        /// <summary>
        /// Número de préstamos activos
        /// </summary>
        public int ActiveLoans { get; init; }

        /// <summary>
        /// Indica si puede tomar más préstamos
        /// </summary>
        public bool CanBorrow { get; init; }

        /// <summary>
        /// Multa total pendiente
        /// </summary>
        public decimal TotalFines { get; init; }
    }

    /// <summary>
    /// DTO para listado paginado de usuarios
    /// </summary>
    public record UserListResponse
    {
        /// <summary>
        /// Lista de usuarios
        /// </summary>
        public IReadOnlyList<UserSummary> Users { get; init; } = Array.Empty<UserSummary>();

        /// <summary>
        /// Información de paginación
        /// </summary>
        public PaginationInfo Pagination { get; init; } = null!;
    }

    /// <summary>
    /// DTO resumido de usuario para listados
    /// </summary>
    public record UserSummary
    {
        public Guid Id { get; init; }
        public string Email { get; init; } = null!;
        public string FullName { get; init; } = null!;
        public string LibraryCardNumber { get; init; } = null!;
        public string Role { get; init; } = null!;
        public string Status { get; init; } = null!;
        public int ActiveLoans { get; init; }
        public bool HasOverdueBooks { get; init; }
    }

    /// <summary>
    /// Información de paginación
    /// </summary>
    public record PaginationInfo
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages { get; init; }
        public bool HasPreviousPage { get; init; }
        public bool HasNextPage { get; init; }
    }
}

// Application/Mappings/UserMappingProfile.cs
using AutoMapper;
using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.ValueObjects;

namespace LibrarySystem.Application.Mappings
{
    /// <summary>
    /// Perfil de mapeo para entidades User
    /// </summary>
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserRequest, User>()
                .ConstructUsing(src => new User(
                    new Email(src.Email),
                    src.FirstName,
                    src.LastName,
                    src.Role))
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => 
                    new ContactInfo(src.Phone, src.Address)));

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.GetDescription()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ActiveLoans, opt => opt.MapFrom(src => 
                    src.Loans.Count(l => l.Status == Domain.Enums.LoanStatus.Active)))
                .ForMember(dest => dest.CanBorrow, opt => opt.MapFrom(src => src.CanBorrowBooks()))
                .ForMember(dest => dest.TotalFines, opt => opt.MapFrom(src => 
                    src.CalculateTotalFines().Amount));

            CreateMap<User, UserSummary>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.GetDescription()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ActiveLoans, opt => opt.MapFrom(src => 
                    src.Loans.Count(l => l.Status == Domain.Enums.LoanStatus.Active)))
                .ForMember(dest => dest.HasOverdueBooks, opt => opt.MapFrom(src => src.HasOverdueBooks()));
        }
    }
}
```

## Generación de APIs y Controladores

### Ejemplo 2: API REST Completa

**Especificación de API:**
```
API REST para gestión de productos en e-commerce:
- CRUD completo de productos
- Búsqueda y filtrado avanzado
- Gestión de inventario
- Sistema de categorías
- Upload de imágenes
- Versionado de API
- Autenticación JWT
- Rate limiting
- Documentación OpenAPI
```

**Prompt para Generación de API:**
```
Como desarrollador .NET experto, genera uma API REST completa en C# con las siguientes características:

**ARQUITECTURA:**
- Clean Architecture con capas bien definidas
- Patrón CQRS usando MediatR
- Repository pattern con Unit of Work
- Dependency Injection nativo de .NET
- Minimal APIs vs Controller-based (recomienda el mejor)

**FUNCIONALIDADES:**
1. **Controladores RESTful** con:
   - Operaciones CRUD completas
   - Validación de input usando FluentValidation
   - Manejo de errores global
   - Respuestas consistentes (Result pattern)
   - Paginación para listados
   - Filtros y ordenamiento

2. **Autenticación y Autorización**:
   - JWT Bearer authentication
   - Role-based authorization
   - Policy-based authorization
   - Refresh token management

3. **Documentación OpenAPI**:
   - Swagger/OpenAPI 3.0
   - Ejemplos de request/response
   - Documentación de códigos de error
   - Schemas detallados

4. **Middleware personalizado** para:
   - Global exception handling
   - Request/Response logging
   - Rate limiting
   - CORS configuration

5. **Testing**:
   - Unit tests para servicios
   - Integration tests para APIs
   - Test fixtures y builders
   - Mocking con Moq

**FRAMEWORKS Y LIBRERÍAS:**
- .NET 8 Web API
- Entity Framework Core 8
- MediatR
- FluentValidation
- AutoMapper
- Serilog
- xUnit + FluentAssertions
- AspNetCore.Mvc.Testing

**PATRONES DE SEGURIDAD:**
- Input validation
- SQL injection prevention
- XSS protection
- Rate limiting
- HTTPS enforcement

Genera código production-ready con:
- Configuración por ambiente
- Health checks
- Métricas y monitoring
- Docker support
- CI/CD considerations

[ESPECIFICACIÓN DE API]
```

### Código Generado (API Controllers):

```csharp
// Controllers/ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using ECommerce.Application.Products.Commands;
using ECommerce.Application.Products.Queries;
using ECommerce.Application.Common.Models;
using ECommerce.Domain.Enums;

namespace ECommerce.API.Controllers
{
    /// <summary>
    /// Controlador para gestión de productos
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene una lista paginada de productos
        /// </summary>
        /// <param name="query">Parámetros de consulta</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Lista paginada de productos</returns>
        /// <response code="200">Lista de productos obtenida exitosamente</response>
        /// <response code="400">Parámetros de consulta inválidos</response>
        /// <response code="401">No autorizado</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<PaginatedList<ProductDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PaginatedList<ProductDto>>>> GetProducts(
            [FromQuery] GetProductsQuery query,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting products with filters: {@Query}", query);

            var result = await _mediator.Send(query, cancellationToken);

            return result.IsSuccess 
                ? Ok(ApiResponse<PaginatedList<ProductDto>>.Success(result.Value))
                : BadRequest(ApiResponse.Failure(result.Errors));
        }

        /// <summary>
        /// Obtiene un producto específico por ID
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Producto encontrado</returns>
        /// <response code="200">Producto encontrado</response>
        /// <response code="404">Producto no encontrado</response>
        /// <response code="401">No autorizado</response>
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ProductDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ProductDetailDto>>> GetProduct(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting product with ID: {ProductId}", id);

            var result = await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);

            return result.IsSuccess
                ? Ok(ApiResponse<ProductDetailDto>.Success(result.Value))
                : NotFound(ApiResponse.Failure($"Product with ID {id} not found"));
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="command">Datos del producto a crear</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Producto creado</returns>
        /// <response code="201">Producto creado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="403">Sin permisos para crear productos</response>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse<ProductDto>>> CreateProduct(
            [FromBody] CreateProductCommand command,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating new product: {@Command}", command);

            var result = await _mediator.Send(command, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(ApiResponse.Failure(result.Errors));
            }

            var product = result.Value;
            var location = Url.Action(nameof(GetProduct), new { id = product.Id });

            return Created(location, ApiResponse<ProductDto>.Success(product));
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="id">ID del producto a actualizar</param>
        /// <param name="command">Datos actualizados del producto</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Producto actualizado</returns>
        /// <response code="200">Producto actualizado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="404">Producto no encontrado</response>
        /// <response code="401">No autorizado</response>
        /// <response code="403">Sin permisos para actualizar productos</response>
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ProductDto>>> UpdateProduct(
            Guid id,
            [FromBody] UpdateProductCommand command,
            CancellationToken cancellationToken = default)
        {
            if (id != command.Id)
            {
                return BadRequest(ApiResponse.Failure("Product ID mismatch"));
            }

            _logger.LogInformation("Updating product {ProductId}: {@Command}", id, command);

            var result = await _mediator.Send(command, cancellationToken);

            return result.IsSuccess
                ? Ok(ApiResponse<ProductDto