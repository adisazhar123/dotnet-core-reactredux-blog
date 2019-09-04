import api from '../apis/tags'
import TYPE from "./types";

export const getTagsByKeywords = (query) => async (dispatch) => {
    try {
        const response = await api.get(`/tags?query=${query}`);
        dispatch({ type: TYPE.TAGS_GET_KEYWORDS, payload: response.data });
    } catch (e) {
        if (e.response) {
            dispatch({ type: TYPE.ERROR_GET_TAGS, payload: e.response });
        } else if (e.request) {
            console.log(e.request);
        } else {
            console.log(e.message);
        }
    }
};