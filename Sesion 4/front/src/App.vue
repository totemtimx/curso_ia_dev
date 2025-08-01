<template>
  <div id="app">
    <!-- Header Superior con Banner -->
    <div class="top-banner">
      <div class="banner-content">
        <div class="banner-design">
          <div class="glow-effect"></div>
        </div>
        <div class="user-info">
          <span>Bienvenido Terence Golla | Login as Vendor | Logout</span>
          <div class="company-info">
            <span>RUHRPUMPEN, INC. (R0004)</span>
            <span>RuhRPumpen S.A.</span>
          </div>
        </div>
      </div>
    </div>

    <!-- Título Principal -->
    <div class="main-title">
      <h1>RUHRPUMPEN EXTRANET</h1>
    </div>

    <!-- Barra de Navegación -->
    <nav class="main-nav">
      <router-link to="/" class="nav-item">Home</router-link>
      <router-link to="/pattern-tracking" class="nav-item active">Pattern Tracking</router-link>
      <router-link to="/po-confirmation" class="nav-item">PO Confirmation</router-link>
      <router-link to="/administration" class="nav-item">Administration</router-link>
      <router-link to="/company" class="nav-item">Company</router-link>
    </nav>

    <!-- Contenido Principal -->
    <main class="main-content">
      <router-view />
    </main>

    <!-- Footer -->
    <footer class="footer">
      <p>Copyright © 2013 Ruhrpumpen Group. All rights reserved.</p>
    </footer>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

#app {
  font-family: Arial, Helvetica, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #333;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

/* Top Banner */
.top-banner {
  background: linear-gradient(135deg, #1e3a8a 0%, #1e40af 100%);
  color: white;
  padding: 10px 0;
}

.banner-content {
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 20px;
}

.banner-design {
  position: relative;
  width: 200px;
  height: 40px;
}

.glow-effect {
  width: 100%;
  height: 100%;
  background: linear-gradient(90deg, #60a5fa, #ffffff, #60a5fa);
  border-radius: 20px;
  opacity: 0.3;
  animation: glow 3s ease-in-out infinite alternate;
}

@keyframes glow {
  from { opacity: 0.3; }
  to { opacity: 0.6; }
}

.user-info {
  text-align: right;
  font-size: 12px;
}

.user-info span {
  display: block;
  margin-bottom: 2px;
}

.company-info {
  margin-top: 5px;
}

.company-info span {
  display: block;
  font-size: 11px;
  opacity: 0.9;
}

/* Main Title */
.main-title {
  background: linear-gradient(135deg, #1e40af 0%, #3b82f6 100%);
  color: white;
  padding: 20px 0;
  text-align: center;
}

.main-title h1 {
  font-size: 32px;
  font-weight: bold;
  letter-spacing: 2px;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
}

/* Navigation */
.main-nav {
  background: #2563eb;
  padding: 0;
  display: flex;
  justify-content: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.nav-item {
  color: white;
  text-decoration: none;
  padding: 15px 25px;
  font-weight: 500;
  transition: background-color 0.3s;
  border-bottom: 3px solid transparent;
}

.nav-item:hover {
  background-color: #1d4ed8;
}

.nav-item.active {
  background-color: #1d4ed8;
  border-bottom-color: #fbbf24;
}

/* Main Content */
.main-content {
  flex: 1;
  background: #f8fafc;
  padding: 20px;
}

/* Footer */
.footer {
  background: #1e3a8a;
  color: white;
  text-align: center;
  padding: 15px 0;
  font-size: 14px;
}

/* Responsive Design */
@media (max-width: 768px) {
  .banner-content {
    flex-direction: column;
    text-align: center;
  }
  
  .user-info {
    text-align: center;
    margin-top: 10px;
  }
  
  .main-nav {
    flex-wrap: wrap;
  }
  
  .nav-item {
    padding: 10px 15px;
    font-size: 14px;
  }
}
</style> 