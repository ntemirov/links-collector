import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';

import { ReactiveFormsModule } from '@angular/forms';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { Angular2PromiseButtonModule } from 'angular2-promise-buttons/dist';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CollectorComponent } from './components/collector/collector.component';

import { LinksCollectorService } from './services/links-collector.service';
import { RequestService } from './services/request.service';

const APP_PROVIDERS = [
    LinksCollectorService,
    RequestService
];

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CollectorComponent,
        FetchDataComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AppRoutingModule,
        ReactiveFormsModule,
        InfiniteScrollModule,
        Angular2PromiseButtonModule.forRoot()
    ],

    providers: [
        APP_PROVIDERS
    ]
})
export class AppModuleShared {
}
