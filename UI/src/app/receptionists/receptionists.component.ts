import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-receptionists',
  templateUrl: './receptionists.component.html',
  styleUrls: ['./receptionists.component.css'],
})
export class ReceptionistsComponent implements OnInit {

  unbookedRoomList: any = [];

  alert: boolean = false;
  loggedType: any;
  btn_active: boolean=true;


  constructor(private service: SharedService) {}

  ngOnInit(): void {

    this.refereshRoomList();
        
    if (localStorage.getItem('role') == 'receptionists') {
      this.loggedType = localStorage.getItem('user');
      this.alert = true;
      this.btn_active= true;
    } 
    else 
    {
    this.alert = false;
    localStorage.clear();
    this.btn_active = true;
    }

  }

  Logout() {
    localStorage.clear();
  }

  refereshRoomList() {
    this.service.unbookedRooms().subscribe((result: any) => {
      this.unbookedRoomList = result;
    });
  }

  activateSPA() {
    this.btn_active = true;
  }

  resetSPA() {
    this.btn_active = false;
  }

}
