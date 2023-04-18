import {defineStore} from "pinia";

export const useSearchPageStore = defineStore("SearchPageStore", {
    state: () => {
        return {
            searchText: "",
            searchResult: [],
            defaultNumber: 0,
            selectedTags: [],
        };
    },

    actions: {

    },

    getters: {
        getFilteredResult(){
            if(this.selectedTags.length === 0) return this.searchResult;
            var filteredResult = [];
            var ok;
            for(let i=0; i<this.searchResult.length; i++){
                ok = true;
                for(let j=0; j<this.selectedTags.length; j++){
                    if(!this.searchResult[i].tags.includes(this.selectedTags[j])) ok = false;
                }
                if(ok) filteredResult.push(this.searchResult[i]);
            }
            return filteredResult;
        },
    },
});