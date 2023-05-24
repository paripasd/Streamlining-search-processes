//------------------------------------------------------------
// USED ONLY FOR LOGGING IN WITHOUT AUTHENTICATION, NOT SECURE
//------------------------------------------------------------

import { defineStore } from 'pinia';

export const useAuthStore = defineStore('auth', {
  state: () => ({
    isLoggedIn: sessionStorage.getItem('isLoggedIn') === 'true',
    user: {username:'', password:''},
  }),
  
  actions: {
    setLoggedIn(value) {
      this.isLoggedIn = value;
      sessionStorage.setItem('isLoggedIn', value);
    },
  },
});
