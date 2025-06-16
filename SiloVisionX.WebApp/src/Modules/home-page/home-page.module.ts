import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePageRoutingModule } from './home-page-routing.module';
import { IndexComponent } from './components/index/index.component';
import { HeaderComponent } from "../../Core/header/header.component";
import { AsideComponent } from "../../Core/aside/aside.component";
import { FooterComponent } from "../../Core/footer/footer.component";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    HeaderComponent,
    AsideComponent,
    FontAwesomeModule
]
})
export class HomePageModule { }
