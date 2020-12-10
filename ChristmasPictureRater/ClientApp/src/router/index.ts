import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/draw',
    name: 'draw',
    component: () => import(/* webpackChunkName: "draw */ '../views/Draw.vue')
  },
  {
    path: '/rate',
    name: 'rate',
    component: () => import(/* webpackChunkName: "rate */ '../views/Rate.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
