import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [{
  path: '',
  children: [
    { path: '', pathMatch: 'full', redirectTo: 'login' },
    {
      path: 'login',
      loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
    },
    {
      path: 'dashboard',
      loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
    },
    {
      path: 'rank',
      loadChildren: () => import('./rank/rank.module').then(m => m.RankModule)
    },
    {
      path: 'rankings/:userId',
      loadChildren: () => import('./ranking/ranking.module').then(m => m.RankingModule)
    },
    {
      path: 'contestants',
      loadChildren: () => import('./contestants/contestants.module').then(m => m.ContestantsModule)
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
