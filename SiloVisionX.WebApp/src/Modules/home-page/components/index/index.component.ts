import { Component } from '@angular/core';
import { faExclamationTriangle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {

  temperatura: any = 14

  umidade: any = 60

  nivel: any = 222.57

  risco: any = "fatal"

  iconRisco = faExclamationTriangle
}
