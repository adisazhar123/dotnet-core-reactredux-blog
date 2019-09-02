import TYPE from '../actions/types'

const initialValue = { status: null, message: null };

const errorMessages = {
	400: 'An error has occured. Please try again.',
	401: 'You are unauthorized. Please login.',
	500: 'A server error has occured. Please try again later.',
};

export default (state, action) => {
	state = state || initialValue;
	
	switch (action.type) {
		case TYPE.ERROR_GENERIC:
			return { ...state, status: action.payload.status, message: errorMessages[state.status] };
		default:
			return state;
	}
};