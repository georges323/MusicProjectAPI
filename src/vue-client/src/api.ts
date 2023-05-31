import axios, { AxiosResponse } from "axios"

export interface IProject {
    id: string
    name: string
    bpm: number
    timeSig: string
}

export interface ITrack {
    id: string
    name: string
    imageUrl: string
    projectId: string
}

const axiosInstance = axios.create({
    baseURL: "https://localhost:5001/api/",    
})

const responseBody = (response: AxiosResponse) => response.data

const requests = {
    get: (url: string) => axiosInstance.get(url).then(responseBody)
}

export const Project = {
    getProjects: () => requests.get('project') as Promise<IProject[]>
}

export const Track = {
    getTracks: (projectId: string) => requests.get(`track/${projectId}`) as Promise<ITrack[]>
}