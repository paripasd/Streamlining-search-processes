import {defineStore} from "pinia";

//Store for communication between components on search page
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
        //Locally filters the fetched search results based on the tags selected at the top of the page
        getFilteredResult(){
            if(this.selectedTags.length === 0) return this.searchResult;
            var filteredResult = [];
            var ok;
            //Loops through the search results
            for(let i=0; i<this.searchResult.length; i++){
                ok = true;
                //Checks if the object has each of the selected tags
                for(let j=0; j<this.selectedTags.length; j++){
                    //If any are missing the object is excluded from the results
                    if(!this.searchResult[i].tags.includes(this.selectedTags[j])) ok = false;
                }
                //If all selected tags are present within the object it is added to the results
                if(ok) filteredResult.push(this.searchResult[i]);
            }
            return filteredResult;
        },
    },
});