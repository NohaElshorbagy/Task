import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerCall } from '../Models/customer-call.interface';

@Injectable({
  providedIn: 'root'
})
export class CustomerCallService {
  private baseUrl = 'https://localhost:7078/api/Customer';

  constructor(private http: HttpClient) { }

  getCustomerCalls(customerId: number): Observable<CustomerCall[]> {
    return this.http.get<CustomerCall[]>(`${this.baseUrl}/GetCustomerCalls?id=${customerId}`);
  }

  addCustomerCall(callData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/AddCustomerCall`, callData);
  }
}
export { CustomerCall };

