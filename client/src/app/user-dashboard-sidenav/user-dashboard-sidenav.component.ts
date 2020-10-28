import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-dashboard-sidenav',
  templateUrl: './user-dashboard-sidenav.component.html',
  styleUrls: ['./user-dashboard-sidenav.component.css']
})
export class UserDashboardSidenavComponent implements OnInit {
  @Input() imageUrl: string;
  
  constructor() { }

  ngOnInit(): void {
  }

}
