<template>
  <div class="about">
    <h1>Esta es la página Acerca de</h1>
    <p>Esta es una aplicación Vue.js creada con Vite.</p>
    <p>Características incluidas:</p>
    <ul>
      <li>Vue 3 con Composition API</li>
      <li>Vue Router para navegación</li>
      <li>Vite como bundler</li>
      <li>ESLint para linting</li>
      <li>Prettier para formateo de código</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'AboutView'
}
</script>

<style scoped>
.about {
  max-width: 600px;
  margin: 0 auto;
  text-align: left;
}

h1 {
  color: #42b983;
  margin-bottom: 20px;
}

ul {
  margin-top: 20px;
  padding-left: 20px;
}

li {
  margin: 10px 0;
}
</style> 