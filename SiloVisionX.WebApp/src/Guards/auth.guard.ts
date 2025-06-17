import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const userStr = localStorage.getItem('usuarioAutenticado');
    if (!userStr) {
      this.router.navigate(['/login']);
      return false;
    }

    const user = JSON.parse(userStr);

    const rolesPermitidos = route.data['role'] as Array<string>;

    if (!rolesPermitidos || rolesPermitidos.length === 0) {
      
      return true;
    }

    if (rolesPermitidos.includes(user.role)) {
      return true;
    } else {
      this.router.navigate(['/home']); 
      return false;
    }
  }
}
