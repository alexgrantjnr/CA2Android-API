import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { SearchPipe } from '../pipes/search/search';
import { SortPipe } from '../pipes/sort/sort';

//Import to access a HTTP GET Request
import { HttpClientModule } from  '@angular/common/http';
import { HttpModule } from '@angular/http';


import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { RestApiProvider } from '../providers/rest-api/rest-api';
import { SearchPage } from '../pages/search/search';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    SearchPipe,
    SearchPage,
    SortPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,    
    HttpModule,  
    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    SearchPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    RestApiProvider
  ]
})
export class AppModule {}
