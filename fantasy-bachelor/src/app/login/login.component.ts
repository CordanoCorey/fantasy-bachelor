import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, HttpActions, SmartComponent, MessageSubscription, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { CurrentUserActions, UsersActions } from '../shared/actions';
import { Login, Users } from '../shared/models';
import { usersSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends SmartComponent implements OnInit {
  @Control(Login) form: FormGroup;
  users: Users = new Users();
  users$: Observable<Users>;
  messages = [
    build(MessageSubscription, {
      action: CurrentUserActions.LOGIN_ERROR,
      channel: 'ERRORS',
      mapper: e => e.message || `Login Failed.`
    })
  ];

  constructor(public store: Store<any>) {
    super(store);
    this.users$ = usersSelector(store);
  }

  get credentials(): string {
    return `grant_type=password&email=${this.form.value.email}&password=${this.form.value.password}`;
  }

  get emailAddress(): string {
    return this.form.controls.email.value;
  }

  ngOnInit() {
    this.onInit();
    this.getUsers();
    this.sync(['users']);
  }

  onSubmit() {
    const email = this.form.value.email;
    if (email) {
      const existing = this.users.asArray.find(x => x.email === email);
      console.dir(existing);
      if (existing) {
        this.dispatch(CurrentUserActions.loginSuccess(existing));
      } else {
        this.dispatch(CurrentUserActions.loginError({ message: `No users exist with the email ${email}.` }));
      }
    }
  }

  getUsers() {
    this.dispatch(HttpActions.get(`users`, UsersActions.GET));
  }

  login() {
    if (this.form.valid) {
      this.dispatch(HttpActions.postFormUrlEncoded('token', this.credentials, CurrentUserActions.LOGIN, CurrentUserActions.LOGIN_ERROR));
    }
  }

  resetPassword() {
    this.dispatch(HttpActions.post(`resetpassword/${this.emailAddress}`, {}, CurrentUserActions.GENERATE_PASSWORD_RESET_CODE));
  }
}
