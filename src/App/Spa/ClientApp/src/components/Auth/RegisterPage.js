import React from 'react'
import { Container } from 'reactstrap'
import RegisterForm from "./RegisterForm";

const registerAccount = (data) => {
	console.log(data);
};

const RegisterPage = (props) => {
	return (
		<div id={'register'} className={'mt-3'}>
			<Container>
				<RegisterForm onSubmit={registerAccount} />
			</Container>
		</div>
	);
};

export default RegisterPage;