import React from 'react'
import {Button, Card, CardBody, Col, Container, Nav, NavItem, Row, TabContent, TabPane, Alert} from 'reactstrap'

import {Link, Route} from "react-router-dom";
import {connect} from "react-redux";

import {
	getUserFavoritePosts, 
	getUserPosts,
	followUser
} from "../../actions/users";

import './UsersShow.css'


class UsersShow extends React.Component {

	constructor(props) {
		super(props);
		const { match } = props;
		this.toggle = this.toggle.bind(this);
		const tabs = match.params.favorites === 'favorites' ? '2' : '1';
		this.state = { activeTab: tabs };
	}

	toggle(tab) {
		if (this.state.activeTab !== tab) {
			this.setState({
				activeTab: "" + tab
			});
		}
	}
	
	followUser = () => {
		const followingUserId = this.props.openedUserId;
		this.props.followUser(followingUserId);
	};
	
	renderHeader = () => {
		return (
			<div className={'users-header mb-3'}>
				<Container>
					<div className="profile">
						<h4>{this.props.username}</h4>
						{  this.props.isFollowing === false ? <Button onClick={this.followUser}>+ Follow @{this.props.username}</Button>  
							: <Button>- Unfollow @{this.props.username}</Button> }
					</div>
				</Container>
			</div>
		);
	};

	renderUsersPosts = () => {
		return (
			<div>
				<Container>
					<NavProfile {...this.props} activeTab={this.state.activeTab} changeNav={this.toggle} />
					<Route path={'/users/@:username'} render={() => <UserPosts {...this.props} />} exact />
					<Route path={'/users/@:username/favorites'} render={() => <UserPosts {...this.props} />} exact />
				</Container>
			</div>
		)
	};
	
	render() {
		return (
			<div className={'users-show'}>
				{this.renderHeader()}
				{this.renderUsersPosts()}
			</div>
		)
	}
}

const NavProfile = (props) => {
	return (
		<React.Fragment>
			<Nav tabs>
				<NavItem>
					<Link onClick={() => props.changeNav(1)}  className={props.activeTab === '1' ? 'nav-link active' : 'nav-link'} to={'/users/@' + props.username}>
						My Posts
					</Link>
				</NavItem>

				<NavItem onClick={() => props.changeNav(2)}>
					<Link className={props.activeTab === '2' ? 'nav-link active' : 'nav-link'} to={'/users/@' + props.username + '/favorites'}>
						Favorited Posts
					</Link>
				</NavItem>
			</Nav>
		</React.Fragment>
	)	
};

class UserPosts extends React.Component {
	constructor(props) {
		super(props);
		const { match } = props;
		const tabs = match.params.favorites === 'favorites' ? '2' : '1';
		this.state = { activeTab: tabs };
	}
	
	componentDidMount = () => {
		console.log(this.props);
		const userName = this.props.match.params.userName;
		this.callGetPosts(userName);
	};
	
	callGetPosts = (userName) => {
		if (this.state.activeTab === '1') {
			this.props.getUserPosts(userName);
		} else {
			this.props.getUserFavoritePosts(userName);
		}
	};

	renderPostBody = (body) => {
		return body.length > 100 ? body.slice(0, 100) + ' ...'
			: body;
	};

	render() {
		console.log(this.props);
		const posts = this.props.userPosts;
		return (
			<TabContent activeTab={'1'}>
				<TabPane tabId="1">
					<Row>
						<Col sm="12">
							<div className="posts">
								{ posts.map(post => (
								<Card key={post.id} className={'post mb-1'}>
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
												{this.renderPostBody(post.body.replace(/<[^>]*>?/gm, ''))}
											</p>
											<Link to={`/posts/${post.id}`}>Read more...</Link>
										</div>
									</CardBody>
								</Card>
								))
								}
							</div>
						</Col>
					</Row>
				</TabPane>
			</TabContent>
		)
	}
}

const mapStateToProps = (state) => {
	return {
		username: state.users.username,
		userPosts: Object.values(state.users.posts),
		openedUserId: state.users.id,
		isFollowing: state.users.isFollowing,
	};
};

const mapDispatchToProps = {
	getUserPosts, getUserFavoritePosts, followUser
};

connect(mapStateToProps, mapDispatchToProps)(UserPosts);
export default connect(mapStateToProps, mapDispatchToProps)(UsersShow);