import React from 'react';
import { connect } from "react-redux";
import {Badge, Container} from "reactstrap";

import { getPost } from "../../actions/posts";
import { createComment, getComments } from "../../actions/comments";
import { favoritePost } from "../../actions/posts";

import CommentsForm from '../Comments/CommentsForm'
import CommentsList from "../Comments/CommentsList";
import FavoritePostHeart from './FavoritePostHeart';
import NonFavoritePostHeart from './NonFavoritePostHeart'

import moment from "moment";
import {Link} from "react-router-dom";

import './PostsShow.css'

import parse from 'html-react-parser'


const PostTags = (props) => {
  if (props.posts.postTags === undefined || props.posts.postTags === null) return false;
  console.log(props);

  const tags = props.posts.postTags;
  console.log(tags);
  return (
      <p>
        { tags.map(({tag}) => (<Badge key={tag.id} className={'mr-1'} color="warning" pill>{ tag.title }</Badge>) ) }
      </p>
  )
};

class PostBody extends React.Component {
  render() {
    // return(
    // 	this.props.children
    // )
    if (this.props.children !== undefined)
      return (
          parse(this.props.children)
      );
    return null
  }
}

class PostsShow extends React.Component {
  componentDidMount() {
    console.log('component mounted!');
    const postId = this.props.match.params.postId;
    this.props.getPost(postId);
  }


  renderErrors = () => {
    return (
        <div className={'alert alert-danger mt-2'}>
          <p>{ this.props.errors }</p>
        </div>
    );
  };

  renderTitle = (post, postInfo) => {
    const title = post === undefined ? 'Loading ...' : post.title;

    return (
        <div className={"posts-header"}>
          <Container>
            <div className="posts-title">
              <h1>
                <strong>{title}</strong>
              </h1>
              {this.renderInfo(postInfo)}
            </div>
          </Container>
        </div>
    );
  };

  favoritePost = () => {
    const postId = this.props.posts.id;
    this.props.favoritePost(postId);
  };

  renderBody = (post) => {
    const body = post === undefined ? 'Loading ...' : post.body;

    return  (
        <div className={"posts-body"}>
          <Container>
            <PostBody>
              {body}
            </PostBody>
            {
              this.props.loggedInUserId !== this.props.postOwnerId
                  // true
                  ? (<div className="favorite-post">
                    <small>Enjoyed this post?</small>
                    <br/>
                    <div className="btn-favorite">
                      {
                        !this.props.isFavorite ? <NonFavoritePostHeart favoritePost={this.favoritePost} />
                            : <FavoritePostHeart favoritePost={this.favoritePost} />
                      }
                    </div>
                  </div>)
                  : null
            }

            <hr/>
          </Container>
        </div>
    );
  };


  renderInfo = (postInfo) => {
    postInfo = postInfo === null ? 'Loading ...' : postInfo;

    const timeStamp = moment(postInfo.updatedAt).format("dddd, MMMM Do YYYY");
    const username = postInfo.user === null ? 'Loading ...' : postInfo.user.username;

    return (
        <div className={'posts-info'}>
          <p className="author text white">
            <Link to={`/users/@${username}`}>
              {username}
            </Link>
          </p>
          <PostTags {...this.props} />
          <small className={'text text-timestamp white'}>{timeStamp}</small>
        </div>
    )
  };
  // Call Action Creators
  createComment = (comment) => {
    const postId = this.props.match.params.postId;
    this.props.createComment(postId, {body: comment});
  };

  render() {
    const { posts, match, postInfo } = this.props;
    return (
        <div>
          <Container>
            {this.props.errors != null ? this.renderErrors() : null }
          </Container>

          {this.renderTitle(posts, postInfo)}
          {this.renderBody(posts)}

          <div className="comments-container">
            <Container>
              <h4>Comments</h4>
              <CommentsForm onSubmit={this.createComment} />
              <CommentsList postId={match.params.postId} />
            </Container>
          </div>

        </div>
    );
  }
}

const mapStateToProps = (state, { match }) => {
  return {
    posts: state.posts.listOfPosts[match.params.postId] || {},
    comments: state.comments.listOfComments,
    tinyMceValue: state.tinyMce.value,
    errors: state.errors.message,
    postInfo: {
      user: state.posts.user,
    },
    favoritePostId: state.posts.favoritePostId,
    isFavorite: state.posts.isFavorite,
    loggedInUserId: state.auth.userId,
    postOwnerId: state.posts.user.id
  }
};

export default connect(mapStateToProps,
    { getPost, createComment, getComments, favoritePost })
(PostsShow);