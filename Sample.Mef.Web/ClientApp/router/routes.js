import Home from 'pages/home'
import NotFound404 from 'pages/404'

export const routes = [
  { showMenu: false, name: '404', path: '/404', component: NotFound404 },
  { showMenu: true, name: 'home', path: '/', component: Home, display: 'Home', icon: 'icon-home' },
  { showMenu: false, name: 'catchAll', path: '*', redirect: '/404' }
]
