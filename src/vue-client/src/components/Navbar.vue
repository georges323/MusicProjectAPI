 <script setup lang="ts">
import { useRouter } from 'vue-router';

const router = useRouter();
</script>

<template>
    <VAppBar :elevation="2" rounded>
        <VAppBarTitle @click="router.push('/')">
            Musicol
        </VAppBarTitle>
        <VSpacer />
        <div class="pr-4">
            <VAvatar color="info">
                <VIcon icon="mdi-account-circle" />
            </VAvatar>
        </div>
    </VAppBar>
</template>