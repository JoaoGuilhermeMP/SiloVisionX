import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { OverlayPanelModule } from 'primeng/overlaypanel';


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [FontAwesomeModule, OverlayPanelModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  iconUser = faUser

  goToProfile() {

  }
  

}
