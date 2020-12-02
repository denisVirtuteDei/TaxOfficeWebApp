import { GET_CHECKS_SUCCESS, GET_CHECKS_ERROR } from '../constants/bankCheckConst'

export const initialState = {
    data: [{ title: '', finalSum: 0, payedDate: 0, isDebtRepayment: false }],
    error: ''
}

export default function blog(state = initialState, action) {
    switch (action.type) {
        case GET_CHECKS_SUCCESS:
            return {
                ...state,
                data: [action.checks],
                error: ''
            }

        case GET_CHECKS_ERROR:
            return {
                ...state,
                error: action.error
            }

        default:
            return state;
    }
}