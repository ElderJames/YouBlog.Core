///// <reference path="../../typings/globals/es6-shim/index.d.ts" />
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
//import { Component, OnInit } from '@angular/core';
//import { Location } from '@angular/common';
//import 'rxjs/add/operator/map';
//import {enableProdMode} from '@angular/core';
//enableProdMode();
//import { MembershipService } from './core/services/membership.service';
//import { User } from './core/domain/user';
//@Component({
//    selector: 'photogallery-app',
//    templateUrl: './app/app.component.html'
//})
//export class AppComponent implements OnInit {
//    constructor(public membershipService: MembershipService,
//                public location: Location) { }
//    ngOnInit() {
//        this.location.go('/');
//    }
//    isUserLoggedIn(): boolean {
//        return this.membershipService.isUserAuthenticated();
//    }
//    getUserName(): string {
//        if (this.isUserLoggedIn()) {
//            var _user = this.membershipService.getLoggedInUser();
//            return _user.Username;
//        }
//        else
//            return 'Account';
//    }
//    logout(): void {
//        this.membershipService.logout()
//            .subscribe(res => {
//                localStorage.removeItem('user');
//            },
//            error => console.error('Error: ' + error),
//            () => { });
//    }
//}
var core_1 = require('@angular/core');
var AppComponent = (function () {
    function AppComponent() {
        this.title = 'Tour of Heroes';
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: "\n  <h1>{{title}}</h1>\n  <nav>\n    <a routerLink=\"console/dashboard\" routerLinkActive=\"active\">Dashboard</a>\n    <a routerLink=\"console/heroes\" routerLinkActive=\"active\">Heroes</a>\n  </nav>\n  <router-outlet></router-outlet>\n",
            styleUrls: ['app/app.component.css']
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
