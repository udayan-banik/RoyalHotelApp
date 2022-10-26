import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoomsComponent } from './rooms/rooms.component';
import { ShowDelComponent } from './rooms/show-del/show-del.component';
import { AddEditComponent } from './rooms/add-edit/add-edit.component';
import { SharedService } from './shared.service';
import { SharedInterceptor } from './shared.interceptor';


import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { BookedRoomsComponent } from './booked-rooms/booked-rooms.component';
import { UnbookedRoomsComponent } from './unbooked-rooms/unbooked-rooms.component';
import { GuestsComponent } from './guests/guests.component';
import { ShowComponent } from './guests/show/show.component';
import { AddEditGuestComponent } from './guests/add-edit-guest/add-edit-guest.component';
import { EmployeeComponent } from './employee/employee.component';
import { ShowDelEmpComponent } from './employee/show-del-emp/show-del-emp.component';
import { AddEditEmpComponent } from './employee/add-edit-emp/add-edit-emp.component';
import { ReceptionistComponent } from './receptionist/receptionist.component';
import { ShowDelRecComponent } from './receptionist/show-del-rec/show-del-rec.component';
import { AddEditRecComponent } from './receptionist/add-edit-rec/add-edit-rec.component';
import { ReservationComponent } from './reservation/reservation.component';
import { ShowCanResComponent } from './reservation/show-can-res/show-can-res.component';
import { AddEditResComponent } from './reservation/add-edit-res/add-edit-res.component';
import { BillComponent } from './bill/bill.component';
import { ShowDelBillComponent } from './bill/show-del-bill/show-del-bill.component';
import { AddEditBillComponent } from './bill/add-edit-bill/add-edit-bill.component';
import { PayComponent } from './pay/pay.component';
import { ShowDelPayComponent } from './pay/show-del-pay/show-del-pay.component';
import { AddEditPayComponent } from './pay/add-edit-pay/add-edit-pay.component';
import { LoginComponent } from './login/login.component';
import { OwnerComponent } from './owner/owner.component';
import { ManagerComponent } from './manager/manager.component';
import { ReceptionistsComponent } from './receptionists/receptionists.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  declarations: [
    AppComponent,
    RoomsComponent,
    ShowDelComponent,
    AddEditComponent,
    BookedRoomsComponent,
    UnbookedRoomsComponent,
    GuestsComponent,
    ShowComponent,
    AddEditGuestComponent,
    EmployeeComponent,
    ShowDelEmpComponent,
    AddEditEmpComponent,
    ReceptionistComponent,
    ShowDelRecComponent,
    AddEditRecComponent,
    ReservationComponent,
    ShowCanResComponent,
    AddEditResComponent,
    BillComponent,
    ShowDelBillComponent,
    AddEditBillComponent,
    PayComponent,
    ShowDelPayComponent,
    AddEditPayComponent,
    LoginComponent,
    OwnerComponent,
    ManagerComponent,
    ReceptionistsComponent,
    FooterComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
  ],
  providers: [SharedService,
    { provide: HTTP_INTERCEPTORS, useClass: SharedInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
