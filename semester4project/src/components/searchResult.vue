<template>
  <div class="h-fit px-2">
    <div v-for="s in store.searchResult" :key="s.id"
      class="h-fit my-4 relative space-x-3 rounded-lg border border-gray-300 bg-white px-6 py-5 shadow-sm hover:border-gray-400">
      <div class="pb-16">
          <div class="mb-4 flex flex-row space-x-3">
            <p class="text-gray-500" v-for="p in s.path">{{ p }} /</p>
          </div>
          <div class="relative">
            <div class="absolute inset-0 flex items-center" aria-hidden="true">
              <div class="w-full border-t border-gray-300" />
            </div>
            <div class="relative flex justify-end">
              <span class="isolate inline-flex -space-x-px rounded-md shadow-sm">
                <button type="button"
                  class="mr-4 relative inline-flex items-center rounded-md bg-white px-3 py-2 text-gray-400 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:z-10">
                  <span class="sr-only">Edit</span>
                  <PencilIcon class="h-5 w-5" aria-hidden="true" />
                </button>
              </span>
            </div>
          </div>
          <p class="text-xl pt-2 pb-8 font-medium text-gray-900">{{ s.question }}</p>
          <div class="flex items-center justify-between bg-white rounded-md px-4 py-2 relative">
            <p id="answer-field" class="text-sm text-gray-500 flex-1 pr-10">{{ s.answer }}</p>
            <button class="transform hover:scale-110 transition duration-200 absolute top-1 right-1"
              @click="animateButton(s.answer, $event)" title="Copy to clipboard">
              <ClipboardDocumentIcon class="w-6 h-6 text-gray-500 hover:text-blue-500" />
              <span class="sr-only">Copy to clipboard</span>
            </button>
          </div>
      </div>
      <div class="flex ml-0 h-20 w-full">
        <div class="h-20 w-full">
          <p class="h-20 text-clip text-sm text-gray-500">{{ s.comment }}</p>
        </div>
        <div class="h-20 w-full text-right">
          <p class="h-20 ml-4 mr-8 text-clip text-sm text-gray-500">{{ s.modifiedBy }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
  
<script setup>
import { useSearchPageStore } from '@/stores/SearchPageStore';
import { ClipboardDocumentIcon } from '@heroicons/vue/24/outline';
import { PencilIcon } from '@heroicons/vue/20/solid'
const store = useSearchPageStore();

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