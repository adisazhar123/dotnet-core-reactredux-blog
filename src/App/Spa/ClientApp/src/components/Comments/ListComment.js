import React from 'react'
import {Card, CardBody, CardFooter} from "reactstrap";
import moment from 'moment'

const ListComment = ({comment}) => {
	// moment().format("dddd, MMMM Do YYYY, h:mm:ss a"); // "Sunday, February 14th 2010, 3:25:50 pm"
	return (
		<div className={'mb-2'}>
			<Card>
				<CardBody>
					<p>{comment.body}</p>
				</CardBody>
				<CardFooter>
					<p>{ moment(comment.updatedAt).format("dddd, MMMM Do YYYY") }</p>
				</CardFooter>
			</Card>
		</div>
	);
};

export default ListComment;