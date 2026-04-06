import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Authentication } from '../../services/authentication';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.html',
  styleUrls: ['./signin.scss'],
  imports: [ReactiveFormsModule, CommonModule]
})
export class Signin {
  signinForm: FormGroup;
  submitted = false;
  loading = false;
  errorMsg = '';

  constructor(private fb: FormBuilder, private auth: Authentication) {
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

        // TODO: redirect to dashboard
      },
      error: (err) => {
        console.error('Login error:', err);
        this.errorMsg = err.error?.message || 'Login failed';
        this.loading = false;
      }
    });
  }
}