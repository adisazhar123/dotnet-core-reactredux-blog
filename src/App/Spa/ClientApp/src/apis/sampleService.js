import axios from 'axios';

const TOKEN = localStorage.getItem('jwtoken');

const api = axios.create({
	baseURL: 'http://192.168.16.106/api',
	headers: {
		Authorization: `Bearer ${TOKEN}`
	}
});

const getUsers = async () => {
	return await api.get('/users');
};

const sampleService = {getUsers};

export {sampleService};
