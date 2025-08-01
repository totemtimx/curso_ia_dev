
Prompts de .gitlab-ci.yml Inicial

"Crea un archivo .gitlab-ci.yml básico para una aplicación Node.js que incluya las etapas de build, test y deploy con runners compartidos de GitLab."

"Genera un pipeline GitLab CI que use la imagen oficial de Node.js 18-alpine y ejecute npm install, npm test y npm run build en etapas separadas."

"Diseña un .gitlab-ci.yml que solo se ejecute cuando hay cambios en archivos específicos usando rules y changes, excluyendo README.md y archivos de documentación."
Prompts de Configuración de Stages

"Implementa un pipeline GitLab con 5 etapas: validate, build, test, security-scan y deploy, definiendo dependencias entre etapas y artefactos compartidos."

"Crea un pipeline que use jobs paralelos en la etapa de testing para ejecutar unit tests, integration tests y linting simultáneamente."
Módulo 2: Variables y Secretos en GitLab
Prompts de Gestión de Variables

"Configura variables de entorno en GitLab CI para manejar diferentes configuraciones por entorno (development, staging, production) usando variables de grupo y proyecto."

"Crea un pipeline que use variables protegidas de GitLab para API keys y tokens, mostrando cómo enmascarar información sensible en los logs."

"Implementa un sistema de variables dinámicas que se generen basadas en el nombre de la rama y el timestamp del commit."
Prompts de Integración con HashiCorp Vault

"Integra GitLab CI con HashiCorp Vault para obtener secretos dinámicamente durante la ejecución del pipeline usando JWT authentication."

"Diseña un job que obtenga credenciales de base de datos desde Vault y las use para ejecutar migraciones durante el deployment."
Módulo 3: Dockerización en GitLab CI
Prompts de Container Registry

"Crea un pipeline que construya una imagen Docker, la almacene en GitLab Container Registry y use semantic versioning basado en git tags."

"Implementa un job que construya imágenes multi-arquitectura (amd64, arm64) usando docker buildx y las publique en el registry de GitLab."

"Diseña un pipeline que use Docker-in-Docker (dind) para construir y probar imágenes Docker de forma segura."
Prompts de Optimización de Imágenes

"Desarrolla un job que optimice imágenes Docker usando multi-stage builds y analice el tamaño de la imagen final con dive o similar."

"Crea un pipeline que use cache de layers de Docker en GitLab para acelerar builds consecutivos de la misma imagen."
Módulo 4: Testing Avanzado en GitLab
Prompts de Coverage y Reporting

"Implementa un pipeline que genere reportes de cobertura de código usando Jest y los publique como GitLab Pages, mostrando trending histórico."

"Crea jobs de testing que generen reportes JUnit XML y los integren con la interfaz de merge requests de GitLab."

"Diseña un pipeline que ejecute pruebas de mutación usando Stryker y bloquee el merge si la cobertura de mutación está por debajo del 80%."
Prompts de Testing de Performance

"Integra k6 en GitLab CI para ejecutar pruebas de carga automáticas y publicar métricas de performance en GitLab Pages."

"Crea un job que ejecute Lighthouse CI para auditar performance web y genere badges dinámicos con los scores."
Módulo 5: Security Scanning en GitLab
Prompts de SAST y DAST

"Implementa GitLab SAST (Static Application Security Testing) en el pipeline con reglas customizadas y umbrales de vulnerabilidades."

"Configura DAST (Dynamic Application Security Testing) para escanear automáticamente la aplicación desplegada en staging."

"Crea un pipeline que use Dependency Scanning para detectar vulnerabilidades en dependencias NPM y genere reportes de seguridad."
Prompts de Container Scanning

"Integra Container Scanning de GitLab para analizar vulnerabilidades en imágenes Docker antes del deployment."

"Implementa Secret Detection para prevenir que credenciales y tokens se commiteen accidentalmente al repositorio."
Módulo 6: GitLab Environments y Deployments
Prompts de Environments

"Configura múltiples environments en GitLab (review, staging, production) con URLs específicas y deployment tracking."

"Crea dynamic environments para feature branches que se desplieguen automáticamente y se destruyan al hacer merge."

"Implementa manual deployment gates para producción con notificaciones automáticas a Slack cuando requiera aprobación."
Prompts de Review Apps

"Diseña un sistema de Review Apps que despliegue automáticamente cada merge request a un entorno temporal usando Kubernetes."

"Crea Review Apps que incluyan datos de prueba y se integren con servicios externos usando stubs o mocks."
Módulo 7: Kubernetes y GitLab
Prompts de GitLab Kubernetes Agent

"Configura GitLab Kubernetes Agent para desplegar aplicaciones usando GitOps con manifest files y Helm charts."

"Implementa canary deployments a Kubernetes usando GitLab CI con validación automática de métricas y rollback."

"Crea un pipeline que despliegue a múltiples clusters de Kubernetes (staging y production) usando diferentes configuraciones."
Prompts de Helm Integration

"Integra Helm charts en GitLab CI para desplegar aplicaciones complejas con valores específicos por entorno."

"Desarrolla un pipeline que valide Helm charts usando helm lint y kubectl dry-run antes del deployment."
Módulo 8: GitLab Pages y Documentation
Prompts de Static Sites

"Crea un pipeline que genere documentación con GitBook o VuePress y la publique automáticamente en GitLab Pages."

"Implementa un job que genere un sitio estático con métricas de código (coverage, complexity) y lo publique en Pages."

"Diseña un pipeline que construya una aplicación React y la despliegue a GitLab Pages con routing SPA configurado."
Módulo 9: Monitoring y Notifications
Prompts de Integración con Prometheus

"Integra métricas de GitLab CI con Prometheus para monitorear success rate, duration y frequency de deployments."

"Crea alertas automáticas que notifiquen cuando el pipeline falla consecutivamente más de 3 veces."
Prompts de Notifications

"Configura notificaciones personalizadas a Microsoft Teams que incluyan información detallada del deployment y links directos."

"Implementa un sistema de notifications que envíe diferentes mensajes según el tipo de fallo (build, test, deploy)."
Módulo 10: Casos de Uso Avanzados
Prompts de Monorepo

"Diseña un pipeline para monorepo que detecte cambios por servicio y solo ejecute CI/CD para los servicios modificados."

"Crea un sistema de dependency tracking en monorepo que rebuild servicios dependientes cuando cambian sus dependencies."
Prompts de Multi-Cloud

"Implementa un pipeline que despliegue la misma aplicación a AWS EKS, Google GKE y Azure AKS usando Terraform y GitLab CI."

"Crea un sistema de blue-green deployment cross-cloud con health checks y automatic failover."
Prompts de Optimización y Performance
Prompts de Cache y Speed

"Optimiza un pipeline GitLab CI que tarda 30 minutos usando cache de dependencies, parallelization y job splitting."

"Implementa GitLab CI cache para node_modules, Docker layers y build artifacts con diferentes estrategias por tipo de job."

"Crea un pipeline que use cache distribuido entre runners y implemente cache warming para acelerar builds."
Prompts de Resource Management

"Diseña un sistema de resource allocation que use diferentes tipos de runners según las necesidades del job (CPU, memory, GPU)."

"Implementa job scheduling inteligente que evite ejecutar jobs pesados simultáneamente en el mismo runner."
Proyectos Integrales
Proyecto Completo - Microservicios

"Crea un pipeline completo para una aplicación microservicios que incluya: build de múltiples servicios, testing cruzado, security scanning, deployment a Kubernetes, monitoring post-deploy y rollback automático en caso de fallo."
Proyecto Completo - GitOps

"Implementa un sistema GitOps completo usando GitLab CI que sincronice cambios de infraestructura y aplicación, con approval workflows y audit trails completos."
Proyecto Completo - Enterprise Compliance

"Diseña un pipeline enterprise que cumpla con SOC 2 compliance, incluyendo: segregation of duties, audit logging, encrypted secrets management, approval workflows y disaster recovery procedures."
Prompts de Troubleshooting y Debugging
Debug de Pipelines

"Crea un guide de troubleshooting para los errores más comunes en GitLab CI: runner connectivity, Docker permissions, cache issues y resource limits."

"Implementa logging avanzado en pipelines GitLab CI que facilite el debugging de fallos intermitentes y problemas de networking."
Performance Analysis

"Desarrolla un dashboard que analice métricas de pipeline performance: queue time, execution time, success rate y resource utilization por runner."

"Crea scripts que identifiquen bottlenecks en pipelines complejos y sugieran optimizaciones automáticamente."
Prompts de Best Practices
Security Best Practices

"Genera una checklist de security best practices para GitLab CI/CD que incluya: secret management, image scanning, least privilege access y audit logging."

"Implementa un pipeline que valide automáticamente compliance con security policies antes de permitir deployments a producción."
Maintenance y Governance

"Diseña un sistema de governance para pipelines GitLab CI que incluya: templates estandarizados, policy enforcement y lifecycle management."

"Crea un proceso automatizado de cleanup que elimine artefactos antiguos, imágenes no utilizadas y environments temporales."
