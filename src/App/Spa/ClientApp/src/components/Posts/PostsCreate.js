import React from 'react'
import {connect} from "react-redux";
import {
  Card, CardBody,
  Container
} from 'reactstrap';

import { createPost } from '../../actions/posts';
import { getTagsByKeywords } from "../../actions/tags";

import PostsForm from "./PostsForm";


class PostsCreate extends React.Component {
  onSubmit = (postData) => {
    this.props.createPost(postData);
  };
  
  searchSelect = (inputValue) => {
    this.props.getTagsByKeywords(inputValue);
  };
  
  getTags = () =>  this.props.tags;
  
  render() {
    return (
          <div className={'mt-3'}>
            <Container>
              <Card>
                  <CardBody>
                      <PostsForm searchTags={this.searchSelect} onSubmit={this.onSubmit} tags={this.getTags} />
                  </CardBody>
              </Card>
            </Container>
          </div>      
      )
  }
}

const mapStateToProps = (state) => {
  return {
      posts: state.posts,
      tags: Object.values(state.tags.listOfTags)
  }  
};

const mapDispatchToProps = {
  createPost,
  getTagsByKeywords  
};

export default connect(mapStateToProps,
    mapDispatchToProps
)(PostsCreate);