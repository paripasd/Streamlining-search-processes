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
          id: 1,
          label: "Animal",
          nodes: [
            {
              id: 2,
              label: "Dog",
            },
            {
              id: 3,
              label: "Cat",
              nodes: [
                {
                  id: 4,
                  label: "Egyptian Mau Cat",
                },
                {
                  id: 5,
                  label: "Japanese Bobtail Cat placeholder placeholder placeholder placeholder placeholder",
                  nodes: [
                    {
                        id: 7,
                        label: "placeholder",
                        nodes: [
                            {
                                id: 8,
                                label: "placeholder"
                            }
                        ]
                    }
                  ]
                },
              ],
            },
          ],
        },
        {
          id: 6,
          label: "People",
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
        console.log(node);
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