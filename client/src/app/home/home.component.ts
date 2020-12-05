import { Component, OnInit } from '@angular/core';

interface ImageDebris {
  x: number;
  y: number;
  src: string;
  width?: number;
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
      { x: 100, y: 1300, src: './assets/spaceman-1.png' },
      { x: 1850, y: 1500, src: './assets/python-logo.png' },
      { x: 30, y: 2200, src: './assets/cpp-logo.png' },
      { x: 1400, y: 2300, src: './assets/rocket.png', width: 400 },
      { x: 350, y: 1700, src: './assets/mongodb-logo.png' },
      { x: 1300, y: 1800, src: './assets/windows-logo.png' },
      { x: 525, y: 2600, src: './assets/linux-logo.png' }
    ];

  }

  ngOnInit(): void { }
}
