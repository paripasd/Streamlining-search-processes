

<template>
  <div class="flex">
    <nav class="min-h-screen max-w-min bg-slate-800 flex flex-col">
      <div class="min-h-full bg-slate-800 flex flex-col">
        <a href="#" class="navitem">Search</a>
        <a href="#" class="navitem bg-gray-900">CRUD</a>
        <a href="#" class="navitem">Login</a>
      </div>
    </nav>
    <div class="grid grid-columns-4 grid-rows-4 h-screen w-screen gap-2">
      <div class="col-span-1 row-span-4">

      </div>
      <div class="bg-green-500 col-span-3 row-span-4">

      </div>
      <div class="col-span-4 row-span-1 h-min">
        <form id="data-edit-form">
          <div class="grid grid-rows-4 w-full h-full p-2 gap-2">
              <div class="col-span-1 row-span-3 flex flex-col">
                <label for="question-input">Question:</label>
                <textarea class="longtextinput" id="question-input"></textarea>
              </div>
              <div class="col-span-1 col-start-2 row-span-3 flex flex-col">
                <label for="answer-input">Answer:</label>
                <textarea class="longtextinput" id="answer-input"></textarea>
              </div>
              <div class="col-span-1 col-start-3 row-span-3 flex flex-col">
                <label for="comment-input">Comment:</label>
                <textarea class="longtextinput" id="comment-input"></textarea>
              </div>
              <div class="flex flex-row">
                <label for="expiry-input">Expiry:</label>
                <input type="date" id="expiry-input" class="shortinput">
              </div>
              <div class="flex flex-row">
                <label for="editedby-input">Edited&nbsp;by:</label>
                <input type="text" id="editedby-input" class="shortinput" disabled>
              </div>
              <div class="flex flex-row justify-evenly">
                <button>Update</button>
                <button class="hover:text-red-500">Delete</button>
              </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
  
  <script>
    export default {
  data() {
    return {
      inputText: '',
      outputText: ''
    }
  },
  methods: {
    addItem() {
      this.outputText += this.inputText + '\n'
      this.inputText = ''
    },
    updateItem() {
      // implement update logic here
      this.outputText = this.inputText
      this.inputText = ''
    },
    deleteItem() {
      this.outputText = ''
    }
  }
}
  
  </script>