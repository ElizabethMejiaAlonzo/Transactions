import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  infoCards = [
    { name: 'Normal Info Card', value: '0000' },
    { name: 'Success Info Card', value: '0000' },
    { name: 'Warning Info Card', value: '0000' }
  ];
  contentCards = [
    { name: 'Card Name' },
    { name: 'Card Name' },
    { name: 'Card Name' },
    { name: 'Card Name' },
    { name: 'Card Name' }
  ];

  inDropdown = [];

  ngOnInit() {
  }
}
