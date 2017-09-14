import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule, Http } from '@angular/http';

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

// i18n support
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

export function createTranslateLoader(http: Http) {
    let baseUrl = 'http://localhost:61832';

    // i18n files are in `wwwroot/assets/`
    return new TranslateHttpLoader(http, `${baseUrl}/assets/i18n/`, '.json');
}

const APP_PROVIDERS = [
    LinksCollectorService,
    RequestService,
    TranslateModule
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
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: (createTranslateLoader),
                deps: [Http]
            }
        }),
        Angular2PromiseButtonModule.forRoot()
    ],

    providers: [
        APP_PROVIDERS
    ]
})
export class AppModuleShared {
}
