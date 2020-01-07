import { build, Token, StorageActions, Action } from '@caiu/library';

import { CurrentUserActions, UsersActions, RankingsActions, RankingActions } from './actions';
import { CurrentUser, Contestants, Users, Rankings } from './models';

export function currentUserReducer(state: CurrentUser = new CurrentUser(), action: Action): CurrentUser {
  switch (action.type) {
    case StorageActions.INIT_STORE:
      return CurrentUser.Build(action.payload.localStore ? action.payload.localStore.currentUser : {});

    case CurrentUserActions.LOGIN:
      const token = build(Token, {
        access_token: 'DEFAULT',
        expires_in: 360000000
      });

      return build(CurrentUser, {
        token,
        id: action.payload.id,
        firstName: action.payload.firstName,
        lastName: action.payload.lastName,
        email: action.payload.email
      });

    case CurrentUserActions.LOGOUT:
      return build(CurrentUser, { token: new Token() });

    default:
      return state;
  }
}

export function usersReducer(state: Users = new Users(), action: Action): Users {
  switch (action.type) {

    case UsersActions.GET:
      return state.update(action.payload);

    default:
      return state;
  }
}

export function contestantsReducer(state: Contestants = new Contestants(), action: Action): Contestants {
  switch (action.type) {

    default:
      return state;
  }
}

export function rankingsReducer(state: Rankings = new Rankings(), action: Action): Rankings {
  switch (action.type) {

    case RankingsActions.GET:
    case RankingsActions.PUT:
    case RankingActions.POST:
    case RankingActions.PUT:
      return state.update(action.payload);

    default:
      return state;
  }
}
