import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyUserMgmtRoutingModule } from './my-user-mgmt-routing.module';
import { IndexComponent } from './Components/index/index.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule,
    FormsModule,
    FontAwesomeModule,
    RouterModule
  ]
})
export class MyUserMgmtModule { }
