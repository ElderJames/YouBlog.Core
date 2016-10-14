"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
var http_1 = require('@angular/http');
var forms_1 = require('@angular/forms');
var common_1 = require('@angular/common');
var http_2 = require('@angular/http');
var angular2_materialize_1 = require('angular2-materialize');
require("materialize-css");
var account_module_1 = require('./components/account/account.module');
var app_component_1 = require('./app.component');
var album_photos_component_1 = require('./components/album-photos.component');
var home_component_1 = require('./components/home.component');
var photos_component_1 = require('./components/photos.component');
var albums_component_1 = require('./components/albums.component');
var routes_1 = require('./routes');
var data_service_1 = require('./core/services/data.service');
var membership_service_1 = require('./core/services/membership.service');
var utility_service_1 = require('./core/services/utility.service');
var notification_service_1 = require('./core/services/notification.service');
var AppBaseRequestOptions = (function (_super) {
    __extends(AppBaseRequestOptions, _super);
    function AppBaseRequestOptions() {
        _super.call(this);
        this.headers = new http_2.Headers();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
    return AppBaseRequestOptions;
}(http_2.BaseRequestOptions));
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpModule,
                angular2_materialize_1.MaterializeModule,
                routes_1.routing,
                account_module_1.AccountModule
            ],
            declarations: [app_component_1.AppComponent, album_photos_component_1.AlbumPhotosComponent, home_component_1.HomeComponent, photos_component_1.PhotosComponent, albums_component_1.AlbumsComponent],
            providers: [data_service_1.DataService, membership_service_1.MembershipService, utility_service_1.UtilityService, notification_service_1.NotificationService,
                { provide: common_1.LocationStrategy, useClass: common_1.HashLocationStrategy },
                { provide: http_2.RequestOptions, useClass: AppBaseRequestOptions }],
            bootstrap: [app_component_1.AppComponent]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
