<script setup lang="ts">
import { Ref, ref, onMounted } from 'vue'
import { IProject, Project } from '../api'

const projects: Ref<IProject[]> = ref([]);

onMounted(async () => {
  projects.value = await Project.getProjects();
});

const trackUrl = (projectId: string) => {
    return `/tracks/${projectId}`;
}
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
            <div class="flex flex-col mt-8">
                <router-link v-for="project in projects"
                    class="text-xl border rounded-xl border-slate-900 py-6 px-4 my-2"
                    :key="project.id"
                    :to=trackUrl(project.id)>
                    {{ project.name }}
                </router-link>
            </div>
        </div>
    </div>
</template>