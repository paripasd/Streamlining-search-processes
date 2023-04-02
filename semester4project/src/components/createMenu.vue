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
                <div class="h-full bg-white py-6 shadow-xl">
                  <div>
                    <DialogTitle class="text-center text-base font-semibold leading-6 text-gray-900">Add New</DialogTitle>
                  </div>
                  <div class="space-x-96 relative mt-6 flex-1 px-4 sm:px-6 flex flex-row">
                    <div class="h-screen basis-1/2">
                      <CreateTree />
                    </div>
                    <div class="flex-auto basis-1/2">
                      <form id="data-entry-form" class="space-y-10">
                      <div class="flex flex-col">
                        <label for="question-input">Question:</label>
                        <textarea class="longtextinput h-32" id="question-input"></textarea>
                      </div>
                      <div class="flex flex-col">
                        <label for="question-input">Answer:</label>
                        <textarea class="longtextinput h-32" id="question-input"></textarea>
                      </div>
                      <div class="flex flex-col">
                        <label for="question-input">Comment:</label>
                        <textarea class="longtextinput h-32" id="question-input"></textarea>
                      </div>
                      <div class="flex flex-row">
                        <label for="expiry-input">Expiry:</label>
                        <input type="date" id="expiry-input" class="shortinput">
                      </div>
                      <div class="flex flex-row">
                        <label for="editedby-input">Edited&nbsp;by:</label>
                        <input type="text" id="editedby-input" class="shortinput" disabled>
                      </div>
                      <div class="flex flex-row">
                        <label for="custompath-checkbox">Use custom path</label>
                        <input type="checkbox" id="custompath-checkbox" v-model="customPathEnabled">
                      </div>
                      <div class="flex flex-row">
                        <input type="text" id="custompath-input" class="shortinput" :disabled="!customPathEnabled" v-model="store.createPath">
                      </div>
                      <input type="submit">
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
import { ref, computed, watchEffect} from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { XMarkIcon } from '@heroicons/vue/24/outline'
import  CreateTree  from '@/components/createTree.vue'
import { useCrudPageStore } from '@/stores/CrudPageStore'

const store = useCrudPageStore();
const customPathEnabled = ref(false);

const open = ref(false)
</script>