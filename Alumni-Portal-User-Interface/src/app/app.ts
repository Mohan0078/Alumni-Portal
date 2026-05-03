import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Signin } from "./auth/signin/signin";
import { Sidebar } from "./sidebar/sidebar";
import { Topbar } from "./topbar/topbar";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Alumni-Portal-User-Interface');
}
