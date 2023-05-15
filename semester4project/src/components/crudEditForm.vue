<template>
  <div>
    <!-- Notification component -->
    <div aria-live="assertive" class="pointer-events-none fixed inset-0 flex items-end px-4 py-6 sm:items-start sm:p-6">
      <div class="flex w-full flex-col items-center space-y-4 sm:items-end">
        <transition enter-active-class="transform ease-out duration-300 transition"
          enter-from-class="translate-y-2 opacity-0 sm:translate-y-0 sm:translate-x-2"
          enter-to-class="translate-y-0 opacity-100 sm:translate-x-0" leave-active-class="transition ease-in duration-100"
          leave-from-class="opacity-100" leave-to-class="opacity-0">
          <div v-if="showNotification"
            class="pointer-events-auto w-full max-w-sm overflow-hidden rounded-lg bg-white shadow-lg ring-1 ring-black ring-opacity-5">
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
                  <button type="button" @click="showNotification = false"
                    class="inline-flex rounded-md bg-white text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2">
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
    <form id="data-edit-form">
      <div class="grid grid-rows-4 grid-cols-6 w-full h-full p-2 gap-2">
        <div class="col-span-2 row-span-3 flex flex-col">
          <label for="question-input">Question:</label>
          <textarea class="longtextinput" id="question-input" v-model="store.unit.question"></textarea>
        </div>
        <div class="col-span-2 col-start-3 row-span-3 flex flex-col">
          <label for="answer-input">Answer:</label>
          <textarea class="longtextinput" id="answer-input" v-model="store.unit.answer"></textarea>
        </div>
        <div class="col-span-2 col-start-5 row-span-3 flex flex-col">
          <label for="comment-input">Comment:</label>
          <textarea class="longtextinput" id="comment-input" v-model="store.unit.comment"></textarea>
        </div>
        <div class="col-span-1 col-start-1 flex flex-row items-center">
          <label for="expiry-input">Expiry:</label>
          <input type="date" id="expiry-input" v-model="expiryDate" class="shortinput">
        </div>
        <div class="col-span-2 col-start-2 flex flex-row items-center">
          <label for="editedby-input">Edited&nbsp;by:</label>
          <input name="editedby-input" class="shortinput" disabled v-model="editedBy">
        </div>
        <div class="col-span-1 col-start-4">
          <TagSelector></TagSelector>
        </div>
        <div class="col-span-2 col-start-5 flex flex-row justify-evenly">
          <button @click="updateUnit()" type="button" class="uniform-button">Update</button>
          <button @click="deleteUnit()" type="button" class="uniform-button hover:bg-red-600">Delete</button>
        </div>
      </div>
    </form>
  </div>
</template>

<style>
#data-edit-form label {
  @apply font-semibold
}
</style>

<script setup>
import { useCrudPageStore } from '@/stores/CrudPageStore';
import { computed, watchEffect } from 'vue';
import { ref } from 'vue'
import { CheckCircleIcon } from '@heroicons/vue/24/outline'
import { XMarkIcon } from '@heroicons/vue/20/solid'
import TagSelector from './tagSelector.vue';

const showNotification = ref(false);
const notificationTitle = ref('');
const notificationMessage = ref('');
const feedback = ref("");
const store = useCrudPageStore();
const expiryDate = computed({
  get: () => {
    return store.unit.expiry.split('T')[0];
  },
  set: (date) => {
    store.unit.expiry = new Date(date).toISOString();
  }
});

const editedBy = computed({
  get: () => {
    if(!store.unit.modificationDate || store.unit.modificationDate == "") return "";
    return "unknown at " + formatModificationDate(store.unit.modificationDate);
  },
  set: () => {}
});

window.addEventListener('load', function () {
  watchEffect(() => {

    const questionField = document.getElementById("question-input");
    questionField.value = store.unit.question;

    const answerField = document.getElementById("answer-input");
    answerField.value = store.unit.answer;

    const commentField = document.getElementById("comment-input");
    commentField.value = store.unit.comment;

    const expiryField = document.getElementById("expiry-input");
    expiryField.value = store.unit.expiry.split('T')[0];

  });
});

async function updateUnit() {
  const unit = { question: "", answer: "", comment: "", id: store.unit.id, path: store.unit.path, tags: store.unit.tags };

  const questionField = document.getElementById("question-input");
  unit.question = questionField.value;

  const answerField = document.getElementById("answer-input");
  unit.answer = answerField.value;

  const commentField = document.getElementById("comment-input");
  unit.comment = commentField.value;

  unit.modificationDate = new Date().toISOString();

  const expiryField = document.getElementById("expiry-input");
  unit.expiry = new Date(expiryField.value).toISOString();


  try {
    const response = await fetch('https://localhost:7018/api/Update', {
      method: 'PUT',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(unit)
    })
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
    

    if (!response.ok) {
      throw new Error(`HTTP error ${response.status}`);
    }
    showNotification.value = true;
    notificationTitle.value = 'Update Successful';
    notificationMessage.value = 'Successfully updated ' + store.unit.question + ' at ' + store.unit.path[0];
    store.updateDataByPath(store.unit.path);
    setTimeout(() => {
      showNotification.value = false;
    }, 4000);

  }
  catch (error) {
    feedback.value = "There was an error performing this action. See the console for details."
    console.error('Error:', error);
  }
}

async function deleteUnit() {

  try {
    const response = await fetch('https://localhost:7018/api/Delete/' + store.unit.id, {
      method: 'DELETE',
    })
    if (!response.ok) {
      throw new Error(`HTTP error ${response.status}`);
    }
    
    
    const questionField = document.getElementById("question-input");
    questionField.innerHTML = "";
    
    const answerField = document.getElementById("answer-input");
    answerField.innerHTML = "";
    
    const commentField = document.getElementById("comment-input");
    commentField.innerHTML = "";
    
    const modificationDateField = document.getElementById("editedby-input");
    
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
    notificationTitle.value = 'Deleted';
    notificationMessage.value = 'Successfully deleted ' + store.unit.question + ' at ' + store.unit.path[0];
    store.updateDataByPath(store.unit.path);
    setTimeout(() => {
      showNotification.value = false;
    }, 4000);
    
    store.unit = {question:"",answer:"",comment:"", id:"", expiry:"",modificationDate:"", modifiedBy:"", path:[], tags:[]};
  }
  catch (error) {
    feedback.value = "There was an error performing this action. See the console for details."
    console.error('Error:', error);
  }
}

function formatModificationDate(txtDate) {
  const date = new Date(txtDate);
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, '0');
  const day = date.getDate().toString().padStart(2, '0');
  const hour = date.getHours().toString().padStart(2, '0');
  const minute = date.getMinutes().toString().padStart(2, '0');
  return `${day}/${month}/${year} ${hour}:${minute}`;
}

</script>
