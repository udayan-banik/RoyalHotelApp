import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-bill',
  templateUrl: './add-edit-bill.component.html',
  styleUrls: ['./add-edit-bill.component.css']
})
export class AddEditBillComponent implements OnInit {

  GuestId!:any;
  ReservationId!:any;
  error: any;
  alert_authorize: boolean = false;
  alert:boolean=false;
  alerterror:boolean=false;

  constructor(private sevice:SharedService) { }

  @Input() bill:any;
  Bill_Id!:string;
  Bill_Amount!:string;
  Bill_Date!:string;
  Reservation_Id!:string;
  Guest_Id!:string;

  ngOnInit(): void {
    this.ReservationId=localStorage.getItem('ReservationId');
    this.GuestId=localStorage.getItem('GuestId');

    this.Bill_Id = this.bill.Bill_Id;
    this.Bill_Amount = this.bill.Bill_Amount;
    this.Bill_Date = this.bill.Bill_Date;
    if(localStorage.getItem('ReservationId')==null){
      this.Reservation_Id = this.bill.Reservation_Id;
    }
    else{
      this.Reservation_Id=this.ReservationId;
    }
    if(localStorage.getItem('GuestId')==null){
      this.Guest_Id = this.bill.Guest_Id;
    }
    else{
      this.Guest_Id = this.GuestId;
    }
  }

  addBill(){
    var val={
      Bill_Amount:this.Bill_Amount,
      Bill_Date:this.Bill_Date,
      Reservation_Id:this.Reservation_Id,
      Guest_Id:this.Guest_Id
    };
    this.sevice.AddBill(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;
      if (this.error == 403) {
        this.error = 'You are not authorized to access this function';
      }}
      );
  }

  updateBill(){
    var val={
      Bill_Id:this.Bill_Id,
      Bill_Amount:this.Bill_Amount,
      Bill_Date:this.Bill_Date,
      Reservation_Id:this.Reservation_Id,
      Guest_Id:this.Guest_Id
    };
    this.sevice.UpdateBill(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }}
            );
          }
  }
