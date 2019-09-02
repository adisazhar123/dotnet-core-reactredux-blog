import axios from 'axios'


// const TOKEN = localStorage.getItem('jwtoken');

const api = axios.create({
	baseURL: 'https://localhost:5001/api/users',
});

const usersService = {
	getUserPosts: async (userId) => {
		return await api.get(`/${userId}/posts`);
	},
	
};


export {usersService};
