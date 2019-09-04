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
		const body = post.body.replace(/<(.|\n)*?>/g, '');
		return this.bodyLength() > 100 ? body.slice(0, 100) + '...'
			: body;
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
					<p>{ this.renderBody() }</p>
					<Link to={`/posts/${post.id}`}>Read more ...</Link>
				</CardBody>
			</Card>
			
			</div>
		);
	}
}
export default ListPost;