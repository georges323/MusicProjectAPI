<script setup lang="ts">
import { reactive } from 'vue'

interface Project {
    id: number
    name: string
}

let projects = reactive<Project[]>([
    {
        id: 1,
        name: "Drowning"
    },
    {
        id: 2,
        name: "Water st"
    }])
</script>

<template>
    <div class="flex h-screen justify-center p-5">
        <div class="h-full w-full md:max-w-2xl">
            <div class="flex gap-3">
                <p class="text-3xl font-bold">
                    Projects
                </p>
                <button 
                    class="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-sm px-3 py-1 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 mt-2 ease-linear transition-all duration-150"
                    type="button"
                >
                    Add
                </button>
            </div>
            <div className="flex flex-col mt-8">
                <div v-for="project in projects" 
                    :key="project.id"
                    class="text-xl border rounded-xl border-slate-900 py-6 px-4 my-2">
                    {{ project.name }}
                </div>
            </div>
        </div>
    </div>
</template>