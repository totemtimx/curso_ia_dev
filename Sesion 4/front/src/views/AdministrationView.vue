<template>
  <div class="administration">
    <div class="page-header">
      <h2>Administration</h2>
    </div>
    <div class="content">
      <p>Esta página está en desarrollo. Aquí se mostrará la funcionalidad de administración del sistema.</p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AdministrationView'
}
</script>

<style scoped>
.administration {
  max-width: 1200px;
  margin: 0 auto;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.page-header {
  background: white;
  padding: 20px;
  border-bottom: 1px solid #e5e7eb;
}

.page-header h2 {
  color: #1e40af;
  font-size: 24px;
  font-weight: bold;
  margin: 0;
}

.content {
  padding: 40px 20px;
  text-align: center;
  color: #6b7280;
}
</style> 