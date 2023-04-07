import {defineStore} from "pinia";

export const useCrudPageStore = defineStore("CrudPageStore", {
    state: () => {
        return {
            path:[],
            createPath:[],
            data:[],
            unit:{question:"",answer:"",comment:"", id:"", expiryDate:"", modifiedBy:"", path:[]},
            results:[],
            selectedRow: null,
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
        },

        updateResults(results){
            this.results = results
        },

        updateDataByPath(path) {
            this.updatePath(path);
            fetch('https://localhost:7018/api/Read/', {
              method: 'POST',
              headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              },
              body: JSON.stringify(path)
            })
            .then(response => response.json())
            .then(data => this.updateData(data));
            console.log(this.data);
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
        getCreatePath: (state) => state.createPath,
        getResults: (state) => state.results
    },
});