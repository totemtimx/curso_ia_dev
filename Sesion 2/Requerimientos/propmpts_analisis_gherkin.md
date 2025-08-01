# Prompts para Análisis de Requerimientos

## 1. Análisis Funcional

### Prompt para Identificación de Requerimientos Funcionales
```
Analiza el siguiente enunciado Gherkin y extrae todos los requerimientos funcionales. Para cada requerimiento identifica:

1. **ID único** del requerimiento
2. **Descripción** clara y concisa
3. **Actor** principal involucrado
4. **Entrada** esperada del sistema
5. **Procesamiento** requerido
6. **Salida** esperada
7. **Prioridad** (Alta/Media/Baja)
8. **Complejidad estimada** (Simple/Media/Compleja)

Presenta los resultados en formato de tabla estructurada.

[ENUNCIADO GHERKIN AQUÍ]
```

### Prompt para Análisis de Casos de Uso
```
Basándote en los escenarios Gherkin proporcionados, genera un análisis detallado de casos de uso que incluya:

1. **Casos de uso principales** identificados
2. **Actores** y sus roles específicos
3. **Precondiciones** para cada caso de uso
4. **Flujo principal** paso a paso
5. **Flujos alternativos** y excepciones
6. **Postcondiciones** y resultados esperados
7. **Relaciones** entre casos de uso (include, extend)

Utiliza notación UML estándar donde sea aplicable.

[ENUNCIADO GHERKIN AQUÍ]
```

## 2. Análisis No Funcional

### Prompt para Requerimientos de Rendimiento
```
Examina los escenarios Gherkin y extrae todos los requerimientos no funcionales relacionados con:

**RENDIMIENTO:**
- Tiempos de respuesta esperados
- Throughput del sistema
- Capacidad de usuarios concurrentes
- Escalabilidad requerida

**DISPONIBILIDAD:**
- Uptime esperado
- Ventanas de mantenimiento
- Recuperación ante fallos

**SEGURIDAD:**
- Autenticación y autorización
- Protección de datos sensibles
- Auditoría y trazabilidad

Para cada requerimiento, especifica métricas cuantificables y criterios de aceptación.

[ENUNCIADO GHERKIN AQUÍ]
```

### Prompt para Análisis de Usabilidad
```
Analiza los aspectos de experiencia de usuario presentes en los escenarios y identifica:

1. **Flujos de navegación** del usuario
2. **Puntos de fricción** potenciales
3. **Requerimientos de accesibilidad**
4. **Compatibilidad** con dispositivos/navegadores
5. **Internacionalización** necesaria
6. **Feedback** y mensajes al usuario
7. **Ayuda contextual** requerida

Proporciona recomendaciones específicas para mejorar la usabilidad.

[ENUNCIADO GHERKIN AQUÍ]
```

## 3. Análisis Técnico

### Prompt para Arquitectura del Sistema
```
Basándote en los requerimientos funcionales identificados, diseña una propuesta de arquitectura técnica que incluya:

**COMPONENTES DEL SISTEMA:**
- Capa de presentación
- Lógica de negocio
- Capa de datos
- Servicios externos

**TECNOLOGÍAS SUGERIDAS:**
- Frontend framework
- Backend tecnologías
- Base de datos
- APIs y integraciones

**PATRONES DE DISEÑO:**
- Arquitectónicos aplicables
- Patrones de integración
- Manejo de errores

**CONSIDERACIONES DE DEPLOYMENT:**
- Infraestructura requerida
- Estrategia de despliegue
- Monitoreo y logging

[ENUNCIADO GHERKIN AQUÍ]
```

### Prompt para Análisis de Integración
```
Identifica todos los puntos de integración mencionados o implícitos en los escenarios y analiza:

1. **Sistemas externos** a integrar
2. **Tipos de integración** (síncrona/asíncrona, batch/real-time)
3. **Protocolos** de comunicación requeridos
4. **Formatos de datos** (JSON, XML, CSV, etc.)
5. **Manejo de errores** en integraciones
6. **Seguridad** en las comunicaciones
7. **Versionado** de APIs
8. **Estrategias de fallback**

Proporciona un diagrama de integración conceptual.

[ENUNCIADO GHERKIN AQUÍ]
```

## 4. Análisis de Riesgos y Restricciones

### Prompt para Identificación de Riesgos
```
Analiza los escenarios Gherkin e identifica potenciales riesgos del proyecto:

**RIESGOS TÉCNICOS:**
- Complejidad de implementación
- Dependencias externas
- Tecnologías emergentes
- Rendimiento del sistema

**RIESGOS DE NEGOCIO:**
- Cambios en requerimientos
- Disponibilidad de stakeholders
- Restricciones presupuestarias
- Plazos de entrega

**RIESGOS OPERACIONALES:**
- Capacitación de usuarios
- Migración de datos
- Compatibilidad con sistemas legacy
- Mantenimiento a largo plazo

Para cada riesgo, proporciona:
- Probabilidad de ocurrencia (Alta/Media/Baja)
- Impacto potencial (Alto/Medio/Bajo)
- Estrategias de mitigación

[ENUNCIADO GHERKIN AQUÍ]
```

### Prompt para Análisis de Restricciones
```
Identifica y analiza todas las restricciones presentes en los escenarios:

**RESTRICCIONES TÉCNICAS:**
- Tecnologías mandatorias
- Estándares de codificación
- Arquitectura existente
- APIs disponibles

**RESTRICCIONES DE NEGOCIO:**
- Presupuesto disponible
- Cronograma del proyecto
- Recursos humanos
- Políticas corporativas

**RESTRICCIONES REGULATORIAS:**
- Cumplimiento normativo
- Privacidad de datos
- Auditoría requerida
- Certificaciones necesarias

Evalúa el impacto de cada restricción en el diseño de la solución.

[ENUNCIADO GHERKIN AQUÍ]
```

## 5. Análisis de Estimación y Planificación

### Prompt para Estimación de Esfuerzo
```
Basándote en los requerimientos funcionales identificados, proporciona una estimación detallada que incluya:

**DESCOMPOSICIÓN DEL TRABAJO:**
- Épicas principales
- Historias de usuario derivadas
- Tareas técnicas específicas
- Criterios de aceptación por historia

**ESTIMACIÓN POR COMPONENTE:**
- Frontend (horas/story points)
- Backend (horas/story points)
- Base de datos (horas/story points)
- Integración (horas/story points)
- Testing (horas/story points)

**CONSIDERACIONES ADICIONALES:**
- Curva de aprendizaje
- Complejidad técnica
- Dependencias entre tareas
- Buffer para riesgos

Utiliza tanto estimación en horas como en story points.

[ENUNCIADO GHERKIN AQUÍ]
```

### Prompt para Plan de Iteraciones
```
Crea un plan de desarrollo iterativo basado en los escenarios Gherkin:

**DEFINICIÓN DE MVPs:**
- Funcionalidad mínima viable
- Criterios de cada iteración
- Valor de negocio por entrega

**ROADMAP DE DESARROLLO:**
- Sprint 0: Setup y arquitectura
- Sprints 1-N: Funcionalidades por prioridad
- Criterios de "Definition of Done"

**ESTRATEGIA DE TESTING:**
- Testing unitario por sprint
- Testing de integración
- Testing de aceptación
- Testing de rendimiento

**PLAN DE DESPLIEGUE:**
- Ambientes de desarrollo
- Estrategia de releases
- Rollback procedures

[ENUNCIADO GHERKIN AQUÍ]
```

## 6. Análisis de Calidad

### Prompt para Estrategia de Testing
```
Desarrolla una estrategia completa de testing basada en los escenarios Gherkin:

**NIVELES DE TESTING:**
- Unit testing: componentes a cubrir
- Integration testing: puntos de integración
- System testing: escenarios end-to-end
- Acceptance testing: criterios de negocio

**TIPOS DE TESTING:**
- Funcional: casos de prueba principales
- No funcional: rendimiento, seguridad, usabilidad
- Regresión: casos críticos a automatizar
- Exploratorio: áreas de riesgo

**AUTOMATIZACIÓN:**
- Herramientas recomendadas
- Casos prioritarios para automatizar
- Estrategia de CI/CD
- Métricas de cobertura

**GESTIÓN DE DEFECTOS:**
- Clasificación de severidad
- Flujo de resolución
- Criterios de salida por fase

[ENUNCIADO GHERKIN AQUÍ]
```

---