#  Detección de Code Smells con IA

### Ejemplo 1: Función con Múltiples Responsabilidades

```python
# Código problemático
def process_user_data(user_id):
    # Conectar a base de datos
    conn = sqlite3.connect('users.db')
    cursor = conn.cursor()
    
    # Obtener datos del usuario
    cursor.execute("SELECT * FROM users WHERE id = ?", (user_id,))
    user = cursor.fetchone()
    
    # Validar email
    email_pattern = r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$'
    if not re.match(email_pattern, user[2]):
        return "Email inválido"
    
    # Calcular edad
    birth_date = datetime.strptime(user[3], '%Y-%m-%d')
    age = (datetime.now() - birth_date).days // 365
    
    # Enviar email de bienvenida
    smtp_server = smtplib.SMTP('smtp.gmail.com', 587)
    smtp_server.send_message(f"Bienvenido {user[1]}")
    
    # Generar reporte
    report = f"Usuario: {user[1]}, Edad: {age}, Email válido"
    
    conn.close()
    return report
```

**Prompt para IA:**
```
Analiza el siguiente código Python y identifica los code smells presentes. 
Proporciona una refactorización que aplique el principio de responsabilidad única (SRP) 
y mejore la legibilidad y mantenibilidad del código.

[INSERTAR CÓDIGO]

Por favor:
1. Lista los problemas identificados
2. Proporciona una versión refactorizada
3. Explica los beneficios de cada cambio
```

### Código Refactorizado (Ejemplo de respuesta esperada):

```python
# Versión refactorizada
class DatabaseManager:
    def __init__(self, db_path):
        self.db_path = db_path
    
    def get_user(self, user_id):
        with sqlite3.connect(self.db_path) as conn:
            cursor = conn.cursor()
            cursor.execute("SELECT * FROM users WHERE id = ?", (user_id,))
            return cursor.fetchone()

class EmailValidator:
    @staticmethod
    def is_valid(email):
        pattern = r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$'
        return bool(re.match(pattern, email))

class AgeCalculator:
    @staticmethod
    def calculate_age(birth_date_str):
        birth_date = datetime.strptime(birth_date_str, '%Y-%m-%d')
        return (datetime.now() - birth_date).days // 365

class EmailService:
    def __init__(self, smtp_server, port):
        self.smtp_server = smtp_server
        self.port = port
    
    def send_welcome_email(self, user_name, email):
        # Implementación del envío de email
        pass

class UserProcessor:
    def __init__(self, db_manager, email_validator, age_calculator, email_service):
        self.db_manager = db_manager
        self.email_validator = email_validator
        self.age_calculator = age_calculator
        self.email_service = email_service
    
    def process_user_data(self, user_id):
        user = self.db_manager.get_user(user_id)
        
        if not self.email_validator.is_valid(user[2]):
            return "Email inválido"
        
        age = self.age_calculator.calculate_age(user[3])
        self.email_service.send_welcome_email(user[1], user[2])
        
        return f"Usuario: {user[1]}, Edad: {age}, Email válido"
```

## Optimización de Rendimiento

### Ejemplo 2: Optimización de Consultas N+1

```python
# Código con problema N+1
def get_users_with_posts():
    users = User.objects.all()  # 1 consulta
    result = []
    
    for user in users:
        user_data = {
            'name': user.name,
            'email': user.email,
            'posts': []
        }
        
        # N consultas adicionales (una por cada usuario)
        posts = Post.objects.filter(user_id=user.id)
        for post in posts:
            user_data['posts'].append({
                'title': post.title,
                'content': post.content
            })
        
        result.append(user_data)
    
    return result
```

**Prompt para IA:**
```
Este código Django tiene un problema de rendimiento conocido como "N+1 queries". 
Analiza el código y propón una solución optimizada que reduzca el número de consultas 
a la base de datos. Incluye métricas de rendimiento estimadas y explica por qué 
la solución es más eficiente.

[INSERTAR CÓDIGO]

Considera:
- Uso de select_related() y prefetch_related()
- Alternativas con consultas raw SQL si es necesario
- Impacto en memoria vs velocidad
```

### Ejemplo 3: Algoritmo de Búsqueda Ineficiente

```javascript
// Búsqueda lineal ineficiente
function findUser(users, targetId) {
    for (let i = 0; i < users.length; i++) {
        if (users[i].id === targetId) {
            return users[i];
        }
    }
    return null;
}

// Múltiples búsquedas sin cacheo
function getUsersData(userIds) {
    const result = [];
    
    userIds.forEach(id => {
        const userData = fetchUserFromAPI(id); // Llamada HTTP por cada ID
        const userPosts = fetchUserPosts(id);   // Otra llamada HTTP
        const userProfile = fetchUserProfile(id); // Y otra más
        
        result.push({
            user: userData,
            posts: userPosts,
            profile: userProfile
        });
    });
    
    return result;
}
```

**Prompt para IA:**
```
Optimiza este código JavaScript que tiene problemas de eficiencia en:
1. Algoritmo de búsqueda O(n)
2. Múltiples llamadas HTTP síncronas
3. Falta de cacheo de datos

Proporciona una versión optimizada que:
- Use estructuras de datos más eficientes
- Implemente llamadas asíncronas en paralelo
- Incluya un sistema de cacheo
- Mantenga la funcionalidad original

Explica la complejidad temporal antes y después de la optimización.
```

## Refactorización de Patrones Antipattern

### Ejemplo 4: God Class

```java
// Clase con demasiadas responsabilidades
public class OrderManager {
    private DatabaseConnection db;
    private EmailService emailService;
    private PaymentGateway paymentGateway;
    private InventorySystem inventory;
    private Logger logger;
    private ConfigManager config;
    
    public void createOrder(OrderData orderData) {
        // Validación de datos
        if (orderData.getItems().isEmpty()) {
            throw new IllegalArgumentException("Order must have items");
        }
        
        // Cálculo de precios
        double totalPrice = 0;
        for (OrderItem item : orderData.getItems()) {
            totalPrice += item.getPrice() * item.getQuantity();
        }
        
        // Aplicar descuentos
        if (orderData.getCustomer().isPremium()) {
            totalPrice *= 0.9; // 10% descuento
        }
        
        // Verificar inventario
        for (OrderItem item : orderData.getItems()) {
            if (!inventory.isAvailable(item.getProductId(), item.getQuantity())) {
                throw new RuntimeException("Product not available");
            }
        }
        
        // Procesar pago
        PaymentResult paymentResult = paymentGateway.processPayment(
            orderData.getPaymentInfo(), totalPrice
        );
        
        if (!paymentResult.isSuccessful()) {
            throw new RuntimeException("Payment failed");
        }
        
        // Actualizar inventario
        for (OrderItem item : orderData.getItems()) {
            inventory.reduceStock(item.getProductId(), item.getQuantity());
        }
        
        // Guardar en base de datos
        Order order = new Order();
        order.setCustomerId(orderData.getCustomer().getId());
        order.setTotalPrice(totalPrice);
        order.setStatus("CONFIRMED");
        db.save(order);
        
        // Enviar confirmación por email
        emailService.sendOrderConfirmation(
            orderData.getCustomer().getEmail(), order
        );
        
        // Log de la transacción
        logger.info("Order created: " + order.getId());
    }
    
    // Muchos otros métodos relacionados con pedidos, pagos, 
    // inventario, emails, etc.
}
```

**Prompt para IA:**
```
Esta clase Java es un ejemplo de "God Class" antipattern. Tiene demasiadas 
responsabilidades y viola múltiples principios SOLID.

Refactoriza este código aplicando:
1. Principio de Responsabilidad Única (SRP)
2. Principio Abierto/Cerrado (OCP)
3. Inversión de Dependencias (DIP)
4. Patrón Strategy para descuentos
5. Patrón Command para el procesamiento de órdenes

Proporciona una arquitectura limpia que sea extensible y testeable.

[INSERTAR CÓDIGO]
```

## Prompts Avanzados para Optimización

### Prompt Template 1: Análisis Integral de Código

```
Actúa como un arquitecto de software senior. Analiza el siguiente código y proporciona:

**ANÁLISIS:**
1. Code smells identificados
2. Violaciones de principios SOLID
3. Problemas de rendimiento
4. Vulnerabilidades de seguridad
5. Problemas de mantenibilidad

**REFACTORIZACIÓN:**
1. Versión refactorizada completa
2. Patrones de diseño aplicados
3. Justificación de cada cambio
4. Métricas de mejora estimadas

**TESTING:**
1. Casos de prueba para el código original
2. Casos de prueba para el código refactorizado
3. Estrategia de testing

**DOCUMENTACIÓN:**
1. Comentarios explicativos en el código
2. Diagramas de arquitectura (en formato texto)
3. Guía de migración paso a paso

[INSERTAR CÓDIGO AQUÍ]

Responde en español y mantén un nivel técnico avanzado.
```

### Prompt Template 2: Optimización Específica por Lenguaje

```
Como experto en [LENGUAJE], optimiza este código siguiendo las mejores prácticas específicas del lenguaje:

**Para Python:**
- Uso pythónico de list comprehensions, generators
- Aprovechamiento de bibliotecas estándar
- Type hints y documentación
- Manejo eficiente de memoria

**Para JavaScript:**
- Patrones modernos ES6+
- Optimizaciones del motor V8
- Manejo asíncrono eficiente
- Bundle size optimization

**Para Java:**
- Uso eficiente de streams y lambdas
- Patrones de concurrencia
- Optimizaciones de JVM
- Manejo de memoria y GC

Incluye:
1. Código optimizado
2. Benchmarks de rendimiento
3. Explicación de optimizaciones específicas
4. Herramientas de profiling recomendadas

[CÓDIGO A OPTIMIZAR]
```

### Prompt Template 3: Refactorización Evolutiva

```
Diseña un plan de refactorización evolutiva para este sistema legacy:

**FASE 1 - Estabilización (Sprint 1-2):**
- Añadir tests de regresión
- Identificar boundaries críticos
- Documentar comportamiento actual

**FASE 2 - Extracción (Sprint 3-5):**
- Extraer servicios/módulos independientes
- Aplicar patrón Strangler Fig
- Crear APIs intermedias

**FASE 3 - Modernización (Sprint 6-10):**
- Refactorizar core business logic
- Implementar nuevos patrones
- Optimizar rendimiento

**FASE 4 - Consolidación (Sprint 11-12):**
- Limpieza de código legacy
- Optimización final
- Documentación completa

Para cada fase proporciona:
- Código específico a refactorizar
- Métricas de éxito
- Riesgos y mitigaciones
- Plan de rollback

[CÓDIGO LEGACY]
```

## Ejercicios Prácticos

### Ejercicio 1: Refactorización Guiada por IA

**Código inicial:**
```python
def calculate_total(items, discount_code, user_type, region):
    total = 0
    for item in items:
        if item['category'] == 'electronics':
            if region == 'US':
                total += item['price'] * 1.08  # Tax
            elif region == 'EU':
                total += item['price'] * 1.20  # VAT
            else:
                total += item['price']
        elif item['category'] == 'books':
            total += item['price']  # No tax on books
        else:
            if region == 'US':
                total += item['price'] * 1.05
            else:
                total += item['price'] * 1.10
    
    if discount_code == 'SAVE10':
        total *= 0.9
    elif discount_code == 'SAVE20':
        total *= 0.8
    elif discount_code == 'NEWUSER' and user_type == 'new':
        total *= 0.85
    
    return total
```

**Instrucciones para estudiantes:**
1. Usar IA para identificar problemas
2. Aplicar refactorización paso a paso
3. Validar con tests
4. Comparar métricas de calidad

### Ejercicio 2: Optimización de Base de Datos

```sql
-- Query problemática
SELECT u.name, u.email,
       (SELECT COUNT(*) FROM orders o WHERE o.user_id = u.id) as order_count,
       (SELECT AVG(o.total) FROM orders o WHERE o.user_id = u.id) as avg_order,
       (SELECT MAX(o.created_at) FROM orders o WHERE o.user_id = u.id) as last_order
FROM users u
WHERE u.active = 1
ORDER BY u.created_at DESC;
```

**Tarea:** Usar IA para optimizar esta consulta y explicar el plan de ejecución.

## Métricas de Evaluación

### Antes y Después de la Refactorización

1. **Complejidad Ciclomática**
2. **Líneas de Código (LOC)**
3. **Cobertura de Tests**
4. **Tiempo de Ejecución**
5. **Uso de Memoria**
6. **Mantenibilidad Index**

### Herramientas Recomendadas

- **Python:** pylint, black, mypy, pytest-cov
- **JavaScript:** ESLint, Prettier, Jest, webpack-bundle-analyzer
- **Java:** SonarQube, SpotBugs, JProfiler
- **Bases de Datos:** EXPLAIN PLAN, pgAdmin, MySQL Workbench

## Recursos Adicionales

- Repositorio con ejemplos completos
- Videos de refactorización en vivo
- Checklist de code review
- Templates de prompts personalizables