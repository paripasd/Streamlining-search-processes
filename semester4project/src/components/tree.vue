<template>
    <input v-model="searchText" type="text" class="shortinput m-0"/>
    <div class="h-full w-full overflow-y-auto">
      <Tree
        v-if="data"
        :nodes="data"
        :search-text="searchText"
        :use-checkbox="false"
        :use-icon="false"
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
  
  export default {
    setup() {
      const store = useCrudPageStore();
      const data = ref(null);
      onMounted(async () => {
        const response = await fetch("https://localhost:7018/api/Read/tree");
        const fdata = await response.json();
        data.value = fdata;
      });
      const olddata = ref([
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
        fetch('https://localhost:7018/api/Read/', {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(node.path)
        })
        .then(response => response.json())
        .then(data => store.updateData(data));
        console.log(store.getData);
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
    },
  };

  
  </script>