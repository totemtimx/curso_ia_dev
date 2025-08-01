#!/usr/bin/env python3
"""
Script para generar datos de prueba para el sistema POS
Genera productos, clientes y ventas con datos realistas
"""

import json
import uuid
from datetime import datetime, timedelta
import random

def generar_id():
    """Genera un ID único"""
    return str(uuid.uuid4())

def generar_fecha_reciente(dias_atras=30):
    """Genera una fecha reciente"""
    fecha = datetime.now() - timedelta(days=random.randint(0, dias_atras))
    return fecha.strftime("%Y-%m-%d %H:%M:%S")

def generar_productos():
    """Genera una lista de productos de prueba"""
    productos = [
        {
            "id": generar_id(),
            "nombre": "Laptop HP Pavilion",
            "precio": 899.99,
            "stock": 15,
            "categoria": "Electrónicos",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Mouse Inalámbrico Logitech",
            "precio": 29.99,
            "stock": 50,
            "categoria": "Accesorios",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Teclado Mecánico RGB",
            "precio": 89.99,
            "stock": 25,
            "categoria": "Accesorios",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Monitor Samsung 24\"",
            "precio": 199.99,
            "stock": 20,
            "categoria": "Electrónicos",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Auriculares Sony WH-1000XM4",
            "precio": 349.99,
            "stock": 10,
            "categoria": "Audio",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Cable HDMI 2m",
            "precio": 12.99,
            "stock": 100,
            "categoria": "Cables",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Webcam Logitech C920",
            "precio": 79.99,
            "stock": 30,
            "categoria": "Video",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Disco Duro Externo 1TB",
            "precio": 59.99,
            "stock": 40,
            "categoria": "Almacenamiento",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Memoria RAM 8GB DDR4",
            "precio": 45.99,
            "stock": 35,
            "categoria": "Componentes",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Fuente de Poder 650W",
            "precio": 89.99,
            "stock": 15,
            "categoria": "Componentes",
            "fecha_creacion": generar_fecha_reciente(60)
        }
    ]
    return productos

def generar_clientes():
    """Genera una lista de clientes de prueba"""
    clientes = [
        {
            "id": generar_id(),
            "nombre": "María González",
            "email": "maria.gonzalez@email.com",
            "telefono": "+52 55 1234 5678",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Carlos Rodríguez",
            "email": "carlos.rodriguez@email.com",
            "telefono": "+52 55 2345 6789",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Ana Martínez",
            "email": "ana.martinez@email.com",
            "telefono": "+52 55 3456 7890",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Luis Pérez",
            "email": "luis.perez@email.com",
            "telefono": "+52 55 4567 8901",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Sofia López",
            "email": "sofia.lopez@email.com",
            "telefono": "+52 55 5678 9012",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Diego Hernández",
            "email": "diego.hernandez@email.com",
            "telefono": "+52 55 6789 0123",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Valentina Torres",
            "email": "valentina.torres@email.com",
            "telefono": "+52 55 7890 1234",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Roberto Silva",
            "email": "roberto.silva@email.com",
            "telefono": "+52 55 8901 2345",
            "fecha_registro": generar_fecha_reciente(90)
        }
    ]
    return clientes

def generar_ventas(productos, clientes):
    """Genera una lista de ventas de prueba"""
    ventas = []
    estados = ["completada", "pendiente", "cancelada"]
    
    # Generar 20 ventas de prueba
    for _ in range(20):
        # Seleccionar cliente aleatorio
        cliente = random.choice(clientes)
        
        # Generar 1-4 items por venta
        num_items = random.randint(1, 4)
        items = []
        total = 0
        
        # Seleccionar productos únicos para esta venta
        productos_venta = random.sample(productos, min(num_items, len(productos)))
        
        for producto in productos_venta:
            cantidad = random.randint(1, 3)
            precio_unitario = producto["precio"]
            subtotal = cantidad * precio_unitario
            total += subtotal
            
            items.append({
                "producto_id": producto["id"],
                "cantidad": cantidad,
                "precio_unitario": precio_unitario
            })
        
        venta = {
            "id": generar_id(),
            "cliente_id": cliente["id"],
            "items": items,
            "total": round(total, 2),
            "fecha": generar_fecha_reciente(30),
            "estado": random.choice(estados)
        }
        ventas.append(venta)
    
    return ventas

def main():
    """Función principal para generar todos los datos de prueba"""
    print("Generando datos de prueba para el sistema POS...")
    
    # Generar datos
    productos = generar_productos()
    clientes = generar_clientes()
    ventas = generar_ventas(productos, clientes)
    
    # Crear estructura de base de datos
    database = {
        "productos": productos,
        "clientes": clientes,
        "ventas": ventas
    }
    
    # Guardar en archivo JSON
    with open("pos_database.json", "w", encoding="utf-8") as f:
        json.dump(database, f, indent=2, ensure_ascii=False)
    
    print(f"✅ Datos generados exitosamente:")
    print(f"   - {len(productos)} productos")
    print(f"   - {len(clientes)} clientes")
    print(f"   - {len(ventas)} ventas")
    print(f"   - Archivo guardado en: pos_database.json")

if __name__ == "__main__":
    main() 