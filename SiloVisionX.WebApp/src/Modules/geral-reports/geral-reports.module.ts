import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IndexComponent } from './components/index/index.component';
import { FormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { ChartComponent } from './components/chart/chart.component';
import { TableComponent } from './components/table/table.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { ReportApiService } from '../../api/ReportApi/report-api.service';


@NgModule({
  declarations: [IndexComponent, ChartComponent, TableComponent],
  imports: [
    CommonModule,
    FormsModule,
    CalendarModule,
    TableModule,
    HttpClientModule
  ],
  providers: [
    ReportApiService
  ]
})
export class GeralReportsModule { }
