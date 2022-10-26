import { Component, OnInit, Input } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { OwnerComponent } from '../owner/owner.component';
import { ReceptionistsComponent } from '../receptionists/receptionists.component';
import { ManagerComponent } from '../manager/manager.component';
import { Call, Token } from '@angular/compiler';
import { SharedService } from 'src/app/shared.service';
import { Validators } from '@angular/forms';

const routes: Routes = [
  { path: 'owner', component: OwnerComponent },
  { path: 'manager', component: ManagerComponent },
  { path: 'receptionist', component: ReceptionistsComponent },
];

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private service: SharedService, private router: Router) {}

  alert: boolean = false;

  @Input() login: any;

  Id!: string;
  Password!: string;
  UserType!: string;
  message!: string;

  ngOnInit(): void {
    this.Id = this.login.Id;
    this.Password = this.login.Password;
    this.UserType = this.login.UserType;
  }

  Login() {
    var val = {
      Id: this.Id,
      Password: this.Password,
      UserType: this.UserType,
    };
    this.service.Login(val).subscribe(
      (token: string) => {
        this.router.navigate(['/' + this.UserType + '']);
        localStorage.setItem('authToken', token);
        this.alert = false;
      },
      (error) => {
        console.log(error);
        this.alert = true;
        this.message = error.error;
      }
    );
  }

  
}
