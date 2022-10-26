import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RoomsComponent } from './rooms/rooms.component';
import { UnbookedRoomsComponent } from './unbooked-rooms/unbooked-rooms.component';
import { BookedRoomsComponent } from './booked-rooms/booked-rooms.component';
import { GuestsComponent } from './guests/guests.component';
import { EmployeeComponent } from './employee/employee.component';
import { ReceptionistComponent } from './receptionist/receptionist.component';
import { ReservationComponent } from './reservation/reservation.component';
import { BillComponent } from './bill/bill.component';
import { PayComponent } from './pay/pay.component';

//Pages
import { LoginComponent } from './login/login.component';
import { OwnerComponent } from './owner/owner.component';
import { ReceptionistsComponent } from './receptionists/receptionists.component';
import { ManagerComponent } from './manager/manager.component';

const routes: Routes = [
  //Pages
  { path: '', component: LoginComponent },

  //pages----
  {
    path: 'owner',
    component: OwnerComponent,
    children: [
      { path: 'guests', component: GuestsComponent },
      { path: 'room', component: RoomsComponent },
      { path: 'receptionist', component: ReceptionistComponent },
      { path: 'employee', component: EmployeeComponent },
      { path: '', redirectTo: 'owner', pathMatch: 'full' },
    ],
  },

  {
    path: 'manager',
    component: ManagerComponent,
    children: [
      { path: 'room', component: RoomsComponent },
      { path: 'reservation', component: ReservationComponent },
      { path: 'receptionist', component: ReceptionistComponent },
      { path: '', redirectTo: 'manager', pathMatch: 'full' },
    ],
  },

  {
    path: 'receptionists',
    component: ReceptionistsComponent,
    children: [
      { path: 'guests', component: GuestsComponent },
      { path: 'room', component: RoomsComponent },
      { path: 'booked-rooms', component: BookedRoomsComponent },
      { path: 'unbooked-rooms', component: UnbookedRoomsComponent },
      { path: 'bill', component: BillComponent },
      { path: 'reservation', component: ReservationComponent },
      { path: 'pay', component: PayComponent },
      { path: '', redirectTo: 'receptionists', pathMatch: 'full' },
    ],
  },


  // { path: 'login', component: LoginComponent },
  // { path: 'owner', component: OwnerComponent },
  // { path: 'receptionists', component: ReceptionistsComponent },
  // { path: 'manager', component: ManagerComponent },

  // { path: 'owner/guests', component: GuestsComponent },
  // { path: 'owner/room', component: RoomsComponent },
  // { path: 'owner/employee', component: EmployeeComponent },
  // { path: 'owner/receptionist', component: ReceptionistComponent },

  // { path: 'receptionists/guests', component: GuestsComponent },
  // { path: 'receptionists/room', component: RoomsComponent },
  // { path: 'receptionists/booked-rooms', component: BookedRoomsComponent },
  // { path: 'receptionists/unbooked-rooms', component: UnbookedRoomsComponent },
  // { path: 'receptionists/bill', component: BillComponent },
  // { path: 'receptionists/reservation', component: ReservationComponent },
  // { path: 'receptionists/pay', component: PayComponent },

  // { path: 'manager/room', component: RoomsComponent },
  // { path: 'manager/reservation', component: ReservationComponent },
  // { path: 'manager/receptionist', component: ReceptionistComponent },

  //Components
  // { path: 'room', component: RoomsComponent },
  // { path: 'unbooked-rooms', component: UnbookedRoomsComponent },
  // { path: 'booked-rooms', component: BookedRoomsComponent },
  // { path: 'guests', component: GuestsComponent },
  // { path: 'employee', component: EmployeeComponent },
  // { path: 'receptionist', component: ReceptionistComponent },
  // { path: 'reservation', component: ReservationComponent },
  // { path: 'bill', component: BillComponent },
  // { path: 'pay', component: PayComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
