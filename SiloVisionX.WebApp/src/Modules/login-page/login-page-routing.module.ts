import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageModule } from './login-page.module';
import { IndexComponent } from './Components/index/index.component';

const routes: Routes = [

  {path: '', component: IndexComponent}

];

@NgModule({
  imports: [LoginPageModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginPageRoutingModule { }
