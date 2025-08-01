#!/usr/bin/env python3
"""
Script para generar datos de prueba adicionales para el sistema POS
Incluye más productos, clientes y ventas con diferentes categorías
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

def generar_productos_adicionales():
    """Genera productos adicionales con más categorías"""
    productos_adicionales = [
        # Productos de Gaming
        {
            "id": generar_id(),
            "nombre": "Mouse Gaming Razer DeathAdder",
            "precio": 69.99,
            "stock": 20,
            "categoria": "Gaming",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Teclado Gaming Corsair K70",
            "precio": 149.99,
            "stock": 12,
            "categoria": "Gaming",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Headset Gaming HyperX Cloud II",
            "precio": 89.99,
            "stock": 18,
            "categoria": "Gaming",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        
        # Productos de Oficina
        {
            "id": generar_id(),
            "nombre": "Impresora HP LaserJet Pro",
            "precio": 299.99,
            "stock": 8,
            "categoria": "Oficina",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Escáner Canon CanoScan",
            "precio": 129.99,
            "stock": 15,
            "categoria": "Oficina",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Proyector Epson PowerLite",
            "precio": 599.99,
            "stock": 5,
            "categoria": "Oficina",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        
        # Productos de Red
        {
            "id": generar_id(),
            "nombre": "Router WiFi TP-Link Archer",
            "precio": 79.99,
            "stock": 25,
            "categoria": "Red",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Switch Gigabit Netgear",
            "precio": 45.99,
            "stock": 30,
            "categoria": "Red",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Cable de Red Cat6 100m",
            "precio": 35.99,
            "stock": 50,
            "categoria": "Red",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        
        # Productos de Seguridad
        {
            "id": generar_id(),
            "nombre": "Cámara IP Hikvision",
            "precio": 89.99,
            "stock": 22,
            "categoria": "Seguridad",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "DVR 8 Canales",
            "precio": 199.99,
            "stock": 10,
            "categoria": "Seguridad",
            "fecha_creacion": generar_fecha_reciente(60)
        },
        {
            "id": generar_id(),
            "nombre": "Sensor de Movimiento PIR",
            "precio": 25.99,
            "stock": 40,
            "categoria": "Seguridad",
            "fecha_creacion": generar_fecha_reciente(60)
        }
    ]
    return productos_adicionales

def generar_clientes_adicionales():
    """Genera clientes adicionales"""
    clientes_adicionales = [
        {
            "id": generar_id(),
            "nombre": "Empresa ABC S.A.",
            "email": "compras@empresaabc.com",
            "telefono": "+52 55 1111 2222",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Universidad Tecnológica",
            "email": "ti@universidad.edu.mx",
            "telefono": "+52 55 3333 4444",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Clínica Médica Central",
            "email": "sistemas@clinicacentral.com",
            "telefono": "+52 55 5555 6666",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Restaurante El Buen Sabor",
            "email": "admin@elbuensabor.com",
            "telefono": "+52 55 7777 8888",
            "fecha_registro": generar_fecha_reciente(90)
        },
        {
            "id": generar_id(),
            "nombre": "Hotel Plaza Mayor",
            "email": "recepcion@hotelplaza.com",
            "telefono": "+52 55 9999 0000",
            "fecha_registro": generar_fecha_reciente(90)
        }
    ]
    return clientes_adicionales

def generar_ventas_adicionales(productos, clientes):
    """Genera ventas adicionales con diferentes patrones"""
    ventas = []
    estados = ["completada", "pendiente", "cancelada"]
    
    # Generar 15 ventas adicionales
    for _ in range(15):
        cliente = random.choice(clientes)
        
        # Generar 1-5 items por venta
        num_items = random.randint(1, 5)
        items = []
        total = 0
        
        # Seleccionar productos únicos para esta venta
        productos_venta = random.sample(productos, min(num_items, len(productos)))
        
        for producto in productos_venta:
            cantidad = random.randint(1, 5)  # Más cantidad para ventas corporativas
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
    """Función principal para generar datos adicionales"""
    print("Generando datos de prueba adicionales para el sistema POS...")
    
    # Generar datos adicionales
    productos_adicionales = generar_productos_adicionales()
    clientes_adicionales = generar_clientes_adicionales()
    
    # Cargar datos existentes
    try:
        with open("pos_database.json", "r", encoding="utf-8") as f:
            database = json.load(f)
    except FileNotFoundError:
        print("❌ No se encontró el archivo pos_database.json")
        return
    
    # Agregar nuevos datos
    database["productos"].extend(productos_adicionales)
    database["clientes"].extend(clientes_adicionales)
    
    # Generar ventas adicionales con todos los productos
    todos_productos = database["productos"]
    todos_clientes = database["clientes"]
    ventas_adicionales = generar_ventas_adicionales(todos_productos, todos_clientes)
    database["ventas"].extend(ventas_adicionales)
    
    # Guardar archivo actualizado
    with open("pos_database.json", "w", encoding="utf-8") as f:
        json.dump(database, f, indent=2, ensure_ascii=False)
    
    print(f"✅ Datos adicionales generados exitosamente:")
    print(f"   - {len(productos_adicionales)} productos adicionales")
    print(f"   - {len(clientes_adicionales)} clientes adicionales")
    print(f"   - {len(ventas_adicionales)} ventas adicionales")
    print(f"   - Total en base de datos:")
    print(f"     * {len(database['productos'])} productos")
    print(f"     * {len(database['clientes'])} clientes")
    print(f"     * {len(database['ventas'])} ventas")

if __name__ == "__main__":
    main() 