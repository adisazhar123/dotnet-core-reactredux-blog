import React from 'react';
import { Editor } from '@tinymce/tinymce-react';
import { FormGroup, Form, Label, Input, Button } from "reactstrap";
import AsyncSelect from 'react-select/async';

class PostsForm extends React.Component {

	constructor(props) {
	  super(props);
	  this.state = { title: '', body: '' };
	}
	
	setTinyMceContent = (e) => {
		const val = e.target.getContent();
		this.setState({ body: val });
	};
  
  onSubmit = (e) => {
  	  e.preventDefault();
  	  const formValues = { title: this.state.title, body: this.state.body };
      this.props.onSubmit(formValues);
  };
  
  handleTitle = (e) => {
  	this.setState({ title: e.target.value });
  };
  
  getTags = (inputValue) => {
  	console.log(inputValue);
  	// this.props.selectDataSource(inputValue);
  };
  
  render() {
      return (
          <div>
              <Form onSubmit={this.onSubmit}> 	
								<FormGroup>
									<Label>Title</Label>
                  <Input type={'text'} onChange={this.handleTitle} value={this.state.title} />
								</FormGroup>
	              
	              <FormGroup>
		              <Label for={"Body"}>Body</Label>
		              <Editor apiKey='a3evimmg1cn4cb561y133694ucxuznl5hd7bm42l2039y0i7'
		                      init={{
			                      plugins: 'link image code',
			                      toolbar: 'undo redo | bold italic | alignleft aligncenter alignright | code',
			                      images_upload_url: '/posts/test',
		                      }}
		                      onChange={this.setTinyMceContent}
		                      value={this.state.body}
		              />
	              </FormGroup>
	              
	              <FormGroup>
		              <AsyncSelect
		                isMulti
		                cacheOptions
		                defaultOptions
		                loadOptions={this.getTags}
		              />
	              </FormGroup>

                  
                <input type={'hidden'} name={'body'} value={this.state.body} />                 
                <Button type={'submit'}>Submit</Button>
              </Form>
          </div>
      )
  }
}

export default PostsForm;