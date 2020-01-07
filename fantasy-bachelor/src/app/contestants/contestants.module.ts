import { NgModule } from '@angular/core';

import { ContestantsRoutingModule } from './contestants-routing.module';
import { ContestantsComponent } from './contestants.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [ContestantsComponent],
  imports: [
    SharedModule,
    ContestantsRoutingModule
  ]
})
export class ContestantsModule { }
