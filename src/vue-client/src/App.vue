<script setup lang="ts">
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';
</script>

<template>
  <VApp>
    <Navbar />
    <VMain class="d-flex justify-center mb-6 w-20">
      <div class="w-50">
        <RouterView />
      </div>
    </VMain>
  </VApp>
</template>