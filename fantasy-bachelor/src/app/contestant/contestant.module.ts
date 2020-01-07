import { NgModule } from '@angular/core';

import { ContestantRoutingModule } from './contestant-routing.module';
import { ContestantComponent } from './contestant.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [ContestantComponent],
  imports: [
    SharedModule,
    ContestantRoutingModule
  ],
  entryComponents: [ContestantComponent]
})
export class ContestantModule { }
