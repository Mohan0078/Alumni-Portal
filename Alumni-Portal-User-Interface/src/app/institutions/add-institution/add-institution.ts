import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { InstitutionService } from '../../services/institution-service';
import { Institution, InstitutionRequest } from '../../models/Institution';

@Component({
  selector: 'app-institution-add',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-institution.html',
  styleUrls: ['./add-institution.scss'],
})
export class AddInstitution {
  @Input() institution: Institution | null = null;

  @Output() save = new EventEmitter<Institution>();
  @Output() cancel = new EventEmitter<void>();

  institutionForm!: FormGroup;

  isEditMode = false;
  submitted = false;

  statuses = ['Active', 'Inactive', 'Suspended'];

  constructor(
    private fb: FormBuilder,
    private institutionService: InstitutionService,
  ) {}

  ngOnInit(): void {
    this.initializeForm();

    if (this.institution) {
      this.isEditMode = true;
      this.institutionForm.patchValue(this.institution);
    }
  }

  initializeForm(): void {
    this.institutionForm = this.fb.group({
      id: [this.institution?.id || ''],
      name: ['', [Validators.required, Validators.maxLength(150)]],
      code: ['', [Validators.required, Validators.maxLength(30)]],
      email: ['', [Validators.email]],
      phone: ['', [Validators.pattern(/^[0-9+\-\s()]{7,20}$/)]],
      website: ['', [Validators.pattern(/^https?:\/\/.+\..+/i)]],
      address: [''],
      city: [''],
      state: [''],
      country: [''],
      logo: [''],
      establishedYear: [null, [Validators.min(1800), Validators.max(new Date().getFullYear())]],
      status: ['Active', Validators.required],
      createdAt: [this.institution?.createdAt || null],
      updatedAt: [this.institution?.updatedAt || null],
    });
  }

  get f() {
    return this.institutionForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.institutionForm.invalid) {
      this.institutionForm.markAllAsTouched();
      return;
    }

    console.log('save button called::');
    const formValue = this.institutionForm.value;

    const institution: Institution = {
      ...formValue,
      id: formValue.id || crypto.randomUUID(),
      updatedAt: new Date().toISOString(),
      createdAt: formValue.createdAt || new Date().toISOString(),
    };

    this.save.emit(institution);

    this.institutionService.saveInstitution(institution).subscribe({
      next: (res) => {
        console.log('Institution added successfully', res);
        this.submitted = false;
      },
      error: (err) => {
        console.error('Error adding Institution', err);
      },
    });
  }

  onCancel(): void {
    this.cancel.emit();
  }

  onReset(): void {
    this.submitted = false;

    if (this.isEditMode && this.institution) {
      this.institutionForm.reset({
        ...this.institution,
      });
    } else {
      this.institutionForm.reset({
        status: 'Active',
      });
    }
  }
}
