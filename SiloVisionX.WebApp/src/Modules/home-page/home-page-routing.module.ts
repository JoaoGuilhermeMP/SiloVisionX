import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageModule } from './home-page.module';
import { IndexComponent } from './components/index/index.component';

const routes: Routes = [
  {path: '', component: IndexComponent}
];

@NgModule({
  imports: [HomePageModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomePageRoutingModule { }
