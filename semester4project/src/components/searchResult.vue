<template>
    <div class="h-fit px-2">
      <div v-for="s in store.searchResult" :key="s.id" class="h-fit my-4 relative space-x-3 rounded-lg border border-gray-300 bg-white px-6 py-5 shadow-sm focus-within:ring-2 focus-within:ring-indigo-500 focus-within:ring-offset-2 hover:border-gray-400">
        <div class="pb-16">
          <a href="#" class="focus:outline-none">
            <p class="text-xl pt-2 pb-8 font-medium text-gray-900">{{ s.question }}</p>
            <p class="h-fit pt-2 text-clip text-sm text-gray-500">{{ s.answer }}</p>
          </a>
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
  import { ref, onMounted } from 'vue';
  const store = useSearchPageStore();

  const sample = [
  {
    question: "Besøg skolen - udover åbent hus",
    answer: "",
    comment: "test",
    id: "398a4f7c-5bce-4a9d-84c8-c96993b387ec",
    path: [
        "427 Gudenaadalens Efterskole"
    ],
    modifiedBy: "Bjorn Jeppensen"
  },
  {
    question: "Besøg skolen - udover åbent hus",
    answer: "Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.",
    comment: "test",
    id: "398a4f7c-5bce-4a9d-84c8-c96993b387ec",
    path: [
        "427 Gudenaadalens Efterskole"
    ],
    modifiedBy: "Bjorn Jeppensen"
  },
  {
    question: "Besøg skolen - udover åbent hus",
    answer: "Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.",
    comment: "test",
    id: "398a4f7c-5bce-4a9d-84c8-c96993b387ec",
    path: [
        "427 Gudenaadalens Efterskole"
    ],
    modifiedBy: "Bjorn Jeppensen"
  },
  {
    question: "Besøg skolen - udover åbent hus",
    answer: "Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.",
    comment: "test",
    id: "398a4f7c-5bce-4a9d-84c8-c96993b387ec",
    path: [
        "427 Gudenaadalens Efterskole"
    ],
    modifiedBy: "Bjorn Jeppensen"
  },
  {
    question: "Besøg skolen - udover åbent hus",
    answer: "Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.",
    comment: "test",
    id: "398a4f7c-5bce-4a9d-84c8-c96993b387ec",
    path: [
        "427 Gudenaadalens Efterskole"
    ],
    modifiedBy: "Bjorn Jeppensen"
  },
  {
    question: "Besøg skolen - udover åbent hus",
    answer: "Hvis der er nogen, der spørger ind til at se skolen udover vores åbent hus arrangementer:\nVi vil helst, at man bruger vores åbent hus arrangementer, men hvis man får tilbudt en plads, så finder vi en aften.",
    comment: "test",
    id: "398a4f7c-5bce-4a9d-84c8-c96993b387ec",
    path: [
        "427 Gudenaadalens Efterskole"
    ],
    modifiedBy: "Bjorn Jeppensen"
  }

  ]
  </script>