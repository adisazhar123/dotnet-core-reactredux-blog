import React from 'react'
import {connect} from "react-redux";
import {
  Card, CardBody,
  CardTitle, Container
} from 'reactstrap';

import { createPost } from '../../actions/posts';
import PostsForm from "./PostsForm";


class PostsCreate extends React.Component {
  onSubmit = (postData) => {
    this.props.createPost(postData);
  };
  
  render() {
    return (
          <div className={'mt-3'}>
            <Container>
              <Card>
                  <CardBody>
                      <PostsForm onSubmit={this.onSubmit} />
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