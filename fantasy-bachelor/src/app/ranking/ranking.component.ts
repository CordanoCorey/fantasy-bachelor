import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent } from '@caiu/library';
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
  contestants: Contestant[] = [];
  contestants$: Observable<Contestant[]>;
  userName$: Observable<string>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.contestants$ = contestantsArraySelector(store);
    this.userName$ = activeUserNameSelector(store);
  }

  ngOnInit() {
    this.sync(['contestants']);
  }

}
