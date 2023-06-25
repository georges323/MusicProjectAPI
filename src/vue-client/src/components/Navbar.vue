 <script setup lang="ts">
import { useRouter } from 'vue-router';

const router = useRouter();
</script>

<template>
    <VAppBar :elevation="2" rounded>
        <VAppBarTitle @click="router.push('/projects')">
            Musicol
        </VAppBarTitle>
        <VSpacer />
    </VAppBar>
</template>