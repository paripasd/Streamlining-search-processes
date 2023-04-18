<template>
    <div class="px-4 sm:px-6 lg:px-8 flow-root max-h-[95%] w-full min-h-[0px] overflow-scroll">
        <div class="-my-2 -mx-4 sm:-mx-6 lg:-mx-8">
          <div class="inline-block py-2 align-middle w-full sm:px-6 lg:px-8">
            <table id="table" class="max-h-full w-full">
              <thead>
                <tr class="divide-x sticky">
                  <th class="sticky overflow-y-hidden top-0 z-10 py-3.5 pl-4 pr-4 text-left rounded-md text-sm font-semibold text-gray-100 bg-stone-800">Question</th>
                  <th class="sticky top-0 z-10 py-3.5 pl-4 pr-4 text-left text-sm rounded-md font-semibold text-gray-100 bg-stone-800">Answer</th>
                </tr>
              </thead>
                <tbody class="bg-white">
                  <tr ref="tableRows" v-for="(q, qIndex) in store.data" :key="qIndex" :class="{ 'bg-orange-300 hover:bg-orange-300': selectedRowId === q.id }" @click="updateSelected(q, qIndex)" class="divide-x hover:bg-gray-200">
                    <td class="whitespace-normal break-words w-1/3 max-w-[80px] pl-4 pr-4 py-4 text-sm font-medium text-gray-900">{{ q.question }}</td>
                    <td class="whitespace-normal break-words w-2/3 max-w-screen-sm py-4 pl-4 pr-4 text-sm text-gray-500">{{ q.answer }}</td>
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
  }


  
</script>



