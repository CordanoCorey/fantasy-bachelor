import { NgModule } from '@angular/core';

import { RankRoutingModule } from './rank-routing.module';
import { RankComponent } from './rank.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [RankComponent],
  imports: [
    SharedModule,
    RankRoutingModule
  ]
})
export class RankModule { }
