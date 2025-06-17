import { Component, OnDestroy, OnInit } from '@angular/core';
import { GeralInnerService } from '../../service/geral-inner.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'table',
  standalone: false,
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnInit, OnDestroy{
  
  /**
   *
   */
  constructor(private pageService: GeralInnerService) {
    
    
  }

  // data = [
  //   { day: '2025-06-10', temperature: 25, humidity: 70, level: 80 },
  //   { day: '2025-06-11', temperature: 28, humidity: 65, level: 75 },
  //   { day: '2025-06-12', temperature: 22, humidity: 60, level: 90 },
  //   { day: '2025-06-13', temperature: 30, humidity: 55, level: 85 },
  //   { day: '2025-06-14', temperature: 27, humidity: 68, level: 78 }
  // ];

  data: any

  private lifeCycle = new Subject<void>()

  ngOnInit(): void {
    this.registerTableData()
  }
  ngOnDestroy(): void {
    this.lifeCycle.next()
  }

  exportToCSV() {
  const headers = ['Dia', 'Temperatura (Em °C)', 'Umidade (Em %)', 'Nível', 'Status'];
  const rows = this.data.map((row: any) => [
    new Date(row?.data).toLocaleString('pt-BR'),
    row?.temperaturaValue,
    row?.umidadeValue,
    row?.nivelValue,
    row?.status
  ]);

  let csvContent = '';
  csvContent += headers.join(',') + '\n';
  rows.forEach((rowArray: any) => {
    const row = rowArray.map((field: any) => `"${field}"`).join(',');
    csvContent += row + '\n';
  });

  const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
  const url = URL.createObjectURL(blob);

  const a = document.createElement('a');
  a.href = url;
  a.download = 'relatorio.csv';
  a.click();
  URL.revokeObjectURL(url);
}

  private registerTableData() {
    this.pageService.$apiData
    .pipe(takeUntil(this.lifeCycle))
    .subscribe({
      next: (state) => {
        this.data = state.data
      }
    })
  }


}
