import React from 'react'
import {connect} from "react-redux";
import {
  Card, CardBody,
  Container
} from 'reactstrap';

import { createPost } from '../../actions/posts';
import PostsForm from "./PostsForm";


class PostsCreate extends React.Component {
  onSubmit = (postData) => {
    this.props.createPost(postData);
  };
  
  selectDataSource = (inputValue) => {
    
  };
  
  render() {
    return (
          <div className={'mt-3'}>
            <Container>
              <Card>
                  <CardBody>
                      <PostsForm selectDataSource={this.selectDataSource} onSubmit={this.onSubmit} />
                  </CardBody>
              </Card>
            </Container>
          </div>      
      )
  }
}

const mapStateToProps = (state) => {
  return {
      posts: state.posts
  }  
};

export default connect(mapStateToProps,
  { createPost }
)(PostsCreate);