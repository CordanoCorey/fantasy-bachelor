import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RankComponent } from './rank.component';


const routes: Routes = [{
  path: '',
  component: RankComponent,
  data: { routeName: 'rank', routeLabel: 'Rank' }
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RankRoutingModule { }
