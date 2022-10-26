import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
//import { Route,RouterModule,ActivatedRoute,ParamMap, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor(private http: HttpClient) {}

  //#region Rooms
  getRoomsList() {
    let APIUrl = 'https://localhost:7103/GetRooms';
    return this.http.get(APIUrl);
  }
  AddRoom(val: any) {
    let APIUrl = 'https://localhost:7103/AddRoom';
    return this.http.post(APIUrl, val);
  }
  UpdateRoom(val: any) {
    console.log(val.Room_Status);
    let APIUrl = 'https://localhost:7103/UpdateRoom?Roomid=' + val.Room_Id;
    return this.http.put(APIUrl, val);
  }
  DelteRoom(val: any) {
    let APIUrl = 'https://localhost:7103/DeleteRoom?RoomId=' + val.Room_Id;
    return this.http.delete(APIUrl, val);
  }
  //#endregion

  //#region BookedRooms
  bookedRooms() {
    let APIUrl = 'https://localhost:7103/BookedRooms';
    return this.http.get(APIUrl);
  }
  //#endregion

  //#region UnbookedRooms
  unbookedRooms() {
    let APIUrl = 'https://localhost:7103/UnbookedRooms';
    return this.http.get(APIUrl);
  }
  //#endregion

  //#region Guest
  GetGuests() {
    let APIUrl = 'https://localhost:7103/GetGuests';
    return this.http.get(APIUrl);
  }

  AddGuest(val: any) {
    let APIUrl = 'https://localhost:7103/AddGuest';
    return this.http.post(APIUrl, val);
  }

  UpdateGuest(val: any) {
    let APIUrl = 'https://localhost:7103/UpdateGuest?Guestid=' + val.Guest_Id;
    return this.http.put(APIUrl, val);
  }
  //#endregion

  //#region Employee
  GetEmployee() {
    let APIUrl = 'https://localhost:7103/Departments';
    return this.http.get(APIUrl);
  }

  AddEmployee(val: any) {
    let APIUrl = 'https://localhost:7103/AddEmployee';
    return this.http.post(APIUrl, val);
  }

  DelteEmployee(val: any) {
    let APIUrl =
      'https://localhost:7103/DeleteEmployee?Employeeid=' + val.Employee_Id;
    return this.http.delete(APIUrl, val);
  }

  UpdateEmployee(val: any) {
    let APIUrl =
      'https://localhost:7103/UpdateEmployee?Employeeid=' + val.Employee_Id;
    return this.http.put(APIUrl, val);
  }

  //#endregion

  //#region Receptionist
  GetReceptionist() {
    let APIUrl = 'https://localhost:7103/GetReceptionist';
    return this.http.get(APIUrl);
  }

  AddReceptionist(val: any) {
    let APIUrl = 'https://localhost:7103/AddReceptionist';
    return this.http.post(APIUrl, val);
  }

  DeleteReceptionist(val: any) {
    let APIUrl =
      'https://localhost:7103/DeleteReceptionist?Employeeid=' + val.Employee_Id;
    return this.http.delete(APIUrl, val);
  }

  UpdateReceptionist(val: any) {
    let APIUrl =
      'https://localhost:7103/UpdateReceptionist?Employeeid=' + val.Employee_Id;
    return this.http.put(APIUrl, val);
  }
  //#endregion

  //#region Bill
  GetBill() {
    let APIUrl = 'https://localhost:7103/GetBill';
    return this.http.get(APIUrl);
  }

  AddBill(val: any) {
    let APIUrl =
      'https://localhost:7103/AddBill?CheckGuestId=' +
      val.Guest_Id +
      '&CheckReservationId=' +
      val.Reservation_Id;
    return this.http.post(APIUrl, val);
  }

  DeleteBill(val: any) {
    let APIUrl = 'https://localhost:7103/DeleteBill?Billid=' + val.Bill_Id;
    return this.http.delete(APIUrl, val);
  }

  UpdateBill(val: any) {
    let APIUrl =
      'https://localhost:7103/UpdateBill?Billid=' +
      val.Bill_Id +
      '&CheckGuestId=' +
      val.Guest_Id +
      '&CheckReservationId=' +
      val.Reservation_Id;
    return this.http.put(APIUrl, val);
  }
  //#endregion

  //#region Payments
  getPayList() {
    let APIUrl = 'https://localhost:7103/GetPaymentDetails';
    return this.http.get(APIUrl);
  }
  AddPay(val: any) {
    let APIUrl =
      'https://localhost:7103/AddPaymentDetails?CheckBillId=' + val.Bill_Id;
    return this.http.post(APIUrl, val);
  }
  UpdatePay(val: any) {
    console.log(val.Payment_Id);
    console.log(val.Bill_Id);
    let APIUrl =
      'https://localhost:7103/UpdatePaymentDetails?PaymentId=' +
      val.Payment_Id +
      '&CheckBillId=' +
      val.Bill_Id;
    return this.http.put(APIUrl, val);
  }
  //#endregion

  //#region Reservation
  GetReservation() {
    let APIUrl = 'https://localhost:7103/GetReservations';
    return this.http.get(APIUrl);
  }

  AddReservation(val: any) {
    let APIUrl =
      'https://localhost:7103/AddReservation?CheckRoomId=' +
      val.Room_Id +
      '&CheckGuestId=' +
      val.Guest_Id;
    return this.http.post(APIUrl, val,{ responseType: 'text' });
  }

  CancelReservation(val: any) {
    let APIUrl =
      'https://localhost:7103/CancelReservation?CheckReservationId=' +
      val.Reservation_Id;
    return this.http.post(APIUrl, val);
  }

  UpdateReservation(val: any) {
    let APIUrl =
      'https://localhost:7103/UpdateReservation?Reservationid=' +
      val.Reservation_Id +
      '&CheckRoomId=' +
      val.Room_Id +
      '&CheckGuestId=' +
      val.Guest_Id;
    return this.http.put(APIUrl, val);
  }
  //#endregion

  //#region Login
  Login(val: any) {
    let APIUrl =
      'https://localhost:7103/Login?UserEmail=' +
      val.Id +
      '&Password=' +
      val.Password +
      '&UserType=' +
      val.UserType;
    localStorage.setItem('role', val.UserType);
    localStorage.setItem('user', val.Id);
    return this.http.post(APIUrl, val, { responseType: 'text' });
  }
  //#endregion
}
