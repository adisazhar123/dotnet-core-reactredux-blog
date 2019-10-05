import TYPE from '../actions/types'
import _ from "lodash";

const initialState = { 
	users: {}, 
	posts:{}, 
	username: null, 
	usersFollow: {
		success: null,
		message: null
	},
	id: null,
	isFollowing: false,
};

export default (state, action) => {
	state = state || initialState;
	switch (action.type) {
		case TYPE.USERS_GET_ALL:
			return { ...state, 
				users: {..._.mapKeys(action.payload, 'username') } 
			};
		case TYPE.USERS_GET_POSTS:
			return { 
				...state, 
				posts: { ..._.mapKeys(action.payload.posts, 'id')}, 
				username: action.payload.username,
				id: action.payload.userId,
				isFollowing: action.payload.isFollowing
			};
		case TYPE.USERS_GET_FAVORITE_POSTS:
			return { 
				...state, 
				posts: { ..._.mapKeys(action.payload.posts, 'id') } 
			};
		case TYPE.USERS_FOLLOW_SUCCESS:
			return { 
				...state,
				usersFollow: {
					success: true,
					message: 'Successfully followed user.'
				},
				isFollowing: true
			};
		case TYPE.USERS_UNFOLLOW_SUCCESS:
			return {
				...state,
				isFollowing: false
			};
		default:
			return state;
	}
};