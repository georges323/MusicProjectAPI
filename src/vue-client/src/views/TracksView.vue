<script setup lang="ts">
import { useRoute } from 'vue-router';
import { Ref, ref, onBeforeMount } from 'vue';
import { ITrack, Track, IProjectMetaData, Project } from '../api';

const projectMeta: Ref<IProjectMetaData | null> = ref(null);
const tracks: Ref<ITrack[]> = ref([]);
const route = useRoute();

const projectId = route.params.projectId as string;

onBeforeMount(async () => {
    tracks.value = await Track.getTracks(projectId);
    projectMeta.value = await Project.getProject(projectId);
});
</script>

<template>
    <p></p>
</template>