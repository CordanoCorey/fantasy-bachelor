import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, HttpActions, RouterActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Contestant, Ranking } from '../shared/models';
import { contestantsArraySelector, currentUserIdSelector } from '../shared/selectors';
import { RankingsActions } from '../shared/actions';

@Component({
  selector: 'bachelor-rank',
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.scss']
})
export class RankComponent extends SmartComponent implements OnInit {
  contestants: Contestant[] = [];
  contestants$: Observable<Contestant[]>;
  userId = 0;
  userId$: Observable<number>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.contestants$ = contestantsArraySelector(store);
    this.userId$ = currentUserIdSelector(store);
  }

  get valueOut(): Ranking[] {
    return [];
  }

  ngOnInit() {
    this.sync(['contestants']);
  }

  reorderList(e) {
    console.dir(e);
  }

  saveRankings(e: Ranking[]) {
    this.dispatch(HttpActions.put(`users/${this.userId}/rankings`, e, RankingsActions.PUT));
  }

  toContestant(e: number) {
    this.dispatch(RouterActions.navigate(`/rank?contestantId=${e}`));
  }

}
