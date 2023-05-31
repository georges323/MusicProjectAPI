<script setup lang="ts">
import { Ref, ref, onMounted } from 'vue'
import { ITrack, Track } from '../api'

const tracks: Ref<ITrack[]> = ref([]);

const props = defineProps<{
    projectId: string
}>()
 
onMounted(async () => {
    tracks.value = await Track.getTracks(props.projectId);
});
</script>

<template>
    <p>{{ props.projectId }}</p>
</template>