import React from 'react';
import { getComments } from "../../actions/comments";
import {connect} from "react-redux";
import ListComment from "./ListComment";

class CommentsList extends React.Component {
	componentDidMount() {
		const { postId } = this.props;
		this.props.getComments(postId);
	}
	
	renderComments = () => {
		return this.props.comments.map((comment) => {
			return (
				<div key={comment.id}>
					<ListComment comment={comment} />
				</div>
			)
		});
	};
	
	
	render() {
		return (
			<div>
				{this.renderComments()}
			</div>
		);
	}
}

const mapStateToProps = (state) => {
	return {
		comments: Object.values(state.comments.listOfComments)
	}
};

export default connect(mapStateToProps, 
	{ getComments })
(CommentsList);