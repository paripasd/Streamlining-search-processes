import {defineStore} from "pinia";

export const useCrudPageStore = defineStore("CrudPageStore", {
    state: () => {
        return {
            path,
        };
    },

    actions: {
        updatePath(path) {
            this.path = path;
        }
    },
});