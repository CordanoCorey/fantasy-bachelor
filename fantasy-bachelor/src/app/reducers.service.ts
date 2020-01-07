import { Injectable } from '@angular/core';
import {
  configReducer,
  errorsReducer,
  eventsReducer,
  formReducer,
  lookupReducer,
  messagesReducer,
  redirectsReducer,
  routerReducer,
  sidenavReducer,
  viewSettingsReducer,
  windowReducer
} from '@caiu/library';
import { ActionReducerMap } from '@ngrx/store';
import { currentUserReducer, contestantsReducer, usersReducer, rankingsReducer } from './shared/reducers';

@Injectable({
  providedIn: 'root'
})
export class ReducersService {

  constructor() { }

  getReducers(): ActionReducerMap<any> {
    return {
      currentUser: currentUserReducer,
      config: configReducer,
      errors: errorsReducer,
      events: eventsReducer,
      form: formReducer,
      lookup: lookupReducer,
      messages: messagesReducer,
      redirects: redirectsReducer,
      route: routerReducer,
      sidenav: sidenavReducer,
      viewSettings: viewSettingsReducer,
      window: windowReducer,
      contestants: contestantsReducer,
      rankings: rankingsReducer,
      users: usersReducer
    };
  }
}
