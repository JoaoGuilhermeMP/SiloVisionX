import { Routes } from '@angular/router';

export const routes: Routes = [

    {path: '', redirectTo: 'login', pathMatch: 'full'},

    {path: 'home', loadChildren: () => import('../Modules/home-page/home-page-routing.module').then(m => m.HomePageRoutingModule)},

    {path: 'general-reports', loadChildren: () => import('../Modules/geral-reports/geral-reports-routing.module').then(m => m.GeralReportsRoutingModule)},

    {path: 'user-mgmt', loadChildren: () => import('../Modules/user-mgmt/user-mgmt-routing.module').then(m => m.UserMgmtRoutingModule)},

    {path: 'role-mgmt', loadChildren: () => import('../Modules/roles-mgmt/roles-mgmt-routing.module').then(m => m.RolesMgmtRoutingModule)},

    {path: 'my-profile', loadChildren: () => import('../Modules/my-user-mgmt/my-user-mgmt-routing.module').then(m => m.MyUserMgmtRoutingModule)},

    {path: 'login', loadChildren: () => import('../Modules/login-page/login-page-routing.module').then(m => m.LoginPageRoutingModule)},
    

];
