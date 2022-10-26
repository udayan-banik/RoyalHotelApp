import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-del-emp',
  templateUrl: './show-del-emp.component.html',
  styleUrls: ['./show-del-emp.component.css']
})
export class ShowDelEmpComponent implements OnInit {

  constructor(private service: SharedService) { }

  searchText:any

  isLogged:boolean = true;

  EmployeeList:any =[];
  Modaltitle!: string;
  employees:any;
  ActivateAddEditEmployee:Boolean = false;

  ngOnInit(): void {
    this.refereshEmployeeList();

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;
  }

  addClick() {
    this.employees = {
      Employee_Id: 0,
      Employee_Name: '',
      Employee_Password: '',
      Employee_Designation: '',
      Employee_Salary: '',
      Employee_Email:'',
      Employee_Age:'',
      Employee_PhoneNo:'',
      Employee_Address:'',
    };
    this.Modaltitle = 'Add Employee';
    this.ActivateAddEditEmployee = true;
  }

  editClick(item: any) {
    this.employees  = item;
    this.Modaltitle = 'Edit Employee';
    this.ActivateAddEditEmployee = true;
    
  }
  
  closeClick() {
    this.ActivateAddEditEmployee = false;
    this.refereshEmployeeList();
  }

  deleteClick(item: any) {
    if (confirm('Are you sure?')) {
      this.service.DelteEmployee(item).subscribe((data) => {
        console.log(data);
        this.refereshEmployeeList();
      });
    }
  }

  refereshEmployeeList() {
    this.service.GetEmployee().subscribe((result: any) => {
      this.EmployeeList = result;
    });
  }

}
