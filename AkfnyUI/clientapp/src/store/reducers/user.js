import {
  SET_LANG,
} from '../actions/creators/actions';

const initState = {
  isLoading: false,
  isSignout: false,
  userToken: null,
  userData: {},
  isSignUp: false,
  lang: 'ar',
};
export default (state = initState, action) => {
  const { type } = action;
  switch (type) {
    case SET_LANG:
      return {
        ...state,
        lang: action.payload,
      };
    // case RESTORE_TOKEN:
    //   return {
    //     ...state,
    //     userToken: action.payload.accessToken,
    //     isLoading: false,
    //     userData: action.payload,
    //   };
    // case SIGN_IN:
    //   return {
    //     ...state,
    //     isSignout: false,
    //     userToken: action.payload.payload.accessToken,
    //     userData: action.payload.payload,
    //     isSignUp: action.signup,
    //   };
    // case CLEAR_SIGN_UP:
    //   return {
    //     ...state,
    //     isSignUp: false,
    //   };

    // case SIGN_OUT:
    //   return {
    //     ...state,
    //     isSignUp: false,
    //     isSignout: true,
    //     userToken: false,
    //     userData: {},
    //   };
    default:
      return state;
  }
};
