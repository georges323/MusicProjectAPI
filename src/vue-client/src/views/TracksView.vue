<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router';
import { Ref, ref } from 'vue';
import { ITrack, Track, IProjectMetaData, Project } from '../api';

const projectMeta: Ref<IProjectMetaData | null> = ref(null);
const tracks: Ref<ITrack[]> = ref([]);
const route = useRoute();
const router = useRouter();

const projectId = route.params.projectId as string;

Project.getProject(projectId)
.then(data => {
    projectMeta.value = data;
}).catch(() => {
    router.push('/NotFound');
})

Track.getTracks(projectId)
.then(data => {
    tracks.value = data;
});
</script>

<template>
    <VContainer>
        <VRow class="d-flex mb-6">
            <VCol class="ma-2 pa-2 me-auto">
                <h2><span class="text-grey-lighten-1" @click="router.push('/')">Projects</span> / {{ projectMeta?.name }}</h2>
            </VCol>
            <VCol class="d-flex justify-end ma-2 pa-2">
                <VBtn :elevation="1" :border="true">
                    Add
                    <VIcon end icon="mdi-plus" class="pr-2" />
                </VBtn>
            </VCol>
        </VRow>
        <VList lines="one" v-if="tracks">
            <VListItem
                v-for="track in tracks"
                :key="track.id" 
                :title="track.name"
                class="ma-1 pb-5 pt-5"
                :border="true"
                :elevation="2"
                :rounded="true"
            >
            </VListItem>
        </VList>
        <VCard v-else>
            No tracks ... yet!
        </VCard>
    </VContainer>
</template>