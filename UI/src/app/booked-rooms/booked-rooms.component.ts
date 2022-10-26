import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-booked-rooms',
  templateUrl: './booked-rooms.component.html',
  styleUrls: ['./booked-rooms.component.css'],
})
export class BookedRoomsComponent implements OnInit {
  constructor(private service: SharedService) {}

  isLogged:boolean = true;
  bookedRoomList: any = [];
  Modaltitle!: string;
  ActivateAddEditRoom: Boolean = false;
  room: any;
  ngOnInit(): void {
    this.refereshRoomList();
    // ngOnInit(): void {
    // }

    if (localStorage.getItem('authToken')) {
      this.isLogged = true;
    } else this.isLogged = false;
  }

  refereshRoomList() {
    this.service.bookedRooms().subscribe((result: any) => {
      this.bookedRoomList = result;
    });
  }
}
