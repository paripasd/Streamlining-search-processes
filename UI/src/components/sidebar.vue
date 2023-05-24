<template>
    <div class="flex min-h-0 flex-1 flex-col bg-stone-800">
          <div class="flex flex-1 flex-col overflow-y-auto pt-5 pb-4">
            <div class="flex flex-shrink-0 items-center px-4">
              <img class="h-8 w-auto" src="@/assets/images/CY_white.svg" alt="CompanYoung" />
              
            </div>
            <nav class="mt-5 flex-1 space-y-1 px-2">
              <a v-for="item in navigation" :key="item.name" :href="item.href" :class="[item.current ? 'bg-gray-900 text-white' : 'text-gray-100 hover:bg-cyorange hover:text-white', 'group flex items-center rounded-md px-2 py-2 text-sm font-medium']">
                <component :is="item.icon" :class="[item.current ? 'text-gray-300' : 'text-gray-400 group-hover:text-gray-300', 'mr-3 h-6 w-6 flex-shrink-0']" aria-hidden="true" />
                {{ item.name }}
              </a>
            </nav>
          </div>
          <div class="flex flex-shrink-0 bg-neutral-700 p-4">
            <a href="/login" class="group block w-full flex-shrink-0">
              <div class="flex items-center">
                <div>
                  <img class="inline-block h-9 w-9 rounded-full" src="https://upload.wikimedia.org/wikipedia/commons/2/2c/Default_pfp.svg" alt="" />
                </div>
                <div class="ml-3">
                  <p class="text-sm font-medium text-white">Your Name</p>
                  <p class="text-xs font-medium text-gray-300 group-hover:text-gray-200">View profile</p>
                </div>
              </div>
            </a>
          </div>
        </div>
</template>

<script setup>
  import { ref } from 'vue'
  import {
    MagnifyingGlassIcon,
    FolderIcon,
    HomeIcon,
  } from '@heroicons/vue/24/outline'
  
  const navigation = [
    //{ name: 'Home', href: '/', icon: HomeIcon, current: false },
    { name: 'Search', href: '/search', icon: MagnifyingGlassIcon, current: false },
    { name: 'Data Manager', href: '/datamanager', icon: FolderIcon, current: false },
  ]
  
  const sidebarOpen = ref(false)
  </script>