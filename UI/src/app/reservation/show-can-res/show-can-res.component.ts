import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';


import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-can-res',
  templateUrl: './show-can-res.component.html',
  styleUrls: ['./show-can-res.component.css']
})
export class ShowCanResComponent implements OnInit {

  constructor(private service: SharedService,private router: Router) { }

  isLogged:boolean = true;

  searchText:any;
  ReservationList:any = [];

  reservation:any;
  Modaltitle!: string;
  ActivateAddEditReservation:Boolean = false;
  isAuthorized:boolean=false;

  


  ngOnInit(): void {
    this.refereshReservationList();

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;

    if(localStorage.getItem('role')=="receptionists"){
      this.isAuthorized=true;

    }
    
  }

  addClick() {
    this.reservation = {
      Reservation_Id: 0,
      Resevation_Check_In: '',
      Resevation_Check_Out: '',
      Reservation_No_of_Guests: '',
      Reservation_Status: '',
      Guest_Id:'',
      Room_Id:'',
    };
    this.Modaltitle = 'Add Reservation';
    this.ActivateAddEditReservation = true;
  }

  editClick(item: any) {
    this.reservation  = item;
    this.Modaltitle = 'Edit Reservation';
    this.ActivateAddEditReservation = true;
    
  }

  closeClick() {
    this.ActivateAddEditReservation = false;
    this.refereshReservationList();
  }

  deleteClick(item: any) {
    if (confirm('Are you sure?')) {
      this.service.CancelReservation(item).subscribe((data) => {
        console.log(data);
        this.refereshReservationList();
      });
    }
  }

  refereshReservationList() {
    this.service.GetReservation().subscribe((result: any) => {
      this.ReservationList = result;
    });
  }

  BillClick(val:any){
    console.log(val.Reservation_Id);
    localStorage.setItem('ReservationId',val.Reservation_Id);
    this.router.navigate(['/receptionists/bill']);
  }

  clearclick(){
    localStorage.removeItem('GuestId');
    localStorage.removeItem('RoomId');
  }

}
