import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from  '@angular/common/http';
import { RestApiProvider } from '../../providers/rest-api/rest-api';
import { SearchPage } from '../search/search';
//import 'rxjs/add/operator/map';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

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

    find()
    {
      this.navCtrl.push(SearchPage);
    }
}
