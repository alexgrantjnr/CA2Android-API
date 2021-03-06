import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HomePage } from '../home/home';
import { TranslateService } from '@ngx-translate/core';
import { LanguageProvider } from "../../providers/language/language";
import { LanguageModel } from "../../models/language.model";

@IonicPage()
@Component({
  selector: 'page-landing',
  templateUrl: 'landing.html',
})
export class LandingPage { 

  languageSelected : any = 'en';
  languages : Array<LanguageModel>;

  constructor(public navCtrl: NavController, 
    public navParams: NavParams,
    public translate: TranslateService,
    public LanguageProvider: LanguageProvider) {

      this.languages = this.LanguageProvider.getLanguages();
      this.setLanguage();
  }

  setLanguage(){
    let defaultLanguage = this.translate.getDefaultLang();
    if(this.languageSelected){
      this.translate.setDefaultLang(this.languageSelected);
      this.translate.use(this.languageSelected);
    }
    else{
      this.languageSelected = defaultLanguage;
      this.translate.use(defaultLanguage);
    }
  }

  goToPlayerList(){             
    this.navCtrl.setRoot(HomePage);            
  } 

}
