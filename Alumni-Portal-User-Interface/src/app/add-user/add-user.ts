import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { User } from '../services/user';

@Component({
  selector: 'app-add-user',
  imports: [ReactiveFormsModule],
  templateUrl: './add-user.html',
  styleUrl: './add-user.scss',
})
export class AddUser {

  userForm: FormGroup;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private userService: User
  ) {
    this.userForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      gender: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      mobileNumber: ['', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]]
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.userForm.invalid) {
      return;
    }

    this.userService.addUser(this.userForm.value).subscribe({
      next: (res) => {
        console.log('User added successfully', res);
        this.userForm.reset();
        this.submitted = false;
      },
      error: (err) => {
        console.error('Error adding user', err);
      }
    });
  }
}