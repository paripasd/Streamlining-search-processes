import {defineStore} from "pinia";

export const useCrudPageStore = defineStore("CrudPageStore", {
    state: () => {
        return {
            path:[],
            createPath:[],
            data:[],
            unit:{question:"",answer:"",comment:"", id:"", expiry:"",modificationDate:"", modifiedBy:"", path:[], tags:[]},
            results:[],
            selectedRow: null,
            highlightedWords:[],
            tagList: [
                //{label:"TEXT TO DISPLAY", color:"COLOR OF TAG - BACKGROUND COLOR"}
                {label:"Important",color:"bg-green-500"},
                {label:"Draft",color:"bg-sky-500"},
                {label:"Expires soon",color:"bg-cyorange"},
                {label:"Expired",color:"bg-red-600"},
            ],
        };
    },

    actions: {
        updateHighlightedWords(highlightedWords){
            this.highlightedWords = highlightedWords;
        },
        
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

        async updateDataByPath(path) {
            this.updatePath(path);
            const response = await fetch('https://localhost:7018/api/Read/', {
              method: 'POST',
              headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              },
              body: JSON.stringify(path)
            });
            const data = await response.json();
            this.updateData(data);
          },

          updateFormattedExpiry(expiry){
            this.unit.expiry = expiry;
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
        getResults: (state) => state.results,
        getFormattedExpiry() {
            const date = new Date(this.unit.expiry);
            const year = date.getFullYear();
            const month = (date.getMonth() + 1).toString().padStart(2, '0');
            const day = date.getDate().toString().padStart(2, '0');
            return `${year}-${month}-${day}`;
        }
    },
});