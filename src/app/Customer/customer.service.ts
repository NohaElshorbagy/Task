import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Customer {
  id: number;
  name: string;
  address: string;
  district: string;
  mobile: number;
  phoneNumber1: number;
  phoneNumber2: number;
  whatsapp_Number: number;
  email: string;
  gender: string;
  residence: string;
  description: string;
  jop: string;
  salesman: string;
  client_source: string;
  customer_rating: string;
  [key: string]: any;
}

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
