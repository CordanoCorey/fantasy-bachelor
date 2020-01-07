import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, RouterActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Contestant } from '../shared/models';
import { contestantsArraySelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-contestants',
  templateUrl: './contestants.component.html',
  styleUrls: ['./contestants.component.scss']
})
export class ContestantsComponent extends SmartComponent implements OnInit {

  contestants$: Observable<Contestant[]>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.contestants$ = contestantsArraySelector(store);
  }

  ngOnInit() {
  }

  toContestant(e: number) {
    this.dispatch(RouterActions.navigate(`/contestants?contestantId=${e}`));
  }

}
