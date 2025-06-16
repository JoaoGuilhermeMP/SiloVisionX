import { Routes } from '@angular/router';

export const routes: Routes = [
    {path: 'home', loadChildren: () => import('../Modules/home-page/home-page-routing.module').then(m => m.HomePageRoutingModule)},

    {path: 'general-reports', loadChildren: () => import('../Modules/geral-reports/geral-reports-routing.module').then(m => m.GeralReportsRoutingModule)},

    {path: 'user-mgmt', loadChildren: () => import('../Modules/user-mgmt/user-mgmt-routing.module').then(m => m.UserMgmtRoutingModule)},
];
