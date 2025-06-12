import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePageRoutingModule } from './home-page-routing.module';
import { IndexComponent } from './components/index/index.component';


@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
  ]
})
export class HomePageModule { }
