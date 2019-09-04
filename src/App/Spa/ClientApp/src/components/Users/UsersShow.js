import React from 'react'
import {Button, Card, CardBody, Col, Container, Nav, NavItem, Row, TabContent, TabPane} from 'reactstrap'

import {Link} from "react-router-dom";
import {connect} from "react-redux";

import {getUserFavoritePosts, getUserPosts} from "../../actions/users";

import './UsersShow.css'


class UsersShow extends React.Component {

	constructor(props) {
		super(props);
		const { match } = props;
		console.log('constructor');
		this.toggle = this.toggle.bind(this);
		const tabs = match.params.favorites === 'favorites' ? '2' : '1';
		this.state = { activeTab: tabs };
	}

	componentDidMount() {
		const { match } = this.props;
		const userName = match.params.userName;
		this.state.activeTab === '1' ? this.props.getUserPosts(userName)
			: this.props.getUserFavoritePosts(userName);
	}
	
	componentDidUpdate(prevProps, prevState, snapshot) {
		const { match } = this.props;
		console.log('component did update');
		const userName = match.params.userName;
		
		if (prevState.activeTab !== this.state.activeTab)
			this.state.activeTab === '1' ? this.props.getUserPosts(userName)
				: this.props.getUserFavoritePosts(userName);
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
						<h4>{this.props.username}</h4>
						<Button>+ Follow @{this.props.username}</Button>
					</div>
				</Container>
			</div>
		)	;
	};
	
	switchTab = (tabType) => {
		console.log('okkokokok');
		this.setState({ activeTab: tabType });
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
						<h5>{this.props.username}</h5>
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
	
	link1 = () => {
		const userName = this.props.match.params.userName;
		return `/users/@${userName}`;
	};

	renderUsersPosts = (posts) => {
		return (
			<div>
				<Container>
					<Nav tabs>
						<NavItem>
							<Link to={this.link1()}
							      className={ this.state.activeTab === '1' ? "nav-link active" : 'nav-link' }
							      onClick={() => this.switchTab("1")}
							>
								My Posts
							</Link>
						</NavItem>
						
						<NavItem>
							<Link to={this.link1() + '/favorites'}
							      className={ this.state.activeTab === '2' ? "nav-link active" : 'nav-link' }
							      onClick={() => this.switchTab("2")}
							>
								Favorited Posts
							</Link>
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
								<Col sm="12">
									<div className="posts">
										{this.renderPosts(posts)}
									</div>
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
	{ getUserPosts, getUserFavoritePosts }
)(UsersShow);