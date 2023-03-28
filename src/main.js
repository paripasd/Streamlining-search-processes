import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'

//import router
import router from './router'

//import CSS
import './assets/CSS/app.css'
const app = createApp(App).use(createPinia())
app.use(router)
app.mount('#app')