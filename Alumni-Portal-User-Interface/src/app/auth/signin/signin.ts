import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Authentication } from '../../services/authentication';
import { CommonModule } from '@angular/common';
import { AddUser } from "../../add-user/add-user";
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.html',
  styleUrls: ['./signin.scss'],
  imports: [ReactiveFormsModule, CommonModule, AddUser]
})
export class Signin {
  signinForm: FormGroup;
  submitted = false;
  loading = false;
  errorMsg = '';

  constructor(private fb: FormBuilder, private auth: Authentication, private router: Router) {
    this.signinForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  get f() {
    return this.signinForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    this.errorMsg = '';

    if (this.signinForm.invalid) return;

    this.loading = true;

    this.auth.login(this.signinForm.value).subscribe({
      next: (res) => {
        console.log('Login success:', res);

        // Example: store token
        localStorage.setItem('token', res);

        this.loading = false;
        // redirect to dashboard
        this.router.navigate(['/dashboard']).then(r => {
      console.log('NAV RESULT:', r);
    });
      
      },
      error: (err) => {
        console.error('Login error:', err);
        this.errorMsg = err.error?.message || 'Login failed';
        this.loading = false;
      }
    });
  }

  isRegisterMode = false;

toggleMode() {
  this.isRegisterMode = !this.isRegisterMode;
}
}