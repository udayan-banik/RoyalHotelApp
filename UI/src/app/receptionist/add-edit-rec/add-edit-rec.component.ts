import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-rec',
  templateUrl: './add-edit-rec.component.html',
  styleUrls: ['./add-edit-rec.component.css']
})
export class AddEditRecComponent implements OnInit {

  error: any;
  alert_authorize: boolean = false;
  alert:boolean = false;
  alerterror:boolean=false;
  constructor(private sevice:SharedService) { }

  @Input() receptionist:any;
  
  Employee_Id!:string;
  Employee_Name!:string;
  Employee_Password!:string;
  Employee_Designation!:string;
  Employee_Salary!:string;
  Employee_Email!:string;
  Employee_Age!:string;
  Employee_PhoneNo!:string;
  Employee_Address!:string;


  ngOnInit(): void {
    this.Employee_Id = this.receptionist.Employee_Id;
    this.Employee_Name = this.receptionist.Employee_Name;
    this.Employee_Password = this.receptionist.Employee_Password;
    this.Employee_Designation = this.receptionist.Employee_Designation;
    this.Employee_Salary = this.receptionist.Employee_Salary;
    this.Employee_Email = this.receptionist.Employee_Email;
    this.Employee_Age = this.receptionist.Employee_Age;
    this.Employee_PhoneNo = this.receptionist.Employee_PhoneNo;
    this.Employee_Address = this.receptionist.Employee_Address;
  }

  addReceptionist(){
    var val={
      Employee_Name:this.Employee_Name,
      Employee_Password:this.Employee_Password,
      Employee_Designation:this.Employee_Designation,
      Employee_Salary:this.Employee_Salary,
      Employee_Email:this.Employee_Email,
      Employee_Age:this.Employee_Age,
      Employee_PhoneNo:this.Employee_PhoneNo,
      Employee_Address:this.Employee_Address,
    };
    this.sevice.AddReceptionist(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert = true;
  }

  updateReceptionist(){
    var val={
      Employee_Id:this.Employee_Id,
      Employee_Name:this.Employee_Name,
      Employee_Password:this.Employee_Password,
      Employee_Designation:this.Employee_Designation,
      Employee_Salary:this.Employee_Salary,
      Employee_Email:this.Employee_Email,
      Employee_Age:this.Employee_Age,
      Employee_PhoneNo:this.Employee_PhoneNo,
      Employee_Address:this.Employee_Address,
    };
    this.sevice.UpdateReceptionist(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert = true;
  }
}
