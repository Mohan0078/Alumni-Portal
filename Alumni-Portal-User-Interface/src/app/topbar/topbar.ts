import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-topbar',
  imports: [],
  templateUrl: './topbar.html',
  styleUrl: './topbar.scss',
})
export class Topbar {
  constructor(private router : Router){

  }
logout() : void {
localStorage.removeItem('accessToken');
this.router.navigate(['/login']);
}

}
