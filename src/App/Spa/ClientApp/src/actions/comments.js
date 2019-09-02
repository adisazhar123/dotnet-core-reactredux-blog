import { reset } from "redux-form";
import posts from '../apis/posts'
import TYPE from './types'

export const createComment = (postId, comment) => async (dispatch) => {
	try {
		const response = await posts.post(`/posts/${postId}/comments`, comment);
		dispatch({ type: TYPE.CREATE_COMMENT, payload: response.data });
		dispatch(reset('commentsForm'));
	} catch (e) {
		// switch (e.response.status) {
		// 	case TYPE.HTTP_STATUS_UNAUTHORIZED:
		// 		dispatch({ type: TYPE.HTTP_STATUS_UNAUTHORIZED, payload: 'You are unauthorized. Please login.' });
		// 	default:
		// }
			dispatch({ type: TYPE.ERROR_GENERIC, payload: { status: e.response.status } });
	}
};

export const getComments = (postId) => async (dispatch) => {
	const response = await posts.get(`/posts/${postId}/comments`);
	dispatch({ type: TYPE.GET_COMMENTS, payload: response.data });
};