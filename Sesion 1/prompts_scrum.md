# Guía de Prompts para Seguimiento y Tareas Comunes de Scrum

## Introducción
Esta guía especializada proporciona prompts específicos para equipos Scrum, organizados por roles, eventos y artefactos del framework. Cada prompt está diseñado para optimizar la productividad, transparencia y mejora continua en el desarrollo ágil.

---

## 1. Artefactos de Scrum

### 1.1 Product Backlog

**Creación de User Stories:**
```
Redacta una user story para [funcionalidad específica] siguiendo el formato "Como [tipo de usuario], quiero [funcionalidad] para [beneficio/valor]". Incluye criterios de aceptación específicos, definición de done, estimación en story points y dependencias identificadas.
```

**Refinamiento del Backlog:**
```
Refina estos 5 elementos del product backlog para [producto]: [lista de items]. Para cada uno, define: criterios de aceptación claros, estimación actualizada, prioridad relativa, riesgos técnicos y valor de negocio cuantificado.
```

**Priorización del Backlog:**
```
Prioriza estos elementos del product backlog usando el framework [MoSCoW/Value vs Effort/RICE]: [lista de features]. Considera: valor de negocio, esfuerzo técnico, dependencias, feedback de usuarios y objetivos del roadmap para Q[X].
```

**Epic Breakdown:**
```
Descompone la épica "[nombre de épica]" en user stories específicas para el sprint planning. Cada story debe ser: independiente, negociable, valiosa, estimable, pequeña y testeable (criterios INVEST), con estimación entre 1-8 story points.
```

### 1.2 Sprint Backlog

**Planning de Sprint:**
```
Planifica el Sprint [número] para el equipo [nombre] con capacity de [número] story points. Selecciona user stories del product backlog que: cumplan la definición de ready, aporten al sprint goal, respeten la velocidad del equipo y permitan un incremento potencialmente entregable.
```

**Descomposición en Tareas:**
```
Descompone la user story "[título]" en tareas técnicas específicas de máximo 8 horas cada una. Incluye: tasks de desarrollo, testing, code review, documentación, deployment y criterios de done para cada tarea.
```

**Estimación de Esfuerzo:**
```
Facilita una sesión de planning poker para estimar estas user stories: [lista]. Proporciona: contexto técnico, criterios de aceptación, definición de done, complejidad esperada y referencias de stories similares ya completadas.
```

### 1.3 Incremento del Producto

**Definición de Done:**
```
Actualiza la definición de done para [producto/equipo] considerando: estándares de código, cobertura de tests mínima [%], criterios de performance, revisiones de seguridad, documentación requerida y proceso de deployment a [ambiente].
```

**Criterios de Release:**
```
Define los criterios para el release [versión] del [producto] que incluya: features completadas, bugs críticos resueltos, performance benchmarks, tests de regresión, documentación de usuario y plan de rollback validado.
```

---

## 2. Eventos de Scrum

### 2.1 Sprint Planning

**Preparación del Sprint Planning:**
```
Prepara la agenda para el sprint planning del Sprint [número] de [duración]. Incluye: revisión del product backlog refinado, definición del sprint goal, capacity planning del equipo, identificación de dependencies y definición de success criteria.
```

**Sprint Goal Definition:**
```
Define un sprint goal claro y conciso para el Sprint [número] que: aporte valor medible al usuario, sea alcanzable con el equipo actual, esté alineado con los objetivos del producto y permita tomar decisiones durante el sprint.
```

**Capacity Planning:**
```
Calcula la capacity del equipo para el Sprint [número] considerando: [número] developers disponibles, holidays/vacaciones planificadas, meetings recurrentes, support tasks estimadas y velocity promedio de últimos [número] sprints.
```

### 2.2 Daily Scrum

**Template Daily Standup:**
```
Crea un template estructurado para el daily scrum que incluya: progreso desde ayer, plan para hoy, impedimentos identificados, apoyo necesario del equipo, actualización de tasks en [herramienta] y riesgos para el sprint goal.
```

**Seguimiento de Impedimentos:**
```
Documenta y da seguimiento a estos impedimentos del daily scrum: [lista]. Para cada uno incluye: descripción del problema, impacto en el sprint, acciones tomadas, responsable de resolución, timeline esperado y escalación si es necesaria.
```

**Burndown Analysis:**
```
Analiza el burndown chart del Sprint [número] en el día [X]. Evalúa: progreso vs. trend ideal, work remaining, impedimentos que afectan velocity, proyección de completion y acciones correctivas recomendadas.
```

### 2.3 Sprint Review

**Preparación del Sprint Review:**
```
Prepara la demo del Sprint [número] para stakeholders que incluya: features completadas vs. sprint goal, demo de funcionalidades working, métricas de valor entregado, feedback collected y próximos pasos en el product backlog.
```

**Demo Script:**
```
Crea un script de demo para el Sprint Review que muestre [funcionalidad] en [duración] minutos. Incluye: contexto del problema resuelto, walkthrough de la solución, datos de impacto/métricas, limitaciones conocidas y solicitud de feedback específico.
```

**Stakeholder Feedback Collection:**
```
Diseña un mecanismo para capturar feedback efectivo en el Sprint Review sobre [features demostradas]. Incluye: preguntas específicas, escala de satisfacción, sugerencias de mejora, priorización de next features y validación de product assumptions.
```

### 2.4 Sprint Retrospective

**Facilitación de Retrospectivas:**
```
Facilita una retrospectiva para el Sprint [número] usando la técnica [Start/Stop/Continue, Sailboat, 4Ls]. Enfócate en: qué funcionó bien, qué mejorar, impedimientos sistémicos, acciones específicas con owner y timeline, y follow-up de retrospectiva anterior.
```

**Análisis de Métricas del Sprint:**
```
Analiza las métricas del Sprint [número]: velocity [número], commitment vs completion [%], cycle time promedio, defect rate, team happiness [escala]. Identifica tendencias, causas raíz de variaciones y oportunidades de mejora.
```

**Action Items de Retrospectiva:**
```
Convierte estos insights de retrospectiva en action items específicos: [lista de insights]. Cada acción debe tener: descripción clara, owner asignado, timeline definido, criterios de éxito y método de seguimiento.
```

---

## 3. Roles de Scrum

### 3.1 Product Owner

**Product Roadmap Planning:**
```
Desarrolla un product roadmap trimestral que alinee el backlog con: objetivos de negocio para Q[X], user feedback prioritario, technical debt crítico, dependencies con otros equipos y métricas de éxito por release.
```

**Stakeholder Communication:**
```
Redacta una comunicación para stakeholders sobre el progreso del [producto] que incluya: features completadas este sprint, valor entregado medible, próximos releases planificados, decisiones de priorización tomadas y solicitudes de input para planning.
```

**User Acceptance Criteria:**
```
Define criterios de aceptación detallados para la user story "[título]" que incluyan: happy path scenarios, edge cases identificados, criterios de performance, validaciones de business rules y integration points con sistemas existentes.
```

**ROI Analysis:**
```
Analiza el ROI de implementar [feature] vs. alternativas en el backlog. Considera: costo de desarrollo estimado, impacto en métricas clave, time to market, user adoption esperada y alignment con product strategy.
```

### 3.2 Scrum Master

**Coaching del Equipo:**
```
Desarrolla un plan de coaching para mejorar [área específica: velocity, quality, collaboration] del equipo. Incluye: assessment actual, objetivos específicos, actividades de desarrollo, métricas de progreso y timeline de evaluación.
```

**Facilitación de Conflictos:**
```
Facilita la resolución del conflicto entre [miembros del equipo] sobre [tema específico]. Estructura: sesión de escucha activa, identificación de intereses comunes, opciones de solución, acuerdo de trabajo y seguimiento de cumplimiento.
```

**Mejora de Procesos:**
```
Analiza la efectividad de nuestros eventos Scrum y propón mejoras específicas para: duración de meetings, participation level, value delivered, action items follow-up y team satisfaction con los ceremoniales.
```

**Eliminación de Impedimentos:**
```
Crea un plan de acción para eliminar el impedimento sistémico "[descripción]" que incluya: análisis de causa raíz, stakeholders involucrados, opciones de solución, timeline de implementación y métricas para validar resolución.
```

### 3.3 Development Team

**Technical Debt Management:**
```
Evalúa el technical debt actual en [componente/módulo] y propón un plan de refactoring que incluya: areas críticas identificadas, impacto en velocity, effort estimation, priorización vs. new features y plan de implementación por sprints.
```

**Code Review Guidelines:**
```
Establece guidelines de code review para el equipo que incluyan: criterios técnicos obligatorios, standards de documentación, performance considerations, security checks y process para resolving review comments.
```

**Definition of Ready:**
```
Define criterios de "ready" para user stories antes del sprint planning: acceptance criteria definidos, dependencies resueltas, technical approach clarificado, estimación completada y validation con Product Owner realizada.
```

**Testing Strategy:**
```
Desarrolla una estrategia de testing para [feature/sprint] que incluya: unit tests coverage mínima [%], integration tests necesarios, manual testing scenarios, performance testing criteria y acceptance testing process.
```

---

## 4. Métricas y Reporting

### 4.1 Métricas de Equipo

**Velocity Tracking:**
```
Analiza la velocity del equipo durante los últimos [número] sprints: [datos]. Identifica: tendencias y patrones, factores que impactan variabilidad, capacity vs. commitment accuracy y recomendaciones para planning futuro.
```

**Burndown Analysis:**
```
Interpreta el burndown chart del Sprint [número] que muestra [descripción del patrón]. Evalúa: health del sprint, riesgos para el sprint goal, necesidad de scope adjustment y lessons learned para próximos sprints.
```

**Cycle Time Optimization:**
```
Analiza el cycle time de user stories en los últimos [período] y propón optimizaciones para: reducir time in development, acelerar code review process, mejorar testing efficiency y streamline deployment pipeline.
```

### 4.2 Métricas de Calidad

**Defect Rate Analysis:**
```
Evalúa la tasa de defectos del último release: [número] bugs encontrados de [total] story points entregados. Analiza: tipos de defectos más comunes, root causes identificadas, impacto en user experience y plan de mejora de calidad.
```

**Test Coverage Monitoring:**
```
Revisa la cobertura de tests actual: [%] unit tests, [%] integration tests. Identifica: áreas críticas sin cobertura, gaps en testing strategy, ROI de incrementar coverage y plan para alcanzar target de [%].
```

### 4.3 Métricas de Valor

**Business Value Delivery:**
```
Mide el valor de negocio entregado en el Sprint [número] usando métricas: [user engagement, conversion rate, customer satisfaction]. Compara con objetivos, identifica success stories y áreas para optimizar value delivery.
```

**User Adoption Tracking:**
```
Analiza la adopción de features lanzadas en los últimos [período]: [datos de usage]. Evalúa: adoption rate vs. expectations, user feedback patterns, feature success metrics y decisiones para product backlog.
```

---

## 5. Gestión de Dependencias y Scaling

### 5.1 Coordinación entre Equipos

**Scrum of Scrums:**
```
Prepara el reporte para Scrum of Scrums del equipo [nombre] que incluya: progreso del sprint actual, dependencies con otros equipos, impedimentos que requieren coordinación, upcoming integrations y support needed from other teams.
```

**Cross-team Dependencies:**
```
Gestiona la dependencia entre [equipo A] y [equipo B] para [deliverable específico]. Define: interface agreements, timeline coordination, communication protocol, risk mitigation y escalation path si hay delays.
```

### 5.2 Program Level Planning

**PI Planning Preparation:**
```
Prepara el team readiness para PI Planning incluyendo: capacity planning para [número] sprints, backlog refinement status, architectural dependencies identificadas, team composition changes y commitment confidence level.
```

**Release Train Coordination:**
```
Coordina la participación del equipo en el Agile Release Train para [release]. Incluye: features committed, integration points, shared components dependencies, testing coordination y go-live readiness criteria.
```

---

## 6. Herramientas y Automatización

### 6.1 Jira/Azure DevOps Management

**Board Configuration:**
```
Configura el Scrum board en [herramienta] para optimizar workflow del equipo. Define: columns del board, WIP limits apropiados, automation rules, reporting dashboards y integration con development tools.
```

**Sprint Automation:**
```
Configura automatizaciones en [herramienta] para: auto-assign tasks based on expertise, update status when PR merged, generate burndown reports, notify on impediments y create release notes automáticamente.
```

### 6.2 CI/CD Integration

**Pipeline Optimization:**
```
Optimiza el CI/CD pipeline para support frequent deployments: reduce build time de [tiempo actual] a [target], implement automated testing, configure deployment environments y establish rollback procedures.
```

**Quality Gates:**
```
Define quality gates en el pipeline que incluyan: code coverage threshold [%], security scan results, performance benchmarks, automated test success rate y manual approval criteria para production deployment.
```

---

## 7. Resolución de Problemas Comunes

### 7.1 Sprint Planning Issues

**Scope Creep Management:**
```
El sprint [número] está experimentando scope creep con [descripción]. Evalúa: impact on sprint goal, options para scope adjustment, communication strategy con stakeholders y prevention measures para futuros sprints.
```

**Under/Over Commitment:**
```
El equipo consistentemente [over/under] commits en sprint planning. Analiza: patterns en estimation accuracy, factors affecting velocity, team capacity reality y recommendations para improved planning.
```

### 7.2 Team Dynamics

**Low Participation in Ceremonies:**
```
Algunos team members muestran baja participación en [daily/retro/planning]. Identifica: possible root causes, impact on team effectiveness, strategies para increase engagement y follow-up actions específicas.
```

**Knowledge Silos:**
```
Hay knowledge silos en [área técnica/dominio] que impactan team flexibility. Desarrolla: knowledge sharing plan, pairing/mentoring strategy, documentation improvements y cross-training roadmap.
```

---

## 8. Mejora Continua

### 8.1 Retrospective Techniques

**Innovation Time:**
```
Propón un programa de innovation time (20%) para el equipo que incluya: guidelines para project selection, time allocation per sprint, demo sessions structure, success metrics y integration con regular work.
```

**Experiment Framework:**
```
Diseña un experimento para mejorar [aspecto específico] durante [duración]. Define: hypothesis a validar, success metrics, implementation plan, data collection method y decision criteria para continue/stop.
```

### 8.2 Skills Development

**Team Skills Matrix:**
```
Crea una skills matrix para el equipo identificando: technical competencies actuales, gaps críticos, learning paths recomendados, mentoring opportunities y timeline para skill development goals.
```

**Cross-functional Training:**
```
Desarrolla un plan de cross-functional training para que team members puedan: contribute across different areas, reduce bottlenecks, improve collaboration, share domain knowledge y increase team resilience.
```

---

## 9. Comunicación y Stakeholder Management

### 9.1 Executive Reporting

**Sprint Summary for Leadership:**
```
Crea un executive summary del Sprint [número] en formato de 1 página que incluya: key accomplishments, business value delivered, metrics dashboard, upcoming milestones y escalations needed from leadership.
```

**Quarterly Business Review:**
```
Prepara una presentación de QBR para el [producto] que muestre: features delivered vs. roadmap, user adoption metrics, team productivity trends, technical health indicators y strategic recommendations.
```

### 9.2 Customer Communication

**Release Notes:**
```
Redacta release notes user-friendly para [versión] que incluyan: new features con screenshots, improvements realizadas, bug fixes importantes, known limitations y next release preview.
```

**Customer Feedback Integration:**
```
Analiza el customer feedback de [fuente] e integra insights en el product backlog: feature requests prioritarios, usability issues identificados, satisfaction scores y recommended backlog adjustments.
```

---

## 10. Consejos para Maximizar Efectividad

### 10.1 Personalización por Contexto
- **Tamaño del equipo:** Adapte ceremonies para equipos de 3-9 personas
- **Madurez Agile:** Simplifique para equipos nuevos, profundice para experimentados
- **Dominio del producto:** Use ejemplos relevantes a su industria
- **Herramientas disponibles:** Adapte prompts a su tech stack

### 10.2 Integración con Frameworks
- **SAFe:** Incluya elementos de PI Planning y ART coordination
- **LeSS:** Adapte para multiple teams, single product backlog
- **Nexus:** Enfoque en integration y dependencies management
- **Spotify Model:** Incluya tribe/squad/chapter dynamics

### 10.3 Métricas Actionables
- Use métricas que driving behavior changes
- Combine leading y lagging indicators
- Focus en trends más que números absolutos
- Conecte métricas de equipo con business outcomes

---

## Conclusión

Esta guía proporciona prompts específicos para cada aspecto del framework Scrum, desde ceremonials básicos hasta scaling avanzado. La clave está en adaptar estos prompts a su contexto específico, iterando basándose en los resultados obtenidos y manteniendo el focus en la entrega continua de valor al usuario.

**Para mejores resultados:**
- Comience con prompts básicos y agregue complejidad gradualmente
- Adapte el lenguaje a su team culture
- Combine múltiples prompts para situaciones complejas
- Mantenga focus en outcomes sobre outputs
- Use data para validar y ajustar approaches