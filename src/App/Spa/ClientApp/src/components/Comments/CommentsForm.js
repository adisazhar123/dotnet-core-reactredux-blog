import React from 'react';
import {FormGroup, Form, Button } from "reactstrap";

import './CommentsForm.css'

class CommentsForm extends React.Component {
	constructor(props) {
		super(props);
		this.state = {comment: ''};
	}
	
	onSubmit = (e) => {
		e.preventDefault();
		const formValues = this.state.comment;
		console.log(formValues);
		this.props.onSubmit(formValues);
	};
	
	handleComment = (event) => {
		this.setState({ comment: event.target.value });
	};
	
	render() {
		return (
			<div className={'mb-2'}>
				<Form onSubmit={this.onSubmit}>
					<FormGroup className={'comments-input'}>
						<textarea className={'form-control'} value={this.state.value} onChange={this.handleComment} />
					</FormGroup>
					
					<div className="comments-form-footer">
				    <Button type={'submit'} color={'success'}>Post Comment</Button>
					</div>
				</Form>
			</div>
		);
	}
}

export default CommentsForm;