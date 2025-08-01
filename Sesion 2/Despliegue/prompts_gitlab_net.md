Prompts para Proyectos C# en GitLab CI/CD

Prompts de Setup Inicial

"Crea un archivo .gitlab-ci.yml completo para una aplicación C# .NET 8 que incluya restore, build, test y publish usando la imagen oficial mcr.microsoft.com/dotnet/sdk:8.0."

"Genera un pipeline GitLab CI para una solución C# multi-proyecto que compile diferentes assemblies (Web API, Class Library, Tests) en paralelo."

"Diseña un .gitlab-ci.yml que detecte automáticamente la versión de .NET del proyecto leyendo el archivo .csproj y use la imagen Docker correspondiente."
Prompts de Configuración de Build

"Implementa un pipeline que compile una aplicación C# en modo Release con optimizaciones habilitadas y genere artefactos de build como .nupkg y binarios."

"Crea un job de GitLab CI que restaure paquetes NuGet usando cache local y genere un reporte de dependencias vulnerables usando dotnet list package --vulnerable."


Testing en Proyectos C#

Prompts de Unit Testing

"Desarrolla un pipeline que ejecute pruebas unitarias con xUnit, genere reportes de cobertura usando coverlet y publique los resultados en GitLab Test Reports."

"Implementa jobs paralelos para ejecutar diferentes suites de pruebas C# (Unit, Integration, Performance) usando dotnet test con filtros de categorías."

"Crea un pipeline que ejecute pruebas con múltiples frameworks target (.NET 6, .NET 8) y genere reportes consolidados de compatibilidad."
Prompts de Integration Testing

"Diseña un job que ejecute pruebas de integración C# con base de datos SQL Server usando TestContainers y docker-compose en GitLab CI."

"Implementa pruebas E2E para una aplicación ASP.NET Core usando Playwright y C#, con captura de screenshots en caso de fallo."

"Crea un pipeline que ejecute pruebas de carga con NBomber contra una API ASP.NET Core desplegada en un environment temporal."
M

Quality Gates y Code Analysis

Prompts de SonarQube Integration

"Integra SonarQube en GitLab CI para análisis de código C# con quality gates que bloqueen merge requests si no cumplen con los estándares de calidad."

"Implementa análisis de SonarQube que incluya coverage, duplicación de código, bugs, vulnerabilidades y code smells para proyectos .NET."

"Crea un pipeline que genere reportes de technical debt usando SonarQube y los publique como comentarios automáticos en merge requests."
Prompts de Static Analysis

"Configura análisis estático usando .editorconfig, StyleCop y FxCop Analyzers en GitLab CI con reportes de violations como artefactos."

"Implementa un job que ejecute Roslyn Analyzers personalizados y genere reportes de métricas de código (complejidad ciclomática, maintainability index)."


Packaging y NuGet

Prompts de NuGet Packages

"Crea un pipeline que genere paquetes NuGet automáticamente con semantic versioning basado en git tags y los publique en GitLab Package Registry."

"Implementa un job que valide la integridad de paquetes NuGet, ejecute vulnerability scanning y genere reportes de licencias de dependencias."

"Diseña un pipeline para bibliotecas C# que genere paquetes multi-target (.NET Standard 2.0, .NET 6, .NET 8) y símbolos de debug."
Prompts de Dependency Management

"Desarrolla un sistema de actualización automática de dependencias NuGet usando Dependabot o renovate integrado con GitLab CI."

"Crea un job que analice conflictos de versiones en dependencias transitivas y genere reportes de resolución de paquetes."


Containerización de Aplicaciones .NET

Prompts de Docker para .NET

"Genera un Dockerfile multi-stage optimizado para una aplicación ASP.NET Core que incluya build, test y runtime stages con imagen alpine."

"Crea un pipeline GitLab CI que construya imágenes Docker para aplicaciones .NET con diferentes configuraciones (Debug/Release) y las publique en Container Registry."

"Implementa un job que construya imágenes Docker multi-arquitectura (linux/amd64, linux/arm64) para aplicaciones .NET 8 usando buildx."
Prompts de Container Security

"Diseña un pipeline que escanee vulnerabilidades en imágenes Docker de aplicaciones .NET usando Trivy y bloquee deploys si encuentra vulnerabilidades críticas."

"Implementa un job que analice la superficie de ataque de containers .NET usando herramientas como dive y genere reportes de optimización."


Web APIs y Microservicios

Prompts de ASP.NET Core APIs

"Crea un pipeline completo para una Web API ASP.NET Core que incluya build, tests, generación de documentación OpenAPI y deploy a Kubernetes."

"Implementa un job que genere clientes HTTP automáticamente usando NSwag a partir de la especificación OpenAPI de una API C#."

"Diseña un pipeline que ejecute contract testing usando Pact.NET para validar compatibilidad entre microservicios C#."
Prompts de Service Mesh

"Desarrolla un pipeline que despliegue microservicios C# a Istio service mesh con configuración de traffic routing y observability."

"Crea jobs que configuren circuit breakers, retry policies y timeout usando Polly en APIs C# como parte del pipeline de deployment."


Entity Framework y Migrations

Prompts de Database Migrations

"Implementa un pipeline que ejecute Entity Framework migrations automáticamente durante el deployment con rollback capability."

"Crea un job que genere scripts SQL de migrations de EF Core y los valide contra diferentes versiones de base de datos (SQL Server, PostgreSQL, MySQL)."

"Diseña un pipeline que ejecute migrations de EF Core con zero-downtime usando blue-green deployment strategy."
Prompts de Database Testing

"Desarrolla jobs que ejecuten pruebas de integridad de datos después de aplicar migrations usando Entity Framework Core."

"Implementa un sistema de seeding de datos de prueba usando EF Core que se ejecute automáticamente en environments de testing."


Blazor Applications

Prompts de Blazor Server/WASM

"Crea un pipeline para una aplicación Blazor WebAssembly que incluya AOT compilation, tree shaking y optimización de bundle size."

"Implementa un job que ejecute pruebas de componentes Blazor usando bUnit y genere reportes de coverage específicos para Razor components."

"Diseña un pipeline que despliegue aplicaciones Blazor Server con SignalR hubs a Azure App Service con slot swapping."
Prompts de PWA y Static Sites

"Desarrolla un pipeline que genere una PWA desde una aplicación Blazor WASM y la publique en GitLab Pages con service worker caching."

"Crea un job que optimice assets estáticos de Blazor (CSS, JS, images) usando webpack y los publique en CDN."


Background Services y Workers

Prompts de Hosted Services

"Implementa un pipeline para .NET Worker Services que incluya health checks, metrics collection y deployment a Kubernetes como CronJobs."

"Crea un job que valide la configuración de Background Services usando IHostedService y ejecute pruebas de long-running processes."

"Diseña un pipeline que despliegue Azure Functions C# con diferentes triggers (HTTP, Timer, Queue) y monitoreo integrado."
Prompts de Message Queues

"Desarrolla un pipeline que integre aplicaciones C# con RabbitMQ/Azure Service Bus incluyendo pruebas de message processing y dead letter handling."

"Implementa jobs que validen el procesamiento de eventos usando MassTransit o NServiceBus con sagas y compensating actions."


Performance y Monitoring

Prompts de Performance Testing

"Crea un pipeline que ejecute benchmarks de performance usando BenchmarkDotNet y publique trending reports en GitLab Pages."

"Implementa jobs que ejecuten profiling de memoria usando dotMemory Unit y detecten memory leaks en aplicaciones .NET."

"Diseña un pipeline que ejecute stress testing de APIs C# usando k6 con métricas específicas de .NET (GC, ThreadPool, HTTP)."
Prompts de Application Monitoring

"Desarrolla un job que configure Application Insights telemetry en aplicaciones C# con custom metrics y distributed tracing."

"Implementa un pipeline que genere dashboards de Grafana automáticamente basados en métricas de aplicaciones .NET usando Prometheus.NET."


Security en Aplicaciones .NET

Prompts de Security Scanning

"Crea un pipeline que ejecute security scanning específico para .NET usando tools como Security Code Scan y genere SARIF reports."

"Implementa jobs que validen configuraciones de seguridad en aplicaciones ASP.NET Core (HTTPS, HSTS, CSP, authentication)."

"Diseña un pipeline que ejecute OWASP dependency check para paquetes NuGet y genere reportes de vulnerabilidades conocidas."
Prompts de Authentication & Authorization

"Desarrolla un job que valide la implementación de JWT authentication en APIs C# incluyendo token validation y claims testing."

"Implementa pruebas automatizadas de autorización basada en políticas usando ASP.NET Core Identity con diferentes roles y scopes."


Enterprise Patterns

Prompts de Clean Architecture

"Crea un pipeline para proyectos C# con Clean Architecture que valide dependencies entre layers y ejecute architecture tests usando NetArchTest."

"Implementa jobs que generen diagramas de arquitectura automáticamente a partir del código C# usando tools como PlantUML y C# reflection."

"Diseña un pipeline que valide Domain-Driven Design patterns en código C# usando custom analyzers y architecture guidelines."
Prompts de CQRS y Event Sourcing

"Desarrolla un pipeline que valide la implementación de CQRS patterns usando MediatR incluyendo testing de command/query handlers."

"Implementa jobs que ejecuten pruebas de Event Sourcing con EventStore incluyendo snapshot validation y projection rebuilding."
Proyectos Completos e Integrales
Proyecto E-Commerce Completo

"Diseña un pipeline completo para una aplicación e-commerce C# que incluya: Web API, Blazor frontend, Worker services para processing, Entity Framework con migrations, Redis caching, message queues, security scanning, performance testing y deployment a Kubernetes con monitoring completo."
Proyecto Microservicios Enterprise

"Implementa un pipeline enterprise para arquitectura de microservicios .NET que incluya: API Gateway, service discovery, distributed logging, circuit breakers, event-driven communication, database per service, CI/CD por servicio, integration testing entre servicios y observability completa."
Proyecto FinTech Compliance

"Crea un pipeline para aplicación financiera C# que cumpla con regulaciones (PCI DSS, SOX) incluyendo: encryption at rest/transit, audit logging, segregation of duties en deployments, vulnerability management, compliance reporting y disaster recovery procedures."
Prompts de Troubleshooting C#
Debug de Build Issues

"Genera un guide de troubleshooting para errores comunes en builds de C# en GitLab CI: package restore failures, assembly conflicts, compiler errors y runtime issues."

"Implementa logging detallado en pipelines C# que facilite el debugging de problemas de compilación, dependency resolution y runtime configuration."
Performance Debugging

"Crea jobs que diagnostiquen problemas de performance en aplicaciones .NET durante CI/CD: slow startup, memory leaks, high CPU usage y database query performance."

"Desarrolla scripts que analicen dumps de memoria de aplicaciones .NET que fallan durante testing y generen reportes automáticos de root cause analysis."
Prompts de Migration y Modernización
.NET Framework to .NET Core/5+

"Diseña un pipeline de migración que valide la compatibilidad de código .NET Framework con .NET 8 usando .NET Portability Analyzer."

"Implementa jobs que ejecuten side-by-side testing entre versiones .NET Framework y .NET Core de la misma aplicación."
Legacy System Integration

"Crea un pipeline que maneje la integración entre aplicaciones .NET modernas y sistemas legacy usando COM interop, P/Invoke y message bridging."

"Desarrolla jobs que validen backward compatibility durante upgrades de .NET manteniendo interfaces con sistemas existentes."
