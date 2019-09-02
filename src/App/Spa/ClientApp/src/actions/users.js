import { sampleService } from "../apis/sampleService";
import { usersService } from '../services/usersService';

import TYPE from './types'

export const getUsers = () => async (dispatch) => {
	try {
		const response = await sampleService.getUsers();
		dispatch({ type: TYPE.USERS_GET_ALL, payload: response.data });
	} catch (e) {
		dispatch({ type: TYPE.ERROR_AUTHENTICATION, payload: e.message });
	}
};

export const getUserPosts = (userId) => async (dispatch) => {
	try {
		const response = await usersService.getUserPosts(userId);
		dispatch({ type: TYPE.USERS_GET_POSTS, payload: response.data });
	} catch (e) {
		if (e.response) {
			dispatch({ type: TYPE.ERROR_GENERIC, payload: e.response.status });
		}
	}
};

export const getUserFavoritePosts = (username) => async (dispatch) => {
	try {
		const response = await usersService.getUserFavoritePosts(username);
		dispatch({ type: TYPE.USERS_GET_FAVORITE_POSTS, payload: response.data });
	} catch (e) {
		if (e.response) {
			dispatch({ type: TYPE.ERROR_GENERIC, payload: e.response.status });
		}
	}
};