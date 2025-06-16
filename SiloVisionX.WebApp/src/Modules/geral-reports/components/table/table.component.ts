import { Component } from '@angular/core';

@Component({
  selector: 'table',
  standalone: false,
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {


  data = [
    { day: '2025-06-10', temperature: 25, humidity: 70, level: 80 },
    { day: '2025-06-11', temperature: 28, humidity: 65, level: 75 },
    { day: '2025-06-12', temperature: 22, humidity: 60, level: 90 },
    { day: '2025-06-13', temperature: 30, humidity: 55, level: 85 },
    { day: '2025-06-14', temperature: 27, humidity: 68, level: 78 }
  ];

}
