import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-add-edit-pay',
  templateUrl: './add-edit-pay.component.html',
  styleUrls: ['./add-edit-pay.component.css']
})
export class AddEditPayComponent implements OnInit {

  BillId:any;

  error: any;
  alert_authorize: boolean = false;
  alert:boolean=false;
  alerterror:boolean=false;

  constructor(private sevice:SharedService) { }

  @Input() pay:any;
  Payment_Id!:string;
  Payment_Card!:string;
  Payment_Card_Holder_Name!:string;
  Bill_Id!:string;

  ngOnInit(): void {
    this.BillId = localStorage.getItem('BillId');
    this.Payment_Id = this.pay.Payment_Id;
    this.Payment_Card = this.pay.Payment_Card;
    this.Payment_Card_Holder_Name = this.pay.Payment_Card_Holder_Name;
    if(localStorage.getItem('BillId')==null){
      this.Bill_Id = this.pay.Bill_Id;
    }
    else{
      this.Bill_Id=this.BillId;
    }
    
  }

  addPay(){
    var val={
      Payment_Card:this.Payment_Card,
      Payment_Card_Holder_Name:this.Payment_Card_Holder_Name,
      Bill_Id:this.Bill_Id,
    };
    this.sevice.AddPay(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert=true;
  }

  updatePay(){
    var val={
      Payment_Id:this.Payment_Id,
      Payment_Card:this.Payment_Card,
      Payment_Card_Holder_Name:this.Payment_Card_Holder_Name,
      Bill_Id:this.Bill_Id,
    };
    this.sevice.UpdatePay(val).subscribe(success=>{this.alert=true,this.alerterror=false},error=>{this.alerterror=true,this.alert=false;this.alert_authorize=true;this.error = error.status;

      if (this.error == 403) {
              this.error = 'You are not authorized to access this function';
            }});
    // this.alert=true;
  }

}
