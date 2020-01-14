import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { SmartComponent, HttpActions, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { RankingActions } from '../shared/actions';
import { Ranking, Contestant } from '../shared/models';
import { contestantSelector, currentUserIdSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-contestant',
  templateUrl: './contestant.component.html',
  styleUrls: ['./contestant.component.scss']
})
export class ContestantComponent extends SmartComponent implements OnInit {

  _contestant: Contestant = new Contestant();
  contestant$: Observable<Contestant>;
  _notes = '';
  userId = 0;
  userId$: Observable<number>;

  constructor(public store: Store<any>, public dialogRef?: MatDialogRef<ContestantComponent>, @Inject(MAT_DIALOG_DATA) public data?: any) {
    super(store);
    this.contestant$ = contestantSelector(store);
    this.userId$ = currentUserIdSelector(store);
  }

  set contestant(value: Contestant) {
    console.dir(value);
    this._contestant = value;
    this.notes = value.userNotes;
  }

  get contestant(): Contestant {
    return this._contestant;
  }

  set notes(value: string) {
    this._notes = value;
  }

  get notes(): string {
    return this._notes;
  }

  get notesChanged(): boolean {
    return this.notes != this.contestant.userNotes;
  }

  get valueOut(): Ranking {
    return build(Ranking, {
      id: this.contestant.userRankingId,
      contestantSeasonId: this.contestant.id,
      notes: this.notes,
      rank: this.contestant.userRank,
      userId: this.userId
    });
  }

  ngOnInit() {
    this.sync(['contestant', 'userId']);
  }

  onSave() {
    if (this.contestant.userRankingId) {
      this.updateRanking(this.valueOut);
    } else {
      this.addRanking(this.valueOut);
    }
  }

  addRanking(e: Ranking) {
    this.dispatch(HttpActions.post(`rankings`, e, RankingActions.POST));
  }

  updateRanking(e: Ranking) {
    this.dispatch(HttpActions.put(`rankings/${e.id}`, e, RankingActions.PUT));
  }

}
