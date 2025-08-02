// Funcionalidades de navegación adicionales

class Navigation {
    constructor() {
        this.isScrolled = false;
        this.lastScrollTop = 0;
        this.init();
    }

    init() {
        this.setupScrollEffects();
        this.setupSmoothScrolling();
        this.setupKeyboardNavigation();
        this.setupTouchNavigation();
    }

    setupScrollEffects() {
        const header = document.querySelector('.header');
        
        window.addEventListener('scroll', () => {
            const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
            
            // Efecto de header al hacer scroll
            if (scrollTop > 100 && !this.isScrolled) {
                header.classList.add('scrolled');
                this.isScrolled = true;
            } else if (scrollTop <= 100 && this.isScrolled) {
                header.classList.remove('scrolled');
                this.isScrolled = false;
            }

            // Efecto de parallax suave
            this.handleParallax(scrollTop);
            
            this.lastScrollTop = scrollTop;
        });
    }

    handleParallax(scrollTop) {
        const parallaxElements = document.querySelectorAll('.parallax');
        parallaxElements.forEach(element => {
            const speed = element.dataset.speed || 0.5;
            const yPos = -(scrollTop * speed);
            element.style.transform = `translateY(${yPos}px)`;
        });
    }

    setupSmoothScrolling() {
        // Smooth scroll para enlaces internos
        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
            anchor.addEventListener('click', function (e) {
                e.preventDefault();
                const target = document.querySelector(this.getAttribute('href'));
                if (target) {
                    target.scrollIntoView({
                        behavior: 'smooth',
                        block: 'start'
                    });
                }
            });
        });
    }

    setupKeyboardNavigation() {
        document.addEventListener('keydown', (e) => {
            // Navegación con teclado
            switch(e.key) {
                case 'ArrowLeft':
                    this.navigateToPreviousView();
                    break;
                case 'ArrowRight':
                    this.navigateToNextView();
                    break;
                case 'Home':
                    e.preventDefault();
                    if (window.app) {
                        window.app.showView('home');
                    }
                    break;
                case 'Escape':
                    this.closeMobileMenu();
                    break;
            }
        });
    }

    setupTouchNavigation() {
        let touchStartX = 0;
        let touchEndX = 0;

        document.addEventListener('touchstart', (e) => {
            touchStartX = e.changedTouches[0].screenX;
        });

        document.addEventListener('touchend', (e) => {
            touchEndX = e.changedTouches[0].screenX;
            this.handleSwipe();
        });
    }

    handleSwipe() {
        const swipeThreshold = 50;
        const diff = touchStartX - touchEndX;

        if (Math.abs(diff) > swipeThreshold) {
            if (diff > 0) {
                // Swipe izquierda - siguiente vista
                this.navigateToNextView();
            } else {
                // Swipe derecha - vista anterior
                this.navigateToPreviousView();
            }
        }
    }

    navigateToNextView() {
        if (!window.app) return;
        
        const currentIndex = window.app.views.indexOf(window.app.currentView);
        const nextIndex = (currentIndex + 1) % window.app.views.length;
        const nextView = window.app.views[nextIndex];
        
        window.app.showView(nextView);
    }

    navigateToPreviousView() {
        if (!window.app) return;
        
        const currentIndex = window.app.views.indexOf(window.app.currentView);
        const prevIndex = currentIndex === 0 ? window.app.views.length - 1 : currentIndex - 1;
        const prevView = window.app.views[prevIndex];
        
        window.app.showView(prevView);
    }

    closeMobileMenu() {
        const navMenu = document.querySelector('.nav-menu');
        const navToggle = document.querySelector('.nav-toggle');
        
        if (navMenu && navMenu.classList.contains('active')) {
            navMenu.classList.remove('active');
            navToggle.classList.remove('active');
        }
    }

    // Método para mostrar indicador de progreso
    showProgressIndicator() {
        const progressBar = document.createElement('div');
        progressBar.className = 'progress-indicator';
        progressBar.innerHTML = `
            <div class="progress-bar">
                <div class="progress-fill"></div>
            </div>
        `;
        
        document.body.appendChild(progressBar);
        
        // Animar la barra de progreso
        setTimeout(() => {
            progressBar.querySelector('.progress-fill').style.width = '100%';
        }, 100);
        
        // Remover después de completar
        setTimeout(() => {
            progressBar.remove();
        }, 1000);
    }

    // Método para mostrar breadcrumbs
    updateBreadcrumbs(currentView) {
        const breadcrumbContainer = document.querySelector('.breadcrumbs');
        if (!breadcrumbContainer) return;

        const breadcrumbs = {
            'home': 'Inicio',
            'about': 'Acerca de',
            'services': 'Servicios',
            'contact': 'Contacto'
        };

        breadcrumbContainer.innerHTML = `
            <a href="#home">Inicio</a>
            ${currentView !== 'home' ? ` > <span>${breadcrumbs[currentView]}</span>` : ''}
        `;
    }

    // Método para manejar navegación por URL
    handleURLNavigation() {
        const hash = window.location.hash.substring(1);
        if (hash && window.app && window.app.views.includes(hash)) {
            window.app.showView(hash);
        }
    }
}

// Inicializar navegación cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', () => {
    window.navigation = new Navigation();
    
    // Manejar navegación por URL al cargar la página
    setTimeout(() => {
        window.navigation.handleURLNavigation();
    }, 100);
});

// Exportar para uso en otros módulos
if (typeof module !== 'undefined' && module.exports) {
    module.exports = Navigation;
} 