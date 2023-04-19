<template>
    <div class="w-full mb-2">
        <TagFilter/>
    </div>
    <div class="flex w-full">
        <Combobox class="z-20 w-full" v-model="selectedLiveSuggestion">
            <div class="relative mt-1">
                <div
                    class="relative w-full cursor-default overflow-hidden rounded-lg bg-white text-left shadow-md focus:outline-none focus-visible:ring-2 focus-visible:ring-white focus-visible:ring-opacity-75 focus-visible:ring-offset-2 focus-visible:ring-offset-teal-300 sm:text-sm">
                    <ComboboxInput class="w-full border-none py-2 pl-3 pr-10 text-sm leading-5 text-gray-900 focus:ring-0"
                        placeholder="Search..."
                        @change="querySearch = $event.target.value, getLiveSuggestions(), selectedLiveSuggestion = $event.target.value" />

                    <ComboboxButton v-if="selectedLiveSuggestion" @click="selectedLiveSuggestion = ''"
                        class="absolute inset-y-0 right-6 flex items-center pr-2">
                        <XMarkIcon class="h-5 w-5 hover:text-red-600 text-gray-400" aria-hidden="true" />
                    </ComboboxButton>
                    <ComboboxButton @click="getLiveSuggestions()" class="absolute inset-y-0 right-0 flex items-center pr-2">
                        <ChevronDownIcon class="h-5 w-5 hover:text-cyorange text-gray-400" aria-hidden="true" />
                    </ComboboxButton>

                </div>
                <TransitionRoot leave="transition ease-in duration-100" leaveFrom="opacity-100" leaveTo="opacity-0"
                    @after-leave="querySearch = ''">
                    <ComboboxOptions
                        class="absolute mt-1 max-h-60 w-full overflow-auto rounded-md bg-white py-1 text-base shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
                        <div v-if="liveSuggesstions.length === 0 && querySearch !== ''"
                            class="relative cursor-default select-none py-2 px-4 text-gray-700">
                            Nothing found.
                        </div>

                        <ComboboxOption @click="selectedLiveSuggestion = item" v-for="item in liveSuggesstions"
                            as="template" v-slot="{ selectedLiveSuggestion, active }">
                            <li class="relative cursor-default select-none py-2 pl-10 pr-4" :class="{
                                'bg-teal-600 text-white': active,
                                'text-gray-900': !active,
                            }">
                                <span class="block truncate"
                                    :class="{ 'font-medium': selectedLiveSuggestion, 'font-normal': !selectedLiveSuggestion }">
                                    {{ item }}
                                </span>
                                <span v-if="selectedLiveSuggestion" class="absolute inset-y-0 left-0 flex items-center pl-3"
                                    :class="{ 'text-white': active, 'text-teal-600': !active }">
                                    <CheckIcon class="h-5 w-5" aria-hidden="true" />
                                </span>
                            </li>
                        </ComboboxOption>
                    </ComboboxOptions>
                </TransitionRoot>
            </div>
        </Combobox>

        <button v-on:click="search()" class="uniform-button flex-1 h-10 ml-4 py-4 px-6 rounded-md flex items-center">
            <MagnifyingGlassIcon class="w-6 h-6" />
        </button>


        <!--<input v-model="searchFieldText" placeholder="Search..."
            class="w-full h-10 p-2 block rounded-md text-gray-900 shadow-sm border border-solid border-slate-300 placeholder:text-gray-400 focus:border-cyorange outline-none sm:text-sm sm:leading-6" />
        <button v-on:click="search()" class="uniform-button flex-1 h-10 ml-4 py-4 px-6 rounded-md flex items-center">
            <MagnifyingGlassIcon class="w-6 h-6" />
        </button>-->
    </div>
    <div class="flex mt-4 mb-2">
        <div class="w-full mr-4">
            <label class="pl-1 mb-4">Organization</label>
            <Combobox class="z-10" v-model="selectedInstitute">
                <div class="relative mt-1">
                    <div
                        class="relative w-full cursor-default overflow-hidden rounded-lg bg-white text-left shadow-md focus:outline-none focus-visible:ring-2 focus-visible:ring-white focus-visible:ring-opacity-75 focus-visible:ring-offset-2 focus-visible:ring-offset-teal-300 sm:text-sm">
                        <ComboboxInput id="input"
                            class="w-full border-none py-2 pl-3 pr-10 text-sm leading-5 text-gray-900 focus:ring-0"
                            :displayValue="(institute) => institute" @change="query = $event.target.value" />
                        <ComboboxButton class="absolute inset-y-0 right-0 flex items-center pr-2">
                            <ChevronUpDownIcon class="h-5 w-5 hover:text-cyorange text-gray-400" aria-hidden="true" />
                        </ComboboxButton>
                    </div>
                    <TransitionRoot leave="transition ease-in duration-100" leaveFrom="opacity-100" leaveTo="opacity-0"
                        @after-leave="query = ''">
                        <ComboboxOptions
                            class="absolute mt-1 max-h-60 w-full overflow-auto rounded-md bg-white py-1 text-base shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
                            <div v-if="filteredInstitutes.length === 0 && query !== ''"
                                class="relative cursor-default select-none py-2 px-4 text-gray-700">
                                Nothing found.
                            </div>

                            <ComboboxOption
                                @click="selectedInstitute = item, getSubpaths(), deleteSubPathInput(), selectedLiveSuggestion = ''"
                                v-for="item in filteredInstitutes" as="template" v-slot="{ selectedInstitute, active }">
                                <li class="relative cursor-default select-none py-2 pl-10 pr-4" :class="{
                                    'bg-teal-600 text-white': active,
                                    'text-gray-900': !active,
                                }">
                                    <span class="block truncate"
                                        :class="{ 'font-medium': selectedInstitute, 'font-normal': !selectedInstitute }">
                                        {{ item }}
                                    </span>
                                    <span v-if="selectedInstitute" class="absolute inset-y-0 left-0 flex items-center pl-3"
                                        :class="{ 'text-white': active, 'text-teal-600': !active }">
                                        <CheckIcon class="h-5 w-5" aria-hidden="true" />
                                    </span>
                                </li>
                            </ComboboxOption>
                        </ComboboxOptions>
                    </TransitionRoot>
                </div>
            </Combobox>
        </div>
        <div class="w-full ml-4">
            <label class="pl-1 mb-4">Department</label>
            <Combobox class="z-10" v-model="selectedSubpath">
                <div class="relative mt-1">
                    <div
                        class="relative w-full cursor-default overflow-hidden rounded-lg bg-white text-left shadow-md focus:outline-none focus-visible:ring-2 focus-visible:ring-white focus-visible:ring-opacity-75 focus-visible:ring-offset-2 focus-visible:ring-offset-teal-300 sm:text-sm">
                        <ComboboxInput id="input-2"
                            class="w-full border-none py-2 pl-3 pr-10 text-sm leading-5 text-gray-900 focus:ring-0"
                            :displayValue="(subpaths) => subpaths" @change="query2 = $event.target.value" />
                        <ComboboxButton class="absolute inset-y-0 right-0 flex items-center pr-2">
                            <ChevronUpDownIcon class="h-5 w-5 hover:text-cyorange text-gray-400" aria-hidden="true" />
                        </ComboboxButton>
                    </div>
                    <TransitionRoot leave="transition ease-in duration-100" leaveFrom="opacity-100" leaveTo="opacity-0"
                        @after-leave="query2 = ''">
                        <ComboboxOptions
                            class="absolute mt-1 max-h-60 w-full overflow-auto rounded-md bg-white py-1 text-base shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
                            <div v-if="filteredSubpaths.length === 0 && query2 !== ''"
                                class="relative cursor-default select-none py-2 px-4 text-gray-700">
                                Nothing found.
                            </div>

                            <ComboboxOption @click="selectedSubpath = i, selectedLiveSuggestion = ''"
                                v-for="i in filteredSubpaths" as="template" v-slot="{ selectedSubpath, active }">
                                <li class="relative cursor-default select-none py-2 pl-10 pr-4" :class="{
                                    'bg-teal-600 text-white': active,
                                    'text-gray-900': !active,
                                }">
                                    <span class="block truncate"
                                        :class="{ 'font-medium': selectedSubpath, 'font-normal': !selectedSubpath }">
                                        {{ i }}
                                    </span>
                                    <span v-if="selectedSubpath" class="absolute inset-y-0 left-0 flex items-center pl-3"
                                        :class="{ 'text-white': active, 'text-teal-600': !active }">
                                        <CheckIcon class="h-5 w-5" aria-hidden="true" />
                                    </span>
                                </li>
                            </ComboboxOption>
                        </ComboboxOptions>
                    </TransitionRoot>
                </div>
            </Combobox>
        </div>
    </div>
</template>


<script setup>
import { useSearchPageStore } from '@/stores/SearchPageStore';
import { ref, computed, onMounted, watchEffect } from 'vue';
import {
    Combobox,
    ComboboxInput,
    ComboboxButton,
    ComboboxOptions,
    ComboboxOption,
    TransitionRoot,
} from '@headlessui/vue'
import { CheckIcon, ChevronDownIcon, ChevronUpDownIcon, XMarkIcon } from '@heroicons/vue/20/solid'
import { MagnifyingGlassIcon } from '@heroicons/vue/20/solid';
import TagFilter from './tagFilter.vue';

const store = useSearchPageStore();
const questionsToSuggest = ref('');
const selectedLiveSuggestion = ref('');
const selectedInstitute = ref('');
const query = ref('');
const query2 = ref('');
const querySearch = ref('');
const searchFieldText = ref(null);
const institutes = ref(null);
const subpaths = ref(null);
const selectedSubpath = ref('');
onMounted(async () => {
    const response = await fetch(`https://localhost:7018/api/Read/institutes`);
    const data = await response.json();
    institutes.value = data;
    const result = institutes.value.filter(i => i.split(" ")[0] === store.defaultNumber.toString());
    selectedInstitute.value = result[0];
    getSubpaths();
    getLiveSuggestions();
});

const filteredInstitutes = computed(() => institutes.value.filter((institute) => institute.toLowerCase().includes(query.value.toLowerCase())));

const filteredSubpaths = computed(() => subpaths.value.filter((subpaths) => subpaths.toLowerCase().includes(query2.value.toLowerCase())));

const liveSuggesstions = computed(() => questionsToSuggest.value.filter((question) => question.toLowerCase().includes(querySearch.value.toLowerCase())));

async function getLiveSuggestions() {
    const selectedInstituteArray = [selectedInstitute.value];
    const path = selectedInstituteArray.concat(selectedSubpath.value.split('/'));
    const response = await fetch(`https://localhost:7018/api/Read/livesuggest`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(path)
    });
    questionsToSuggest.value = await response.json();
    console.log(questionsToSuggest.value);
}

function deleteSubPathInput() {
    selectedSubpath.value = "";
}

const checkEmptyString = (str) => (str === "" ? null : str);

async function getSubpaths() {
    const response = await fetch(`https://localhost:7018/api/Read/subpaths/${selectedInstitute.value}`);
    const data = await response.json();
    subpaths.value = data.flatMap(innerArr => innerArr.join('/'));
}

async function search() {
    selectedLiveSuggestion.value = checkEmptyString(selectedLiveSuggestion.value);
    const selectedInstituteArray = [selectedInstitute.value];
    var path;
    if(selectedSubpath.value === '' || selectedSubpath.value === null){
        path = selectedInstituteArray;
    }else{
        path = selectedInstituteArray.concat(selectedSubpath.value.split('/'));
    }
    
    console.log(path);
    const response = await fetch(`https://localhost:7018/api/Read/search/${selectedLiveSuggestion.value}`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(path)
    });
    const data = await response.json();
    store.searchResult = data;
    console.log(data);
}
</script>