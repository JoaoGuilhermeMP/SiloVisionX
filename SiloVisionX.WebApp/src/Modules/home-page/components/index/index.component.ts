import { Component, OnInit } from '@angular/core';
import { faExclamationTriangle } from '@fortawesome/free-solid-svg-icons';
import { DashApiService } from '../../../../api/DashApi/dash-api.service';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent implements OnInit{

  /**
   *
   */
  constructor(private api: DashApiService) {
    
    
  }

  temperatura: any 

  umidade: any 

  nivel: any 

  risco: any 

  lastAlert: any

  lastFatalAlert: any

  iconRisco = faExclamationTriangle

  ngOnInit(): void {
    this.getData()
  }

  private async getData() {
    const result: any = await this.api.getDashBoardData()

    this.temperatura = result[0].temperaturaValue

    this.umidade = result[0].umidadeValue

    this.nivel = result[0].nivelValue

    this.risco = result[0].status

    this.lastAlert = result[0].data

    this.lastFatalAlert = result[0].lastFatalStatus



  }

  formatDateOrDefault(date?: Date | null): string {
  if (!date) {
    return '01/01/0001 01:01';
  }

  const d = new Date(date);

  const day = String(d.getDate()).padStart(2, '0');
  const month = String(d.getMonth() + 1).padStart(2, '0'); 
  const year = d.getFullYear();

  const hours = String(d.getHours()).padStart(2, '0');
  const minutes = String(d.getMinutes()).padStart(2, '0');

  return `${day}/${month}/${year} ${hours}:${minutes}`;
}

}
