#!/usr/bin/env python3
"""
Script para mostrar estadísticas de la base de datos POS
Muestra resumen de productos, clientes y ventas
"""

import json
from collections import Counter
from datetime import datetime

def cargar_database():
    """Carga la base de datos desde el archivo JSON"""
    try:
        with open("pos_database.json", "r", encoding="utf-8") as f:
            return json.load(f)
    except FileNotFoundError:
        print("❌ No se encontró el archivo pos_database.json")
        return None

def mostrar_estadisticas_productos(productos):
    """Muestra estadísticas de productos"""
    print("\n📦 ESTADÍSTICAS DE PRODUCTOS")
    print("=" * 50)
    
    # Contar por categoría
    categorias = Counter([p["categoria"] for p in productos])
    print(f"Total de productos: {len(productos)}")
    print(f"Categorías disponibles: {len(categorias)}")
    
    print("\nProductos por categoría:")
    for categoria, cantidad in categorias.most_common():
        print(f"  • {categoria}: {cantidad} productos")
    
    # Estadísticas de precios
    precios = [p["precio"] for p in productos]
    print(f"\nPrecios:")
    print(f"  • Precio mínimo: ${min(precios):.2f}")
    print(f"  • Precio máximo: ${max(precios):.2f}")
    print(f"  • Precio promedio: ${sum(precios)/len(precios):.2f}")
    
    # Productos con bajo stock (menos de 10)
    bajo_stock = [p for p in productos if p["stock"] < 10]
    print(f"\nProductos con bajo stock (< 10): {len(bajo_stock)}")
    for producto in bajo_stock:
        print(f"  • {producto['nombre']}: {producto['stock']} unidades")

def mostrar_estadisticas_clientes(clientes):
    """Muestra estadísticas de clientes"""
    print("\n👥 ESTADÍSTICAS DE CLIENTES")
    print("=" * 50)
    
    print(f"Total de clientes: {len(clientes)}")
    
    # Separar clientes individuales y empresas
    clientes_individuales = [c for c in clientes if not any(palabra in c["nombre"].lower() for palabra in ["s.a.", "universidad", "clínica", "restaurante", "hotel"])]
    clientes_empresas = [c for c in clientes if any(palabra in c["nombre"].lower() for palabra in ["s.a.", "universidad", "clínica", "restaurante", "hotel"])]
    
    print(f"Clientes individuales: {len(clientes_individuales)}")
    print(f"Clientes empresariales: {len(clientes_empresas)}")
    
    print("\nClientes empresariales:")
    for cliente in clientes_empresas:
        print(f"  • {cliente['nombre']}")

def mostrar_estadisticas_ventas(ventas, productos, clientes):
    """Muestra estadísticas de ventas"""
    print("\n💰 ESTADÍSTICAS DE VENTAS")
    print("=" * 50)
    
    print(f"Total de ventas: {len(ventas)}")
    
    # Estadísticas por estado
    estados = Counter([v["estado"] for v in ventas])
    print("\nVentas por estado:")
    for estado, cantidad in estados.items():
        print(f"  • {estado.capitalize()}: {cantidad} ventas")
    
    # Estadísticas de montos
    montos = [v["total"] for v in ventas]
    print(f"\nMontos:")
    print(f"  • Venta mínima: ${min(montos):.2f}")
    print(f"  • Venta máxima: ${max(montos):.2f}")
    print(f"  • Venta promedio: ${sum(montos)/len(montos):.2f}")
    print(f"  • Total de ingresos: ${sum(montos):.2f}")
    
    # Productos más vendidos
    print("\nProductos más vendidos:")
    productos_vendidos = Counter()
    for venta in ventas:
        for item in venta["items"]:
            productos_vendidos[item["producto_id"]] += item["cantidad"]
    
    # Crear diccionario de productos para buscar nombres
    productos_dict = {p["id"]: p["nombre"] for p in productos}
    
    for producto_id, cantidad in productos_vendidos.most_common(5):
        nombre = productos_dict.get(producto_id, "Producto desconocido")
        print(f"  • {nombre}: {cantidad} unidades")

def mostrar_resumen_general(database):
    """Muestra un resumen general de la base de datos"""
    print("\n📊 RESUMEN GENERAL DE LA BASE DE DATOS")
    print("=" * 60)
    
    productos = database["productos"]
    clientes = database["clientes"]
    ventas = database["ventas"]
    
    print(f"📦 Productos: {len(productos)}")
    print(f"👥 Clientes: {len(clientes)}")
    print(f"💰 Ventas: {len(ventas)}")
    
    # Calcular valor total del inventario
    valor_inventario = sum(p["precio"] * p["stock"] for p in productos)
    print(f"📈 Valor total del inventario: ${valor_inventario:,.2f}")
    
    # Calcular ingresos totales
    ingresos_totales = sum(v["total"] for v in ventas if v["estado"] == "completada")
    print(f"💵 Ingresos totales (ventas completadas): ${ingresos_totales:,.2f}")

def main():
    """Función principal"""
    print("🔍 ANALIZANDO BASE DE DATOS POS")
    print("=" * 60)
    
    # Cargar base de datos
    database = cargar_database()
    if not database:
        return
    
    # Mostrar estadísticas
    mostrar_resumen_general(database)
    mostrar_estadisticas_productos(database["productos"])
    mostrar_estadisticas_clientes(database["clientes"])
    mostrar_estadisticas_ventas(database["ventas"], database["productos"], database["clientes"])
    
    print("\n✅ Análisis completado")

if __name__ == "__main__":
    main() 