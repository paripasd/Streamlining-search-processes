<template>
  <div class="flex">
    <Sidebar />
    <div class="h-screen w-[90%] px-8 py-8 bg-gray-100">
      <SearchParameters />
      <div v-if="store.getFilteredResult.length > 0" class="h-[85%] overflow-y-scroll">
        <SearchResult />
      </div>
      <div v-else class="flex h-[85%] items-center justify-center">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
          class="w-12 h-12 pr-2">
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M19.5 14.25v-2.625a3.375 3.375 0 00-3.375-3.375h-1.5A1.125 1.125 0 0113.5 7.125v-1.5a3.375 3.375 0 00-3.375-3.375H8.25m5.231 13.481L15 17.25m-4.5-15H5.625c-.621 0-1.125.504-1.125 1.125v16.5c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 00-9-9zm3.75 11.625a2.625 2.625 0 11-5.25 0 2.625 2.625 0 015.25 0z" />
        </svg>
        <p class="text-2xl">No result</p>
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
  const response = await fetch(`https://localhost:7018/api/Read/cydata`); //When the page is loaded this automatically fetches the actual institution from YoungCRM - currently test data from our own API instead
  const data = await response.json();
  store.defaultNumber = data;
});


</script>