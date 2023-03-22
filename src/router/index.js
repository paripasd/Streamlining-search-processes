import { createRouter, createWebHistory } from 'vue-router'

import home from '../pages/home'
import crud from '../pages/crud'

const routes = [
  {
    name:'Home',
    path:'/',
    component:home
  },
  {
    name:'Crud',
    path:'/crud',
    component:crud
  },
 
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
  


