<template>
 <div id="app">
	<b-navbar toggleable="lg" variant="light">
	 <b-navbar-brand href="#">Christmas Draw</b-navbar-brand>

	 <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

	 <b-collapse id="nav-collapse" is-nav>
		<b-navbar-nav>
		 <b-nav-item to="/">Home</b-nav-item>
		 <b-nav-item to="/draw">Draw</b-nav-item>
		 <b-nav-item to="/rate">Rate</b-nav-item>
		</b-navbar-nav>
	 </b-collapse>
	</b-navbar>
	<router-view />

 </div>
</template>

<style lang="scss">
#app {
  text-align: center;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
