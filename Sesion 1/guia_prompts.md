# Guía Completa de Prompting para Desarrolladores de Software

## Introducción

La ingeniería de prompts es una habilidad esencial para desarrolladores que trabajan con IA. Un prompt bien estructurado puede ser la diferencia entre obtener código funcional o perder tiempo con respuestas imprecisas.

## Principios Fundamentales

### 1. Claridad y Especificidad

**❌ Prompt vago:**
```
"Ayúdame con mi API"
```

**✅ Prompt específico:**
```
"Necesito crear una API REST en Node.js con Express que maneje autenticación JWT, 
tenga endpoints para CRUD de usuarios, y use MongoDB como base de datos. 
Incluye validación de datos con Joi y manejo de errores."
```

### 2. Contexto Técnico

Siempre proporciona:
- Lenguaje de programación
- Framework/librerías específicas
- Versiones si son relevantes
- Arquitectura del proyecto
- Restricciones técnicas

**Ejemplo:**

```
"Usando React 18 con TypeScript y Tailwind CSS, crea un componente de formulario 
de registro que valide email, contraseña (mínimo 8 caracteres, al menos una 
mayúscula y un número) y confirme la contraseña. Usa React Hook Form para el 
manejo del estado."
```

## Estructura de un Prompt Efectivo

### Plantilla Base:
```
[Objetivo] + [Contexto] + [Restricciones] + [FORMATO DE SALIDA]
```

### Ejemplo Aplicado:
```
**Objetivo:** Estoy desarrollando una aplicación de e-commerce en Django 4.2 con PostgreSQL.

**Contexto:** Necesito implementar un sistema de carrito de compras.

**Restricciones:**
- Modelos para Product, Cart, CartItem
- Funcionalidad para agregar/quitar productos
- Cálculo de totales con impuestos
- Validación de stock disponible
- API endpoints con Django REST Framework

**Formato:** Proporciona el código completo con comentarios explicativos.
```

## Técnicas Avanzadas de Prompting

### 1. Prompting por Roles

```
"Actúa como un arquitecto de software senior. Diseña la estructura de una 
aplicación de microservicios para un sistema de gestión de inventario. 
Incluye diagramas de arquitectura, patrones de diseño recomendados, y 
tecnologías específicas para cada servicio."
```

### 2. Prompting Paso a Paso

```
"Explícame cómo implementar autenticación OAuth2 en una aplicación Flask:

1. Primero explica la teoría básica de OAuth2
2. Lista las dependencias necesarias
3. Muestra la configuración inicial
4. Implementa el flujo de autorización
5. Crea middleware para proteger rutas
6. Incluye ejemplos de testing"
```

### 3. Prompting con Ejemplos (Few-Shot)

```
"Convierte estas funciones JavaScript a TypeScript con tipado estricto:

Ejemplo de entrada:
function calculateDiscount(price, percentage) {
    return price * (percentage / 100);
}

Ejemplo de salida:
function calculateDiscount(price: number, percentage: number): number {
    return price * (percentage / 100);
}

Ahora convierte estas funciones:
[tu código aquí]"
```

## Prompts Especializados por Área

### Debugging y Resolución de Problemas

```
"Tengo este error en mi aplicación React:

**Error:** TypeError: Cannot read property 'map' of undefined

**Código problemático:**
[incluir código]

**Contexto:** Los datos vienen de una API externa que a veces demora en responder.

**Necesito:** 
1. Explicación del error
2. Múltiples soluciones posibles
3. Mejores prácticas para evitarlo en el futuro
4. Código corregido con manejo de loading states"
```

### Optimización de Rendimiento

```
"Analiza este componente React y sugiere optimizaciones de rendimiento:

[código del componente]

**Métricas actuales:**
- Tiempo de render: 150ms
- Re-renders innecesarios: 5-8 por interacción
- Bundle size impact: 50KB

**Objetivos:**
- Reducir tiempo de render bajo 50ms
- Minimizar re-renders
- Implementar lazy loading donde sea apropiado

Proporciona código optimizado con explicaciones detalladas de cada mejora."
```

### Arquitectura y Patrones de Diseño

```
"Diseña la arquitectura para un sistema de chat en tiempo real:

**Requisitos funcionales:**
- 10,000 usuarios concurrentes
- Mensajes de texto, imágenes, archivos
- Salas públicas y privadas
- Historial de mensajes persistente

**Requisitos técnicos:**
- Stack: Node.js, Socket.io, Redis, MongoDB
- Escalabilidad horizontal
- Alta disponibilidad (99.9% uptime)

**Entregables:**
1. Diagrama de arquitectura
2. Esquema de base de datos
3. API design
4. Estrategia de deployment
5. Código de ejemplo para componentes críticos"
```

## Prompts para Testing

### Testing Unitario

```
"Genera tests unitarios completos para esta función:

[código de la función]

**Framework:** Jest con Testing Library (React)
**Cobertura requerida:** 100%
**Casos a testear:**
- Happy path
- Edge cases
- Error handling
- Mocking de dependencias externas

Incluye setup, teardown y utilidades de test helpers si son necesarias."
```

### Testing de Integración

```
"Crea tests de integración para esta API:

**Endpoints a testear:**
- POST /api/users (crear usuario)
- GET /api/users/:id (obtener usuario)
- PUT /api/users/:id (actualizar usuario)
- DELETE /api/users/:id (eliminar usuario)

**Requisitos:**
- Usar Supertest con Jest
- Base de datos de test independiente
- Tests de autenticación/autorización
- Validación de esquemas de respuesta
- Cleanup automático entre tests"
```

## Prompts para DevOps y Deployment

### Containerización

```
"Crea una configuración completa de Docker para esta aplicación:

**Stack:** 
- Frontend: React (build estático)
- Backend: Express.js API
- Base de datos: PostgreSQL
- Cache: Redis

**Requisitos:**
- Multi-stage builds para optimización
- Docker Compose para desarrollo local
- Health checks para todos los servicios
- Volúmenes persistentes para datos
- Variables de entorno seguras
- Configuración para producción y desarrollo"
```

### CI/CD Pipeline

```
"Diseña un pipeline de CI/CD para GitHub Actions:

**Aplicación:** API Node.js con frontend React
**Deployment target:** AWS ECS

**Pipeline debe incluir:**
1. Testing automatizado (unit + integration)
2. Linting y code quality checks
3. Security scanning
4. Build y push de imágenes Docker
5. Deployment automático a staging
6. Deployment manual a producción con approval
7. Rollback strategy

Proporciona el archivo .github/workflows/ci-cd.yml completo."
```

## Mejores Prácticas

### ✅ DO:

- **Se específico con versiones:** "React 18.2" en lugar de "React"
- **Incluye restricciones:** presupuesto de bundle, requisitos de performance
- **Proporciona contexto del proyecto:** tipo de aplicación, audiencia, escala
- **Especifica el formato de salida:** "código completo", "solo la función", "paso a paso"
- **Incluye criterios de éxito:** métricas, objetivos de rendimiento

### ❌ DON'T:
- Usar términos ambiguos como "mejor práctica" sin contexto
- Omitir información sobre el stack tecnológico
- Pedir "cualquier solución" sin especificar preferencias
- Ignorar restricciones del proyecto (tiempo, recursos, equipo)


## Plantillas Reutilizables

### Plantilla para Nuevas Features

```
**Contexto del Proyecto:** [descripción breve del proyecto y stack]

**Feature Solicitada:** [descripción detallada de la funcionalidad]

**Criterios de Aceptación:**
- [ ] [criterio 1]
- [ ] [criterio 2]
- [ ] [criterio 3]

**Restricciones Técnicas:**
- [restricción 1]
- [restricción 2]

**Entregables Esperados:**
1. [código/documentación/tests]
2. [instrucciones de deployment]
3. [documentación para el equipo]
```

### Plantilla para Code Review

```
**Código a Revisar:**
[incluir código]

**Contexto:** [propósito del código, parte del sistema que afecta]

**Criterios de Review:**
- Funcionalidad y correctness
- Performance y optimización
- Seguridad
- Mantenibilidad y legibilidad
- Adherencia a patrones del proyecto
- Testing coverage

**Formato de Respuesta:**
- Issues críticos (deben corregirse)
- Sugerencias de mejora
- Aspectos positivos del código
- Código refactorizado (si aplica)
```


## Ejercicios Prácticos

### Ejercicio 1: Refinando Prompts
Convierte este prompt vago en uno específico y efectivo:
```
"Ayúdame a hacer una base de datos para mi app"
```

### Ejercicio 2: Prompt Multi-paso
Crea un prompt que solicite la implementación de autenticación en una aplicación, incluyendo todos los pasos desde el diseño hasta el testing.

### Ejercicio 3: Debugging Colaborativo
Diseña un prompt para resolver un bug complejo, incluyendo toda la información necesaria para que la IA pueda ayudar efectivamente.

## Recursos Adicionales

- **Documentación oficial:** Consulta siempre la documentación de las tecnologías específicas
- **Comunidades:** Stack Overflow, GitHub Discussions, Discord de tecnologías específicas
- **Herramientas:** Usa IDEs con autocompletado y linters para validar el código generado
- **Testing:** Siempre valida el código generado en tu entorno de desarrollo

---

## Conclusión

La maestría en prompting viene con la práctica. Comienza con prompts simples y específicos, luego evoluciona hacia técnicas más avanzadas. Recuerda que un buen prompt es una inversión en tiempo que se paga con código de mejor calidad y soluciones más precisas.

**Próximos pasos:**
1. Practica con los ejemplos de esta guía
2. Adapta las plantillas a tu stack tecnológico
3. Experimenta con diferentes técnicas de prompting
4. Documenta los prompts que te funcionen mejor para reutilizarlos