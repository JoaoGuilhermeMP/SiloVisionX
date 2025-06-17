import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginPageRoutingModule } from './login-page-routing.module';
import { InputTextModule } from 'primeng/inputtext';
import { IndexComponent } from './Components/index/index.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthApiService } from '../../api/AuthApi/auth-api.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    InputTextModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [
    AuthApiService
  ]
})
export class LoginPageModule { }
