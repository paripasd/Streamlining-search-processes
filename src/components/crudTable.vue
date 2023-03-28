<template>
    <div class="px-4 sm:px-6 lg:px-8 flow-root">
        <div class="-my-2 -mx-4 sm:-mx-6 lg:-mx-8">
          <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
            <table class="min-w-full border-separate highlight-selected-row">
              <thead>
                <tr class="divide-x sticky">
                  <th class="sticky overflow-y-hidden top-0 z-10 py-3.5 pl-4 pr-4 text-left rounded-md text-sm font-semibold text-gray-900 bg-gray-100">Question</th>
                  <th class="sticky top-0 z-10 py-3.5 pl-4 pr-4 text-left text-sm rounded-md font-semibold text-gray-900 bg-gray-100">Answer</th>
                </tr>
              </thead>
              <tbody class="divide-y divide-gray-200 bg-white">
                <tr v-for="q in qna" :key="q.question" class="divide-x divide-gray-200">
                  <td class="whitespace-nowrap w-1/3 overflow-y-hidden max-w-[80px] py-4 pl-4 pr-4 text-sm font-medium text-gray-900 sm:pl-0">{{ q.question }}</td>
                  <td class="whitespace-nowrap w-2/3 overflow-y-hidden max-w-screen-sm py-4 pl-4 pr-4 text-sm text-gray-500 sm:pr-0">{{ q.answer }}</td>
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
  watchEffect(() => {
    console.log("data updated:", store.data)
  });
  const qnas = [
    {question:"Link til uddannelsen", answer:"https://www.rts.dk/eud-erhvervsuddannelser/fagretninger/902-bygge-og-anlaeg"},
    {question:"Økonomi", answer:"Du kan få SU, hvis du opfylder betingelserne herfor. Når du har en uddannelsesaftale, kan du få elevløn"},
    {question:"Lokale undervisningsplaner", answer:"Via linket her kan du finde de lokale undervisningsplaner. Her finder du de formelle krav til uddannelsen (undervisning, opbygning, prøver og eksamen):https://www.rts.dk/om-skolen/kvalitet/916-lokale-undervisningsplaner-lup"},
    {question:"Læreplads", answer:"Du skal selv finde en læreplads, men skolens vejledere kan hjælpe dig på vej"},
    {question:"Ansøgningsfrist", answer:"Søg ind via optagelse.dk senest 1. marts"},
  ]
  </script>

