"use strict";
/// <reference path="../../typings/globals/es6-shim/index.d.ts" />
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
//import "materialize-css";
//import "angular2-materialize";
require('rxjs/add/operator/map');
require('rxjs/add/operator/toPromise');
var app_module_1 = require('./app.module');
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule);
