import TYPE from '../actions/types'


const initialState = { 
	authenticated: false, 
	errorMessage: null,
	userId: null
};

export default (state, action) => {
	state = state || initialState;
	
	switch (action.type) {
		case TYPE.USER_AUTHENTICATED:
			return { ...state, authenticated: true, userId: action.payload };
		case TYPE.ERROR_AUTHENTICATION:
			return { ...state, errorMessage: action.payload };
		case TYPE.USER_UNAUTHENTICATED:
			return { ...state, authenticated: false };
		default:
			return state;
	}
};