import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Counter';

const Counter = props => {
    return (
        <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p>Current count: <strong>{props.count}</strong></p>

            <button className="btn btn-primary" onClick={props.increment}>Increment</button>
        </div>     
    )
};

const mapStateToProps = state => {
  return {
      count: state.counter.count,
  };
};

export default connect(
  mapStateToProps,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Counter);
