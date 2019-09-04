import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import { reducer as formReducer } from 'redux-form'

import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';
import postsReducer from '../reducers/posts'
import commentsReducer from '../reducers/comments'
import authReducer from '../reducers/auth'
import usersReducer from '../reducers/users'
import tinyMceReducer from  '../reducers/tinymce'
import errorsReducer from '../reducers/errors'
import tagsReducer from '../reducers/tags'

export default function configureStore (history, initialState) {
  const reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
    posts: postsReducer,
    comments: commentsReducer,
    auth: authReducer,
    users: usersReducer,
    tinyMce: tinyMceReducer,
    errors: errorsReducer,
    tags: tagsReducer
  };

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer,
    form: formReducer
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
