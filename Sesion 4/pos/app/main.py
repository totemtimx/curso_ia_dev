from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

from .routers import productos, clientes, ventas, reportes
from .config import settings

# Crear la aplicación FastAPI
app = FastAPI(
    title=settings.APP_NAME,
    description=settings.APP_DESCRIPTION,
    version=settings.APP_VERSION,
    docs_url="/docs",
    redoc_url="/redoc",
    # Configuración para proxy reverso
    root_path="/pos"
)

# Crear aplicación con prefijo /pos
from fastapi import APIRouter

# Router principal con prefijo /pos
main_router = APIRouter(prefix="/pos")

# Configurar CORS
app.add_middleware(
    CORSMiddleware,
    allow_origins=settings.CORS_ORIGINS,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Incluir routers en el router principal
main_router.include_router(productos.router)
main_router.include_router(clientes.router)
main_router.include_router(ventas.router)
main_router.include_router(reportes.router)

@main_router.get("/")
async def root():
    """Endpoint raíz de la aplicación"""
    return {
        "mensaje": f"{settings.APP_NAME} API",
        "version": settings.APP_VERSION,
        "environment": "development" if settings.is_development() else "production",
        "documentacion": "/docs",
        "endpoints": {
            "productos": "/pos/productos",
            "clientes": "/pos/clientes", 
            "ventas": "/pos/ventas",
            "reportes": "/pos/reportes"
        }
    }

@main_router.get("/health")
async def health_check():
    """Endpoint para verificar el estado de la aplicación"""
    return {"status": "healthy", "message": "API funcionando correctamente"}

# Incluir el router principal en la aplicación
app.include_router(main_router) 


def hola():
    print("asdas")
    var1 = [1,2,3]
    print(var1)