import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyUserMgmtModule } from './my-user-mgmt.module';
import { IndexComponent } from './Components/index/index.component';

const routes: Routes = [

  {path: '', component: IndexComponent}

];

@NgModule({
  imports: [MyUserMgmtModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyUserMgmtRoutingModule { }
