<script setup lang="ts">
import { Ref, ref } from 'vue';
import { IProject, Project } from '../api';
import { useRouter } from 'vue-router';

const router = useRouter();
const projects: Ref<IProject[]> = ref([]);

Project.getProjects()
.then(data => {
    projects.value = data;
});

</script>

<template>
    <VContainer>
        <VRow class="d-flex mb-6">
            <VCol class="ma-2 pa-2 me-auto">
                <h2>Projects</h2>
            </VCol>
            <VCol class="d-flex justify-end ma-2 pa-2">
                <VBtn :elevation="1" :border="true">
                    Add
                    <VIcon end icon="mdi-plus" class="pr-2" />
                </VBtn>
            </VCol>
        </VRow>
        <VRow>
            <VList class="w-100" lines="one">
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
        </VRow>
    </VContainer>
</template>