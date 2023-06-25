<script setup lang="ts">
import type { CallbackTypes } from "vue3-google-login";
import { useRouter } from 'vue-router';

const router = useRouter();

const idToken: string | null = localStorage.getItem("Bearer");

if (idToken) {
    // validate token either in the backend or the frontend
}

const callback: CallbackTypes.CredentialCallback = (response) => {
    console.log("Handle the response", response);
    
    localStorage.setItem("Bearer", response.credential);
 
    router.push('/Projects');
}

</script>

<template>
    <v-card
      class="mx-auto"
      max-width="344"
      title="Sign In"
    >
      <v-container>
        <GoogleLogin :callback="callback" />
      </v-container>
    </v-card>
  </template>