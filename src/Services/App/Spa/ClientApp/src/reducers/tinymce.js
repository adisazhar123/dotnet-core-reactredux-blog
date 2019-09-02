import TYPE from '../actions/types'

const initialValue = { value: '' };

export default (state = null, action) => {
	state = state || initialValue;
	switch (action.type) {
		case TYPE.TINY_MCE_RESET:
			return {...state, value: ''};
		default:
			return state;
	}
};