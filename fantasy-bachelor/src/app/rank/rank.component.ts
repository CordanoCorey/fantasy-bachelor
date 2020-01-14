import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, HttpActions, RouterActions, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject } from 'rxjs';

import { Ranking, Ordering } from '../shared/models';
import { currentUserIdSelector, currentUserContestantRankingsSelector } from '../shared/selectors';
import { RankingsActions } from '../shared/actions';
import { map } from 'rxjs/operators';

@Component({
  selector: 'bachelor-rank',
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.scss']
})
export class RankComponent extends SmartComponent implements OnInit {
  ordered$: Observable<Ranking[]>;
  orderingSubject = new BehaviorSubject<Ordering<Ranking>>(new Ordering([], Ranking));
  _rankings: Ranking[] = [];
  rankings$: Observable<Ranking[]>;
  userId = 0;
  userId$: Observable<number>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.rankings$ = currentUserContestantRankingsSelector(store);
    this.userId$ = currentUserIdSelector(store);
    this.ordered$ = this.orderingSubject.asObservable().pipe(
      map(x => x.items)
    );
  }

  set rankings(value: Ranking[]) {
    console.dir(value.map(x => `${x.order}. ${x.contestantName}`));
    this._rankings = value;
    this.orderingSubject.next(new Ordering(value, Ranking));
  }

  get rankings(): Ranking[] {
    return this._rankings;
  }

  get valueOut(): Ranking[] {
    return this.orderingSubject.value.items.map(x => build(Ranking, {
      id: x.id,
      userId: this.userId,
      contestantSeasonId: x.contestantSeasonId,
      notes: x.notes,
      rank: x.order
    }));
  }

  ngOnInit() {
    this.sync(['rankings', 'userId']);
  }

  changeValue(e: any, ranking: Ranking) {
    if (e && e.srcElement && e.srcElement.valueAsNumber) {
      this.orderingSubject.next(new Ordering(this.orderingSubject.value.move(ranking, e.srcElement.valueAsNumber - 1), Ranking));
      this.saveRankings(this.valueOut);
    }
  }

  reorderList(e) {
    this.orderingSubject.next(new Ordering(this.orderingSubject.value.move(e.item.data, e.currentIndex), Ranking));
    this.saveRankings(this.valueOut);
  }

  saveRankings(e: Ranking[]) {
    // this.dispatch(HttpActions.put(`users/${this.userId}/rankings`, e, RankingsActions.PUT));
  }

  toContestant(e: number) {
    if (e) {
      this.dispatch(RouterActions.navigate(`/rank?contestantId=${e}`));
    }
  }

}
