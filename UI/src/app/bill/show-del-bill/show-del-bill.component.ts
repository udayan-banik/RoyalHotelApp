import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-del-bill',
  templateUrl: './show-del-bill.component.html',
  styleUrls: ['./show-del-bill.component.css']
})
export class ShowDelBillComponent implements OnInit {

  constructor(private service: SharedService, private router: Router) { }

  // alert:boolean=false;
  isLogged:boolean = true;

  searchText:any;

  BillList:any=[];
  bill:any;
  Modaltitle!: string;
  ActivateAddEditBill:Boolean = false;

  ngOnInit(): void {
    this.refereshBillList();

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;
  }

  addClick() {
    this.bill = {
      Bill_Id: 0,
      Bill_Amount: '',
      Bill_Date: '',
      Reservation_Id: '',
      Guest_Id: '',
    };
    this.Modaltitle = 'Add Bill';
    this.ActivateAddEditBill = true;
  }

  editClick(item: any) {
    this.bill  = item;
    this.Modaltitle = 'Edit Bill';
    this.ActivateAddEditBill = true;
  }

  closeClick() {
    this.ActivateAddEditBill = false;
    this.refereshBillList();
  }

  deleteClick(item: any) {
    if (confirm('Are you sure?')) {
      this.service.DeleteBill(item).subscribe((data) => {
        this.refereshBillList();
      });
    }
  }

  refereshBillList() {
    this.service.GetBill().subscribe((result: any) => {
      this.BillList = result;
    });
  }

  BillClick(val:any){
    console.log(val.Bill_Id);
    localStorage.setItem('BillId',val.Bill_Id);
    this.router.navigate(['/receptionists/pay']);
  }

  clearclick(){
    localStorage.removeItem('GuestId');
    localStorage.removeItem('ReservationId');
  }
}
