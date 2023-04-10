import { createRouter, createWebHistory } from 'vue-router'

import home from '../pages/home'
import crud from '../pages/crud'
import search from '../pages/search'

const routes = [
  {
    name:'Home',
    path:'/',
    component:home
  },
  {
    name:'Search',
    path:'/search',
    component:search
  },
  {
    name:'Crud',
    path:'/datamanager',
    component:crud
  },
  {
    name:'CrudWithId',
    path:'/datamanager/:id',
    component: crud,
    props: true,
  },
 
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
  


