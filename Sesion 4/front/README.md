# Mi Aplicación Web - Proyecto de Vistas

Una aplicación web moderna con navegación de vistas dinámicas, diseñada con HTML5, CSS3 y JavaScript vanilla.

## 🚀 Características

- **Navegación SPA (Single Page Application)**: Cambio de vistas sin recargar la página
- **Diseño Responsive**: Optimizado para dispositivos móviles, tablets y desktop
- **Animaciones Suaves**: Transiciones y efectos visuales modernos
- **Formulario Interactivo**: Validación en tiempo real y manejo de estados
- **Navegación por Teclado**: Soporte para navegación con flechas y teclas especiales
- **Touch Navigation**: Soporte para gestos de swipe en dispositivos táctiles
- **Accesibilidad**: Diseñado siguiendo las mejores prácticas de accesibilidad web

## 📁 Estructura del Proyecto

```
front/
├── index.html              # Página principal
├── css/
│   ├── styles.css          # Estilos principales
│   └── components.css      # Componentes y utilidades
├── js/
│   ├── app.js             # Lógica principal de la aplicación
│   └── navigation.js      # Funcionalidades de navegación
└── README.md              # Documentación
```

## 🎨 Vistas Disponibles

### 1. **Inicio (Home)**
- Hero section con llamada a la acción
- Diseño moderno con gradientes
- Botón de navegación rápida

### 2. **Acerca de (About)**
- Información sobre la empresa/servicio
- Cards con iconos y descripciones
- Efectos hover interactivos

### 3. **Servicios (Services)**
- Lista de servicios ofrecidos
- Detalles técnicos y características
- Diseño en grid responsive

### 4. **Contacto (Contact)**
- Formulario de contacto funcional
- Información de contacto
- Validación de campos en tiempo real

## 🛠️ Tecnologías Utilizadas

- **HTML5**: Estructura semántica moderna
- **CSS3**: 
  - Variables CSS (Custom Properties)
  - Grid y Flexbox para layouts
  - Animaciones y transiciones
  - Media queries para responsive design
- **JavaScript ES6+**:
  - Clases y módulos
  - Async/await para operaciones asíncronas
  - Event listeners y DOM manipulation
  - History API para navegación

## 🚀 Cómo Usar

### Instalación
1. Clona o descarga el proyecto
2. Abre `index.html` en tu navegador web
3. ¡Listo! La aplicación está funcionando

### Desarrollo
Para modificar o extender la aplicación:

1. **Agregar una nueva vista**:
   - Crea una nueva sección en `index.html` con `id="nueva-vista"` y clase `view`
   - Agrega el enlace en la navegación
   - Actualiza el array `views` en `app.js`

2. **Modificar estilos**:
   - Edita `css/styles.css` para cambios generales
   - Usa `css/components.css` para componentes específicos

3. **Agregar funcionalidad**:
   - Extiende la clase `App` en `app.js`
   - Usa `navigation.js` para funcionalidades de navegación

## 📱 Responsive Design

La aplicación está optimizada para:

- **Desktop**: 1200px+
- **Tablet**: 768px - 1199px
- **Mobile**: 320px - 767px

### Breakpoints
```css
@media (max-width: 768px) { /* Tablet y Mobile */ }
@media (max-width: 480px) { /* Mobile pequeño */ }
```

## ⌨️ Navegación por Teclado

- **Flecha Izquierda**: Vista anterior
- **Flecha Derecha**: Vista siguiente
- **Home**: Ir a la vista de inicio
- **Escape**: Cerrar menú móvil

## 📱 Gestos Táctiles

- **Swipe Izquierda**: Vista siguiente
- **Swipe Derecha**: Vista anterior

## 🎯 Funcionalidades Principales

### Sistema de Vistas
```javascript
// Cambiar vista programáticamente
window.app.showView('about');

// Obtener vista actual
console.log(window.app.currentView);
```

### Manejo de Formularios
```javascript
// El formulario se valida automáticamente
// Muestra alertas de éxito/error
// Simula envío con delay de 1.5 segundos
```

### Animaciones
- Fade in/out para cambios de vista
- Hover effects en cards
- Scroll animations con Intersection Observer
- Parallax effects (opcional)

## 🔧 Personalización

### Colores
Modifica las variables CSS en `:root`:
```css
:root {
    --primary-color: #6366f1;
    --primary-dark: #4f46e5;
    --secondary-color: #f8fafc;
    /* ... más variables */
}
```

### Fuentes
Cambia la fuente principal en `body`:
```css
body {
    font-family: 'Tu-Fuente', sans-serif;
}
```

### Animaciones
Ajusta las transiciones:
```css
:root {
    --transition: all 0.3s ease;
}
```

## 🐛 Solución de Problemas

### La aplicación no carga
- Verifica que todos los archivos estén en las carpetas correctas
- Revisa la consola del navegador para errores JavaScript

### Las vistas no cambian
- Asegúrate de que los IDs coincidan con los enlaces de navegación
- Verifica que el archivo `app.js` se esté cargando correctamente

### Estilos no se aplican
- Confirma que los archivos CSS estén en la carpeta `css/`
- Verifica las rutas en el HTML

## 📈 Próximas Mejoras

- [ ] Integración con backend real
- [ ] Sistema de autenticación
- [ ] Base de datos para formularios
- [ ] PWA (Progressive Web App)
- [ ] SEO optimizado
- [ ] Tests automatizados
- [ ] Build process con bundler

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Puedes usarlo libremente para proyectos personales y comerciales.

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature
3. Commit tus cambios
4. Push a la rama
5. Abre un Pull Request

---

**Desarrollado con ❤️ usando tecnologías web modernas** 