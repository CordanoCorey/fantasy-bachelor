import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, RouterActions, routeParamIdSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Contestant } from '../shared/models';
import { contestantsArraySelector, activeUserNameSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss']
})
export class RankingComponent extends SmartComponent implements OnInit {
  activeUserId = 0;
  activeUserId$: Observable<number>;
  contestants: Contestant[] = [];
  contestants$: Observable<Contestant[]>;
  userName$: Observable<string>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.activeUserId$ = routeParamIdSelector(store, 'userId');
    this.contestants$ = contestantsArraySelector(store);
    this.userName$ = activeUserNameSelector(store);
  }

  ngOnInit() {
    this.sync(['activeUserId', 'contestants']);
  }

  toContestant(e: number) {
    if (e) {
      this.dispatch(RouterActions.navigate(`/rankings/${this.activeUserId}?contestantId=${e}`));
    }
  }

}
