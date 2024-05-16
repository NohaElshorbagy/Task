import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService, Customer } from '../../Customer/customer.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
  customerForm: FormGroup;
  customerId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.customerForm = this.fb.group({
      name: [''],
      address: [''],
      district: [''],
      mobile: [null, Validators.required],
      phoneNumber1: [null],
      phoneNumber2: [null],
      whatsapp_Number: [null],
      email: ['', [Validators.email, Validators.required]],
      gender: [''],
      residence: [''],
      description: [''],
      jop: [''],
      salesman: [''],
      client_source: [''],
      customer_rating: ['']
    });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['id']) {
        this.customerId = +params['id'];
        this.loadCustomer(this.customerId);
      }
    });
  }

  loadCustomer(id: number): void {
    this.customerService.getCustomerById(id).subscribe(
      customer => {
        if (customer) {
          console.log('Customer data loaded:', customer); // Debugging step
          this.customerForm.patchValue({
            name: customer.name || '',
            address: customer.address || '',
            district: customer.district || '',
            mobile: customer.mobile || null,
            phoneNumber1: customer.phoneNumber1 || null,
            phoneNumber2: customer.phoneNumber2 || null,
            whatsapp_Number: customer.whatsapp_Number || null,
            email: customer.email || '',
            gender: customer.gender || '',
            residence: customer.residence || '',
            description: customer.description || '',
            jop: customer.jop || '',
            salesman: customer.salesman || '',
            client_source: customer.client_source || '',
            customer_rating: customer.customer_rating || ''
          });
        }
      },
      error => {
        console.error('Error loading customer:', error); // Debugging step
      }
    );
  }

  onSubmit(): void {
    if (this.customerForm.valid) {
      if (this.customerId) {
        this.customerService.updateCustomer(this.customerId, this.customerForm.value).subscribe({
          next: response => {
            console.log('Customer updated successfully:', response);
            this.router.navigate(['/customer-table']);
          },
          error: err => {
            console.error('Error updating customer:', err);
          }
        });
      } else {
        this.customerService.addCustomer(this.customerForm.value).subscribe({
          next: response => {
            console.log('Customer added successfully:', response);
            this.customerForm.reset();
            this.router.navigate(['/customer-table']);
          },
          error: err => {
            console.error('Error adding customer:', err);
          }
        });
      }
    } else {
      console.error('Form is invalid');
    }
  }

  onCancel(): void {
    this.router.navigate(['/customer-table']);
  }
}
