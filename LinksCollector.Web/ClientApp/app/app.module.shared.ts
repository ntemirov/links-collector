import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';

import { ReactiveFormsModule } from '@angular/forms';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { Angular2PromiseButtonModule } from 'angular2-promise-buttons/dist';
import { ToastModule } from 'ng2-toastr/ng2-toastr';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CollectorComponent } from './components/collector/collector.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CollectorComponent,
        FetchDataComponent,
        HomeComponent
    ],
    imports: [
        AppRoutingModule,
        BrowserAnimationsModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        InfiniteScrollModule,
        Angular2PromiseButtonModule.forRoot(),
        ToastModule.forRoot()
    ]
})
export class AppModuleShared {
}
