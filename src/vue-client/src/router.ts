import { createRouter, createWebHistory } from 'vue-router'
import ProjectsView from './views/ProjectsView.vue'
import TracksView from './views/TracksView.vue'
import NotFoundView from './views/NotFoundView.vue'
import LoginView from './views/LoginView.vue'

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/Login',
      name: 'Login',
      component: LoginView
    },
    {
      path: '/projects',
      name: 'Projects',
      component: ProjectsView
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
