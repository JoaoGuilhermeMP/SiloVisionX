import { Component } from '@angular/core';
import { GeralInnerService } from '../../service/geral-inner.service';
import { ReportApiService } from '../../../../api/ReportApi/report-api.service';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {


  /**
   *
   */
  constructor(private pageService: GeralInnerService, private api: ReportApiService) {
    
    
  }


  errorData: boolean = false

  date1: any
  date2: any

  hasData: boolean = false;


  search() {
  const formattedDate1 = this.formatDateForCSharp(this.date1);
  const formattedDate2 = this.formatDateForCSharp(this.date2);

  console.log("Searching from " + formattedDate1 + " to " + formattedDate2);

  this.getData(formattedDate1, formattedDate2)

  
}

  private async getData(initialDate: any, finalDate: any) {
    try {

      const result = await this.api.getReportData(initialDate, finalDate)

      if (result.length < 1) {
        this.errorData = true
      }

      this.pageService.$apiData.next({data: result})
      this.hasData = true
    } catch (error) {
      this.errorData = true
    }
  }

formatDateForCSharp(date: Date): string {
  if (!date) return '';

  
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, '0');
  const day = date.getDate().toString().padStart(2, '0');
  const hour = date.getHours().toString().padStart(2, '0');
  const min = date.getMinutes().toString().padStart(2, '0');
  const sec = date.getSeconds().toString().padStart(2, '0');

  return `${year}-${month}-${day}T${hour}:${min}:${sec}`;
}

}
