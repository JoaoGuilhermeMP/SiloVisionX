import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IndexComponent } from './components/index/index.component';
import { FormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { ChartComponent } from './components/chart/chart.component';
import { TableComponent } from './components/table/table.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [IndexComponent, ChartComponent, TableComponent],
  imports: [
    CommonModule,
    FormsModule,
    CalendarModule,
    TableModule
  ]
})
export class GeralReportsModule { }
