import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-res',
  templateUrl: './add-edit-res.component.html',
  styleUrls: ['./add-edit-res.component.css']
})
export class AddEditResComponent implements OnInit {
  // RoomId:string;

  RoomId!:any;
  GuestId!:any;
  error: any;
  alert_authorize: boolean = false;
  alert:boolean = false;
  alerterror:boolean=false;



  constructor(private sevice:SharedService) { }

  currentDate : any = new Date();

  @Input() reservation:any;

  Reservation_Id!:string;
  Resevation_Check_In!:string;
  Resevation_Check_Out!:string;
  Reservation_No_of_Guests!:string;
  Reservation_Status!:boolean;
  Guest_Id!:string;
  Room_Id!:string;

  ngOnInit(): void {

    this.RoomId=localStorage.getItem('RoomId');
    this.GuestId=localStorage.getItem('GuestId');


    this.Reservation_Id = this.reservation.Reservation_Id;
    this.Resevation_Check_In = this.reservation.Resevation_Check_In;
    this.Resevation_Check_Out = this.reservation.Resevation_Check_Out;
    this.Reservation_No_of_Guests = this.reservation.Reservation_No_of_Guests;
    this.Reservation_Status = this.reservation.Reservation_Status;
    if(localStorage.getItem('RoomId')==null){
      this.Room_Id = this.reservation.Room_Id;
    }
    else{
      this.Room_Id = this.RoomId;
    }

    if(localStorage.getItem('GuestId')==null){
      this.Guest_Id = this.reservation.Guest_Id;
    }
    else{
      this.Guest_Id = this.GuestId;
    }
    


    

    console.log(this.RoomId);
    console.log(this.GuestId);
  }

  addReservation(){
    var val = {
      Resevation_Check_In:this.Resevation_Check_In,
      Resevation_Check_Out:this.Resevation_Check_Out,
      Reservation_No_of_Guests:this.Reservation_No_of_Guests,
      Reservation_Status:Boolean(this.Reservation_Status),
      Guest_Id:this.Guest_Id,
      Room_Id:this.Room_Id,
    };
    this.sevice.AddReservation(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert = true;
  }

  updateReservation(){
    var val = {
      Reservation_Id:this.Reservation_Id,
      Resevation_Check_In:this.Resevation_Check_In,
      Resevation_Check_Out:this.Resevation_Check_Out,
      Reservation_No_of_Guests:this.Reservation_No_of_Guests,
      Reservation_Status:Boolean(this.Reservation_Status),
      Guest_Id:this.Guest_Id,
      Room_Id:this.Room_Id,
    };
    this.sevice.UpdateReservation(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert =true;
  }
}
