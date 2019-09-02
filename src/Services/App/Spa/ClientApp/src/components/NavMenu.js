import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux'

import './NavMenu.css';

class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  
  publicMenu = () => {
      return (
        [
          <NavItem>
            <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
          </NavItem>,
          <NavItem>
            <NavLink tag={Link} className={'text-dark'} to={'/posts/create'}>Create a Post</NavLink>
          </NavItem>
        ]
      )
  };
  
  authenticationMenu = () => {
    if (this.props.auth.authenticated) {
      return (
        [
          <NavItem>
            <NavLink tag={Link} className={'text-dark'} to={'/logout'}>Logout</NavLink>
          </NavItem>
        ]
      )
    } else {
      return (
        [
          <NavItem>
            <NavLink tag={Link} className={'text-dark'} to={'/login'}>Login</NavLink>
          </NavItem>
        ]
      )
    }
  };
  
  authenticatedMenu = () => {
    return (
        <NavItem>
          <NavLink tag={Link} className={'text-dark'} to={'/users'}>Users</NavLink>
        </NavItem>
    )
  }
  
  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow" light >
          <Container>
            <NavbarBrand tag={Link} to="/">Adis Blog</NavbarBrand>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
              <ul className="navbar-nav flex-grow">
                {this.publicMenu()}
                {/*{this.authenticatedMenu()}*/}
                {this.authenticationMenu()}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
        
      </header>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    auth: state.auth  
  }
};

export default connect(mapStateToProps)(NavMenu);