import {defineStore} from "pinia";

export const useCrudPageStore = defineStore("CrudPageStore", {
    state: () => {
        return {
            path:"fos",
            data:{"default":"data"},
        };
    },

    actions: {
        updatePath(path) {
            this.path = path
        },

        updateData(data) {
            this.data = data
        },
    },

    getters: {
        getData: (state) => state.data,
        getPath: (state) => state.path,
    },
});