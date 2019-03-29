import { Component } from '@angular/core';
import { NavController,NavParams } from 'ionic-angular';
import { HttpClient } from  '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { LandingPage } from '../landing/landing';
import { RestApiProvider } from '../../providers/rest-api/rest-api';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  errorMessage: string; 
  descending: boolean = true;
  order: number;
  column: string = 'firstName';

  //Players arry to hold json object
   players: string[];

  constructor(public navCtrl: NavController, 
    public navParams: NavParams, 
    private httpClient: HttpClient,
    public rest: RestApiProvider) {      
  }

  //Method to fill players array 
  getPlayers() {
    this.rest.getPlayers()
       .subscribe(
         players => this.players = players,
         error =>  this.errorMessage = <any>error);
         console.log(this.players);
  }

  goToHome(){
    this.navCtrl.setRoot(LandingPage);
  }

  //Load players when page loades 
  ionViewDidLoad() {
    this.getPlayers();
    console.log(this.players);
  }

  //Sort in accending order
  sort(){
    this.descending = !this.descending;
    this.order = this.descending ? 1 : -1;
  }

 
}
