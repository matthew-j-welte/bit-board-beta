import { Component, OnInit } from '@angular/core';

interface ImageDebris {
  x: number; 
  y: number;
  src: string;
  width?: number
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  imageDebris: ImageDebris[];

  constructor() {
    this.imageDebris = [
      {x: 200, y: 1300, src: './assets/spaceman-1.png'},
      {x: 1600, y: 1500, src: './assets/python-logo.png'},
      {x: 400, y: 2000, src: './assets/golang-logo.png'},
      {x: 1400, y: 2300, src: './assets/rocket.png', width: 400}
    ]
    
  }

  ngOnInit(): void {}
}
