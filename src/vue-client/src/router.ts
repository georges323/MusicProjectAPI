import { createRouter, createWebHistory } from 'vue-router'
import ProjectsView from './views/ProjectsView.vue'
import TracksView from './views/TracksView.vue'
import NotFoundView from './views/NotFoundView.vue'

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      name: 'Projects',
      component: ProjectsView,
    },
    {
      path: '/tracks/:projectId',
      name: 'Tracks',
      component: TracksView,
      props: true
    },
    {
      path: '/:pathMatch(.*)*',
      name: "NotFound",
      component: NotFoundView
    }
  ],
})
