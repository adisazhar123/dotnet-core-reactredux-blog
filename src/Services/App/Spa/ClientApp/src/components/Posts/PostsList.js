import React from 'react'
import {connect} from "react-redux";

import ListPost from './ListPost'
import { deletePost, getPosts } from "../../actions/posts";
import {Link} from "react-router-dom";

class PostsList extends React.Component {
	constructor(props) {
		super(props);
		this.state = { currentPage: 1 };	
	}
	
	componentDidMount() {
		console.log('mounted again ok');
		this.getPosts();
	}
	
	componentDidUpdate(prevProps, prevState, snapshot) {
		console.log('updated');
		const prevPage = parseInt(prevProps.currentPage);
		prevPage !== parseInt(this.props.currentPage) ? this.getPosts()
			: null;
	}
	
	getPosts = (prevPage) => {
		const page = parseInt(this.props.currentPage, 10) || 1;
		this.props.getPosts(page);
	};

	deletePost = (postId) => {
		this.props.deletePost(postId);
	};

	renderList = () => {
		return this.props.posts.map(post => {
			return (<div key={post.id}>
				<ListPost post={post} 
					deletePost={this.deletePost}
				/>
				</div>
			);
		}
		);
	};
	
	renderLoading = () => {
		const { posts } = this.props;
		return posts.isLoading ? 'Loading' : '';
	};
	
	changePage = (page) => {
		console.log(page.target.text);
		// this.setState({ currentPage: parseInt(page.target.text) });
	};
	
	renderPagination = () => {
		let htmlLinks = [];
		for (let i = 0; i < this.props.postsPagination.totalPages; i++) {
			let pageNumber = (i+1);
			htmlLinks.push(<Link onClick={this.changePage} key={i} to={`?page=${i+1}`}>{pageNumber + " "}</Link>);
		}
		return htmlLinks;
	};
	
	render() {			
		console.log("wkwkwkkw");
		return (
			<div>
				{this.renderList()}		
				{this.renderLoading()}
				{this.renderPagination()}
			</div>
		);
	}
}

PostsList.defaultProps = {
	currentPage: 1
};

const mapStateToProps = (state) => {
	return {
		posts: Object.values(state.posts.listOfPosts),
		postsPagination: state.posts.pagination
	}
};

export default connect(mapStateToProps, { getPosts, deletePost })
(PostsList);