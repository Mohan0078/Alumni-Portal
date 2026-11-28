import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Institution } from '../../models/Institution';

@Component({
  selector: 'app-institution-list',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './institutions-list.html',
  styleUrls: ['./institutions-list.scss']
})
export class InstitutionsList implements OnInit {

  // private institutionService = inject(InstitutionService);
  private router = inject(Router);

  institutions: Institution[] = [];

  filteredInstitutions: Institution[] = [];

  searchText = '';
  selectedStatus = '';

  loading = false;
  errorMessage = '';

  totalInstitutions = 0;
  activeInstitutions = 0;
  inactiveInstitutions = 0;
  suspendedInstitutions = 0;

  ngOnInit(): void {
    this.loadInstitutions();
  }

  loadInstitutions(): void {
    this.loading = true;
    this.errorMessage = '';

    // this.institutionService.getAll().subscribe({
    //   next: (response) => {
    //     this.institutions = response || [];

        this.calculateStatistics();
        this.applyFilters();

        this.loading = false;
    //   },
    //   error: () => {
    //     this.errorMessage = 'Unable to load institutions. Please try again.';
    //     this.loading = false;
    //   }
    // });
  }

  calculateStatistics(): void {
    this.totalInstitutions = this.institutions.length;

    this.activeInstitutions =
      this.institutions.filter(x => x.status === 'Active').length;

    this.inactiveInstitutions =
      this.institutions.filter(x => x.status === 'Inactive').length;

    this.suspendedInstitutions =
      this.institutions.filter(x => x.status === 'Suspended').length;
  }

  applyFilters(): void {
    const search = this.searchText.trim().toLowerCase();

    this.filteredInstitutions = this.institutions.filter(item => {

      const matchesSearch =
        !search ||
        item.name?.toLowerCase().includes(search) ||
        item.code?.toLowerCase().includes(search) ||
        item.email?.toLowerCase().includes(search) ||
        item.city?.toLowerCase().includes(search);

      const matchesStatus =
        !this.selectedStatus ||
        item.status === this.selectedStatus;

      return matchesSearch && matchesStatus;
    });
  }

  addInstitution(): void {
    this.router.navigate(['/super-admin/institutions/create']);
  }

  editInstitution(id: string): void {
    this.router.navigate(['/super-admin/institutions/edit', id]);
  }

  viewInstitution(id: string): void {
    this.router.navigate(['/super-admin/institutions/view', id]);
  }

  refresh(): void {
    this.loadInstitutions();
  }

  clearFilters(): void {
    this.searchText = '';
    this.selectedStatus = '';
    this.applyFilters();
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'Active':
        return 'status-active';

      case 'Inactive':
        return 'status-inactive';

      case 'Suspended':
        return 'status-suspended';

      default:
        return '';
    }
  }

  getInitial(name: string): string {
    return name?.charAt(0)?.toUpperCase() || 'I';
  }
}

