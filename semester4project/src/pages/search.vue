<template>
    <div class="flex">
      <Sidebar/>
        <div class="h-screen w-[90%] px-8 py-8 bg-gray-100">
            <SearchParameters/>
            <div class="h-[85%] overflow-y-scroll">
                <SearchResult/>
            </div>
        </div>
    </div>
  </template>
  
<script setup>
import Sidebar from '@/components/sidebar.vue';
import SearchResult from '@/components/searchResult.vue';
import SearchParameters from '@/components/searchParameters.vue';
import { useSearchPageStore } from '@/stores/SearchPageStore';
import { onMounted } from 'vue';

const store = useSearchPageStore();
onMounted(async () => {
    const response = await fetch(`https://localhost:7018/api/Read/cydata`);
    const data = await response.json();
    store.defaultNumber = data;
});


</script>