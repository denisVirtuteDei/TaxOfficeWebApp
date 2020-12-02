import { GET_CHECKS_SUCCESS, GET_CHECKS_ERROR } from '../constants/bankCheckConst'
//import "isomorphic-fetch"

export function receiveChecks(data) {
    return {
        type: GET_CHECKS_SUCCESS,
        checks: [data]
    }
}

export function errorReceive(err) {
    return {
        type: GET_CHECKS_ERROR,
        error: err
    }
}

export function getChecks(checkId = 0) {
    return (dispatch) => {
        let queryTrailer = '?Id=' + checkId;
        
        fetch(constants.getChecks + queryTrailer)
            .then(response => response.json())
            .then(data => {
                dispatch(receivePosts(data))
            })
            .catch((ex) => {
                dispatch(errorReceive(err))
            });
    }
}