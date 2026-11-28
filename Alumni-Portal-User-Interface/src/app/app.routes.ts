import { Routes } from '@angular/router';
import { Signin } from './auth/signin/signin';
import { Dashboard } from './dashboard/dashboard';
import { AppLayout } from './layout/app-layout/app-layout';
import { authGuard } from './guards/auth-guard';
import { InstitutionsList } from './institutions/institutions-list/institutions-list';
import { AddInstitution } from './institutions/add-institution/add-institution';

export const routes: Routes = [
  // Auth routes (no layout)
  {
    path: 'login',
    component: Signin,
  },
  // App routes (with sidebar + topbar)
  {
    path: '',
    component: AppLayout,
    canActivate: [authGuard],
    children: [
      { path: 'dashboard', component: Dashboard },
      { path: 'institutions', component: InstitutionsList },
      { path: 'add-institution', component: AddInstitution },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    ],
  },
   // Wildcard route
  {
    path: '**',
    redirectTo: 'dashboard'
  }
];
