import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageModule } from './home-page.module';

const routes: Routes = [];

@NgModule({
  imports: [HomePageModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomePageRoutingModule { }
