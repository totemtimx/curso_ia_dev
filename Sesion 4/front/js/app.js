// Aplicación principal
class App {
    constructor() {
        this.currentView = 'home';
        this.views = ['home', 'about', 'services', 'contact'];
        this.init();
    }

    init() {
        this.setupEventListeners();
        this.setupFormHandling();
        this.setupAnimations();
        console.log('Aplicación iniciada correctamente');
    }

    setupEventListeners() {
        // Event listeners para navegación
        document.querySelectorAll('.nav-link').forEach(link => {
            link.addEventListener('click', (e) => {
                e.preventDefault();
                const viewId = e.target.getAttribute('href').substring(1);
                this.showView(viewId);
            });
        });

        // Event listener para menú móvil
        const navToggle = document.querySelector('.nav-toggle');
        const navMenu = document.querySelector('.nav-menu');
        
        if (navToggle && navMenu) {
            navToggle.addEventListener('click', () => {
                navMenu.classList.toggle('active');
                navToggle.classList.toggle('active');
            });
        }

        // Cerrar menú móvil al hacer clic en un enlace
        document.querySelectorAll('.nav-link').forEach(link => {
            link.addEventListener('click', () => {
                navMenu.classList.remove('active');
                navToggle.classList.remove('active');
            });
        });
    }

    setupFormHandling() {
        const contactForm = document.querySelector('.contact-form');
        if (contactForm) {
            contactForm.addEventListener('submit', (e) => {
                e.preventDefault();
                this.handleFormSubmit(e.target);
            });
        }
    }

    setupAnimations() {
        // Animaciones de entrada para elementos
        const observerOptions = {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        };

        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('animate-in');
                }
            });
        }, observerOptions);

        // Observar elementos para animación
        document.querySelectorAll('.about-card, .service-card').forEach(card => {
            observer.observe(card);
        });
    }

    showView(viewId) {
        if (!this.views.includes(viewId)) {
            console.error('Vista no encontrada:', viewId);
            return;
        }

        // Ocultar vista actual
        const currentView = document.querySelector(`#${this.currentView}`);
        if (currentView) {
            currentView.classList.remove('active');
        }

        // Mostrar nueva vista
        const newView = document.querySelector(`#${viewId}`);
        if (newView) {
            newView.classList.add('active');
        }

        // Actualizar navegación
        this.updateNavigation(viewId);
        
        // Actualizar estado
        this.currentView = viewId;

        // Actualizar URL sin recargar la página
        history.pushState({ view: viewId }, '', `#${viewId}`);

        console.log(`Vista cambiada a: ${viewId}`);
    }

    updateNavigation(activeViewId) {
        // Remover clase active de todos los enlaces
        document.querySelectorAll('.nav-link').forEach(link => {
            link.classList.remove('active');
        });

        // Agregar clase active al enlace correspondiente
        const activeLink = document.querySelector(`[href="#${activeViewId}"]`);
        if (activeLink) {
            activeLink.classList.add('active');
        }
    }

    async handleFormSubmit(form) {
        const formData = new FormData(form);
        const data = Object.fromEntries(formData);

        // Validación básica
        if (!this.validateForm(data)) {
            return;
        }

        // Mostrar estado de carga
        const submitButton = form.querySelector('button[type="submit"]');
        const originalText = submitButton.textContent;
        submitButton.textContent = 'Enviando...';
        submitButton.disabled = true;

        try {
            // Simular envío de formulario
            await this.simulateFormSubmission(data);
            
            // Mostrar mensaje de éxito
            this.showAlert('Mensaje enviado correctamente', 'success');
            form.reset();
            
        } catch (error) {
            // Mostrar mensaje de error
            this.showAlert('Error al enviar el mensaje', 'error');
            console.error('Error en formulario:', error);
        } finally {
            // Restaurar botón
            submitButton.textContent = originalText;
            submitButton.disabled = false;
        }
    }

    validateForm(data) {
        const errors = [];

        if (!data.name || data.name.trim().length < 2) {
            errors.push('El nombre debe tener al menos 2 caracteres');
        }

        if (!data.email || !this.isValidEmail(data.email)) {
            errors.push('Ingresa un email válido');
        }

        if (!data.message || data.message.trim().length < 10) {
            errors.push('El mensaje debe tener al menos 10 caracteres');
        }

        if (errors.length > 0) {
            this.showAlert(errors.join('\n'), 'error');
            return false;
        }

        return true;
    }

    isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    async simulateFormSubmission(data) {
        // Simular delay de red
        return new Promise((resolve) => {
            setTimeout(() => {
                console.log('Datos del formulario:', data);
                resolve();
            }, 1500);
        });
    }

    showAlert(message, type = 'info') {
        // Crear elemento de alerta
        const alert = document.createElement('div');
        alert.className = `alert alert-${type}`;
        alert.textContent = message;

        // Insertar al inicio del contenido principal
        const mainContent = document.querySelector('.main-content');
        mainContent.insertBefore(alert, mainContent.firstChild);

        // Remover después de 5 segundos
        setTimeout(() => {
            alert.remove();
        }, 5000);
    }

    // Método para manejar navegación del navegador
    handlePopState(event) {
        if (event.state && event.state.view) {
            this.showView(event.state.view);
        }
    }
}

// Inicializar aplicación cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', () => {
    window.app = new App();
    
    // Manejar navegación del navegador
    window.addEventListener('popstate', (event) => {
        window.app.handlePopState(event);
    });
});

// Función global para mostrar vistas (para compatibilidad con onclick)
function showView(viewId) {
    if (window.app) {
        window.app.showView(viewId);
    }
} 