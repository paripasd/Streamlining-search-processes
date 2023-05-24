<template>
    <nav class="flex" aria-label="Breadcrumb">
      <ol role="list" class="flex items-center space-x-4">
        <li v-for="(page, index) in pages" :key="page.label">
          <div class="flex items-center">
            <a :href="page.href" @click="changePathFromBar(index)" class="mr-4 text-sm font-medium text-gray-500 hover:text-gray-700" :aria-current="page.current ? 'page' : undefined">{{ page.label }}</a>
            <svg class="h-5 w-5 flex-shrink-0 text-gray-300" fill="currentColor" viewBox="0 0 20 20" aria-hidden="true">
              <path d="M5.555 17.776l8-16 .894.448-8 16-.894-.448z" />
            </svg>
          </div>
        </li>
      </ol>
    </nav>
  </template>
  
  <script setup>
  import { computed } from '@vue/reactivity';
  import { useCrudPageStore } from '@/stores/CrudPageStore';

  const store = useCrudPageStore();
      const pages = computed(() => store.getPath);
  

  function changePathFromBar(index){
    store.updateDataByPath(store.path.slice(0,index+1));
  }

  </script>