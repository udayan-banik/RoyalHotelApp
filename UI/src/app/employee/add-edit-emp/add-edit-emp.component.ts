import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {
  error: any;
  alert_authorize: boolean = false;
  alert:boolean= false;
  alerterror:boolean=false;

  constructor(private sevice:SharedService) { }

  @Input() employees:any;
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
    this.Employee_Id = this.employees.Employee_Id;
    this.Employee_Name = this.employees.Employee_Name;
    this.Employee_Password = this.employees.Employee_Password;
    this.Employee_Designation = this.employees.Employee_Designation;
    this.Employee_Salary = this.employees.Employee_Salary;
    this.Employee_Email = this.employees.Employee_Email;
    this.Employee_Age = this.employees.Employee_Age;
    this.Employee_PhoneNo = this.employees.Employee_PhoneNo;
    this.Employee_Address = this.employees.Employee_Address;
    
  }

  addEmployee(){
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
    this.sevice.AddEmployee(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true;this.alert=false;this.alert_authorize=true;this.error = error.status;
      if (this.error == 403) {
      this.error = 'You are not authorized to access this function'
    }
  });
  }

  updateEmployee(){
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
    this.sevice.UpdateEmployee(val).subscribe((success)=>{this.alert=true,this.alerterror=false},(error)=>{this.alerterror=true,this.alert=false;this.error = error.status;
    if (this.error == 403) {
      this.error = 'You are not authorized to access this function';
    }}
    );
  }

}
