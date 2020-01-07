import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { CurrentUser } from '../shared/models';
import { currentUserSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends SmartComponent implements OnInit {

  currentUser: CurrentUser = new CurrentUser();
  currentUser$: Observable<CurrentUser>;

  constructor(public store: Store<any>) {
    super(store);
    this.currentUser$ = currentUserSelector(store);
  }

  ngOnInit() {
    this.sync(['currentUser']);
  }

}
