import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-del-pay',
  templateUrl: './show-del-pay.component.html',
  styleUrls: ['./show-del-pay.component.css']
})
export class ShowDelPayComponent implements OnInit {

  constructor(private service: SharedService) { }

  isLogged:boolean = true;

  PayList:any=[];
  pay:any;
  Modaltitle!: string;
  ActivateAddEditPay:Boolean = false;

  ngOnInit(): void {
    this.refereshPayList();

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;
    
  }

  addClick() {
    this.pay = {
      Payment_Id: 0,
      Payment_Card: '',
      Payment_Card_Holder_Name: '',
      Bill_Id: '',
    };
    this.Modaltitle = 'Add Payment Detail';
    this.ActivateAddEditPay = true;
  }

  editClick(item: any) {
    this.pay  = item;
    this.Modaltitle = 'Edit Payment Detail';
    this.ActivateAddEditPay = true;
  }

  closeClick() {
    this.ActivateAddEditPay = false;
    this.refereshPayList();
  }


  refereshPayList() {
    this.service.getPayList().subscribe((result: any) => {
      this.PayList = result;
    });
  }

  clearclick(){
    localStorage.removeItem('BillId');
  }

}
