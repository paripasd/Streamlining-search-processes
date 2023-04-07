<template>
    <div class="px-4 sm:px-6 lg:px-8 flow-root">
        <div class="-my-2 -mx-4 sm:-mx-6 lg:-mx-8">
          <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
            <table id="table" class="min-w-full overflow-hidden">
              <thead>
                <tr class="divide-x sticky">
                  <th class="sticky overflow-y-hidden top-0 z-10 py-3.5 pl-4 pr-4 text-left rounded-md text-sm font-semibold text-gray-900 bg-gray-100">Question</th>
                  <th class="sticky top-0 z-10 py-3.5 pl-4 pr-4 text-left text-sm rounded-md font-semibold text-gray-900 bg-gray-100">Answer</th>
                </tr>
              </thead>
                <tbody class="bg-white">
                  <tr ref="tableRows" v-for="(q, qIndex) in store.data" :key="qIndex" :class="{ 'border-2 border-blue-500': selectedRowId === q.id }" @click="updateSelected(q, qIndex)" class="divide-x hover:bg-gray-200">
                    <td class="whitespace-normal w-1/3 max-w-[80px] py-4 pl-4 pr-4 text-sm font-medium text-gray-900 sm:pl-0">{{ q.question }}</td>
                    <td class="whitespace-normal w-2/3 max-w-screen-sm py-4 pl-4 pr-4 text-sm text-gray-500 sm:pr-0">{{ q.answer }}</td>
                  </tr>
                </tbody>
            </table>
          </div>
        </div>
      </div>
  </template>

<style>
</style>
  
  <script setup>
  import { useCrudPageStore } from '@/stores/CrudPageStore';
  import {computed, onMounted, ref} from 'vue';

  const store = useCrudPageStore();
  const selectedRowId = computed(() => store.unit.id);
  const tableRows = ref([]);
  

  function updateSelected(unit, index){
    store.updateUnit(unit);
    store.selectedRow = tableRows.value[index];
    console.log(store.selectedRow)
  }


  
</script>



