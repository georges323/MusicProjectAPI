import { createRouter, createWebHistory } from 'vue-router'
import Projects from './components/Projects.vue'
import Tracks from './components/Tracks.vue'

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      name: 'Projects',
      component: Projects,
    },
    {
      path: '/tracks/:projectId',
      name: 'Tracks',
      component: Tracks,
      props: true
    }
  ],
})
