import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Signin } from "./auth/signin/signin";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Signin],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Alumni-Portal-User-Interface');
}
