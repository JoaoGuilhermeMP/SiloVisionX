import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RolesMgmtRoutingModule } from './roles-mgmt-routing.module';
import { IndexComponent } from './components/index/index.component';
import { CreateOrEditRolesComponent } from './components/create-or-edit-roles/create-or-edit-roles.component';
import { DeleteRoleComponent } from './components/delete-role/delete-role.component';
import { TableModule } from 'primeng/table';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DialogModule } from 'primeng/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RolesApiService } from '../../api/RolesApi/roles-api.service';


@NgModule({
  declarations: [IndexComponent, CreateOrEditRolesComponent, DeleteRoleComponent],
  imports: [
    CommonModule,
    TableModule,
    FontAwesomeModule,
    DialogModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    RolesApiService
  ]
})
export class RolesMgmtModule { }
