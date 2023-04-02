import {defineStore} from "pinia";

export const useCrudPageStore = defineStore("CrudPageStore", {
    state: () => {
        return {
            path:[],
            createPath:[],
            data:[],
            unit:{question:"",answer:"",comment:"", id:"", expiryDate:"", modifiedBy:"", path:[]},
        };
    },

    actions: {
        updatePath(path) {
            this.path = path;
        },

        updateCreatePath(path) {
            this.createPath = path
        },

        updateData(data) {
            this.data = data
        },

        updateUnit(unit) {
            this.unit = unit
            console.log(unit)
        },
    },

    getters: {
        getData: (state) => state.data,
        getPath() {
            let objectifiedPath = [];
            let i = 0;
            while (i<this.path.length){
                objectifiedPath.push({label:this.path[i],href:"#",current:false});
                i++;
            }
            return objectifiedPath;
        },
        getUnit: (state) => state.path,
        getCreatePath() {
            var stringifiedPath = "";
            let i = 0;
            while (i<this.createPath.length){
                stringifiedPath += this.createPath[i] + '/';
                i++;
            }
            return stringifiedPath;
        },
    },
});