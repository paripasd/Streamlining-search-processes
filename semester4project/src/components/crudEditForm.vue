<template>
    <form id="data-edit-form">
          <div class="grid grid-rows-4 w-full h-full p-2 gap-2">
              <div class="col-span-1 row-span-3 flex flex-col">
                <label for="question-input">Question:</label>
                <textarea class="longtextinput" id="question-input"></textarea>
              </div>
              <div class="col-span-1 col-start-2 row-span-3 flex flex-col">
                <label for="answer-input">Answer:</label>
                <textarea class="longtextinput" id="answer-input"></textarea>
              </div>
              <div class="col-span-1 col-start-3 row-span-3 flex flex-col">
                <label for="comment-input">Comment:</label>
                <textarea class="longtextinput" id="comment-input"></textarea>
              </div>
              <div class="flex flex-row">
                <label for="expiry-input">Expiry:</label>
                <input type="date" id="expiry-input" class="shortinput">
              </div>
              <div class="flex flex-row">
                <label for="editedby-input">Edited&nbsp;by:</label>
                <input type="text" id="editedby-input" class="shortinput" disabled>
              </div>
              <div class="flex flex-row justify-evenly">
                <button @click="updateUnit()" class="uniform-button">Update</button>
                <button @click="deleteUnit()" class="uniform-button hover:text-red-500">Delete</button>
              </div>
          </div>
    </form>
</template>

<script setup>
import { useCrudPageStore } from '@/stores/CrudPageStore';
import {computed, watchEffect} from 'vue';
const store = useCrudPageStore();
computed(() => store.unit);
window.addEventListener('DOMContentLoaded', function() {
    watchEffect(() => {
      const questionField = document.getElementById("question-input");
      questionField.innerHTML = store.unit.question;

      const answerField = document.getElementById("answer-input");
      answerField.innerHTML = store.unit.answer;

      const commentField = document.getElementById("comment-input");
      commentField.innerHTML = store.unit.comment;
    });
  });

function updateUnit(){
  const unit = { question:"", answer:"", comment:"", id:store.unit.id, path: store.unit.path };
  
  const questionField = document.getElementById("question-input");
  unit.question = questionField.value;
  
  const answerField = document.getElementById("answer-input");
  unit.answer = answerField.value;
  
  const commentField = document.getElementById("comment-input");
  unit.comment = commentField.value;
  
  console.log(unit);
  fetch('https://localhost:7018/api/Update', {
      method: 'PUT',
      headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
      body: JSON.stringify(unit)
  })
  .then(response => response.json())
}

function deleteUnit(){
  fetch('https://localhost:7018/api/Delete/'+store.unit.id, {
    method: 'DELETE',
    })
    .then(response => response.json())
}

</script>
