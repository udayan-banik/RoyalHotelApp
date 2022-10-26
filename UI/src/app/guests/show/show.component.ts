import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterModule, Routes, Router } from '@angular/router';

import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css'],
})
export class ShowComponent implements OnInit {
  
  constructor(private service: SharedService,private router: Router) {}
  
  searchText:any
  isLogged:boolean = true;

  GuestList: any = [];

  Modaltitle!: string;
  ActivateAddEditGuest: Boolean = false;
  guest: any;
  isAuthorized:boolean=false;

  ngOnInit(): void {
    this.refreshGuestList();

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;

    if(localStorage.getItem('role')=="receptionists"){
      this.isAuthorized=true;

    }
    // if()
  }

  //crud functions

  addClick() {
    this.guest = {
      Guest_Id: 0,
      Guest_Name: '',
      Guest_Email: '',
      Guest_Age: '',
      Guest_Phone_Number: '',
      Guest_Aadhar_Id: '',
      Guest_Address: '',
    };
    this.Modaltitle = 'Add Guest';
    this.ActivateAddEditGuest = true
  }
  
  editClick(item: any) {
    this.guest = item;
    this.Modaltitle = 'Edit Guest';
    this.ActivateAddEditGuest = true
  }

  closeClick() {
    this.ActivateAddEditGuest = false;
    this.refreshGuestList();
  }



  refreshGuestList() {

    this.service.GetGuests().subscribe((result: any) => {
      this.GuestList = result;
    });
  }

  ReservationClick(val:any){
    console.log(val.Guest_Id);
    localStorage.setItem('GuestId',val.Guest_Id);
    this.router.navigate(['/receptionists/reservation']);
    
  }



}
