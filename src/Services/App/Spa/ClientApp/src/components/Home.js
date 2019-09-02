import React from 'react';
import { connect } from 'react-redux';
import {Col, Container, Row} from "reactstrap";

import PostsList from "./Posts/PostsList";

class Home extends React.Component {

	componentDidMount() {
		console.log(this.props.location);

	}

	componentDidUpdate(prevProps, prevState, snapshot) {
		this.state = { currentPage: 1 };
	}


	render() {
		return (
			<div className={"mt-3"}>
				<Container>
					<Row>
						<Col md={"12"}>
							<PostsList currentPage={this.props.location.search.replace("?page=", "") ||  "1" } />
						</Col>
					</Row>
				</Container>
			</div>
		);
	}
}

export default connect()(Home);
