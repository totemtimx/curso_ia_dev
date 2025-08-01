#!/bin/bash

echo "Probando creación de usuario..."

curl -X POST "https://localhost:7000/api/message/process" \
  -H "Content-Type: application/json" \
  -d '{
    "message": "Quiero crear un usuario llamado Juan Pérez",
    "userEmail": "juan@ejemplo.com"
  }' \
  --insecure

echo -e "\n\nProbando información de producto..."

curl -X POST "https://localhost:7000/api/message/process" \
  -H "Content-Type: application/json" \
  -d '{
    "message": "¿Pueden enviarme información sobre el producto X?",
    "userEmail": "cliente@ejemplo.com"
  }' \
  --insecure

echo -e "\n\nProbando otro tipo de mensaje..."

curl -X POST "https://localhost:7000/api/message/process" \
  -H "Content-Type: application/json" \
  -d '{
    "message": "Tengo una pregunta general sobre el servicio",
    "userEmail": "usuario@ejemplo.com"
  }' \
  --insecure 