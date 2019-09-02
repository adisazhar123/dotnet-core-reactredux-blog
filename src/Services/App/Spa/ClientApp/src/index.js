import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'react-router-redux';
import configureStore from './store/configureStore';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import history from './configs/history'


// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;
const store = configureStore(history, initialState);

const USER_AUTHENTICATED = 'USER_AUTHENTICATED';
const rootElement = document.getElementById('root');

localStorage.getItem('jwtoken') ? store.dispatch({type: USER_AUTHENTICATED}) : null;

ReactDOM.render(
	<Provider store={store}>
		<ConnectedRouter history={history}>
			<App />
		</ConnectedRouter>
	</Provider>,
	rootElement);

registerServiceWorker();
