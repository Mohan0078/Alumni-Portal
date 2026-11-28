import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Institution } from '../models/Institution';

@Injectable({
  providedIn: 'root'
})
export class InstitutionService {
 private baseUrl = 'https://localhost:7060/api/Institution';

  constructor(private http: HttpClient) {}

  //  for adding institution
  saveInstitution(instution: Institution): Observable<any> {
    return this.http.post(`${this.baseUrl}/save-institution`, instution);
  }
}