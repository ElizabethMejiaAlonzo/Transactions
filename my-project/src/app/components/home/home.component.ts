import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public transacction: any = [];

  constructor(
    private dataService: DataService
  ) { }


  ngOnInit(): void {
    this.getTransacction();
  }

  /**
   * getTransacction
   * 
   */
  public getTransacction() {
    this.dataService.sendGetRequest().toPromise().then(res => {
      this.transacction = res;
    });
  }
}