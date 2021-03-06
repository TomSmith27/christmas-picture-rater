import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import './plugins/bootstrap-vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import './styles.scss'

Vue.config.productionTip = false   

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
