import React from 'react'
import {connect} from "react-redux";

import { getUsers } from "../../actions/users";
import {Container} from "reactstrap";

class UsersList extends React.Component {
	componentDidMount() {
		this.props.getUsers();
	}
	
	errorExists = () => {
		if (this.props.auth.errorMessage != null) console.log("ada error haha");
		return this.props.auth.errorMessage != null;
	};
	
	componentDidUpdate(prevProps, prevState, snapshot) {
		console.log('yea updated');
	}

	renderErrorMessages = () => {
		const messages = this.props.auth.errorMessage;
		return (
			<div className="alert alert-danger">
				<p>{messages}</p>
			</div>
		);
	};

	render() {
		return (
			<div>
				<Container>
					<h1>Users List</h1>
					{ this.errorExists() === true ? this.renderErrorMessages() : null}
				</Container>
			</div>
		)	
	}
}

const mapStateToProps = (state) => {
	return {
		users: state.users,
		auth: state.auth
	}
};
export default connect(mapStateToProps,
	{ getUsers })
(UsersList);