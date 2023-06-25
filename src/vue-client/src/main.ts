import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import vue3GoogleLogin from 'vue3-google-login'

loadFonts();

const app = createApp(App);
app.use(vuetify);
app.use(router);

app.use(vue3GoogleLogin, {
    clientId: import.meta.env.VITE_CLIENTID
})

app.mount('#app');