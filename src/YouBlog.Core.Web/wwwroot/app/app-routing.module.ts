import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent }   from './dashboard.component';
import { HeroesComponent }      from './heroes.component';
import { HeroDetailComponent }  from './hero-detail.component';

const routes: Routes = [
    { path: 'console', redirectTo: 'console/dashboard', pathMatch: 'full' },
    { path: 'console/dashboard', component: DashboardComponent },
    { path: 'console/detail/:id', component: HeroDetailComponent },
    { path: 'console/heroes', component: HeroesComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
