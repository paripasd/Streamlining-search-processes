<template>
    <div class="flex min-h-full flex-1 items-center justify-center px-4 py-12 sm:px-6 lg:px-8">
    <div class="w-full max-w-sm space-y-10">
      <div>
        <img class="mx-auto h-10 w-auto" src="@/assets/images/CY_black.svg" alt="Your Company" />
        <h2 class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">Sign in to your account</h2>
      </div>
      <form class="space-y-6" @submit.prevent="login">
        <div class="relative -space-y-px rounded-md shadow-sm">
          <div class="pointer-events-none absolute inset-0 z-10 rounded-md ring-1 ring-inset ring-gray-300" />
          <div>
            <label for="email-address" class="sr-only">Username</label>
            <input id="email-address" name="email" type="text" v-model="username" autocomplete="email" class="relative block w-full rounded-t-md border-0 py-1.5 text-gray-900 ring-1 ring-inset ring-gray-100 placeholder:text-gray-400 focus:z-10 focus:ring-2 focus:ring-inset focus:ring-cyorange sm:text-sm sm:leading-6 p-1 outline-none" placeholder="Username" />
          </div>
          <div>
            <label for="password" class="sr-only">Password</label>
            <input id="password" name="password" type="password" autocomplete="current-password" class="relative block w-full rounded-b-md border-0 py-1.5 text-gray-900 ring-1 ring-inset ring-gray-100 placeholder:text-gray-400 focus:z-10 focus:ring-2 focus:ring-inset focus:ring-cyorange sm:text-sm sm:leading-6 p-1 outline-none" placeholder="Password" />
          </div>
        </div>

        <div>
          <button type="submit" class="flex w-full justify-center rounded-md bg-cyorange px-3 py-1.5 text-sm font-semibold leading-6 text-gray-100 hover:bg-cyorange hover:text-white focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-cyorange">Sign in</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup>
import { useRouter, useRoute } from 'vue-router';
import { useAuthStore } from '../stores/AuthStore';
import { ref } from 'vue';

const store = useAuthStore();
const router = useRouter();
const route = useRoute();

const username = ref('');
const password = ref('');

function login(){
    store.setLoggedIn(true);
    store.user.username = username;
    const redirectPath = route.query.redirect || '/';
    router.push(redirectPath);
}
</script>