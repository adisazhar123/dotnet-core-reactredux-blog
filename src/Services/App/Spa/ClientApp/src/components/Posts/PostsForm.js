import React from 'react';
import { Field, reduxForm } from 'redux-form';
import { Editor } from '@tinymce/tinymce-react';
import { FormGroup, Form, Label, Input, Button } from "reactstrap";
import { change } from "redux-form";

class PostsForm extends React.Component {

	constructor(props) {
	  super(props);
	  this.state = {value: ''};
	}
	
	setTinyMceContent = (e) => {
		const val = e.target.getContent();
		this.props.dispatch(change('postsForm', 'body', val));
		this.setState({ value: val });
	};
  
  renderTitle = ({ input, label, meta, autoComplete }) => {
      return (
          <FormGroup>
              <Label for="exampleEmail">{label}</Label>
              <Input autoComplete={autoComplete} />
          </FormGroup>
      )
  };
  
  renderBody = ({ input, label, meta, name, type }) => {
      console.log('input', input)
    return (
        <FormGroup>
            <Label for={name}>{label}</Label>
            <Input type={type} />
        </FormGroup>
    )  
  };

  renderInput = ({ input, label, meta, autoComplete, type, name, value = null }) => {
      return (
          <FormGroup>
              <Label for={name}>{label}</Label>
              <Input {...input} autoComplete={autoComplete} type={type} />
          </FormGroup>
      )
  };
  
  renderTinyMce = ({ input, label, meta, autoComplete, type, name, value = null }) => {
    return (
    	<FormGroup>
		    <Label for={name}>{label}</Label>
		    <Editor apiKey='a3evimmg1cn4cb561y133694ucxuznl5hd7bm42l2039y0i7'
	              // initialValue="<p>This is the initial content of the editor</p>"
	              init={{
	                plugins: 'link image code',
	                toolbar: 'undo redo | bold italic | alignleft aligncenter alignright | code'
	              }}
	              onChange={this.setTinyMceContent}
		            value={'kekekke'}
		            // ref={(editor) => {
			          //   this.editor = editor;
		            // }}
	      />
	    </FormGroup>
    )
  };
  
  onSubmit = (formValues) => {
    // console.log(this.props);
      this.props.onSubmit(formValues);
  };
  
  render() {
      return (
          <div>
              <Form onSubmit={this.props.handleSubmit(this.onSubmit)}>
                  <Field 
                   name={'title'}
                   component={this.renderInput}
                   label={'Title'}
                   autoComplete={'off'}
                   type={'text'}
                  />
                  
                  <Field
                   name={'tinyMce'}
                   component={this.renderTinyMce}
                   label={'Body'}
                   type={'textarea'}
                  />

                <Field
                  name={'body'}
                  component={this.renderInput}
                  label={null}
                  type={'hidden'}
                  value={this.state.value}
                />
                  
                  <Button type={'submit'}>Submit</Button>
              </Form>
          </div>
      )
  }
}

const validate = (formValues) => {
  const errors = {};
  
  if (!formValues.title) {
      errors.title = 'You must enter a title!';
  }
  
  // if (!formValues.body) {
  //     errors.body = 'You must enter a description!';
  // }
    return errors;
};

// export default PostsForm;

export default reduxForm({
    form: 'postsForm'
})(PostsForm);