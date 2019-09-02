import _ from 'lodash'
import TYPE from '../actions/types'

const initialState = { listOfComments: {}, isLoading: false };

export default (state, action) => {
	state = state || initialState;
	
	switch (action.type) {
		case TYPE.CREATE_COMMENT:
			console.log(action.payload);
			return { ...state, listOfComments: { ...state.listOfComments, [action.payload.id]: action.payload } };
		case TYPE.GET_COMMENTS:
			return { ...state, listOfComments: {..._.mapKeys(action.payload, 'id')} };
		default:
			return state;
	}
};
