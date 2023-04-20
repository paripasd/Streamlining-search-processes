<template>
  <div class="h-fit">
    <div v-for="d in store.getFilteredResult" :key="d.id"
      class="h-fit my-4 relative space-x-3 rounded-lg border border-gray-300 bg-white px-6 py-5 shadow-sm hover:border-cyorange">
      <div class="pb-8">
          <div class="flex flex-row space-x-3">
            <p class="text-gray-500" v-for="p in d.path">{{ p }} /</p>
          </div>
          <div class="relative">
            <div class="absolute inset-0 flex items-center" aria-hidden="true">
              <div class="w-full border-t border-gray-300" />
            </div>
            <div class="relative flex justify-end">
              <span class="isolate inline-flex -space-x-px rounded-md shadow-sm">
                <RouterLink :to="{name: 'CrudWithId', params: {id: d.id}}"> 
                  <button type="button"
                    class="mr-4 relative inline-flex items-center rounded-md bg-white px-3 py-2 text-gray-400 ring-1 ring-inset ring-gray-300 hover:text-cyorange focus:z-10">
                    <span class="sr-only">Edit</span>
                    <PencilIcon class="h-5 w-5" aria-hidden="true" />
                  </button>
                </RouterLink>
              </span>
            </div>
          </div>
          <div class="flex flex-row items-center space-x-1">
            <p class="text-xl pt-2 pb-2 mr-4 font-medium text-gray-900">{{ d.question }}</p>
            <p v-for="tag in tagList.filter(item => d.tags.includes(item.label))" class="tag-text" :class="tag.color" :title="tag.label">{{ tag.label }}</p>
          </div>
          <div class="flex items-center justify-between bg-stone-100 rounded-lg p-4 pb-2 w-full relative">
            <p v-if="d.snippet.answer == null" id="answer-field" class="w-full text-sm text-gray-900 flex-1 pr-10">{{ d.answer }}</p>
            <p v-else v-html="d.snippet.answer" class="w-full text-sm text-gray-900 flex-1"></p>
            <button  class="transform hover:scale-110 transition duration-200 absolute right-0 my-1 mr-1"
              @click="animateButton(d.answer, $event)" title="Copy to clipboard">
              <ClipboardDocumentIcon class="w-6 h-6 text-gray-500 hover:text-cyorange" />
              <span class="sr-only">Copy to clipboard</span>
            </button>
          </div>
      </div>
      <div class="flex min-h-[0px] max-h-min w-full">
        <div class="flex flex-row items-center space-x-3">
          <ChatBubbleLeftIcon v-if="d.comment" class="w-5 h-5 flex-none text-gray-500"/>
          <p class="text-clip text-sm text-gray-500">{{ d.comment }}</p>
        </div>
        <div class="w-full justify-end items-center flex flex-row">
          <PencilIconOutline v-if="d.modifiedBy" class="w-5 h-5 flex-none text-gray-500"/>
          <p class="ml-4 mr-8 text-clip text-sm text-gray-500">{{ d.modifiedBy }}</p>
          <p class="ml-4 mr-8 text-clip text-sm text-gray-500">{{ new Date(d.modificationDate).toLocaleString().replace('T', ' ').replace('Z', '') }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
  
<script setup>
import { useSearchPageStore } from '@/stores/SearchPageStore';
import { useCrudPageStore } from '@/stores/CrudPageStore';
import { ClipboardDocumentIcon } from '@heroicons/vue/24/outline';
import { PencilIcon } from '@heroicons/vue/20/solid'
import { PencilIcon as PencilIconOutline} from '@heroicons/vue/24/outline';
import {ChatBubbleLeftIcon} from '@heroicons/vue/24/outline';
const store = useSearchPageStore();
const tagList = useCrudPageStore().tagList;
console.log(store.searchResult);

function animateButton(answer, event) {
  navigator.clipboard.writeText(answer);
  event.target.classList.add('animate-bounce');
  event.target.classList.add('text-blue-500');
  setTimeout(() => {
    event.target.classList.remove('animate-bounce');
    event.target.classList.remove('text-blue-500');
  }, 500);
}


</script>