import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PatternTrackingView from '../views/PatternTrackingView.vue'
import PatternDetailView from '../views/PatternDetailView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/pattern-tracking',
    name: 'pattern-tracking',
    component: PatternTrackingView
  },
  {
    path: '/pattern/:id',
    name: 'pattern-detail',
    component: PatternDetailView
  },
  {
    path: '/po-confirmation',
    name: 'po-confirmation',
    component: () => import('../views/POConfirmationView.vue')
  },
  {
    path: '/administration',
    name: 'administration',
    component: () => import('../views/AdministrationView.vue')
  },
  {
    path: '/company',
    name: 'company',
    component: () => import('../views/CompanyView.vue')
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (About.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router 