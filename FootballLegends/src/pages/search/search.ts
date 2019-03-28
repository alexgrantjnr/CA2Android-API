import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { RestApiProvider } from '../../providers/rest-api/rest-api';
import { HttpClient } from '@angular/common/http';

/**
 * Generated class for the SearchPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-search',
  templateUrl: 'search.html',
})
export class SearchPage {
  players: string[];
  errorMessage: string; 
  //json: any;
  //players: any = [];
  //players: any;

  descending: boolean = false;
  order: number;
  column: string = 'firstName';

  constructor(public navCtrl: NavController, 
    public rest: RestApiProvider) { }

    getPlayers() {
      this.rest.getPlayers()
         .subscribe(
           players => this.players = players,
           error =>  this.errorMessage = <any>error);
    }

    ionViewDidLoad() {
      this.getPlayers();
      console.log(this.players);
    }

    sort(){
      this.descending = !this.descending;
      this.order = this.descending ? 1 : -1;
    }

}
