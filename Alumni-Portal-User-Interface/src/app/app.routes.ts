import { Routes } from '@angular/router';
import { Signin } from './auth/signin/signin';
import { Dashboard } from './dashboard/dashboard';
import { AppLayout } from './layout/app-layout/app-layout';

export const routes: Routes = [
// Auth routes (no layout)
  {
    path: 'login',
    component: Signin
  },
  // App routes (with sidebar + topbar)
  {
    path: '',
    component: AppLayout,
    children: [
      { path: 'dashboard', component: Dashboard },
    //   { path: 'alumni', component: AlumniComponent },
    //   { path: 'jobs', component: JobsComponent },
    //   { path: 'events', component: EventsComponent },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
    ]
  }
];
