import React from 'react'
import { Container } from 'reactstrap'
import { connect } from "react-redux";

import { register } from '../../actions/authentication'

import RegisterForm from "./RegisterForm";


class RegisterPage extends React.Component {

	registerAccount = (data) => {
		console.log(data);
		this.props.register(data);
	};
	
	render() {
		return (
			<div id={'register'} className={'mt-3'}>
				<Container>
					<RegisterForm onSubmit={this.registerAccount} />
				</Container>
			</div>
		);
	}
}

// const mapStateToProps = (state) => {
// 	return {
//		
// 	}
// };

export default connect(null, {
	register
})(RegisterPage);