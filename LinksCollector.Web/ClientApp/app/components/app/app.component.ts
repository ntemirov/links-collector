import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { TranslateService } from "@ngx-translate/core";
import { isPlatformBrowser } from '@angular/common';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private translate: TranslateService, @Inject(PLATFORM_ID) platformId: Object) {
        let isBrowser = isPlatformBrowser(platformId);

        // Hack: During the prerendering process, static files are loaded with an error
        if (isBrowser) {
            let lang = translate.getBrowserLang();

            // this language will be used as a fallback when a translation isn't found in the current language
            translate.setDefaultLang(lang);

            // the lang to use, if the lang isn't available, it will use the current loader to get them
            translate.use(lang);
        }
    }
}
