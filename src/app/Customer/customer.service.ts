// src/app/services/customer.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../Models/customer.interface';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:7078/api/Customer';

  constructor(private http: HttpClient) {}

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.apiUrl}/GetAllCustomer`);
  }

  getCustomerById(id: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.apiUrl}/${id}`);
  }

  addCustomer(newCustomer: Partial<Customer>): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/AddCustomer`, newCustomer);
  }

  updateCustomer(id: number, updatedCustomer: Partial<Customer>): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, updatedCustomer);
  }

  deleteCustomer(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
