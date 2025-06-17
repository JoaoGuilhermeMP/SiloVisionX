import { Routes } from '@angular/router';
import { AuthGuard } from '../Guards/auth.guard';

export const routes: Routes = [

    { path: '', redirectTo: 'login', pathMatch: 'full' },

    
    { 
      path: 'home', 
      loadChildren: () => import('../Modules/home-page/home-page-routing.module').then(m => m.HomePageRoutingModule), 
      canActivate: [AuthGuard], 
      data: { roles: [] }  
    },

   
    { 
      path: 'general-reports', 
      loadChildren: () => import('../Modules/geral-reports/geral-reports-routing.module').then(m => m.GeralReportsRoutingModule), 
      canActivate: [AuthGuard], 
      data: { roles: ['SUPERVISOR', 'ADMIN'] } 
    },

    
    { 
      path: 'user-mgmt', 
      loadChildren: () => import('../Modules/user-mgmt/user-mgmt-routing.module').then(m => m.UserMgmtRoutingModule), 
      canActivate: [AuthGuard], 
      data: { roles: ['ADMIN'] } 
    },

    
    { 
      path: 'role-mgmt', 
      loadChildren: () => import('../Modules/roles-mgmt/roles-mgmt-routing.module').then(m => m.RolesMgmtRoutingModule), 
      canActivate: [AuthGuard], 
      data: { roles: ['ADMIN'] } 
    },

    
    { 
      path: 'my-profile', 
      loadChildren: () => import('../Modules/my-user-mgmt/my-user-mgmt-routing.module').then(m => m.MyUserMgmtRoutingModule), 
      canActivate: [AuthGuard], 
      data: { roles: [] } 
    },

    
    { 
      path: 'login', 
      loadChildren: () => import('../Modules/login-page/login-page-routing.module').then(m => m.LoginPageRoutingModule) 
    },

];
