

<template>
  <div class="flex">
    <Sidebar/>
      <div class="grid grid-cols-[300px,auto,auto,auto] grid-rows-4 h-screen w-[90%] gap-2 bg-white">
        <div class="col-span-1 row-span-4 w-full m-2 pr-2">
          <Tree class=""/>
        </div>
        <div class="col-span-3 row-span-4 grid grid-rows-[80px,auto,auto,auto,auto] bg-stone-100">
          <div class="row-span-1 w-full">
            <TableHeader/>
          </div>
          <div id="tableContainer" class="row-span-4 h-auto min-h-[0px]">
            <Crudtable/>
            
          </div>
        </div>
        <div class="col-span-4 row-span-1 h-min bg-white">
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
import CreateMenu from '@/components/createMenu.vue';
import { useCrudPageStore } from '@/stores/CrudPageStore';
import { onMounted, ref, watch } from 'vue';

export default {
    setup(props){
      const store = useCrudPageStore();

      if(props.id){
        const fetchData = async () => {
          const response = await fetch(`https://localhost:7018/api/Read/${props.id}`, {
            method: 'GET',
            headers: {
              Accept: 'application/json',
              'Content-Type': 'application/json',
            },
          });
  
          const data = await response.json();
          store.updateUnit(data);
          store.updateDataByPath(data.path);
          console.log(store.data);
        };
  
        onMounted(fetchData);

      }

      watch(() => store.selectedRow, (newValue) => {
        if(newValue !== null){

          document.getElementById("tableContainer").scrollTo({
              top: store.selectedRow.offsetTop,
              behavior: "smooth",
          });
        }
      });

    },
    props: ['id'],
    components: { Sidebar, CrudEditForm, Crudtable, TableHeader, Tree, CreateMenu }
}
  </script>