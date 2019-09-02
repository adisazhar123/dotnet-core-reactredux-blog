import React from 'react';
import { Route, Switch } from 'react-router';

import requireAuth from './components/Hoc/Authentication'
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import PostsCreate from './components/Posts/PostsCreate';
import PostsShow from "./components/Posts/PostsShow";
import LoginPage from "./components/Auth/LoginPage";
import UsersList from "./components/Users/UsersList";
import Logout from "./components/Auth/Logout";
import UsersShow from './components/Users/UsersShow'
import RegisterPage from "./components/Auth/RegisterPage";

export default () => (
	<Layout>
		<Switch>
			<Route path='/' exact component={Home} />
			<Route path='/counter' component={Counter} exact />
			<Route path='/fetch-data/:startDateIndex?' exact component={FetchData} />
			{/*Posts*/}
			<Route path={'/posts/create'} exact component={PostsCreate} />
			<Route path={'/posts/:postId'} component={PostsShow} />
			{/*Account*/}
			<Route path={'/login'} exact component={LoginPage} />
			<Route path={'/users'} exact component={requireAuth(UsersList)} />
			<Route path={'/logout'} exact component={Logout} />
			<Route path={'/register'} exact component={RegisterPage} />
			
			{/*	Users*/}
			<Route path={'/users/@:userName/:favorites?'} exact component={UsersShow} />
		</Switch>
	</Layout>
);
