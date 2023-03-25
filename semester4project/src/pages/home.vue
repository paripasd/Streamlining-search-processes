<template>
    <div>
        <Sidebar/>
    </div>
  </template>
  
  <script>
import CrudTable from '@/components/crudTable.vue';
import Sidebar from '@/components/sidebar.vue';
    export default {
    components: { Sidebar, CrudTable }
}
  </script>