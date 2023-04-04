<template>
    <div class="flex">
      <Sidebar/>
        <div class="h-screen w-10/12 px-8 py-8 bg-gray-100">
            <SearchParameters/>
            <div class="h-[90%] overflow-y-scroll">
                <SearchResult/>
            </div>
        </div>
    </div>
  </template>
  
<script>
import Sidebar from '@/components/sidebar.vue';
import SearchResult from '@/components/searchResult.vue';
import SearchParameters from '@/components/searchParameters.vue';
export default {
    components: { Sidebar, SearchResult, SearchParameters }
}
</script>