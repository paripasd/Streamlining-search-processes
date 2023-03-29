<template>
    <input v-model="searchText" type="text" class="shortinput m-0"/>
    <Tree
      :nodes="data"
      :search-text="searchText"
      :use-checkbox="false"
      :use-icon="false"
      show-child-count
      @nodeExpanded="onNodeExpanded"
      @update:nodes="onUpdate"
      @nodeClick="onNodeClick"
    />
  </template>
  
  <script lang="js">
  import { ref } from "vue";
  import Tree from "vue3-tree";
  import "vue3-tree/dist/style.css";
  import { useCrudPageStore } from '@/stores/CrudPageStore';
  
  export default {
    components: {
      Tree,
    },
    setup() {
      const store = useCrudPageStore();
      const data = ref([
        {
          label: "609 Roskilde Tekniske Skole",
          path: ["609 Roskilde Tekniske Skole"],
          nodes: [
            {
              label: "Generelt",
              path: ["609 Roskilde Tekniske Skole","Generelt"],
              nodes: [
                {
                  label: "KPI'er",
                  path: ["609 Roskilde Tekniske Skole", "Generelt", "KPI'er"],
                },
              ],
            },
          ],
        },
      ]);
      const searchText = ref("");
      const onNodeExpanded = (node, state) => {
        console.log("state: ", state);
        console.log("node: ", node);
      };
  
      const onUpdate = (nodes) => {
        console.log("nodes:", nodes);
      };
  
      const onNodeClick = (node) => {
      };
  
      return {
        data,
        searchText,
        onNodeExpanded,
        onUpdate,
        onNodeClick,
      };
    },
  };

  
  </script>