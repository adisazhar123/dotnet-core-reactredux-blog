import React from 'react';
import { Field, reduxForm } from 'redux-form';
import {FormGroup, Form, Label, Input, Button } from "reactstrap";

class LoginForm extends React.Component {
	renderInput = ({ input, name, label = null, placeholder, type }) => {
		return (
			<FormGroup className={'login-input'}>
				<Label for={name}>{label}</Label>
				<Input {...input} type={type} placeholder={placeholder} />
			</FormGroup>
		);
	};
	
	onSubmit = (formValues) => {
		this.props.onSubmit(formValues);
	};
	
	render() {
		return (
			<Form onSubmit={this.props.handleSubmit(this.onSubmit)}>
				<Field
					name={'username'}
					component={this.renderInput}
					type={'text'}
					placeholder={'Enter username'}
				/>
				<Field
					name={'password'}
					component={this.renderInput}
					type={'password'}
					placeholder={'Enter password'}
				/>
				<FormGroup>
					<Button color={'success'} type={'submit'}>Login</Button>
				</FormGroup>
			</Form>
		)
	}
}

export default reduxForm({
	form: 'loginForm'
})(LoginForm);