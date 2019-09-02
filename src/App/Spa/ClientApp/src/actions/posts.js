import posts from '../apis/posts'
import TYPE from './types'
import history from '../configs/history'

const USER_ID = localStorage.getItem('userId');

export const getPosts = (page = 1) => async (dispatch) => {
	dispatch({ type: TYPE.GETTING_ALL_POSTS });
	const response = await posts.get(`/posts?page=${page}`);
	dispatch({ type: TYPE.GET_ALL_POSTS, payload: response.data });
};

export const createPost = (post) => async (dispatch) => {
	try {
		const response = await posts.post(`/users/${USER_ID}/posts`, { ...post });
		dispatch({ type: TYPE.CREATE_POST, payload: response.data });
		history.push(`/posts/${response.data.id}`);
		// dispatch(reset('postsForm'));
		// dispatch({ type: TYPE.TINY_MCE_RESET })
	} catch (e) {
		if (e.response) {
			dispatch({ type: TYPE.ERROR_CREATE_POST, payload: e.response });
		} else if (e.request) {
			console.log(e.request);
		} else {
			console.log(e.message);
		}
	}
};

export const deletePost= (postId) => async (dispatch) => {
	const response = await posts.delete(`/posts/${postId}`);
	dispatch({ type: TYPE.DELETE_POST, payload: response.data });
};

export const getPost = (postId) => async (dispatch) => {
	const response = await posts.get(`/posts/${postId}`);
	dispatch({ type: TYPE.GET_POST, payload: response.data }); 
};

export const favoritePost = (postId) => async (dispatch) => {
	try {
		const response = await posts.post( `/favorite-posts`, {postId, userId: USER_ID} );
		dispatch({ type: TYPE.POSTS_FAVORITED, payload: response.data });
	} catch (e) {
		dispatch({ type: TYPE.ERROR_GENERIC, payload: e.response.status })
	}
};