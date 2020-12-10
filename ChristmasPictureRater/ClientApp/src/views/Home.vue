<template>
 <b-container className="text-center">
	<h1>Welcome to Christmas Picture Rater!</h1>
	<h2>What would you like to do?</h2>
	<div class="d-flex justify-content-center">
	 <b-button :to="{name : 'rate'}" variant="primary" size="lg">Rate Drawings!</b-button>
	 or
	 <b-button :to="{name : 'draw'}" variant="primary" size="lg">Draw!</b-button>
	</div>
 </b-container>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'Home',
  components: {},
});
</script>
