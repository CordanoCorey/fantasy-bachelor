import { NgModule } from '@angular/core';

import { RankingRoutingModule } from './ranking-routing.module';
import { RankingComponent } from './ranking.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [RankingComponent],
  imports: [
    SharedModule,
    RankingRoutingModule
  ]
})
export class RankingModule { }
