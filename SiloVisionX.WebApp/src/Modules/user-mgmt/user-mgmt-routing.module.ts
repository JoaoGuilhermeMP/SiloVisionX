import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserMgmtModule } from './user-mgmt.module';
import { IndexComponent } from './components/index/index.component';

const routes: Routes = [
  {path: '', component: IndexComponent },
];

@NgModule({
  imports: [UserMgmtModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserMgmtRoutingModule { }
