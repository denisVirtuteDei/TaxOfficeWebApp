import React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { getChecks } from '../actions/bankCheckAction'

class Checks extends React.Component {

    componentDidMount() {
        this.props.getChecks(1);
    }

    render() {
        let checks = this.props.checks.map(item => {
            return (
                <div key={item.Id} className="bankCheck">
                    <table>
                        <tr>
                            <th>{item.title}</th>
                            <th>{item.finalSum}</th>
                            <th>{item.payedDate}</th>
                            <th>{item.isDebtRepayment}</th>
                        </tr>
                    </table>
                    <hr />
                </div>
            );
        });

        return (
            <div id="Checks">
                {checks}
            </div>
        );
    }
};

let mapProps = (state) => {
    return {
        checks: state.data,
        error: state.error
    }
}

let mapDispatch = (dispatch) => {
    return {
        getChecks: (Id) => dispatch(getChecks(Id))
    }
}

export default connect(mapProps, mapDispatch)(Checks) 