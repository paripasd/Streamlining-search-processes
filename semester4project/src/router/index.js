import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '@/stores/AuthStore'

import home from '../pages/home'
import crud from '../pages/crud'
import search from '../pages/search'
import login from '../pages/login'

const routes = [
  {
    name:'Home',
    path:'/',
    component:home,
    redirect: '/search',
    meta: { requiresAuth: true },
  },
  {
    name:'Search',
    path:'/search',
    component:search,
    meta: { requiresAuth: true },
  },
  {
    name:'Crud',
    path:'/datamanager',
    component:crud,
    meta: { requiresAuth: true },
  },
  {
    name:'CrudWithId',
    path:'/datamanager/:id',
    component: crud,
    props: true,
    meta: { requiresAuth: true },
  },
  {
    name:'Login',
    path:'/login',
    component:login,
  },
 
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);
  const authStore = useAuthStore();
  const isLoggedIn = authStore.isLoggedIn;

  if (requiresAuth && !isLoggedIn) {
    next({ path: '/login', query: { redirect: to.fullPath } });
  } else {
    next();
  }
});

export default router;
  


