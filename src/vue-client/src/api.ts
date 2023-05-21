import axios, { AxiosResponse } from "axios"

export interface IProject {
    id: number
    name: string
    bpm: number
    timeSig: string
}

const axiosInstance = axios.create({
    baseURL: "http://localhost:5000/api/",    
})

const responseBody = (response: AxiosResponse) => response.data

const requests = {
    get: (url: string) => axiosInstance.get(url).then(responseBody)
}

export const Project = {
    getProjects: () => requests.get('project') as Promise<IProject[]>
}