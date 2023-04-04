
<template>
    <div class="sm:flex sm:items-center px-6 pt-6 -mb-4">
        <div class="sm:flex-auto">
          <CrudPathBar/>
        </div>
        <div class="mt-4 sm:mt-0 sm:ml-16 sm:flex-none">
          <CreateMenu/>
        </div>
      </div>
</template>

<script setup>
import CrudPathBar from './crudPathBar.vue';
import CreateMenu from './createMenu.vue';



</script>