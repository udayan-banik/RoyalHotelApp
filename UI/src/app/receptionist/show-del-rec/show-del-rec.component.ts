import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-del-rec',
  templateUrl: './show-del-rec.component.html',
  styleUrls: ['./show-del-rec.component.css']
})
export class ShowDelRecComponent implements OnInit {

  constructor(private service: SharedService) { }

  searchText:any

  isLogged:boolean = true;

  ReceptionistList:any=[];
  Modaltitle!: string;
  receptionist:any;
  ActivateAddEditReceptionist:Boolean = false;

  ngOnInit(): void {
    this.refereshReceptionistList();

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;
  }

  addClick() {
    this.receptionist = {
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
    this.Modaltitle = 'Add Receptionist';
    this.ActivateAddEditReceptionist = true;
  }

  editClick(item: any) {
    this.receptionist  = item;
    this.Modaltitle = 'Edit Receptionist';
    this.ActivateAddEditReceptionist = true;
    
  }

  deleteClick(item: any) {
    if (confirm('Are you sure?')) {
      this.service.DeleteReceptionist(item).subscribe((data) => {
        console.log(data);
        this.refereshReceptionistList();
      });
    }
  }

  closeClick() {
    this.ActivateAddEditReceptionist = false;
    this.refereshReceptionistList();
  }

  refereshReceptionistList() {
    this.service.GetReceptionist().subscribe((result: any) => {
      this.ReceptionistList = result;
    });
  }
}
