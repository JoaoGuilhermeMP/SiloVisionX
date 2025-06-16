import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginPageRoutingModule } from './login-page-routing.module';
import { InputTextModule } from 'primeng/inputtext';
import { IndexComponent } from './Components/index/index.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    InputTextModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class LoginPageModule { }
