# Ejemplos y Prompts: IA en Pruebas de Software

## 1. Generación Automática de Pruebas Unitarias

### Ejemplo de Código Base
```javascript
function calculateDiscount(price, customerType, quantity) {
    if (price <= 0) throw new Error("Price must be positive");
    if (quantity <= 0) throw new Error("Quantity must be positive");
    
    let discount = 0;
    if (customerType === "premium") discount = 0.15;
    else if (customerType === "regular") discount = 0.10;
    
    if (quantity >= 10) discount += 0.05;
    
    return price * quantity * (1 - discount);
}
```

### Prompt para IA
```
Analiza esta función JavaScript y genera un conjunto completo de pruebas unitarias que incluya:
- Casos de prueba válidos para todos los tipos de cliente
- Casos edge (límites de cantidad)
- Casos de error (valores inválidos)
- Pruebas de combinaciones de descuentos
- Usa Jest como framework

[PEGAR CÓDIGO AQUÍ]
```

### Resultado Esperado
```javascript
describe('calculateDiscount', () => {
    // Casos válidos
    test('should calculate regular customer discount correctly', () => {
        expect(calculateDiscount(100, 'regular', 5)).toBe(450);
    });
    
    test('should apply quantity discount for large orders', () => {
        expect(calculateDiscount(100, 'regular', 10)).toBe(850);
    });
    
    // Casos de error
    test('should throw error for negative price', () => {
        expect(() => calculateDiscount(-10, 'regular', 5)).toThrow('Price must be positive');
    });
    
    // Casos edge
    test('should handle zero discount for unknown customer type', () => {
        expect(calculateDiscount(100, 'unknown', 5)).toBe(500);
    });
});
```

## 2. Análisis de Código para Detección de Bugs

### Código con Problemas Potenciales
```python
def process_user_data(users):
    results = []
    for user in users:
        if user['age'] > 18:
            user['status'] = 'adult'
            results.append(user)
    return results
```

### Prompt para Análisis
```
Analiza este código Python y identifica:
- Posibles errores de runtime
- Problemas de seguridad
- Casos edge no manejados
- Mejores prácticas no seguidas
- Sugiere pruebas específicas para cada problema identificado

[CÓDIGO A ANALIZAR]
```

### Análisis de IA Esperado
```
PROBLEMAS IDENTIFICADOS:

1. KeyError potencial: No verifica si 'age' existe en user
2. Modificación de datos originales: Modifica el diccionario original
3. Validación faltante: No valida si users es None o vacío
4. Tipo de datos: No valida que age sea numérico

PRUEBAS SUGERIDAS:
- Probar con user sin campo 'age'
- Probar con users = None
- Probar con age como string
- Verificar que no se modifiquen datos originales
```

## 3. Optimización de Ejecución de Pruebas

### Prompt para Análisis de Cambios
```
Dado este diff de código y esta suite de 150 pruebas, determina:
- Qué pruebas son críticas ejecutar basándose en los cambios
- Prioriza las pruebas por probabilidad de fallo
- Sugiere un orden de ejecución óptimo
- Estima tiempo de ejecución reducido

CAMBIOS:
[DIFF DEL CÓDIGO]

SUITE DE PRUEBAS:
[LISTA DE ARCHIVOS DE PRUEBA]
```

### Respuesta de IA Ejemplo
```
ANÁLISIS DE IMPACTO:

Cambios detectados en: authentication.js, user-service.js

PRUEBAS CRÍTICAS (Ejecutar primero):
1. auth.test.js - 15 pruebas (ALTA probabilidad de fallo)
2. user-service.test.js - 23 pruebas (ALTA probabilidad)
3. integration/login.test.js - 8 pruebas (MEDIA probabilidad)

PRUEBAS OPCIONALES (Para regresión completa):
- ui.test.js - Sin cambios relacionados
- payment.test.js - Sin cambios relacionados

TIEMPO ESTIMADO: 8 minutos (vs 45 minutos suite completa)
```

## 4. Generación de Casos de Prueba desde Especificaciones

### Especificación de Ejemplo
```
FEATURE: Sistema de Login
- El usuario debe ingresar email y password
- Email debe ser válido (formato)
- Password debe tener mínimo 8 caracteres
- Máximo 3 intentos fallidos antes de bloqueo
- Bloqueo temporal de 15 minutos
```

### Prompt para Generación
```
Basándote en esta especificación, genera:
- Casos de prueba funcionales completos
- Casos de prueba de seguridad
- Pruebas de usabilidad
- Formato: Given-When-Then
- Incluye datos de prueba específicos

[ESPECIFICACIÓN]
```

### Casos Generados
```
CASO 1: Login exitoso
Given: Usuario con email válido "test@example.com" y password "password123"
When: El usuario intenta hacer login
Then: El sistema permite el acceso y redirige al dashboard

CASO 2: Email inválido
Given: Usuario ingresa "invalid-email" como email
When: El usuario intenta hacer login
Then: El sistema muestra error "Email format is invalid"

CASO 3: Bloqueo por intentos fallidos
Given: Usuario ha fallado login 2 veces
When: El usuario falla el tercer intento
Then: La cuenta se bloquea por 15 minutos
And: Se muestra mensaje "Account temporarily locked"
```

## 5. Análisis de Resultados de Pruebas

### Prompt para Análisis de Fallos
```
Analiza estos resultados de pruebas fallidas y proporciona:
- Patrones comunes en los fallos
- Posibles causas raíz
- Priorización por impacto
- Recomendaciones de fixes
- Pruebas adicionales sugeridas

RESULTADOS:
[LOG DE PRUEBAS FALLIDAS]
```

## 6. Generación de Datos de Prueba

### Prompt para Datos Sintéticos
```
Genera un dataset de prueba para una aplicación de e-commerce que incluya:
- 100 usuarios con datos realistas
- Variedad demográfica
- Casos edge (emails largos, nombres especiales)
- Datos que cubran todos los flujos de negocio
- Formato JSON

ESQUEMA DE USUARIO:
{
  "id": number,
  "name": string,
  "email": string,
  "age": number,
  "membershipType": "basic"|"premium"|"enterprise"
}
```

## 7. Pruebas de Performance con IA

### Prompt para Análisis de Performance
```
Analiza este endpoint API y genera:
- Casos de prueba de carga progresiva
- Identificación de posibles cuellos de botella
- Métricas críticas a monitorear
- Escenarios de stress testing
- Scripts de JMeter o Artillery

ENDPOINT: POST /api/users/search
FUNCIONALIDAD: Búsqueda de usuarios con filtros
TIEMPO ESPERADO: < 500ms
```

## 8. Pruebas de Accesibilidad

### Prompt para Validación A11y
```
Revisa este componente React y genera pruebas de accesibilidad que verifiquen:
- Navegación por teclado
- Compatibilidad con screen readers
- Contraste de colores
- ARIA labels apropiados
- Cumplimiento WCAG 2.1 AA

[COMPONENTE REACT]
```

## 9. Mantenimiento de Pruebas

### Prompt para Actualización Automática
```
El API ha cambiado de "/api/v1/users" a "/api/v2/users" con nueva estructura de respuesta.
Actualiza automáticamente estas pruebas manteniendo la lógica de validación:

CAMBIOS EN API:
- URL: /api/v1/users → /api/v2/users  
- Response: {users: [...]} → {data: [...], meta: {...}}

PRUEBAS A ACTUALIZAR:
[ARCHIVOS DE PRUEBA]
```

## 10. Integración con CI/CD

### Prompt para Pipeline Inteligente
```
Diseña una estrategia de testing inteligente para CI/CD que:
- Ejecute pruebas críticas en cada commit
- Pruebas completas solo en merge requests
- Análisis de código en tiempo real
- Reporte automático de cobertura y calidad
- Bloqueo automático si la calidad baja del 80%

HERRAMIENTAS DISPONIBLES: Jenkins, Docker, SonarQube, Jest
```

## Consejos para Prompts Efectivos


### Palabras Clave Efectivas
- "Analiza exhaustivamente"
- "Genera casos edge"
- "Considera escenarios reales"
- "Prioriza por riesgo"
- "Incluye casos negativos"
- "Optimiza para mantenibilidad"

### Validación de Prompts
Siempre incluye:
- Contexto específico del proyecto
- Tecnologías y frameworks utilizados
- Criterios de aceptación claros
- Ejemplos del formato deseado