

<template>
  <div class="flex">
    <Sidebar/>
      <div class="grid grid-cols-[200px,auto,auto,auto] grid-rows-4 h-screen w-10/12 gap-2 bg-gray-100">
        <div class="col-span-1 row-span-4 w-full m-2 pr-2">
          <Tree class=""/>
        </div>
        <div class=" bg-white col-span-3 row-span-4 grid grid-rows-5">
          <div class="row-span-1 max-h-min">
            <TableHeader/>
          </div>
          <div class="row-span-4 overflow-x-scroll">
            <Crudtable/>
          </div>
        </div>
        <div class="col-span-4 row-span-1 h-min">
          <CrudEditForm/>
        </div>
      </div>
  </div>
</template>
  
  <script>
import Sidebar from '../components/sidebar.vue'
import CrudEditForm from '../components/crudEditForm.vue'
import Crudtable from '@/components/crudTable.vue';
import TableHeader from '@/components/tableHeader.vue';
import Tree from '@/components/tree.vue';
    export default {
    data() {
        return {
            inputText: "",
            outputText: ""
        };
    },
    methods: {
        addItem() {
            this.outputText += this.inputText + "\n";
            this.inputText = "";
        },
        updateItem() {
            // implement update logic here
            this.outputText = this.inputText;
            this.inputText = "";
        },
        deleteItem() {
            this.outputText = "";
        }
    },
    components: { Sidebar, CrudEditForm, Crudtable, TableHeader, Tree }
}
  
  </script>