import axios from 'axios'


const TOKEN = localStorage.getItem('jwtoken');

const api = axios.create({
	baseURL: 'https://localhost:5001/api/users',
	headers: {
		Authorization: `Bearer ${TOKEN}`
	}
});

const usersService = {
	getUserPosts: async (userId) => {
		return await api.get(`/${userId}/posts`);
	},
	
	getUserFavoritePosts: async(username) => {
		return await api.get(`/${username}/posts/favorite`);
	},
	
	followUser: async(followingUserId) => {
		return await api.post('/follow', { followingUserId });
	}
	
};

export {usersService};