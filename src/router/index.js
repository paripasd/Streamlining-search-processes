import { createRouter, createWebHistory } from 'vue-router'
import dashboard from '../pages/master/dashboard.vue'

import home from '../pages/home'
import crud from '../pages/crud'

const routes = [
  {
    name:'Dashboard',
    path:'/',
    component: dashboard
  },
  {
    name:'Home',
    path:'/home',
    component:home
  },
  {
    name:'Crud',
    path:'/crud',
    component:crud
  }
 
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
  


