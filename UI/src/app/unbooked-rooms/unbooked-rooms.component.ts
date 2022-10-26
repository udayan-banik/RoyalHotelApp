import { Component, OnInit, Input } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { OwnerComponent } from '../owner/owner.component';
import { ReceptionistsComponent } from '../receptionists/receptionists.component';
import { ManagerComponent } from '../manager/manager.component';
import { Call, Token } from '@angular/compiler';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-unbooked-rooms',
  templateUrl: './unbooked-rooms.component.html',
  styleUrls: ['./unbooked-rooms.component.css'],
})
export class UnbookedRoomsComponent implements OnInit {
  
  constructor(private service: SharedService, private router: Router) {}

  isLogged:boolean = true;
  
  unbookedRoomList: any = [];
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
    this.service.unbookedRooms().subscribe((result: any) => {
      this.unbookedRoomList = result;
    });
  }
  
  ReservationClick(val:any){
    console.log(val.Room_Id);
    localStorage.setItem('RoomId',val.Room_Id);
    this.router.navigate(['/receptionists/guests']);
  }
}
