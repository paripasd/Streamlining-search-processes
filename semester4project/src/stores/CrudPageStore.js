import {defineStore} from "pinia";

export const useCrudPageStore = defineStore("CrudPageStore", {
    state: () => {
        return {
            path:[],
            data:[],
            unit:{question:"",answer:"",comment:"",expiryDate:"",modifiedBy:"",path:[]},
        };
    },

    actions: {
        updatePath(path) {
            this.path = path
        },

        updateData(data) {
            this.data = data
        },

        updateUnit(unit) {
            this.unit = unit
        },
    },

    getters: {
        getData: (state) => state.data,
        getPath: (state) => state.path,
        getUnit: (state) => state.path,
    },
});