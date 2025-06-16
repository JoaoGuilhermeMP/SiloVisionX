import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RolesMgmtModule } from './roles-mgmt.module';
import { IndexComponent } from './components/index/index.component';

const routes: Routes = [

  {path: '', component: IndexComponent}

];

@NgModule({
  imports: [RolesMgmtModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RolesMgmtRoutingModule { }
