import React from 'react'
import {FormGroup, Form, Label, Input, Button, Row, Col} from "reactstrap";

const registerAccount = () => {
	
};


class RegisterForm extends React.Component {
	constructor(props) {
		super(props);
		this.state = { username: '', password: '' };
	}
	
	registerAccount = (e) => {
		e.preventDefault();
		const newUser = { username: this.state.username, password: this.state.password };
		this.props.onSubmit(newUser);
	};
	
	setUsername = (e) => {
		console.log(e.target.value);
		this.setState({ username: e.target.value })
	};
	
	setPassword = (e) => {
		console.log(e.target.value);
		this.setState({ password: e.target.value });
	};
	
	render() {
		return (
			<Form onSubmit={this.registerAccount}>
				<Row>
					<Col md={6}>
					<FormGroup>
						<Label>Username</Label>
						<Input type={'text'} onChange={this.setUsername} />
					</FormGroup>
					<FormGroup>
						<Label>Password</Label>
						<Input type={'password'} onChange={this.setPassword} />
					</FormGroup>
						<Button color={'primary'}>Register Account</Button>
					</Col>
				</Row>
			</Form>
		)
	}

}

export default RegisterForm;