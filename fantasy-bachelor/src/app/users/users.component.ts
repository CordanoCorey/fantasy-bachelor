import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { User } from '../shared/models';
import { allUsersSelector } from '../shared/selectors';

@Component({
  selector: 'bachelor-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  animations: [
    trigger('expandable', [
      transition(':enter', [
        style({ height: '30px' }),
        animate('1s ease-in-out', style({ height: '*' })),
      ])
    ])
  ]
})
export class UsersComponent extends SmartComponent implements OnInit {

  users: User[] = [];
  users$: Observable<User[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.users$ = allUsersSelector(store);
  }

  ngOnInit() {
  }

}
