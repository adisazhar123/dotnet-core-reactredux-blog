import axios from 'axios'

const TOKEN = localStorage.getItem('jwtoken');

export default axios.create({
    baseURL: 'https://localhost:5001/api',
    headers: {
        Authorization: `Bearer ${TOKEN}`
    }
});