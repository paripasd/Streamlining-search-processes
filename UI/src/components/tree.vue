<template>
  <input v-model="searchText" type="text" class="shortinput m-0" />
  <div class="h-full w-full overflow-y-auto">
    <Tree v-if="data" :nodes="data" :search-text="searchText" :use-checkbox="false" :use-icon="true"
      @nodeExpanded="onNodeExpanded" @update:nodes="onUpdate" @nodeClick="onNodeClick" />
  </div>
</template>
  
<script lang="js">
import { ref, onMounted } from "vue";
import Tree from "vue3-tree";
import "vue3-tree/dist/style.css";
import { useCrudPageStore } from '@/stores/CrudPageStore';

//Third party tree library, with the methods modified so that when a node is clicked it fetches the data for the appropriate path
export default {
  setup() {
    const store = useCrudPageStore();
    const data = ref(null);
    onMounted(async () => {
      const response = await fetch("https://localhost:7018/api/Read/tree");
      const fdata = await response.json();
      data.value = fdata;
    });

    const searchText = ref("");
    const onNodeExpanded = (node, state) => {

    };

    const onUpdate = (nodes) => {

    };

    const onNodeClick = async (node) => {
      store.updateDataByPath(node.path);
      try {
        await fetch('https://localhost:7018/api/Update/expiry', {
          method: 'PUT',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          }
        })
      }
      catch (error) {
        console.error('Error:', error);
      }
    }

    return {
      data,
      searchText,
      store,
      onNodeExpanded,
      onUpdate,
      onNodeClick,
    };
  },
  components: {
    Tree,
  },
};


</script>