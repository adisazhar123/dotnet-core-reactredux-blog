import React from 'react';
import { Field, reduxForm } from 'redux-form';
import {FormGroup, Form, Label, Input, Button } from "reactstrap";

import './CommentsForm.css'

class CommentsForm extends React.Component {
	renderInput = ({ input, name, label = null, placeholder, type }) => {
		return (
			<FormGroup className={'comments-input'}>
				<Label for={name}>{label}</Label>
				<Input {...input} type={type} placeholder={placeholder} />
			</FormGroup>
		);
	};
	
	onSubmit = (formValues) => {
		console.log('on comments submit ', formValues);
		this.props.onSubmit(formValues);
	};
	
	render() {
		return (
			<div className={'mb-2'}>
				<Form onSubmit={this.props.handleSubmit(this.onSubmit)}>
					<Field
						name={'comment'}
						component={this.renderInput}
						type={'textarea'}
						placeholder={'Write a comment...'}
					/>
					<div className="comments-form-footer">
				    <Button type={'submit'} color={'success'}>Post Comment</Button>
					</div>
				</Form>
			</div>
		);
	}
}

export default reduxForm({
	form: 'commentsForm'
})(CommentsForm);