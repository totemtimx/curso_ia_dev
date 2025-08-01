# Guía de Prompts para Desarrolladores

## Introducción
Esta guía especializada proporciona prompts específicos para desarrolladores de software, organizados por actividades del ciclo de desarrollo, tecnologías y situaciones comunes. Cada prompt está diseñado para acelerar el desarrollo, mejorar la calidad del código y optimizar procesos técnicos.

---

## 1. Análisis y Diseño de Código

### 1.1 Arquitectura y Diseño

**Diseño de Arquitectura:**
```
Diseña la arquitectura para una aplicación [tipo: web/mobile/desktop] que [descripción de funcionalidad principal]. Considera: patrones de diseño apropiados, separación de capas, escalabilidad para [número] usuarios concurrentes, tecnologías recomendadas y puntos de integración con [sistemas externos].
```

**Refactoring de Código Legacy:**
```
Analiza este código legacy en [lenguaje] y propón un plan de refactoring: [código]. Identifica: code smells presentes, patrones de diseño aplicables, mejoras de performance, testing strategy y plan de migración incremental sin breaking changes.
```

**API Design:**
```
Diseña una REST API para [dominio específico] que incluya: endpoints principales con métodos HTTP, estructura de request/response, códigos de estado apropiados, autenticación/autorización, versionado y documentación OpenAPI/Swagger.
```

**Database Schema Design:**
```
Diseña el esquema de base de datos para [aplicación] considerando: entidades principales y relaciones, índices para optimización, constraints de integridad, estrategia de particionado si aplica, y migration scripts para [DBMS específico].
```

### 1.2 Patrones de Diseño

**Implementación de Patrones:**
```
Implementa el patrón [Strategy/Factory/Observer/Singleton] en [lenguaje] para resolver [problema específico]. Incluye: clase/interfaz principal, implementaciones concretas, ejemplo de uso, ventajas del patrón en este contexto y alternativas consideradas.
```

**SOLID Principles:**
```
Revisa este código [código] y mejóralo aplicando los principios SOLID. Identifica violaciones específicas, propón refactoring para cada principio, mantén funcionalidad existente y explica cómo cada cambio mejora maintainability.
```

---

## 2. Desarrollo y Implementación

### 2.1 Generación de Código

**Boilerplate Code:**
```
Genera el código boilerplate para [framework/librería] que incluya: estructura de proyecto estándar, configuración inicial, dependencias principales, ejemplos de [CRUD/API endpoints/components], y setup de desarrollo local.
```

**CRUD Operations:**
```
Implementa operaciones CRUD completas para la entidad [nombre] en [tecnología]. Incluye: modelo de datos, validaciones de business rules, manejo de errores apropiado, logging de operaciones y tests unitarios básicos.
```

**Algorithm Implementation:**
```
Implementa el algoritmo [nombre/descripción] en [lenguaje] optimizado para [caso de uso específico]. Considera: complejidad temporal O(), complejidad espacial, casos edge, manejo de inputs inválidos y comparación con algoritmos alternativos.
```

**Data Processing Pipeline:**
```
Crea un pipeline de procesamiento de datos que: lea desde [fuente], aplique transformaciones [específicas], valide data quality, maneje errores gracefully y escriba a [destino]. Incluye logging y monitoring de cada etapa.
```

### 2.2 Optimización y Performance

**Code Optimization:**
```
Optimiza este código [código] para mejorar performance en [métrica específica: velocidad/memoria/CPU]. Analiza: bottlenecks actuales, profiling results, optimizaciones aplicables, trade-offs considerados y benchmarks antes/después.
```

**Database Query Optimization:**
```
Optimiza esta query [query SQL] que actualmente toma [tiempo] para procesar [volumen] de datos. Propón: índices necesarios, reescritura de query, partitioning strategy si aplica, y explain plan analysis.
```

**Memory Management:**
```
Revisa este código [código] por memory leaks y optimización de uso de memoria. Identifica: objetos no liberados, collections que crecen indefinidamente, optimizaciones de garbage collection y best practices para [lenguaje específico].
```

---

## 3. Testing y Calidad

### 3.1 Testing Strategy

**Unit Testing:**
```
Crea tests unitarios completos para [función/clase] que cubran: happy path scenarios, edge cases, error conditions, mocking de dependencias externas, y assertion de side effects. Target: [%] de cobertura mínima.
```

**Integration Testing:**
```
Diseña tests de integración para [componente/API] que validen: interacción con [servicios externos], flow de datos end-to-end, manejo de timeouts, retry logic y rollback scenarios en caso de fallos.
```

**Test Automation Framework:**
```
Configura un framework de testing automatizado para [proyecto] que incluya: estructura de tests, data fixtures/mocks, CI/CD integration, parallel execution, reporting de resultados y maintenance de test data.
```

**Performance Testing:**
```
Diseña tests de performance para [aplicación] que evalúen: load testing con [número] usuarios concurrentes, stress testing hasta breaking point, endurance testing por [duración], y monitoring de métricas clave.
```

### 3.2 Code Quality

**Code Review Guidelines:**
```
Establece guidelines de code review para el equipo que incluyan: checklist técnico, standards de naming, documentation requirements, security considerations, performance criteria y process para resolving feedback.
```

**Static Code Analysis:**
```
Configura herramientas de análisis estático [SonarQube/ESLint/Pylint] para [proyecto] que detecten: code smells, security vulnerabilities, duplicación de código, complexity metrics y compliance con coding standards.
```

**Technical Debt Assessment:**
```
Evalúa el technical debt en [módulo/componente] y prioriza items de refactoring considerando: impacto en development velocity, riesgo de bugs, effort estimation, dependencies y ROI de cada improvement.
```

---

## 4. DevOps y Automatización

### 4.1 CI/CD Pipeline

**Pipeline Configuration:**
```
Configura un pipeline CI/CD para [proyecto] en [plataforma: Jenkins/GitHub Actions/GitLab] que incluya: build automation, automated testing, code quality gates, deployment stages y rollback capabilities.
```

**Docker Configuration:**
```
Crea configuración Docker para [aplicación] que incluya: Dockerfile optimizado, docker-compose para desarrollo local, multi-stage builds, health checks, volume management y security best practices.
```

**Infrastructure as Code:**
```
Desarrolla scripts de Infrastructure as Code usando [Terraform/CloudFormation/Ansible] para desplegar [infraestructura] que incluya: recursos cloud necesarios, networking configuration, security groups y monitoring setup.
```

### 4.2 Monitoring y Observabilidad

**Application Monitoring:**
```
Implementa monitoring comprehensivo para [aplicación] que incluya: application metrics (latency, throughput, errors), business metrics, alerting rules, dashboard configuration y SLA monitoring.
```

**Logging Strategy:**
```
Diseña una estrategia de logging para [aplicación] que incluya: log levels apropiados, structured logging format, sensitive data masking, log aggregation setup y retention policies.
```

**Error Tracking:**
```
Configura error tracking y alerting para [aplicación] usando [herramienta] que capture: exception details, stack traces, user context, error frequency trends y integration con incident management.
```

---

## 5. Seguridad y Compliance

### 5.1 Security Implementation

**Authentication & Authorization:**
```
Implementa sistema de autenticación y autorización para [aplicación] usando [JWT/OAuth2/SAML] que incluya: user registration/login, role-based access control, session management, password policies y two-factor authentication.
```

**Input Validation:**
```
Implementa validación robusta de inputs para [aplicación] que prevenga: SQL injection, XSS attacks, CSRF, command injection y otras vulnerabilidades de OWASP Top 10. Incluye sanitization y encoding apropiados.
```

**Data Encryption:**
```
Implementa encryption para datos sensibles en [aplicación] incluyendo: encryption at rest, encryption in transit, key management, hashing de passwords y compliance con [regulación específica: GDPR/HIPAA].
```

### 5.2 Security Testing

**Vulnerability Assessment:**
```
Realiza assessment de vulnerabilidades en [aplicación] usando [herramientas] que identifique: dependency vulnerabilities, code security issues, configuration problems y compliance gaps con security standards.
```

**Penetration Testing Plan:**
```
Diseña un plan de penetration testing para [aplicación] que cubra: authentication bypass attempts, authorization flaws, injection attacks, business logic vulnerabilities y social engineering vectors.
```

---

## 6. Frontend Development

### 6.1 UI/UX Implementation

**Component Development:**
```
Desarrolla un componente [nombre] en [React/Vue/Angular] que sea: reusable, accessible (WCAG compliant), responsive, performant y incluya unit tests. Considera props/state management, event handling y error boundaries.
```

**State Management:**
```
Implementa state management para [aplicación] usando [Redux/Vuex/NgRx] que maneje: application state structure, actions/mutations, async operations, middleware configuration y dev tools integration.
```

**Performance Optimization:**
```
Optimiza el performance de [aplicación frontend] enfocándose en: bundle size reduction, lazy loading, image optimization, caching strategies, Core Web Vitals improvement y lighthouse score optimization.
```

### 6.2 Modern Frontend Practices

**Progressive Web App:**
```
Convierte [aplicación] en PWA que incluya: service worker implementation, offline functionality, app manifest, push notifications, installability y performance optimization para mobile devices.
```

**Accessibility Implementation:**
```
Implementa accessibility completa en [componente/página] siguiendo WCAG 2.1 guidelines: semantic HTML, ARIA attributes, keyboard navigation, screen reader compatibility y color contrast compliance.
```

---

## 7. Backend Development

### 7.1 API Development

**RESTful API:**
```
Desarrolla una API RESTful para [dominio] que incluya: resource endpoints, HTTP methods apropiados, status codes, error handling, pagination, filtering, rate limiting y API documentation.
```

**GraphQL Implementation:**
```
Implementa GraphQL API para [aplicación] que incluya: schema definition, resolvers, data loading optimization, subscription support, authentication integration y developer tools setup.
```

**Microservices Architecture:**
```
Diseña arquitectura de microservices para [aplicación] considerando: service boundaries, communication patterns, data consistency, service discovery, circuit breakers y distributed tracing.
```

### 7.2 Data Management

**ORM Configuration:**
```
Configura [ORM específico] para [proyecto] que incluya: entity definitions, relationships mapping, query optimization, connection pooling, migration management y performance monitoring.
```

**Caching Strategy:**
```
Implementa estrategia de caching multicapa para [aplicación] usando [Redis/Memcached] que incluya: cache invalidation, TTL policies, cache warming, monitoring y fallback strategies.
```

**Message Queue Implementation:**
```
Implementa message queue system usando [RabbitMQ/Apache Kafka] para [use case] que maneje: message routing, error handling, dead letter queues, monitoring y scaling considerations.
```

---

## 8. Mobile Development

### 8.1 Native Development

**iOS Development:**
```
Desarrolla [feature] en iOS usando Swift que incluya: UI implementation con Auto Layout, data persistence, networking, error handling, unit tests y adherencia a iOS Human Interface Guidelines.
```

**Android Development:**
```
Implementa [feature] en Android usando Kotlin que incluya: UI con Material Design, architecture components, background processing, local storage, testing y compliance con Android best practices.
```

### 8.2 Cross-Platform Development

**React Native Implementation:**
```
Desarrolla [feature] en React Native que funcione en iOS y Android, incluyendo: platform-specific code cuando necesario, navigation setup, state management, native module integration y performance optimization.
```

**Flutter Development:**
```
Crea [aplicación/feature] en Flutter que incluya: widget composition, state management con [Provider/Bloc], platform channels para native functionality, testing strategy y deployment configuration.
```

---

## 9. Data Science y Machine Learning

### 9.1 Data Processing

**ETL Pipeline:**
```
Desarrolla pipeline ETL para procesar [tipo de datos] que incluya: data extraction de [fuentes], transformation logic, quality validation, error handling, monitoring y scheduling con [herramienta].
```

**Data Analysis:**
```
Analiza [dataset] para identificar [insights específicos] usando Python/R que incluya: exploratory data analysis, statistical analysis, visualization, correlation analysis y recommendations basadas en findings.
```

### 9.2 Machine Learning Implementation

**ML Model Development:**
```
Desarrolla modelo de machine learning para [problema específico] que incluya: data preprocessing, feature engineering, model selection, hyperparameter tuning, cross-validation y performance evaluation metrics.
```

**Model Deployment:**
```
Despliega modelo ML [nombre] a producción que incluya: model serving infrastructure, API endpoints, monitoring de model drift, A/B testing capability y rollback strategy.
```

---

## 10. Debugging y Troubleshooting

### 10.1 Debugging Strategies

**Bug Investigation:**
```
Investiga este bug [descripción] que ocurre en [entorno] con síntomas [síntomas]. Desarrolla plan de debugging que incluya: hypothesis formation, logging analysis, reproduction steps, root cause analysis y fix verification.
```

**Performance Debugging:**
```
Debug performance issue en [aplicación] donde [métrica específica] está degradada. Incluye: profiling setup, bottleneck identification, resource utilization analysis, optimization proposals y impact measurement.
```

**Production Issue Resolution:**
```
Resuelve este issue crítico en producción [descripción] que afecta [número] usuarios. Incluye: immediate mitigation, root cause analysis, permanent fix, post-mortem documentation y prevention measures.
```

### 10.2 Monitoring y Alerting

**Custom Metrics:**
```
Implementa métricas custom para [aplicación] que monitoreen [KPIs específicos]. Incluye: metric collection, aggregation logic, alerting thresholds, dashboard visualization y SLA tracking.
```

**Incident Response:**
```
Desarrolla playbook de incident response para [tipo de incident] que incluya: detection criteria, escalation procedures, communication templates, resolution steps y post-incident review process.
```

---

## 11. Colaboración y Documentación

### 11.1 Technical Documentation

**API Documentation:**
```
Crea documentación completa para [API] que incluya: endpoint descriptions, request/response examples, authentication guide, error codes reference, SDKs/client libraries y interactive documentation.
```

**Code Documentation:**
```
Documenta [módulo/clase] con: overview del propósito, parameter descriptions, usage examples, edge cases, dependencies y maintenance notes. Sigue standards de [lenguaje específico].
```

**Architecture Documentation:**
```
Documenta la arquitectura de [sistema] incluyendo: system overview, component diagrams, data flow, integration points, deployment architecture y decision rationale usando C4 model.
```

### 11.2 Knowledge Sharing

**Technical Blog Post:**
```
Escribe blog post técnico sobre [tecnología/problema resuelto] que incluya: problem context, solution approach, implementation details, lessons learned, code examples y references adicionales.
```

**Team Knowledge Transfer:**
```
Prepara sesión de knowledge transfer sobre [tecnología/sistema] para el equipo que incluya: conceptos clave, hands-on examples, best practices, common pitfalls y Q&A preparation.
```

---

## 12. Consejos para Maximizar Efectividad

### 12.1 Personalización por Stack Tecnológico
- **Frontend:** React, Vue, Angular, vanilla JS
- **Backend:** Node.js, Python, Java, .NET, Go, Rust
- **Mobile:** iOS (Swift), Android (Kotlin), React Native, Flutter
- **DevOps:** AWS, Azure, GCP, Docker, Kubernetes
- **Database:** SQL (PostgreSQL, MySQL), NoSQL (MongoDB, Redis)

### 12.2 Adaptación por Nivel de Experiencia
- **Junior Developer:** Enfócate en syntax, basic patterns, testing
- **Mid-level:** Architecture decisions, optimization, debugging
- **Senior:** System design, mentoring, technical leadership
- **Tech Lead:** Cross-team coordination, technical strategy

### 12.3 Contexto de Proyecto
- **Startup:** Rapid prototyping, MVP development, scalability
- **Enterprise:** Security compliance, documentation, maintenance
- **Open Source:** Community guidelines, contribution process
- **Legacy Systems:** Migration strategies, backward compatibility

### 12.4 Mejores Prácticas para Prompts
- **Sea específico:** Incluya tecnologías, versiones, constrains
- **Proporcione contexto:** Ambiente, team size, timeline
- **Defina criterios:** Performance, security, maintainability
- **Itere y refine:** Ajuste prompts basándose en resultados

---

## Ejemplos de Prompts Contextualizados

### **E-commerce Platform (React + Node.js):**
```
Implementa carrito de compras en React con Redux que incluya: add/remove items, quantity updates, price calculations, persistence en localStorage, checkout flow integration y optimistic updates para mejor UX.
```

### **Banking API (Java Spring Boot):**
```
Desarrolla API de transferencias bancarias que cumpla con PCI DSS incluyendo: validación de cuentas, limits checking, transaction logging, fraud detection integration, idempotency handling y audit trail completo.
```

### **IoT Data Processing (Python):**
```
Crea pipeline de procesamiento para datos de sensores IoT que maneje: 1M+ messages/hora, data validation, anomaly detection, time-series storage en InfluxDB, alerting rules y real-time dashboards.
```

---

## Conclusión

Esta guía proporciona prompts específicos para cubrir todas las actividades principales del desarrollo de software moderno. La clave del éxito está en:

1. **Adaptar prompts** a su stack tecnológico específico
2. **Iterar y refinar** basándose en resultados obtenidos
3. **Combinar prompts** para problemas complejos
4. **Mantener focus** en calidad, performance y maintainability
5. **Documentar y compartir** prompts exitosos con el equipo

El desarrollo de software es un campo en constante evolución, por lo que estos prompts deben adaptarse continuamente a nuevas tecnologías, frameworks y best practices de la industria.