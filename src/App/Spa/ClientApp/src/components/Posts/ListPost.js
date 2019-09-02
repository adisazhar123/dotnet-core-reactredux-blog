import React from 'react'
import {Button, Card, CardBody, CardTitle} from "reactstrap";
import {Link} from "react-router-dom";

class ListPost extends React.Component {
	
	bodyLength = () => {
		const { post } = this.props;
		return post.body.length;
	};
	
	renderBody = () => {
		const { post } = this.props;
		return this.bodyLength() > 100 ? post.body.slice(0, 100) + '...'
			: post.body;
	};
	
	render() {
		const { post } = this.props;
		return (
			<div className={"mb-3"}>
			<Card>
				<CardBody>
					<CardTitle>
						<strong>{post.title}</strong>
					</CardTitle>
					<div dangerouslySetInnerHTML={{__html: this.renderBody() }} />
					<Link to={`/posts/${post.id}`}>Read more ...</Link>
				</CardBody>
			</Card>
			
				{/*<p>*/}
				{/*	<Button color={"danger"} onClick={() => this.props.deletePost(post.id)}>Delete </Button>*/}
				{/*	{post.title}					*/}
				{/*</p>*/}
			</div>
		);
	}
}
export default ListPost;