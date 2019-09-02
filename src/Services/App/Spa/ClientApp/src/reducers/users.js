import TYPE from '../actions/types'
import _ from "lodash";

const initialState = { users: {}, posts:{}, username: null };

export default (state, action) => {
	state = state || initialState;
	switch (action.type) {
		case TYPE.USERS_GET_ALL:
			return { ...state, users: {..._.mapKeys(action.payload, 'username') } };
		case TYPE.USERS_GET_POSTS:
			return { ...state, posts: { ..._.mapKeys(action.payload.posts, 'id')}, 
				username: action.payload.username };
		default:
			return state;
	}
};