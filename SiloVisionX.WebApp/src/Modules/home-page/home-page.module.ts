import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePageRoutingModule } from './home-page-routing.module';
import { IndexComponent } from './components/index/index.component';
import { HeaderComponent } from "../../Core/header/header.component";
import { AsideComponent } from "../../Core/aside/aside.component";
import { FooterComponent } from "../../Core/footer/footer.component";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule } from '@angular/common/http';
import { DashApiService } from '../../api/DashApi/dash-api.service';


@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    HeaderComponent,
    AsideComponent,
    FontAwesomeModule,
    HttpClientModule
  ],
  providers: [
    DashApiService
  ]
})
export class HomePageModule { }
