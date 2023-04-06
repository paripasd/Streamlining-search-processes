<template>
    <div class="px-4 sm:px-6 lg:px-8 flow-root">
        <div class="-my-2 -mx-4 sm:-mx-6 lg:-mx-8">
          <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
            <table class="min-w-full overflow-hidden">
              <thead>
                <tr class="divide-x sticky">
                  <th class="sticky overflow-y-hidden top-0 z-10 py-3.5 pl-4 pr-4 text-left rounded-md text-sm font-semibold text-gray-900 bg-gray-100">Question</th>
                  <th class="sticky top-0 z-10 py-3.5 pl-4 pr-4 text-left text-sm rounded-md font-semibold text-gray-900 bg-gray-100">Answer</th>
                </tr>
              </thead>
                <tbody class="bg-white">
                  <tr v-on:click= " getRow(q,$event)" v-for="q in qna" :key="q.id" class="divide-x hover:bg-gray-200">
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
  import {computed, watchEffect} from 'vue';

  const store = useCrudPageStore();
  const qna = computed(() => store.data);

  window.addEventListener('DOMContentLoaded', function() {
    watchEffect(() => {

    });
  });

  let lastClickedRow = null;

  function getRow(q, event) {
    const unit = {question:q.question, answer:q.answer, comment:q.comment, id:q.id, path:q.path}
    store.updateUnit(unit);

    const rows = document.querySelectorAll('tr');
    rows.forEach((r) => {
        r.classList.remove('border-2','border-blue-500','rounded');
    });

    const currentRow = event.target.parentNode;
    currentRow.classList.add('border-2','border-blue-500', 'rounded');

    lastClickedRow = currentRow;
  }
</script>



