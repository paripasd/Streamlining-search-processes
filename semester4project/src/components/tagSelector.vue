<template>
    <Menu as="div" class="relative inline-block text-left w-full">
      <div>
        <MenuButton class="inline-flex w-full justify-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50">
          Tags
          <ChevronDownIcon class="-mr-1 h-5 w-5 text-gray-400 rotate-180" aria-hidden="true" />
        </MenuButton>
      </div>
  
      <transition enter-active-class="transition ease-out duration-100" enter-from-class="transform opacity-0 scale-95" enter-to-class="transform opacity-100 scale-100" leave-active-class="transition ease-in duration-75" leave-from-class="transform opacity-100 scale-100" leave-to-class="transform opacity-0 scale-95">
        <MenuItems class="absolute right-0 bottom-full z-10 mt-2 w-full origin-bottom-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
          <div class="py-1 flex flex-col">
            <div v-for="tag in store.tagList.filter((tag) => tag.label !== 'Expires soon' && tag.label !== 'Expired')" class="flex justify-between items-center px-2 py-3 cursor-pointer hover:bg-gray-300" @click="flipTag(tag.label)">
                <p class="tag-text" :class="tag.color">{{ tag.label }}</p>
                <CheckIcon v-show="store.unit.tags.includes(tag.label)" class="w-5 h-5 text-gray-900"/>
            </div>
          </div>
        </MenuItems>
      </transition>
    </Menu>
  </template>
  
<script setup>
import { Menu, MenuButton, MenuItem, MenuItems } from '@headlessui/vue'
import { ChevronDownIcon } from '@heroicons/vue/20/solid'
import { CheckIcon } from '@heroicons/vue/24/outline';
import { useCrudPageStore } from '@/stores/CrudPageStore';

const store = useCrudPageStore();

//If a tag is clicked and isn't present in the tags of the unit it gets added and vice versa
function flipTag(tag){
  if(store.unit.tags.includes(tag)){
        store.unit.tags = store.unit.tags.filter(function(item){
            return item !== tag;
        });
    } else {
        store.unit.tags.push(tag);
    }
}

</script>