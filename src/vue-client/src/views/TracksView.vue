<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router';
import { Ref, ref, onBeforeMount } from 'vue';
import { ITrack, Track, IProjectMetaData, Project } from '../api';

const projectMeta: Ref<IProjectMetaData | null> = ref(null);
const tracks: Ref<ITrack[]> = ref([]);
const route = useRoute();
const router = useRouter();

const projectId = route.params.projectId as string;

onBeforeMount(async () => {
    try {
        projectMeta.value = await Project.getProject(projectId);
    }
    catch {
        return router.push('/NotFound')
    }

    tracks.value = await Track.getTracks(projectId);
});

</script>

<template>
    <VContainer>
        <VRow class="flex-nowrap mb-2">
            <VCol class="flex-grow-1 flex-shrink-0">
                <h2><span class="text-grey-lighten-1" @click="router.push('/')">Projects</span> / {{ projectMeta?.name }}</h2>
            </VCol>
            <VCol cols="1">
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