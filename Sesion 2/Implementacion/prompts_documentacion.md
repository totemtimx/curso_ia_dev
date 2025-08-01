## Generación de Docstrings y Comentarios

### Ejemplo 1: Función Sin Documentar

```python

def calculate_compound_interest(principal, rate, time, compound_frequency):
    return principal * (1 + rate / compound_frequency) ** (compound_frequency * time)

def validate_email_list(emails, domain_whitelist=None, check_mx=False):
    valid_emails = []
    invalid_emails = []
    
    for email in emails:
        if '@' not in email:
            invalid_emails.append((email, 'missing_at_symbol'))
            continue
            
        local, domain = email.split('@', 1)
        
        if domain_whitelist and domain not in domain_whitelist:
            invalid_emails.append((email, 'domain_not_whitelisted'))
            continue
            
        if check_mx:
            try:
                mx_records = dns.resolver.resolve(domain, 'MX')
                if not mx_records:
                    invalid_emails.append((email, 'no_mx_record'))
                    continue
            except:
                invalid_emails.append((email, 'dns_lookup_failed'))
                continue
                
        valid_emails.append(email)
    
    return {
        'valid': valid_emails,
        'invalid': invalid_emails,
        'success_rate': len(valid_emails) / len(emails) if emails else 0
    }
```

**Prompt para Documentación Automática:**
```
Actúa como un documentador técnico experto. Analiza el siguiente código Python y genera documentación completa siguiendo el estilo Google/NumPy docstring.

Para cada función, incluye:
1. Descripción clara y concisa del propósito
2. Parámetros con tipos, descripciones y valores por defecto
3. Valor de retorno con tipo y descripción detallada
4. Excepciones que puede lanzar
5. Ejemplos de uso prácticos
6. Notas sobre complejidad temporal/espacial si es relevante
7. Referencias a documentación relacionada

Estilo requerido:
- Usar Google docstring format
- Incluir type hints en el código
- Añadir comentarios inline para lógica compleja
- Generar ejemplos ejecutables

[INSERTAR CÓDIGO]

Además, sugiere mejoras en los nombres de variables o funciones si no son autodescriptivos.
```

### Código Documentado (Ejemplo de respuesta esperada):

```python
from typing import List, Tuple, Dict, Optional, Union
import dns.resolver

def calculate_compound_interest(
    principal: float, 
    rate: float, 
    time: float, 
    compound_frequency: int
) -> float:
    """
    Calcula el interés compuesto usando la fórmula estándar.
    
    Esta función implementa la fórmula: A = P(1 + r/n)^(nt)
    donde A es el monto final, P es el principal, r es la tasa anual,
    n es la frecuencia de capitalización y t es el tiempo en años.
    
    Args:
        principal (float): Monto inicial de dinero invertido. Debe ser > 0.
        rate (float): Tasa de interés anual como decimal (ej: 0.05 para 5%).
                     Debe estar entre 0 y 1.
        time (float): Período de tiempo en años. Debe ser > 0.
        compound_frequency (int): Número de veces que se capitaliza por año.
                                 Valores comunes: 1 (anual), 4 (trimestral), 
                                 12 (mensual), 365 (diario).
    
    Returns:
        float: El monto total después de aplicar interés compuesto.
               Incluye el principal más los intereses ganados.
    
    Raises:
        ValueError: Si algún parámetro es negativo o cero donde no debería serlo.
        TypeError: Si los tipos de entrada no son numéricos.
    
    Examples:
        >>> # Inversión de $1000 al 5% anual, capitalizado mensualmente por 2 años
        >>> calculate_compound_interest(1000, 0.05, 2, 12)
        1104.89
        
        >>> # Inversión simple anual
        >>> calculate_compound_interest(5000, 0.03, 1, 1)
        5150.0
    
    Note:
        Para cálculos financieros precisos, considere usar la biblioteca decimal
        para evitar errores de punto flotante.
        
        Complejidad temporal: O(1)
        Complejidad espacial: O(1)
    
    See Also:
        calculate_simple_interest: Para cálculo de interés simple
        https://docs.python.org/3/library/decimal.html: Para aritmética precisa
    """
    if principal <= 0:
        raise ValueError("El principal debe ser mayor que cero")
    if rate < 0:
        raise ValueError("La tasa de interés no puede ser negativa")
    if time <= 0:
        raise ValueError("El tiempo debe ser mayor que cero")
    if compound_frequency <= 0:
        raise ValueError("La frecuencia de capitalización debe ser mayor que cero")
    
    return principal * (1 + rate / compound_frequency) ** (compound_frequency * time)


def validate_email_list(
    emails: List[str], 
    domain_whitelist: Optional[List[str]] = None,
    check_mx: bool = False
) -> Dict[str, Union[List[str], List[Tuple[str, str]], float]]:
    """
    Valida una lista de direcciones de email con múltiples criterios.
    
    Realiza validación básica de formato y opcionalmente verifica dominios
    contra una lista blanca y la existencia de registros MX.
    
    Args:
        emails (List[str]): Lista de direcciones de email a validar.
                           Puede estar vacía.
        domain_whitelist (Optional[List[str]], optional): Lista de dominios 
                                                        permitidos. Si se proporciona, solo emails
                                                        de estos dominios serán considerados válidos.
                                                        Defaults to None.
        check_mx (bool, optional): Si True, verifica la existencia de registros MX
                                  para cada dominio. Requiere conexión a internet.
                                  Defaults to False.
    
    Returns:
        Dict[str, Union[List[str], List[Tuple[str, str]], float]]: Diccionario con:
            - 'valid' (List[str]): Emails que pasaron todas las validaciones
            - 'invalid' (List[Tuple[str, str]]): Tuplas de (email, razón_error)
            - 'success_rate' (float): Porcentaje de emails válidos (0.0 - 1.0)
    
    Raises:
        ImportError: Si check_mx=True pero dnspython no está instalado.
        
    Examples:
        >>> emails = ['user@example.com', 'invalid-email', 'test@gmail.com']
        >>> result = validate_email_list(emails)
        >>> print(result['success_rate'])
        0.67
        
        >>> # Con lista blanca de dominios
        >>> whitelist = ['company.com', 'partner.org']
        >>> result = validate_email_list(emails, domain_whitelist=whitelist)
        
        >>> # Con verificación MX
        >>> result = validate_email_list(emails, check_mx=True)
    
    Note:
        - La verificación MX puede ser lenta y fallar por problemas de red
        - Los emails se procesan secuencialmente, no en paralelo
        - No verifica si la dirección realmente existe, solo el formato y DNS
        
        Complejidad temporal: O(n * m) donde n=len(emails), m=tiempo de DNS lookup
        Complejidad espacial: O(n) para almacenar resultados
    
    See Also:
        email.utils.parseaddr: Para parsing más robusto de emails
        https://pypi.org/project/dnspython/: Biblioteca DNS requerida para check_mx
    """
    valid_emails = []
    invalid_emails = []
    
    # Verificar que dnspython esté disponible si se requiere verificación MX
    if check_mx:
        try:
            import dns.resolver
        except ImportError:
            raise ImportError(
                "dnspython es requerido para verificación MX. "
                "Instale con: pip install dnspython"
            )
    
    for email in emails:
        # Validación básica de formato - buscar símbolo @
        if '@' not in email:
            invalid_emails.append((email, 'missing_at_symbol'))
            continue
            
        # Separar parte local y dominio
        local_part, domain = email.split('@', 1)
        
        # Verificar lista blanca de dominios si se proporciona
        if domain_whitelist and domain not in domain_whitelist:
            invalid_emails.append((email, 'domain_not_whitelisted'))
            continue
            
        # Verificación opcional de registros MX
        if check_mx:
            try:
                mx_records = dns.resolver.resolve(domain, 'MX')
                if not mx_records:
                    invalid_emails.append((email, 'no_mx_record'))
                    continue
            except Exception as e:
                # DNS lookup falló - podría ser dominio inválido o problema de red
                invalid_emails.append((email, 'dns_lookup_failed'))
                continue
                
        # Email pasó todas las validaciones
        valid_emails.append(email)
    
    # Calcular tasa de éxito
    success_rate = len(valid_emails) / len(emails) if emails else 0
    
    return {
        'valid': valid_emails,
        'invalid': invalid_emails,
        'success_rate': success_rate
    }
```

## Documentación de APIs REST

### Ejemplo 2: Endpoint Sin Documentar

```python
from flask import Flask, request, jsonify
from datetime import datetime

app = Flask(__name__)

@app.route('/users', methods=['POST'])
def create_user():
    data = request.get_json()
    
    if not data.get('email'):
        return jsonify({'error': 'Email required'}), 400
        
    user = {
        'id': generate_user_id(),
        'email': data['email'],
        'name': data.get('name'),
        'created_at': datetime.utcnow().isoformat(),
        'status': 'active'
    }
    
    save_user(user)
    return jsonify(user), 201

@app.route('/users/<user_id>/orders', methods=['GET'])
def get_user_orders(user_id):
    page = request.args.get('page', 1, type=int)
    limit = request.args.get('limit', 10, type=int)
    status = request.args.get('status')
    
    orders = fetch_user_orders(user_id, page, limit, status)
    total = count_user_orders(user_id, status)
    
    return jsonify({
        'orders': orders,
        'pagination': {
            'page': page,
            'limit': limit,
            'total': total,
            'pages': (total + limit - 1) // limit
        }
    })
```

**Prompt para Documentación de API:**
```
Como especialista en documentación de APIs, genera documentación completa para estos endpoints Flask siguiendo el estándar OpenAPI 3.0.

Para cada endpoint, proporciona:

1. **Especificación OpenAPI YAML completa** con:
   - Descripción del endpoint y su propósito
   - Parámetros de ruta, query y body
   - Esquemas de request/response
   - Códigos de estado HTTP posibles
   - Ejemplos de request/response

2. **Documentación en formato Markdown** para desarrolladores con:
   - Casos de uso típicos
   - Ejemplos de curl commands
   - Códigos de error comunes y soluciones
   - Limitaciones y consideraciones

3. **Tests de ejemplo** usando pytest para validar la documentación

4. **Comentarios en el código** explicando la lógica de negocio

[INSERTAR CÓDIGO DE API]

Asegúrate de incluir esquemas de validación y ejemplos realistas.
```

### Documentación Generada (Ejemplo):

```yaml
# openapi.yaml
openapi: 3.0.3
info:
  title: User Management API
  description: API para gestión de usuarios y sus pedidos
  version: 1.0.0
  contact:
    name: API Support
    email: api-support@company.com

paths:
  /users:
    post:
      summary: Crear nuevo usuario
      description: |
        Crea un nuevo usuario en el sistema con email obligatorio.
        El usuario se crea con status 'active' por defecto.
      operationId: createUser
      tags:
        - Users
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/CreateUserRequest'
            examples:
              basic_user:
                summary: Usuario básico
                value:
                  email: "john@example.com"
                  name: "John Doe"
              minimal_user:
                summary: Solo email requerido
                value:
                  email: "jane@example.com"
      responses:
        '201':
          description: Usuario creado exitosamente
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/User'
              examples:
                created_user:
                  value:
                    id: "usr_1234567890"
                    email: "john@example.com"
                    name: "John Doe"
                    created_at: "2025-01-15T10:30:00Z"
                    status: "active"
        '400':
          description: Datos de entrada inválidos
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Error'
              examples:
                missing_email:
                  value:
                    error: "Email required"
                    code: "VALIDATION_ERROR"

  /users/{user_id}/orders:
    get:
      summary: Obtener pedidos de usuario
      description: |
        Retorna una lista paginada de pedidos para un usuario específico.
        Soporta filtrado por status y paginación.
      operationId: getUserOrders
      tags:
        - Users
        - Orders
      parameters:
        - name: user_id
          in: path
          required: true
          description: ID único del usuario
          schema:
            type: string
            pattern: '^usr_[a-zA-Z0-9]{10}$'
          example: "usr_1234567890"
        - name: page
          in: query
          description: Número de página (empezando en 1)
          schema:
            type: integer
            minimum: 1
            default: 1
          example: 1
        - name: limit
          in: query
          description: Número de elementos por página
          schema:
            type: integer
            minimum: 1
            maximum: 100
            default: 10
          example: 10
        - name: status
          in: query
          description: Filtrar por status del pedido
          schema:
            type: string
            enum: [pending, processing, shipped, delivered, cancelled]
          example: "shipped"
      responses:
        '200':
          description: Lista de pedidos obtenida exitosamente
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/OrdersResponse'

components:
  schemas:
    CreateUserRequest:
      type: object
      required:
        - email
      properties:
        email:
          type: string
          format: email
          description: Dirección de email única del usuario
          example: "user@example.com"
        name:
          type: string
          description: Nombre completo del usuario
          maxLength: 100
          example: "John Doe"
    
    User:
      type: object
      properties:
        id:
          type: string
          description: ID único del usuario generado por el sistema
          pattern: '^usr_[a-zA-Z0-9]{10}$'
          example: "usr_1234567890"
        email:
          type: string
          format: email
          example: "user@example.com"
        name:
          type: string
          nullable: true
          example: "John Doe"
        created_at:
          type: string
          format: date-time
          description: Timestamp de creación en formato ISO 8601
          example: "2025-01-15T10:30:00Z"
        status:
          type: string
          enum: [active, inactive, suspended]
          example: "active"
    
    OrdersResponse:
      type: object
      properties:
        orders:
          type: array
          items:
            $ref: '#/components/schemas/Order'
        pagination:
          $ref: '#/components/schemas/PaginationInfo'
    
    Order:
      type: object
      properties:
        id:
          type: string
          example: "ord_9876543210"
        status:
          type: string
          enum: [pending, processing, shipped, delivered, cancelled]
        total:
          type: number
          format: decimal
          example: 99.99
        created_at:
          type: string
          format: date-time
    
    PaginationInfo:
      type: object
      properties:
        page:
          type: integer
          example: 1
        limit:
          type: integer
          example: 10
        total:
          type: integer
          example: 45
        pages:
          type: integer
          example: 5
    
    Error:
      type: object
      properties:
        error:
          type: string
          description: Mensaje de error legible
        code:
          type: string
          description: Código de error para manejo programático
```

## Documentación de Arquitectura

### Ejemplo 3: Sistema Microservicios Sin Documentar

```python
# user-service/app.py
class UserService:
    def __init__(self):
        self.db = Database()
        self.cache = RedisCache()
        self.message_queue = RabbitMQPublisher()
    
    def create_user(self, user_data):
        user = self.db.save_user(user_data)
        self.cache.set(f"user:{user.id}", user)
        self.message_queue.publish("user.created", {
            "user_id": user.id,
            "email": user.email
        })
        return user

# order-service/app.py  
class OrderService:
    def __init__(self):
        self.db = Database()
        self.user_service = UserServiceClient()
        self.payment_service = PaymentServiceClient()
        self.inventory_service = InventoryServiceClient()
    
    def create_order(self, order_data):
        user = self.user_service.get_user(order_data['user_id'])
        
        for item in order_data['items']:
            if not self.inventory_service.check_availability(item['product_id'], item['quantity']):
                raise InsufficientInventoryError()
        
        payment_result = self.payment_service.process_payment(
            user.payment_method, 
            order_data['total']
        )
        
        if payment_result.success:
            order = self.db.save_order(order_data)
            return order
        else:
            raise PaymentFailedError()
```

**Prompt para Documentación de Arquitectura:**
```
Como arquitecto de software, documenta este sistema de microservicios creando:

1. **Diagrama de Arquitectura** (en formato texto/ASCII):
   - Servicios y sus responsabilidades
   - Flujo de datos entre servicios
   - Dependencias externas (DB, cache, message queue)
   - Puntos de integración

2. **Documentación de Servicios**:
   - Propósito y responsabilidades de cada servicio
   - APIs expuestas y consumidas
   - Modelo de datos
   - Eventos publicados/consumidos

3. **Guías de Deployment**:
   - Dependencias de infraestructura
   - Variables de entorno requeridas
   - Orden de despliegue
   - Health checks y monitoring

4. **Runbooks Operacionales**:
   - Procedimientos de troubleshooting
   - Escalado horizontal/vertical
   - Backup y recovery
   - Monitoring y alertas

5. **ADRs (Architecture Decision Records)**:
   - Decisiones de diseño tomadas
   - Alternativas consideradas
   - Consecuencias y trade-offs

[INSERTAR CÓDIGO DE MICROSERVICIOS]

Incluye diagramas de secuencia para flujos críticos como creación de pedidos.
```

## Documentación de Bases de Datos

### Ejemplo 4: Schema Sin Documentar

```sql
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status INTEGER DEFAULT 1,
    metadata JSONB
);

CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users(id),
    total DECIMAL(10,2) NOT NULL,
    status VARCHAR(50) DEFAULT 'pending',
    shipping_address JSONB,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_orders_user_status ON orders(user_id, status);
CREATE INDEX idx_users_email_status ON users(email, status);
```

**Prompt para Documentación de BD:**
```
Como especialista en bases de datos, documenta este schema PostgreSQL creando:

1. **Diccionario de Datos** completo:
   - Descripción de cada tabla y su propósito
   - Descripción de cada columna con tipos, constraints y valores por defecto
   - Relaciones entre tablas (FK, cardinalidad)
   - Índices y su justificación de rendimiento

2. **Diagramas ERD** (en formato texto):
   - Entidades y atributos
   - Relaciones y cardinalidades
   - Constrains de integridad

3. **Guías de Uso**:
   - Queries comunes con ejemplos
   - Patrones de acceso optimizados
   - Mejores prácticas para inserts/updates
   - Consideraciones de rendimiento

4. **Scripts de Migración**:
   - Versionado del schema
   - Scripts de rollback
   - Datos de prueba/seed

5. **Políticas de Datos**:
   - Retención de datos
   - Archivado histórico
   - Backup y recovery
   - Consideraciones GDPR/privacidad

[INSERTAR SCHEMA SQL]

Incluye ejemplos de queries y explain plans para operaciones críticas.
```

## Prompts Avanzados para Documentación

### Prompt Template 1: Documentación Integral de Proyecto

```
Actúa como un Technical Writer senior. Analiza este proyecto y crea documentación completa:

**ESTRUCTURA DE DOCUMENTACIÓN:**

1. **README.md Principal**:
   - Descripción del proyecto y valor de negocio
   - Quick start guide (< 5 minutos)
   - Arquitectura de alto nivel
   - Enlaces a documentación detallada

2. **Documentación Técnica** (/docs):
   - Architecture Decision Records (ADRs)
   - API documentation
   - Database schema
   - Deployment guides
   - Troubleshooting runbooks

3. **Documentación para Desarrolladores**:
   - Setup de desarrollo local
   - Coding standards y guidelines
   - Testing strategy
   - CI/CD pipeline documentation

4. **Documentación de Usuario**:
   - User guides por rol
   - Tutorials paso a paso
   - FAQ y troubleshooting común
   - Feature documentation

**CRITERIOS DE CALIDAD:**
- Usar lenguaje claro y conciso
- Incluir ejemplos ejecutables
- Diagramas cuando agreguen valor
- Mantener consistencia en formato
- Información actualizada y versionada

**HERRAMIENTAS:**
- Markdown para todo
- Mermaid para diagramas
- OpenAPI para APIs
- Conventional commits para changelog

[INSERTAR CÓDIGO/PROYECTO]

Prioriza documentación que reduzca tiempo de onboarding y soporte.
```

### Prompt Template 2: Documentación Evolutiva

```
Diseña una estrategia de documentación evolutiva para este proyecto:

**FASE 1 - Documentación Crítica (Semana 1)**:
- README básico funcional
- Setup instructions que funcionen
- API docs para endpoints principales
- Troubleshooting para errores comunes

**FASE 2 - Documentación Operacional (Semana 2-3)**:
- Deployment procedures
- Monitoring y alertas
- Backup/recovery procedures
- Security guidelines

**FASE 3 - Documentación Completa (Semana 4-6)**:
- Architecture documentation
- Developer onboarding guide
- User documentation
- Testing procedures

**AUTOMATIZACIÓN:**
- Scripts para generar docs desde código
- CI/CD integration para validar docs
- Automated testing de ejemplos
- Changelog generation

**MÉTRICAS DE ÉXITO:**
- Tiempo de onboarding < X días
- Tickets de soporte reducidos en Y%
- Developer satisfaction scores
- Doc coverage metrics

Para cada fase proporciona:
- Entregables específicos
- Templates y herramientas
- Criterios de aceptación
- Responsible parties

[CÓDIGO/PROYECTO]
```

### Prompt Template 3: Documentación Auto-Actualizable

```
Crea un sistema de documentación que se mantenga actualizado automáticamente:

**INTEGRACIÓN CON CÓDIGO:**
1. Extraer documentación desde:
   - Docstrings y comentarios
   - Type hints y schemas
   - Tests como ejemplos
   - Configuration files

2. **Generación Automática**:
   - API docs desde OpenAPI specs
   - Database docs desde migrations
   - Architecture diagrams desde código
   - Changelog desde git commits

3. **Validación Continua**:
   - Tests que validen ejemplos en docs
   - Links checker automático
   - Spell checking y grammar
   - Consistencia de formato

4. **Deployment Automático**:
   - Deploy docs con cada release
   - Versionado automático
   - Multi-format output (web, PDF, etc.)
   - Search indexing

**HERRAMIENTAS SUGERIDAS:**
- Sphinx/MkDocs para generación
- GitHub Actions para CI/CD
- PlantUML para diagramas
- Vale para style checking

Implementa esta estrategia para:
[PROYECTO/CÓDIGO]

Incluye:
- Scripts de setup
- Configuration files
- CI/CD workflows
- Maintenance procedures
```

## Herramientas y Automatización

### Ejemplo 5: Script de Generación Automática

```python
# doc_generator.py
import ast
import os
from typing import List, Dict
from jinja2 import Template

class CodeDocumentationGenerator:
    def __init__(self, source_dir: str):
        self.source_dir = source_dir
        self.functions = []
        self.classes = []
    
    def analyze_file(self, filepath: str):
        with open(filepath, 'r') as file:
            tree = ast.parse(file.read())
        
        for node in ast.walk(tree):
            if isinstance(node, ast.FunctionDef):
                self.functions.append(self.extract_function_info(node))
            elif isinstance(node, ast.ClassDef):
                self.classes.append(self.extract_class_info(node))
    
    def extract_function_info(self, node):
        return {
            'name': node.name,
            'args': [arg.arg for arg in node.args.args],
            'docstring': ast.get_docstring(node),
            'line_number': node.lineno
        }
    
    def generate_docs(self) -> str:
        template = Template("""
# API Documentation

## Functions

{% for func in functions %}
### {{ func.name }}

**Arguments:** {{ func.args|join(', ') }}

{% if func.docstring %}
{{ func.docstring }}
{% else %}
*No documentation available*
{% endif %}

---
{% endfor %}
        """)
        
        return template.render(functions=self.functions)
```

**Prompt para Mejorar Herramienta:**
```
Mejora este generador de documentación automática para que:

1. **Extraiga más información**:
   - Type hints y return types
   - Decoradores aplicados
   - Excepciones que puede lanzar
   - Complejidad ciclomática
   - Dependencias importadas

2. **Genere múltiples formatos**:
   - Markdown para GitHub
   - HTML para web docs
   - OpenAPI specs para APIs
   - Sphinx RST format

3. **Incluya análisis estático**:
   - Code coverage de documentación
   - Métricas de calidad
   - Sugerencias de mejora
   - Links entre componentes

4. **Integre con herramientas**:
   - Git hooks para validación
   - CI/CD pipeline integration
   - IDE plugins
   - Documentation hosting

[CÓDIGO DE HERRAMIENTA]

Proporciona código completo y funcional con tests.
```

## Métricas de Calidad de Documentación

### KPIs Sugeridos

1. **Coverage Metrics**:
   - % de funciones documentadas
   - % de APIs con ejemplos
   - % de código con comentarios

2. **Usage Metrics**:
   - Tiempo de onboarding
   - Tickets de soporte reducidos
   - Developer satisfaction

3. **Maintenance Metrics**:
   - Docs out-of-sync detection
   - Update frequency
   - Review cycle time

### Herramientas de Validación
