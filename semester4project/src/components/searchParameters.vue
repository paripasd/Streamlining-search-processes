<template>
    <div class="flex w-full">
      <input v-model="searchFieldText" placeholder="Search..." class="w-full h-10 p-2 block rounded-md text-gray-900 shadow-sm border border-solid border-slate-300 placeholder:text-gray-400 focus:border-cyorange outline-none sm:text-sm sm:leading-6"/>
      <button v-on:click="search()" class="uniform-button flex-1 h-10 ml-4 py-4 px-6 rounded-md flex items-center"><MagnifyingGlassIcon class="w-6 h-6"/></button>
    </div>
    <div class="flex w-full mt-4 mb-6 h-10">
        <select v-model="selectedInstitute" @change="getSubpaths()" class="flex-1 block bg-white rounded-md border-1 text-gray-900 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
            <option selected="" v-for="(item, index) in institutes" :key="index" :value="item">{{ item }}</option>
        </select>
        <select v-model="selectedSubpath" class="flex-1 ml-2 block bg-white rounded-md border-1 text-gray-900 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
            <option v-for="(item, index) in subpaths" :key="index" :value="item">{{ item.join('/') }}</option>
        </select>
    </div>
</template>


<script setup>
import { useSearchPageStore } from '@/stores/SearchPageStore';
import { ref, onMounted } from 'vue';
import { MagnifyingGlassIcon } from '@heroicons/vue/20/solid';

const store = useSearchPageStore();
const searchFieldText = ref(null);
const institutes = ref(null);
const selectedInstitute = ref(null);
const subpaths = ref(null);
const selectedSubpath = ref(null);
onMounted(async () => {
    const response = await fetch(`https://localhost:7018/api/Read/institutes`);
    const data = await response.json();
    institutes.value = data;
    const result = institutes.value.filter(i => i.split(" ")[0] === store.defaultNumber.toString());
    selectedInstitute.value = result[0];
    getSubpaths();
});

    const checkEmptyString = (str) => (str === "" ? null : str);

    async function getSubpaths(){
        const response = await fetch(`https://localhost:7018/api/Read/subpaths/${selectedInstitute.value}`);
        const data = await response.json();
        subpaths.value = data;
    }

    async function search(){
        searchFieldText.value = checkEmptyString(searchFieldText.value);
        const selectedInstituteArray = [selectedInstitute.value];
        const path = selectedInstituteArray.concat(selectedSubpath.value);
        const response = await fetch(`https://localhost:7018/api/Read/search/${searchFieldText.value}`, {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(path)
        });
        console.log(path);
        const data = await response.json();
        store.searchResult = data;
    }
</script>