import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule }   from '@angular/router';
//import { MaterializeModule } from 'angular2-materialize';
//import "materialize-css";
import { AppComponent }   from './app.component';
import { HeroDetailComponent } from './hero-detail.component';
import { HeroesComponent }     from './heroes.component';
import { HeroService }         from './hero.service';
import { DashboardComponent } from './dashboard.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
      //  MaterializeModule
        RouterModule.forRoot([
            {
                path: 'detail/:id',
                component: HeroDetailComponent
            },
            {
                path: 'console/heroes',
                component: HeroesComponent
            },
            {
                path: 'console/dashboard',
                component: DashboardComponent
            },
            {
                path: 'console',
                redirectTo: 'console/dashboard',
                pathMatch: 'full'
            }
        ])
    ],
    declarations: [
        AppComponent,
        HeroDetailComponent,
        HeroesComponent,
        DashboardComponent
    ],
    providers: [HeroService],
    bootstrap: [AppComponent],

})
export class AppModule { }

