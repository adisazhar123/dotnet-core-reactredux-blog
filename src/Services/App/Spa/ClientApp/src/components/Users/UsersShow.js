import React from 'react'
import {
	Button,
	Card,
	CardBody,
	CardText,
	CardTitle,
	Col,
	Container,
	Nav,
	NavItem,
	NavLink,
	Row,
	TabContent,
	TabPane
} from 'reactstrap'

import parse from 'html-react-parser'

import {Link} from "react-router-dom";
import {connect} from "react-redux";

import { getUserPosts } from "../../actions/users";

import './UsersShow.css'


class UsersShow extends React.Component {

	constructor(props) {
		super(props);
		const { match } = props;

		this.toggle = this.toggle.bind(this);
		const tabs = match.params.favorites === 'favorites' ? '2' : '1';
		console.log(tabs);
		this.state = {
			activeTab: tabs
		};
	}

	componentDidMount() {
		const { match } = this.props;

		const userName = match.params.userName;
		this.props.getUserPosts(userName);
	}
	
	toggle(tab) {
		if (this.state.activeTab !== tab) {
			this.setState({
				activeTab: tab
			});
		}
	}
	
	renderHeader = () => {
		return (
			<div className={'users-header mb-3'}>
				<Container>
					<div className="profile">
						<h4>Adis Azhar</h4>
						<Button>+ Follow AdisAzhar</Button>
					</div>
				</Container>
			</div>
		)	;
	};
	
	
	renderPostBody = (body) => {
		return body.length > 100 ? body.slice(0, 100) + ' ...'
			: body;
	};
	
	renderPosts = (posts) => {
		return posts.map(post => (
			<Card className={'post mb-1'}>
				<CardBody>
					<div className="info">
						<h5>Adis Azhar</h5>
						<small>Wed Jul 31 2019</small>
					</div>
					<div className="post-body">
						<h5>
							<strong>
								{post.title}
							</strong>
						</h5>
						<p>
							{
								this.renderPostBody(post.body.replace(/<[^>]*>?/gm, ''))
							}
						</p>
						<Link to={`/posts/${post.id}`}>Read more...</Link>
					</div>
				</CardBody>
			</Card>
		));
	};

	renderUsersPosts = (posts) => {
		return (
			<div>
				<Container>
					<Nav tabs>
						<NavItem>
							<NavLink
								className={ this.state.activeTab === '1' ? "active" : '' }
								href={'#'}
								// onClick={() => { this.toggle('1'); }}
							>
								My Posts
							</NavLink>
						</NavItem>
						<NavItem>
							<NavLink
								className={ this.state.activeTab === '2' ? 'active' : '' }
								href={'#'}
								// onClick={() => { this.toggle('2'); }}
							>
								Favorited Posts
							</NavLink>
						</NavItem>
					</Nav>
					<TabContent activeTab={this.state.activeTab}>
						<TabPane tabId="1">
							<Row>
								<Col sm="12">
									<div className="posts">
										{this.renderPosts(posts)}
									</div>
								</Col>
							</Row>
						</TabPane>
						
						<TabPane tabId="2">
							<Row>
								<Col sm="6">
									<Card body>
										<CardTitle>Special Title Treatment</CardTitle>
										<CardText>With supporting text below as a natural lead-in to additional content.</CardText>
										<Button>Go somewhere</Button>
									</Card>
								</Col>
								<Col sm="6">
									<Card body>
										<CardTitle>Special Title Treatment</CardTitle>
										<CardText>With supporting text below as a natural lead-in to additional content.</CardText>
										<Button>Go somewhere</Button>
									</Card>
								</Col>
							</Row>
						</TabPane>
					</TabContent>					
				</Container>
			</div>
		)
	};
	
	render() {
		return (
			<div className={'users-show'}>
				{this.renderHeader()}
				{this.renderUsersPosts(this.props.userPosts)}
			</div>
		)
	}
}

const mapStateToProps = (state) => {
	return {
		username: state.users.username,
		userPosts: Object.values(state.users.posts)
	};
};

export default connect(mapStateToProps,
	{ getUserPosts }
)(UsersShow);