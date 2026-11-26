
export interface Institution {
  id: string;
  name: string;
  code: string;
  email?: string;
  phone?: string;
  website?: string;
  address?: string;
  city?: string;
  state?: string;
  country?: string;
  logo?: string;
  establishedYear?: number;
  status: 'Active' | 'Inactive' | 'Suspended';
  createdAt?: string;
  updatedAt?: string;
}

export interface InstitutionRequest {
  name: string;
  code: string;
  email?: string;
  phone?: string;
  website?: string;
  address?: string;
  city?: string;
  state?: string;
  country?: string;
  logo?: string;
  establishedYear?: number | null;
  status: 'Active' | 'Inactive' | 'Suspended';
}
