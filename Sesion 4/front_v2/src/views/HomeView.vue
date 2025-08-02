<template>
  <div class="home">
    <div class="welcome-section">
      <h2>Bienvenido al RUHRPUMPEN Extranet</h2>
      <p>Sistema de gestión y seguimiento de patrones y órdenes de compra</p>
    </div>
    
    <div class="quick-actions">
      <div class="action-card">
        <h3>Pattern Tracking</h3>
        <p>Gestiona y rastrea patrones de fabricación</p>
        <router-link to="/pattern-tracking" class="action-btn">Acceder</router-link>
      </div>
      
      <div class="action-card">
        <h3>PO Confirmation</h3>
        <p>Confirma y gestiona órdenes de compra</p>
        <router-link to="/po-confirmation" class="action-btn">Acceder</router-link>
      </div>
      
      <div class="action-card">
        <h3>Administration</h3>
        <p>Configuración y administración del sistema</p>
        <router-link to="/administration" class="action-btn">Acceder</router-link>
      </div>
      
      <div class="action-card">
        <h3>Company</h3>
        <p>Información de la empresa</p>
        <router-link to="/company" class="action-btn">Acceder</router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'HomeView'
}
</script>

<style scoped>
.home {
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

.welcome-section {
  text-align: center;
  margin-bottom: 40px;
  background: white;
  padding: 40px;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

.welcome-section h2 {
  color: #1e40af;
  font-size: 32px;
  font-weight: bold;
  margin-bottom: 10px;
}

.welcome-section p {
  color: #6b7280;
  font-size: 18px;
  margin: 0;
}

.quick-actions {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
  gap: 20px;
}

.action-card {
  background: white;
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
  transition: transform 0.3s, box-shadow 0.3s;
}

.action-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.15);
}

.action-card h3 {
  color: #1e40af;
  font-size: 20px;
  font-weight: bold;
  margin-bottom: 10px;
}

.action-card p {
  color: #6b7280;
  margin-bottom: 20px;
  line-height: 1.5;
}

.action-btn {
  display: inline-block;
  padding: 10px 20px;
  background: #2563eb;
  color: white;
  text-decoration: none;
  border-radius: 6px;
  font-weight: 500;
  transition: background-color 0.3s;
}

.action-btn:hover {
  background: #1d4ed8;
}

@media (max-width: 768px) {
  .welcome-section {
    padding: 30px 20px;
  }
  
  .welcome-section h2 {
    font-size: 24px;
  }
  
  .welcome-section p {
    font-size: 16px;
  }
  
  .quick-actions {
    grid-template-columns: 1fr;
  }
  
  .action-card {
    padding: 25px 20px;
  }
}
</style> 