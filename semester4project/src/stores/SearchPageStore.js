import {defineStore} from "pinia";

export const useSearchPageStore = defineStore("SearchPageStore", {
    state: () => {
        return {
            searchText: "",
            searchResult: [],
            defaultNumber: 0
        };
    },
});