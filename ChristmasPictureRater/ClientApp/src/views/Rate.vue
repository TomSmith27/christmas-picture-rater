<template>
 <div>
	<h3>Who drew the best {{ image1.category }}</h3>
	<b-row class="justify-content-center align-content-center">
	 <b-col cols="5">
		<div class="d-flex flex-column">
		 <img class="img-fluid" :src="image1.image" alt="">
		 by {{ image1.artistsName }}
		</div>
		<b-button size="lg" variant="success">
		 <b-icon-hand-thumbs-up @click="like(image1.id)" />
		</b-button>
	 </b-col>
	 <b-col cols="1" class="align-self-center">vs</b-col>
	 <b-col cols="5">
		<div class="d-flex flex-column">
		 <img class="img-fluid" :src="image2.image" alt="">
		 by {{ image2.artistsName }}
		</div>
		<b-button size="lg" variant="success" >
		 <b-icon-hand-thumbs-up @click="like(image2.id)" />
		</b-button>
	 </b-col>
	</b-row>
 </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Axios from "axios";

export default Vue.extend({
  name: "Rate",
  data() {
    return {
      image1: {},
      image2: {}
    }
  },
  async created() {
    this.getDrawingsToCompare()
  },
  methods: {
    async like(id: number) {
      await Axios.post(`picture/like/${id}`)
      this.getDrawingsToCompare();
    },
    async getDrawingsToCompare() {
      const drawings = (await Axios.get('picture/compare')).data;
      this.image1 = drawings.drawing1
      this.image2 = drawings.drawing2
    }
  }
})
</script>