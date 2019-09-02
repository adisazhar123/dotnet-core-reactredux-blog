import React from 'react';
import {connect} from "react-redux";

import { logout } from "../../actions/authentication";

class Logout extends React.Component {
	componentDidMount() {
		this.props.logout();
	}
	
	render() {
		return null;
	}
}


export default connect(null, 
	{ logout }
)(Logout);