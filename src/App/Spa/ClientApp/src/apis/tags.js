import axios from 'axios'

const TOKEN = localStorage.getItem('jwtoken');

export default axios.create({
    baseURL: 'http://192.168.16.106/api',
    headers: {
        Authorization: `Bearer ${TOKEN}`
    }
});