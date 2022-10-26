import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-guest',
  templateUrl: './add-edit-guest.component.html',
  styleUrls: ['./add-edit-guest.component.css'],
})
export class AddEditGuestComponent implements OnInit {
  
  constructor(private sevice:SharedService) {}

  error: any;
  alert_authorize: boolean = false;
  alert:boolean = false;
  alerterror:boolean=false;

  @Input() guest:any;

  Guest_Id!:string;
  Guest_Name!:string;
  Guest_Email!:string;
  Guest_Age!:string;
  Guest_Phone_Number!:string;
  Guest_Aadhar_Id!:string;
  Guest_Address!:string;

  ngOnInit(): void {
    this.Guest_Id = this.guest.Guest_Id;
    this.Guest_Name = this.guest.Guest_Name;
    this.Guest_Email = this.guest.Guest_Email;
    this.Guest_Age = this.guest.Guest_Age;
    this.Guest_Phone_Number = this.guest.Guest_Phone_Number;
    this.Guest_Aadhar_Id = this.guest.Guest_Aadhar_Id;
    this.Guest_Address = this.guest.Guest_Address;
  }

  addGuest(){
    var val = {
      Guest_Name:this.Guest_Name,
      Guest_Email:this.Guest_Email,
      Guest_Age:this.Guest_Age,
      Guest_Phone_Number:this.Guest_Phone_Number,
      Guest_Aadhar_Id:this.Guest_Aadhar_Id,
      Guest_Address:this.Guest_Address,
    };
    this.sevice.AddGuest(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';}});
    // this.alert = true;
  }

  updateGuest(){
    var val = {
      Guest_Id:this.Guest_Id,
      Guest_Name:this.Guest_Name,
      Guest_Email:this.Guest_Email,
      Guest_Age:this.Guest_Age,
      Guest_Phone_Number:this.Guest_Phone_Number,
      Guest_Aadhar_Id:this.Guest_Aadhar_Id,
      Guest_Address:this.Guest_Address,
    };
    this.sevice.UpdateGuest(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert = true;
  }
}
