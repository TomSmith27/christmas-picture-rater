<template>
 <div class="container">
	<h1>Draw a {{ category }}</h1>
	<canvas ref="canvas" @toucMove="onMouseMove" @mousedown="onMouseDown" @mousemove="onMouseMove" @mouseup="onMouseUp"
					width="300" height="400"
					id="paint-canvas"></canvas>
	<div id="paint-canvas-controls">
	 <input @change="onColourChange" v-model="colour" class="form-control" type="color" />
	 <b-button-group class="my-2 w-100" >
		<b-button :pressed="size === brushSize" squared @click="changeBrushSize(size)"
							:variant="size == brushSize ? 'primary' : 'outline-primary'" v-for="size in 5">
		 <b-icon-circle-fill :scale="0.2 * size" :shift-v="-(size * 0.2)" />
		</b-button>
	 </b-button-group>
	</div>
	<b-button @click="submit" block variant="success">Submit</b-button>
 </div>
</template>

<script lang="ts">
import Vue, { VueConstructor } from 'vue';
import Axios from "axios";

const draw = Vue as VueConstructor<Vue & { $refs: { canvas: HTMLCanvasElement; } }>

export default draw.extend({
  name: "Draw",
  data() {
    return {
      isDrawing: false,
      mouse: {
        x: 0,
        y: 0
      },
      brushSize: 1,
      colour: '#000000',
      category: 'Snowman'
    }
  },
  computed: {
    context() {
      return this.$refs.canvas.getContext("2d")!
    },
  },
  mounted() {
    this.handleTouchInput();
  },
  methods: {
    setMouseCoordinates(event: MouseEvent) {
      const boundings = this.$refs.canvas.getBoundingClientRect();
      this.mouse.x = event.clientX - boundings.left;
      this.mouse.y = event.clientY - boundings.top;
    },
    onMouseDown(event: MouseEvent) {

      this.setMouseCoordinates(event);
      this.isDrawing = true;

      // Start Drawing
      this.context.beginPath();
      this.context.moveTo(this.mouse.x, this.mouse.y);
    },
    onMouseMove(event: MouseEvent) {
      this.setMouseCoordinates(event);

      if (this.isDrawing) {
        this.context.lineTo(this.mouse.x, this.mouse.y);
        this.context.stroke();
      }
    },
    onMouseUp(event: MouseEvent) {
      this.setMouseCoordinates(event);
      this.isDrawing = false;
    },
    onColourChange() {
      this.context.strokeStyle = this.colour;
    },
    changeBrushSize(brushSize: number) {
      this.brushSize = brushSize;
      this.context.lineWidth = brushSize * 3
    },
    handleTouchInput() {
      const canvas = this.$refs.canvas;
      // Set up touch events for mobile, etc
      canvas.addEventListener("touchstart", function (e) {
        const touch = e.touches[0];
        const mouseEvent = new MouseEvent("mousedown", {
          clientX: touch.clientX,
          clientY: touch.clientY
        });
        canvas.dispatchEvent(mouseEvent);
      }, false);
      canvas.addEventListener("touchend", function (e) {
        const mouseEvent = new MouseEvent("mouseup", {});
        canvas.dispatchEvent(mouseEvent);
      }, false);
      canvas.addEventListener("touchmove", function (e) {
        const touch = e.touches[0];
        const mouseEvent = new MouseEvent("mousemove", {
          clientX: touch.clientX,
          clientY: touch.clientY
        });
        canvas.dispatchEvent(mouseEvent);
      }, false);
    },
    async submit() {
      await Axios.post('picture/upload', {
        image: this.$refs.canvas.toDataURL(),
        artistName: 'test'
      }).catch(alert)

      alert('Thank you for your drawing')

    }
  }
})
</script>

<!--
window.onload = function () {

// Definitions
var canvas = document.getElementById("paint-canvas");
var context = canvas.getContext("2d");
var boundings = canvas.getBoundingClientRect();

// Specifications
var mouseX = 0;
var mouseY = 0;
context.strokeStyle = 'black'; // initial brush color
context.lineWidth = 1; // initial brush width
var isDrawing = false;


// Handle Colors
var colors = document.getElementsByClassName('colors')[0];

colors.addEventListener('click', function (event) {
context.strokeStyle = event.target.value || 'black';
});

// Handle Brushes
var brushes = document.getElementsByClassName('brushes')[0];

brushes.addEventListener('click', function (event) {
context.lineWidth = event.target.value || 1;
});

// Mouse Down Event
canvas.addEventListener('mousedown', function (event) {
setMouseCoordinates(event);
isDrawing = true;

// Start Drawing
context.beginPath();
context.moveTo(mouseX, mouseY);
});

// Mouse Move Event
canvas.addEventListener('mousemove', function (event) {
setMouseCoordinates(event);

if (isDrawing) {
context.lineTo(mouseX, mouseY);
context.stroke();
}
});

// Mouse Up Event
canvas.addEventListener('mouseup', function (event) {
setMouseCoordinates(event);
isDrawing = false;
});

// Handle Mouse Coordinates
function setMouseCoordinates(event) {
mouseX = event.clientX - boundings.left;
mouseY = event.clientY - boundings.top;
}

// Handle Clear Button
var clearButton = document.getElementById('clear');

clearButton.addEventListener('click', function () {
context.clearRect(0, 0, canvas.width, canvas.height);
});


};-->
