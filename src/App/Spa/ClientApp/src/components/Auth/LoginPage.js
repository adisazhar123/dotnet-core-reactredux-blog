import React from 'react'
import LoginForm from './LoginForm'
import {Alert, Container} from "reactstrap";
import {connect} from "react-redux";

import { login } from '../../actions/authentication'

class LoginPage extends React.Component {
	login = ({username, password}) => {
		console.log('in login page ', username, password);
		this.props.login({username, password});
	};
	
	renderErrors = () => {
		const error = this.props.auth.errorMessage;
		if (error)
		return (
			<Alert color={'danger'}>
				<p>{error}</p>
			</Alert>
		)	
	};
	
	render() {
		return (
			<div id={'login'} className={'mt-3'}>
				<Container>
					{this.renderErrors()}
					<h3>Login</h3>
					<LoginForm onSubmit={this.login} />
				</Container>
			</div>
		)
	}
}

const mapStateToProps = (state) => {
	return {
		auth: state.auth
	}
};

export default connect(mapStateToProps, 
	{ login })
(LoginPage);