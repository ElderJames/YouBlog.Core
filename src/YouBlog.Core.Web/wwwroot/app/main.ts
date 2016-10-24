/// <reference path="../../typings/globals/es6-shim/index.d.ts" />
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
//import "materialize-css";
//import "angular2-materialize";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { AppModule } from './app.module';


platformBrowserDynamic().bootstrapModule(AppModule);
