<template>
  <div class="text-right flex items-center">
      <button class="uniform-button w-10 h-10" @click="open = true"><PlusIcon/></button>
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
                  <button id="Create Close" type="button" class="rounded-md text-gray-300 hover:text-white focus:outline-none focus:ring-2 focus:ring-white" @click="open = false">
                    <span class="sr-only">Close panel</span>
                    <XMarkIcon class="h-6 w-6" aria-hidden="true" />
                  </button>
                </div>
              </TransitionChild>
              <div class="h-full overflow-y-scroll bg-stone-50 py-6 shadow-xl">
                <div>
                  <DialogTitle class="text-center text-base font-semibold leading-6 text-gray-900">Add New</DialogTitle>
                </div>
                <div class="space-x-12 relative mt-6 flex-1 px-4 sm:px-6 flex flex-row">
                  <div class="basis-1/2">
                    <CreateTree/>
                  </div>
                  <div class="flex-auto basis-1/2">
                    <div>
                        <!-- Notification component -->
                        <div aria-live="assertive" class="pointer-events-none fixed inset-0 flex items-end px-4 py-6 sm:items-start sm:p-6">
                          <div class="flex w-full flex-col items-center space-y-4 sm:items-end">
                            <transition enter-active-class="transform ease-out duration-300 transition" enter-from-class="translate-y-2 opacity-0 sm:translate-y-0 sm:translate-x-2" enter-to-class="translate-y-0 opacity-100 sm:translate-x-0" leave-active-class="transition ease-in duration-100" leave-from-class="opacity-100" leave-to-class="opacity-0">
                              <div v-if="showNotification" class="pointer-events-auto w-full max-w-sm overflow-hidden rounded-lg bg-white shadow-lg ring-1 ring-black ring-opacity-5">
                                <div class="p-4">
                                  <div class="flex items-start">
                                    <div class="flex-shrink-0">
                                      <CheckCircleIcon class="h-6 w-6 text-green-400" aria-hidden="true" />
                                    </div>
                                    <div class="ml-3 w-0 flex-1 pt-0.5">
                                      <p class="text-sm font-medium text-gray-900">{{ notificationTitle }}</p>
                                      <p class="mt-1 text-sm text-gray-500">{{ notificationMessage }}</p>
                                    </div>
                                    <div class="ml-4 flex flex-shrink-0">
                                      <button type="button" @click="showNotification = false" class="inline-flex rounded-md bg-white text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2">
                                        <span class="sr-only">Close</span>
                                        <XMarkIcon class="h-5 w-5" aria-hidden="true" />
                                      </button>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </transition>
                          </div>
                        </div>
                        <form @submit.prevent="createNew()" id="data-entry-form" class="space-y-5">
                          <div>
                            <div class="flex flex-row">
                              <input type="text" id="custompath-input" class="shortinput m-0 mb-4 transition duration-200 disabled:bg-slate-200 disabled:text-black disabled:border-slate-400" :disabled="!customPathEnabled" v-model="store.createPath">
                            </div>
                            <div class="flex flex-row">
                              <SwitchGroup as="div" class="flex items-center">
                                <Switch v-model="customPathEnabled" :class="[customPathEnabled ? 'bg-cyorange' : 'bg-gray-200', 'relative inline-flex h-6 w-11 flex-shrink-0 cursor-pointer rounded-full border-2 border-transparent transition-colors duration-200 ease-in-out focus:outline-none focus:ring-2 focus:ring-cyorange focus:ring-offset-2']">
                                  <span aria-hidden="true" :class="[customPathEnabled ? 'translate-x-5' : 'translate-x-0', 'pointer-events-none inline-block h-5 w-5 transform rounded-full bg-white shadow ring-0 transition duration-200 ease-in-out']" />
                                </Switch>
                                <SwitchLabel as="span" class="ml-3 text-sm">
                                  <span class="font-medium text-gray-900">Use custom path</span>
                                </SwitchLabel>
                              </SwitchGroup>
                            </div>
                            <p class="text-red-500" :hidden="!customPathEnabled">Category names are separated by commas (,) - do not use commas in category names!</p>
                          </div>
                        <div class="flex flex-col">
                          <label for="question-input" class="ml-1">Question:</label>
                          <textarea class="longtextinput h-32" id="question-input" v-model="formQuestion"></textarea>
                        </div>
                        <div class="flex flex-col">
                          <label for="question-input" class="ml-1">Answer:</label>
                          <textarea class="longtextinput h-32" id="question-input" v-model="formAnswer"></textarea>
                        </div>
                        <div class="flex flex-col">
                          <label for="question-input" class="ml-1">Comment:</label>
                          <textarea class="longtextinput h-32" id="question-input" v-model="formComment"></textarea>
                        </div>
                        <div class="flex flex-row items-center">
                          <label for="expiry-input" class="ml-1">Expiry:</label>
                          <input type="date" id="add-expiry-input" value="2029-12-31" class="shortinput">
                        </div>
                        <div class="flex flex-row items-center">
                          <label for="editedby-input" class="ml-1">Edited&nbsp;by:</label>
                          <input type="text" id="editedby-input" class="shortinput" disabled>
                        </div>
                        <div class="flex justify-end items-end h-full">
                          <button type="submit" class="uniform-button py-4 mr-4">Done</button>
                        </div>
                        <p>{{ feedback }}</p>
                      </form>
                      </div>
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
import { Switch, SwitchGroup, SwitchLabel } from '@headlessui/vue'
import { PlusIcon } from '@heroicons/vue/20/solid';
import { CheckCircleIcon } from '@heroicons/vue/24/outline'


const showNotification = ref(false)
const notificationTitle = ref('')
const notificationMessage = ref('')


const store = useCrudPageStore();
const customPathEnabled = ref(false);
const formQuestion = ref("");
const formAnswer = ref("");
const formComment = ref("");
const feedback = ref("");

async function createNew(){
  //id is generated at API, but can't be null
  const newQna = {question: formQuestion.value, answer: formAnswer.value, comment: formComment.value, id: "", tags: ["none"], path: store.getCreatePath};
  if(typeof newQna.path === 'string'){ //by default it's an array, if it's a string it means that it was modified using the custom path field
    newQna.path = newQna.path.split(',');
  }
  newQna.expiry = new Date(document.getElementById("add-expiry-input").value).toISOString();
  newQna.modificationDate = new Date().toISOString();
  console.log(document.getElementById("add-expiry-input").value);
  console.log(JSON.stringify(newQna));
  try{
    const response = await fetch('https://localhost:7018/api/Create',{
      method: 'POST',
        headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            },
        body: JSON.stringify(newQna)
    });

    if (!response.ok) {
      throw new Error(`HTTP error ${response.status}`);
    }
    const responseData = await response.json();

    try{
      await fetch('https://localhost:7018/api/Update/expiry', {
      method: 'PUT',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
      })
    }
    catch (error) {
      console.error('Error:', error);
    }

    showNotification.value = true;
    notificationTitle.value = 'Successfully created!';
    notificationMessage.value = '';
    store.updateDataByPath(newQna.path);
    setTimeout(() => {
    showNotification.value = false;
    }, 4000);

    

  } catch(error) {
    feedback.value = "There was an error performing this action. See the console for details."
    console.error('Error:', error);
  }
}

const open = ref(false)
</script>