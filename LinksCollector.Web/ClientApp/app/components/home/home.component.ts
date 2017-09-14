import { Component } from '@angular/core';
import { TranslateService, LangChangeEvent, TranslationChangeEvent } from "@ngx-translate/core";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    constructor(private translate: TranslateService) {
        console.log('BrowserLang:', translate.getBrowserLang());
        console.log('BrowserCultureLang:', translate.getBrowserCultureLang());

        translate.onLangChange.subscribe((event: LangChangeEvent) => {
            console.log('onLangChange', event);
        });

        translate.onTranslationChange.subscribe((event: TranslationChangeEvent) => {
            console.log('onTranslationChange', event);
        });
    }

    public setLanguage(lang: string): void {
        console.log(location.origin);

        this.translate.use(lang);
        this.translate.setDefaultLang(lang);
    }
}
