import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserMgmtRoutingModule } from './user-mgmt-routing.module';
import { IndexComponent } from './components/index/index.component';
import { DeleteModalComponent } from './components/delete-modal/delete-modal.component';
import { CreateEditModalComponent } from './components/create-edit-modal/create-edit-modal.component';
import { TableModule } from 'primeng/table';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserApiService } from '../../api/UserApi/user-api.service';
import { RolesApiService } from '../../api/RolesApi/roles-api.service';


@NgModule({
  declarations: [IndexComponent, DeleteModalComponent, CreateEditModalComponent],
  imports: [
    CommonModule,
    TableModule,
    FontAwesomeModule,
    DialogModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    UserApiService,
    RolesApiService
  ]
})
export class UserMgmtModule { }
