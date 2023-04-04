<template>
  <input v-model="searchText" type="text" class="shortinput m-0"/>
  <div class="h-5/6 max-h-[90%] w-full overflow-y-auto">
    <Tree
      v-if="data"
      :nodes="data"
      :search-text="searchText"
      :use-checkbox="false"
      :use-icon="true"
      show-child-count
      @nodeExpanded="onNodeExpanded"
      @update:nodes="onUpdate"
      @nodeClick="onNodeClick"
    />
  </div>
</template>

<script lang="js">
import { ref, onMounted } from "vue";
import Tree from "vue3-tree";
import "vue3-tree/dist/style.css";
import { useCrudPageStore } from '@/stores/CrudPageStore';
import Button from "@/components/button.vue";

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

    const onNodeClick = (node) => {
      store.createPath = node.path;
    };

    return {
      data,
      searchText,
      onNodeExpanded,
      onUpdate,
      onNodeClick,
    };
  },
  components: {
    Tree,
    Button
  },
};


</script>