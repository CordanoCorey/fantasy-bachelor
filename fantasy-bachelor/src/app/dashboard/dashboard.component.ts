import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { CurrentUser } from '../shared/models';
import { currentUserSelector, currentUserIdSelector, currentUserHasRankingsSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends SmartComponent implements OnInit {

  currentUser: CurrentUser = new CurrentUser();
  currentUser$: Observable<CurrentUser>;
  userHasRankings = true;
  userHasRankings$: Observable<boolean>;
  userId$: Observable<number>;

  constructor(public store: Store<any>) {
    super(store);
    this.currentUser$ = currentUserSelector(store);
    this.userHasRankings$ = currentUserHasRankingsSelector(store);
    this.userId$ = currentUserIdSelector(store);
  }

  ngOnInit() {
    this.sync(['currentUser', 'userHasRankings']);
  }

}
