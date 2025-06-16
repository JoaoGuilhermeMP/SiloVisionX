import { Component } from '@angular/core';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {


  date1: any
  date2: any

  hasData: boolean = false;


  search() {
  const formattedDate1 = this.formatDateForCSharp(this.date1);
  const formattedDate2 = this.formatDateForCSharp(this.date2);

  console.log("Searching from " + formattedDate1 + " to " + formattedDate2);

  this.hasData = true
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
