import axios from 'axios';

const TOKEN = localStorage.getItem('jwtoken');

const api = axios.create({
	baseURL: 'https://localhost:5001/api',
	headers: {
		Authorization: `Bearer ${TOKEN}`
	}
});

const getUsers = async () => {
	return await api.get('/users');
};

const sampleService = {getUsers};

export {sampleService};
