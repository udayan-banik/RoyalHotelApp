import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.css'],
})
export class OwnerComponent implements OnInit {
  alert: boolean = false;
  loggedType: any;
  btn_active: boolean = false;

  constructor() {}

  ngOnInit(): void {
    if (localStorage.getItem('role') == 'owner') {
      this.alert = true;
      this.loggedType = localStorage.getItem('user');
      this.btn_active= false;
    } 
    else {
      this.alert = false;
      localStorage.clear();
      this.btn_active= true;
    }
  }

  Logout() {
    localStorage.clear();
  }

  activateSPA() {
    this.btn_active = true;
  }

  resetSPA() {
    this.btn_active = false;
  }
}
