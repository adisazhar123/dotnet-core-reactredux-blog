import React from 'react';
import { Editor } from '@tinymce/tinymce-react';
import { FormGroup, Form, Label, Input, Button } from "reactstrap";
import AsyncSelect from 'react-select/async';

class PostsForm extends React.Component {

    constructor(props) {
        super(props);
        const initialState = { title: '', body: '', selectedTags: [], coverImage: null };
        this.state = initialState;
    }

    setTinyMceContent = (e) => {
        const val = e.target.getContent();
        this.setState({ body: val });
    };

    onSubmit = (e) => {
        e.preventDefault();
        const formData = new FormData();
        formData.append('title', this.state.title);
        formData.append('body', this.state.body);
        formData.append('tags',  JSON.stringify(this.state.selectedTags));
        formData.append('coverImage', this.state.coverImage);
        this.props.onSubmit(formData);
    };

    handleTitle = (e) => {
        this.setState({ title: e.target.value });
    };

    searchTags = (inputValue) => {
        console.log('tag values', inputValue);
        this.props.searchTags(inputValue);
        console.log('tags from state', this.props.tags());
        return this.props.tags();
    };
    
    promiseOptions = inputValue =>
        new Promise(resolve => {
            resolve(this.searchTags(inputValue));
        });
    
    handleChange = (selected) => {
        selected = selected || [];
        console.log(selected);
        this.setState({ selectedTags: selected });
    };
    
    handleFileChange = (e) => {
      console.log(e.target.files);
      this.setState({ coverImage: e.target.files[0] });
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
                            onChange={this.handleChange}
                            loadOptions={this.promiseOptions}
                        />

                    </FormGroup>
                    
                    <FormGroup>
                        <input type={'file'} onChange={this.handleFileChange} />
                    </FormGroup>


                    <input type={'hidden'} name={'body'} value={this.state.body} />
                    <Button type={'submit'}>Submit</Button>
                </Form>
            </div>
        )
    }
}

export default PostsForm;