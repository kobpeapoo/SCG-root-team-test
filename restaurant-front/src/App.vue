<template>
  <div id="app">
    <Navigation />
    <ListRestaurant />
  </div>
</template>

<script>
import Navigation from './components/navigation.vue'
import ListRestaurant from './components/ListRestaurants'
export default {
  name: 'App',
  components: {
    Navigation,
    ListRestaurant
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
