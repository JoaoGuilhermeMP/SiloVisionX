import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeralReportsModule } from './geral-reports.module';
import { IndexComponent } from './components/index/index.component';

const routes: Routes = [
  {path: '', component: IndexComponent} 
];

@NgModule({
  imports: [GeralReportsModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeralReportsRoutingModule { }
