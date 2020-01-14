import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, RouterActions, routeParamIdSelector, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { RankingsActions } from '../shared/actions';
import { Contestant, Ranking } from '../shared/models';
import { contestantsArraySelector, activeUserNameSelector, activeUserContestantRankingsSelector, activeUserTotalPointsSelector, contestantsRemainingSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss']
})
export class RankingComponent extends SmartComponent implements OnInit {
  _activeUserId = 0;
  activeUserId$: Observable<number>;
  contestants: Contestant[] = [];
  contestants$: Observable<Contestant[]>;
  contestantsRemaining$: Observable<number>;
  rankings$: Observable<Ranking[]>;
  totalPoints$: Observable<number>;
  userName$: Observable<string>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.activeUserId$ = routeParamIdSelector(store, 'userId');
    this.contestants$ = contestantsArraySelector(store);
    this.userName$ = activeUserNameSelector(store);
    this.rankings$ = activeUserContestantRankingsSelector(store);
    this.totalPoints$ = activeUserTotalPointsSelector(store);
    this.contestantsRemaining$ = contestantsRemainingSelector(store);
  }

  set activeUserId(value: number) {
    this.getUserRankings(value);
    this._activeUserId = value;
  }

  get activeUserId(): number {
    return this._activeUserId;
  }

  ngOnInit() {
    this.sync(['activeUserId', 'contestants']);
    this.rankings$.subscribe(x => { console.dir(x); });
  }

  getUserRankings(userId: number) {
    this.dispatch(HttpActions.get(`users/${userId}/rankings`, RankingsActions.GET));
  }

  toContestant(e: number) {
    if (e) {
      this.dispatch(RouterActions.navigate(`/rankings/${this.activeUserId}?contestantId=${e}`));
    }
  }

}
