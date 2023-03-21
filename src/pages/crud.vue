

<template>
  <div class="w-screen h-screen flex">
  <!-- Side bar -->
  <div class="w-[400px] h-full bg-gray-200 text-white">
   <div class="h-[50px] bg-gray-900 flex justify-start items-center">
      <div class="px-[20px]">
          <h3 class="font-bold text-xl">  Dashboard</h3>
      </div>
  </div>
  <div class="h-[calc(100vh-50px)] bg-gray-800">
      <div class="px-[20px] flex flex-col justify-between space-y-[10px]">
          <div class="h-auto">
          
              <router-link to="/home" class="inline-flex relative items-center py-[10px] px-[10px] w-full text-sm font-medium rounded-md border-gray-200 hover:bg-gray-200 hover:text-gray-800  transition duration-400 ease-in-out">
            <svg aria-hidden="true" class="mr-2 w-[25px] h-[25px] fill-current" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clip-rule="evenodd"></path>
            </svg>
            Home
          </router-link>
        
          <router-link to="/home" class="inline-flex relative items-center py-[10px] px-[10px] w-full text-sm font-medium rounded-md border-gray-200 hover:bg-gray-200 hover:text-gray-800  transition duration-400 ease-in-out">
            <svg aria-hidden="true" class="mr-2 w-[25px] h-[25px] fill-current" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clip-rule="evenodd"></path>
            </svg>
            Search
          </router-link>
          <router-link to="/CRUD" class="inline-flex relative items-center py-[10px] px-[10px] w-full text-sm font-medium rounded-md border-gray-200 hover:bg-gray-200 hover:text-gray-800  transition duration-400 ease-in-out">
            <svg aria-hidden="true" class="mr-2 w-[25px] h-[25px] fill-current" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clip-rule="evenodd"></path>
            </svg>
            CRUD
          </router-link>
          <router-link to="/home" class="inline-flex relative items-center py-[10px] px-[10px] w-full text-sm font-medium rounded-md border-gray-200 hover:bg-gray-200 hover:text-gray-800  transition duration-400 ease-in-out">
            <svg aria-hidden="true" class="mr-2 w-[25px] h-[25px] fill-current" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clip-rule="evenodd"></path>
            </svg>
            Tab
          </router-link>

          </div>
          <div>

          </div>
          
      </div>
  </div>
</div>
  <div class="w-full h-full bg-gray-400">
      <div class="h-[50px] bg-gray-100 flex items-center shadow-sm px-[20px] w-full py-[10px] z-10">
      <!--Hambuger menu-->
      
      
  </div>
  <div class="h-[calc(100vh-50px)] bg-white">
    <div>
      
      <div class="flex">
  <div class="w-full md:w-1/2 px-4">
    <textarea  v-model="inputText" class="block w-full bg-gray-100 rounded-md px-4 py-2" rows="10"></textarea>
    <button  @click="addItem" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mt-4">Add Item</button>
  </div>

</div>
<div class="flex flex-col h-screen">
<div class="flex-1 p-4">
  <textarea  v-model="outputText" class="w-full h-full border-gray-400 border rounded-md p-2"></textarea>
</div>
<div class="flex-none p-4">
  <button @click="updateItem" class="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded float-left">Update</button>
    

  <button  @click="deleteItem" class="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded float-right">Delete</button>
    

</div>
</div>

  </div>
  </div>
  </div>
  
  <!-- Main -->
 
      
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