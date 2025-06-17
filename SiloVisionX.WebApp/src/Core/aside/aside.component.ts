import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-aside',
  imports: [RouterModule, CommonModule],
  standalone: true,
  templateUrl: './aside.component.html',
  styleUrl: './aside.component.css'
})
export class AsideComponent {


  userRole: string = '';

  ngOnInit() {
    const userStr = localStorage.getItem('usuarioAutenticado');
    if (userStr) {
      const user = JSON.parse(userStr);
      this.userRole = user.role;
    }
  }

  isAdmin(): boolean {
    return this.userRole === 'ADMIN';
  }

  isSupervisorOrAdmin(): boolean {
    return this.userRole === 'ADMIN' || this.userRole === 'SUPERVISOR';
  }

}
