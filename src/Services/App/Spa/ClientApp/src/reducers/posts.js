import _ from 'lodash'
import TYPE from '../actions/types'

const initialState = { 
	listOfPosts: {}, 
	isLoading: false, 
	errorMessage: null, 
	pagination: {
		currentPage: null,
		totalPages: null,
		nextPageUrl: null,
		prevPageUrl: null
	},
	user: null,	
};

export default (state, action) => {
	state = state || initialState;
	
	switch (action.type) {
		case TYPE.GETTING_ALL_POSTS:
			return { ...state, isLoading: true};
		case TYPE.GET_ALL_POSTS:
			return { ...state, listOfPosts: { ..._.mapKeys(action.payload.posts, 'id') }, isLoading: false, pagination: { ..._.omit(action.payload, 'posts') } };
		case TYPE.CREATE_POST:
			return { ...state, listOfPosts: { ...state.listOfPosts, [action.payload.id]: action.payload } };
		case TYPE.DELETE_POST:
			return {...state, listOfPosts: _.omit(state.listOfPosts, action.payload.id) } ;
		case TYPE.GET_POST:
			return { ...state, listOfPosts: { ...state.listOfPosts, [action.payload.id]: action.payload }, 
				user: action.payload.user };
		case TYPE.ERROR_CREATE_POST:
			return { ...state, errorMessage: action.payload };
		default:
			return state;
	}
}