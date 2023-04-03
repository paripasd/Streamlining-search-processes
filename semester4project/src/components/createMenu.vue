<template>
  <div class="text-right">
      <button  @click="open = true">Open Panel</button>
  </div>
  <TransitionRoot as="template" :show="open">
    <Dialog as="div" class="relative z-10" @close="open = false">
      <!-- The rest of the code for the panel -->
      <template>
<TransitionRoot as="template" :show="open">
  <Dialog as="div" class="relative z-10" @close="open = false">
    <TransitionChild as="template" enter="ease-in-out duration-500" enter-from="opacity-0" enter-to="opacity-100" leave="ease-in-out duration-500" leave-from="opacity-100" leave-to="opacity-0">
      <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity" />
    </TransitionChild>

    <div class="fixed inset-0 overflow-hidden">
      <div class="absolute inset-0 overflow-hidden">
        <div class="pointer-events-none fixed inset-y-0 right-0 flex max-w-full pl-10">
          <TransitionChild as="template" enter="transform transition ease-in-out duration-500 sm:duration-700" enter-from="translate-x-full" enter-to="translate-x-0" leave="transform transition ease-in-out duration-500 sm:duration-700" leave-from="translate-x-0" leave-to="translate-x-full">
            <DialogPanel class="pointer-events-auto relative w-screen max-w-full">
              <TransitionChild as="template" enter="ease-in-out duration-500" enter-from="opacity-0" enter-to="opacity-100" leave="ease-in-out duration-500" leave-from="opacity-100" leave-to="opacity-0">
                <div class="absolute top-0 left-0 -ml-8 flex pt-4 pr-2 sm:-ml-10 sm:pr-4">
                  <button type="button" class="rounded-md text-gray-300 hover:text-white focus:outline-none focus:ring-2 focus:ring-white" @click="open = false">
                    <span class="sr-only">Close panel</span>
                    <XMarkIcon class="h-6 w-6" aria-hidden="true" />
                  </button>
                </div>
              </TransitionChild>
              <div class="h-full overflow-y-scroll bg-white py-6 shadow-xl">
                <div>
                  <DialogTitle class="text-center text-base font-semibold leading-6 text-gray-900">Add New</DialogTitle>
                </div>
                <div class="space-x-96 relative mt-6 flex-1 px-4 sm:px-6 flex flex-row">
                  <div class="basis-1/2">
                    <CreateTree/>
                  </div>
                  <div class="flex-auto basis-1/2">
                    <form @submit.prevent="createNew()" id="data-entry-form" class="space-y-5">
                    <div class="flex flex-col">
                      <label for="question-input">Question:</label>
                      <textarea class="longtextinput h-32" id="question-input" v-model="formQuestion"></textarea>
                    </div>
                    <div class="flex flex-col">
                      <label for="question-input">Answer:</label>
                      <textarea class="longtextinput h-32" id="question-input" v-model="formAnswer"></textarea>
                    </div>
                    <div class="flex flex-col">
                      <label for="question-input">Comment:</label>
                      <textarea class="longtextinput h-32" id="question-input" v-model="formComment"></textarea>
                    </div>
                    <div class="flex flex-row">
                      <label for="expiry-input">Expiry:</label>
                      <input type="date" id="expiry-input" class="shortinput">
                    </div>
                    <div class="flex flex-row">
                      <label for="editedby-input">Edited&nbsp;by:</label>
                      <input type="text" id="editedby-input" class="shortinput" disabled>
                    </div>
                    <div>
                      <div class="flex flex-row">
                        <label for="custompath-checkbox">Use custom path</label>
                        <input type="checkbox" id="custompath-checkbox" v-model="customPathEnabled">
                      </div>
                      <p class="text-red-500" :hidden="!customPathEnabled">Category names are separated by commas (,) - do not use commas in category names!</p>
                    </div>
                    <div class="flex flex-row">
                      <input type="text" id="custompath-input" class="shortinput" :disabled="!customPathEnabled" v-model="store.createPath">
                    </div>
                    <button type="submit">Create</button>
                  </form>
                  </div>
                  
                </div>
              </div>
            </DialogPanel>
          </TransitionChild>
        </div>
      </div>
    </div>
  </Dialog>
</TransitionRoot>
</template>
    </Dialog>
  </TransitionRoot>
</template>

<script setup>
import { ref, computed} from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { XMarkIcon } from '@heroicons/vue/24/outline'
import  CreateTree  from '@/components/createTree.vue'
import { useCrudPageStore } from '@/stores/CrudPageStore'

const store = useCrudPageStore();
const customPathEnabled = ref(false);
const formQuestion = ref("");
const formAnswer = ref("");
const formComment = ref("");
//const formPath = computed(() => store.createPath);

function createNew(){
  //id is generated at API, but can't be null
  const newQna = {question: formQuestion.value, answer: formAnswer.value, comment: formComment.value, id: "", path: store.getCreatePath};
  if(typeof newQna.path === 'string'){ //by default it's an array, if it's a string it means that it was modified using the custom path field
    newQna.path = newQna.path.split(',');
  }
  let success = false;
  fetch('https://localhost:7018/api/Create', {
        method: 'POST',
        headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            },
        body: JSON.stringify(newQna)
    })
    .then(response => {});
  }
  console.log(success);

const open = ref(false)
</script>