import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-del',
  templateUrl: './show-del.component.html',
  styleUrls: ['./show-del.component.css'],
})
export class ShowDelComponent implements OnInit {
  constructor(private service: SharedService) {}

  isLogged:boolean = true;


  RoomList: any = [];
  Modaltitle!: string;
  ActivateAddEditRoom: Boolean = false;
  room: any;
  
  ngOnInit(): void {
    
    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;

    this.refereshRoomList();

    
  }

  addClick() {
    this.room = {
      Room_Id: 0,
      Room_Status: '',
      Room_Comment: '',
      Room_Inventory: '',
      Room_Price: '',
    };
    this.Modaltitle = 'Add Room';
    this.ActivateAddEditRoom = true;
  }

  editClick(item: any) {
    this.room = item;
    this.Modaltitle = 'Edit Room';
    this.ActivateAddEditRoom = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure?')) {
      this.service.DelteRoom(item).subscribe((data) => {
        console.log(data);
        this.refereshRoomList();
      });
    }
  }

  closeClick() {
    this.ActivateAddEditRoom = false;
    this.refereshRoomList();
  }

  refereshRoomList() {
    this.service.getRoomsList().subscribe((result: any) => {
      this.RoomList = result;
    });
  }
}
