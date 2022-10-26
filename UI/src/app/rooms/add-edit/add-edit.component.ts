import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css'],
})
export class AddEditComponent implements OnInit {

  error: any;
  alert_authorize: boolean = false;
  alert: Boolean = false;
  alerterror: boolean = false;

  constructor(private sevice: SharedService) {}

  @Input() room: any;
  Room_Id!: string;
  Room_Status!: any;
  Room_Comment!: string;
  Room_Inventory!: string;
  Room_Price!: string;

  ngOnInit(): void {
    this.Room_Id = this.room.Room_Id;
    this.Room_Status = this.room.Room_Status;
    this.Room_Comment = this.room.Room_Comment;
    this.Room_Inventory = this.room.Room_Inventory;
    this.Room_Price = this.room.Room_Price;
  }

  addRoom() {
    var val = {
      Room_Status:true,
      Room_Comment: this.Room_Comment,
      Room_Inventory: this.Room_Inventory,
      Room_Price: this.Room_Price,
    };
    this.sevice.AddRoom(val).subscribe(
      (success) => {
        (this.alert = true), (this.alerterror = false);
      },
      (error) => {
        (this.alerterror = true), (this.alert = false);
        this.alert_authorize=true;this.error = error.status;

if (this.error == 403) {
        this.error = 'You are not authorized to access this function';
      }
      }
    );
  }

  updateRoom() {
    var val = {
      Room_Id: this.Room_Id,
      Room_Status: Boolean(this.Room_Status),
      Room_Comment: this.Room_Comment,
      Room_Inventory: this.Room_Inventory,
      Room_Price: this.Room_Price,
    };
    console.log(val);
    this.sevice.UpdateRoom(val).subscribe(
      (success) => {
        (this.alert = true), (this.alerterror = false);
      },
      (error) => {
        (this.alerterror = true), (this.alert = false);
        this.alert_authorize=true;this.error = error.status;

if (this.error == 403) {
        this.error = 'You are not authorized to access this function';
      }
      }
    );
  }
}
