import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

export default function (ComposedComponent) {
	class Authentication extends React.Component {
		UNSAFE_componentWillMount() {
			if (!this.props.authenticated) {
				this.props.history.push('/login');
			}
		}
		UNSAFE_componentWillUpdate(nextProps, nextState, nextContext) {
			if (!nextProps.authenticated) {
				this.props.history.push('/login');
			}
		}
		
		PropTypes = {
			router: PropTypes.object,
		};
		
		render() {
			return <ComposedComponent {...this.props} />
		}
	}
	
	const mapStateToProps = (state) => {
		return { authenticated: state.auth.authenticated };
	};
	return connect(mapStateToProps)(Authentication);
}