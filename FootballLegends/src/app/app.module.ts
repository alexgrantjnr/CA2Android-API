import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { SearchPipe } from '../pipes/search/search';
import { SortPipe } from '../pipes/sort/sort';

//Import to access a HTTP GET Request
import { HttpClientModule , HttpClient} from  '@angular/common/http';
import { HttpModule, Http } from '@angular/http';
import { TranslateModule, TranslateLoader} from '@ngx-translate/core';
import { TranslateHttpLoader} from '@ngx-translate/http-loader';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { RestApiProvider } from '../providers/rest-api/rest-api';
import { LandingPage } from '../pages/landing/landing';
import { LanguageProvider } from '../providers/language/language';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
  }
  
@NgModule({
  declarations: [
    MyApp,
    HomePage,
    SearchPipe,
    SortPipe,
    LandingPage
  ],
  imports: [
    BrowserModule,
    HttpClientModule,    
    HttpModule,  
    IonicModule.forRoot(MyApp),
    TranslateModule.forRoot({
      loader: {
           provide: TranslateLoader,
           useFactory: (createTranslateLoader),
           deps: [HttpClient]
         }
      })
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    LandingPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    RestApiProvider,
    LanguageProvider
  ]
})
export class AppModule {}
