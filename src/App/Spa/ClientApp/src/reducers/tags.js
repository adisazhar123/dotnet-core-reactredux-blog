// import _ from 'lodash'
import TYPE from '../actions/types'

const initialState = {
    listOfTags: {}
};

export default (state, action) => {
    state = state || initialState;
    switch (action.type) {
        case TYPE.TAGS_GET_KEYWORDS:
            return { ...state, listOfTags: action.payload };
        default:
            return state;
    }
}