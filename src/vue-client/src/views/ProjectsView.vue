<script setup lang="ts">
import { Ref, ref, onBeforeMount } from 'vue';
import { IProject, Project } from '../api';
import { useRouter } from 'vue-router';

const router = useRouter();
const projects: Ref<IProject[]> = ref([]);

onBeforeMount(async () => {
  projects.value = await Project.getProjects();
});
</script>

<template>
    <VContainer>
        <VRow class="flex-nowrap mb-2">
            <VCol class="flex-grow-1 flex-shrink-0">
                <h2>Projects</h2>
            </VCol>
            <VCol cols="1">
                <VBtn :elevation="1" :border="true">
                    Add
                    <VIcon end icon="mdi-plus" class="pr-2" />
                </VBtn>
            </VCol>
        </VRow>
        <VList lines="one">
            <VListItem
                v-for="project in projects"
                :key="project.id"
                :title="project.name"
                @click="router.push(`/tracks/${project.id}`)"
                class="ma-1 pb-5 pt-5"
                :border="true"
                :elevation="2"
                :rounded="true"
            ></VListItem>
        </VList>
    </VContainer>
</template>