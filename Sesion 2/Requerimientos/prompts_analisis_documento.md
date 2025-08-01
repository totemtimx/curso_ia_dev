1. Extracción de Entidades y Actores Clave

Estos prompts se centran en identificar los elementos principales y los usuarios del sistema.

    "Identifica todos los actores (usuarios, sistemas externos, roles) mencionados en el documento y describe su rol principal en relación con el sistema."

    "Lista todas las entidades de negocio o sustantivos clave (ej. 'pedido', 'cliente', 'producto', 'factura', 'transacción') presentes en el texto y sus principales atributos."

    "¿Qué objetos de información principales se gestionan o manipulan a lo largo de este documento? Para cada uno, enumera los detalles o propiedades que se le asocian."

2. Identificación de Funcionalidades y Acciones

Estos prompts buscan desglosar las capacidades del sistema y las acciones que se pueden realizar.

    "Enumera todas las acciones o verbos funcionales que describen lo que el sistema o un actor puede hacer. Para cada acción, identifica el actor que la realiza y la entidad sobre la que actúa."

    "¿Cuáles son las funcionalidades principales que se espera que el software realice? Agrúpalas por módulos o áreas temáticas si es posible."

    "Describe el flujo de eventos o la secuencia de pasos para las operaciones más críticas (ej., 'realizar un pedido', 'registrar un usuario', 'gestionar un inventario')."

3. Detección de Reglas de Negocio y Restricciones

Estos prompts ayudan a descubrir las condiciones, validaciones y limitaciones inherentes al dominio.

    "Extrae todas las reglas de negocio explícitas (ej. 'un pedido debe ser confirmado en X minutos', 'el stock no puede ser negativo', 'solo usuarios con rol X pueden acceder a Y')."

    "Identifica las condiciones o criterios que deben cumplirse para que una acción se ejecute o un estado cambie (ej., 'si el pago es exitoso...', 'cuando el usuario selecciona...')."

    "¿Qué restricciones técnicas o no funcionales se mencionan (ej., rendimiento, seguridad, usabilidad, compatibilidad)? Detalla su naturaleza."

    "Busca términos que indiquen obligatoriedad o prohibición (ej. 'debe', 'no debe', 'es requerido', 'está prohibido') y la regla asociada."

4. Detección de Ambigüedades y Gaps

Estos prompts son cruciales para mejorar la calidad del documento.

    "Identifica cualquier término ambiguo o vago que necesite una definición más clara (ej. 'rápido', 'seguro', 'fácil de usar', 'pronto')."

    "¿Existen requisitos que parecen incompletos o donde falta información crucial (ej., qué sucede después de una acción, qué datos se necesitan realmente)? Señálalos."

    "¿Hay inconsistencias o contradicciones entre diferentes partes del documento?"

    "¿Qué suposiciones se hacen en el texto que no están explícitamente declaradas como requisitos?"

5. Priorización y Clasificación

Estos prompts ayudan a organizar los requisitos.

    "Clasifica los requisitos identificados en categorías como funcionales, no funcionales o reglas de negocio."

    "¿Qué requisitos parecen ser de alta prioridad según el lenguaje utilizado o su impacto en el objetivo principal del sistema?" (Busca términos como 'crítico', 'esencial', 'fundamental').

6. Análisis de Relaciones

Estos prompts buscan comprender cómo los diferentes elementos se conectan.

    "Establece las relaciones entre las entidades identificadas (ej., 'un Cliente realiza uno o más Pedidos', 'un Pedido contiene múltiples Productos')."

    "¿Cómo interactúan los diferentes actores con las funcionalidades del sistema o entre sí?"