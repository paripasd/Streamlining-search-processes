<template>
    <div class="w-full min-h-fit block rounded-md">
        <div class="flex p-1 space-x-2 items-center">
            <p v-for="tag in tagList" @click="flipTag(tag.label)" class="tag-text cursor-pointer" :class="store.selectedTags.includes(tag.label) ? 'opacity-100' : 'opacity-30', tag.color">{{ tag.label }}</p>
        </div>
    </div>
</template>

<script setup>
import { useCrudPageStore } from '@/stores/CrudPageStore';
import { useSearchPageStore } from '@/stores/SearchPageStore';

const tagList = useCrudPageStore().tagList;
const store = useSearchPageStore();

//If a tag is clicked and isn't present in the selected tags array (for filtering) it gets added and vice versa
function flipTag(tag){
    if(store.selectedTags.includes(tag)){
        store.selectedTags = store.selectedTags.filter(function(item){
            return item !== tag;
        });
    } else {
        store.selectedTags.push(tag);
    }
}
</script>