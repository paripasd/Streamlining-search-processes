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
  
  export default {
    components: {
      Tree,
    },
    setup() {
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
        fetch('https://localhost:7018/api/Read/', {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(node.path)
        })
        .then(response => response.json())
        .then(data => console.log(data));
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