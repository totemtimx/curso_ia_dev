# Datos de Prueba para Sistema POS

Este directorio contiene scripts para generar datos de prueba realistas para el sistema POS (Point of Sale).

## 📁 Archivos de Datos

### `pos_database.json`
Archivo principal de la base de datos que contiene:
- **22 productos** en 11 categorías diferentes
- **13 clientes** (8 individuales, 5 empresariales)
- **35 ventas** con diferentes estados y montos

## 🛠️ Scripts Disponibles

### 1. `generate_test_data.py`
Script principal para generar datos básicos de prueba.

**Uso:**
```bash
python3 generate_test_data.py
```

**Genera:**
- 10 productos en categorías básicas (Electrónicos, Accesorios, etc.)
- 8 clientes individuales
- 20 ventas con diferentes patrones

### 2. `generate_more_test_data.py`
Script para agregar datos adicionales a la base existente.

**Uso:**
```bash
python3 generate_more_test_data.py
```

**Agrega:**
- 12 productos adicionales en nuevas categorías (Gaming, Oficina, Red, Seguridad)
- 5 clientes empresariales
- 15 ventas adicionales

### 3. `show_database_stats.py`
Script para mostrar estadísticas y análisis de la base de datos.

**Uso:**
```bash
python3 show_database_stats.py
```

**Muestra:**
- Resumen general de la base de datos
- Estadísticas de productos por categoría
- Análisis de clientes (individuales vs empresariales)
- Estadísticas de ventas y productos más vendidos

## 📊 Estadísticas Actuales

### Productos
- **Total:** 22 productos
- **Categorías:** 11 (Gaming, Oficina, Red, Seguridad, Electrónicos, etc.)
- **Precio promedio:** $167.13
- **Rango de precios:** $12.99 - $899.99

### Clientes
- **Total:** 13 clientes
- **Individuales:** 8
- **Empresariales:** 5

### Ventas
- **Total:** 35 ventas
- **Estados:** Completada (12), Pendiente (10), Cancelada (13)
- **Venta promedio:** $1,044.60
- **Ingresos totales:** $36,560.86

## 🎯 Categorías de Productos

1. **Gaming** - Productos para videojuegos
2. **Oficina** - Equipos de oficina
3. **Red** - Equipos de networking
4. **Seguridad** - Sistemas de vigilancia
5. **Electrónicos** - Dispositivos electrónicos
6. **Accesorios** - Accesorios de computadora
7. **Componentes** - Partes de computadora
8. **Audio** - Equipos de audio
9. **Cables** - Cables y conectores
10. **Video** - Equipos de video
11. **Almacenamiento** - Dispositivos de almacenamiento

## 🔄 Cómo Regenerar Datos

Si necesitas regenerar completamente los datos de prueba:

1. **Eliminar archivo actual:**
   ```bash
   rm pos_database.json
   ```

2. **Generar datos básicos:**
   ```bash
   python3 generate_test_data.py
   ```

3. **Agregar datos adicionales (opcional):**
   ```bash
   python3 generate_more_test_data.py
   ```

4. **Verificar estadísticas:**
   ```bash
   python3 show_database_stats.py
   ```

## 📝 Notas Importantes

- Los datos se generan con IDs únicos usando UUID
- Las fechas se generan aleatoriamente en los últimos 30-90 días
- Los precios y cantidades son realistas para un negocio de tecnología
- Las ventas incluyen diferentes estados para simular un entorno real
- Los clientes incluyen tanto personas individuales como empresas

## 🚀 Uso con la API

Una vez generados los datos, puedes usar la API del sistema POS para:

- Consultar productos: `GET /productos`
- Consultar clientes: `GET /clientes`
- Consultar ventas: `GET /ventas`
- Generar reportes: `GET /reportes/ventas`

Los datos están listos para ser utilizados inmediatamente con el sistema POS. 