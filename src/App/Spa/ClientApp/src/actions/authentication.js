import TYPE from'./types'
import auth from '../apis/auth'
import history from '../configs/history'

export const login = ({username, password}) => async (dispatch) => {
	try {
		const response = await auth.post('/login', {username, password});
		dispatch({ type: TYPE.USER_AUTHENTICATED, payload: response.data });
		localStorage.setItem("jwtoken", response.data.token);
		localStorage.setItem("userId", response.data.userId);
		window.location = '/';
	} catch (e) {
		dispatch({ type: TYPE.ERROR_AUTHENTICATION, payload: 'Invalid credentials' })
	}
};

export const logout = () => async (dispatch) => {
	localStorage.removeItem('jwtoken');
	dispatch({ type: TYPE.USER_UNAUTHENTICATED });
	window.location = '/';
};

export const register = ({username, password}) => async (dispatch) => {
	try {
		const response = await auth.post('/register', {username, password});
		dispatch({ type: TYPE.USERS_REGISTERED, payload: response.data });
		history.push('/login');
	} catch (e) {
		dispatch({ type: TYPE.ERROR_GENERIC, payload: e.response.status });
	}
};