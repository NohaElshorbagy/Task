import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {  CustomerService } from '../../Customer/customer.service';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';
import { MatSidenav } from '@angular/material/sidenav';
import { MatSort } from '@angular/material/sort';
import { CustomerCallService } from '../../Customer/customer-call.service';
import { MatDialog } from '@angular/material/dialog';  // Import MatDialog
import { Customer } from '../../Models/customer.interface';

@Component({
  selector: 'app-customer-table',
  templateUrl: './customer-table.component.html',
  styleUrls: ['./customer-table.component.css']
})
export class CustomerTableComponent implements OnInit {
  dataSource: MatTableDataSource<Customer>;
  displayedColumns: string[] = ['name', 'address', 'district', 'email', 'gender', 'description', 'actions'];
  allColumns: string[] = ['name', 'address', 'district', 'email', 'gender', 'description'];
  selectedColumns: string[] = this.allColumns.slice();
  searchEnabled: boolean = false;
  columnFilters: { [key: string]: string } = {};

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSidenav) sidenav!: MatSidenav;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private customerService: CustomerService,
    private router: Router,
    private customerCallService: CustomerCallService,
    private dialog: MatDialog  // Inject MatDialog
  ) {
    this.dataSource = new MatTableDataSource<Customer>();
  }

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getCustomers().subscribe(customers => {
      this.dataSource.data = customers;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      // Apply initial filter settings
      this.dataSource.filterPredicate = this.createFilter();
    });
  }

  exportToExcel(): void {
    const fileName = 'customers.xlsx';
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(this.dataSource.data);
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    XLSX.writeFile(workbook, fileName);
  }

  print(): void {
    window.print();
  }

  refreshTable(): void {
    this.getCustomers();
  }

  addCustomer(): void {
    this.router.navigate(['/add-customer']);
  }

  updateCustomer(customer: Customer): void {
    this.router.navigate(['/add-customer'], { queryParams: { id: customer.id } });
  }

  deleteCustomer(id: number): void {
    if (confirm('Are you sure you want to delete this customer?')) {
      this.customerService.deleteCustomer(id).subscribe({
        next: response => {
          console.log('Customer deleted successfully:', response);
          this.refreshTable();
        },
        error: err => {
          console.error('Error deleting customer:', err);
        }
      });
    }
  }

  updateSelectedColumns(): void {
    this.displayedColumns = [...this.selectedColumns, 'actions'];
  }

  getColumnName(column: string): string {
    const columnNames: { [key: string]: string } = {
      name: 'Name',
      address: 'Address',
      district: 'District',
      email: 'Email',
      gender: 'Gender',
      description: 'Description'
    };
    return columnNames[column] || column;
  }

  toggleSearch(): void {
    this.searchEnabled = !this.searchEnabled;
    console.log('Search toggled, now:', this.searchEnabled);
  }

  applyFilter(): void {
    this.dataSource.filter = JSON.stringify(this.columnFilters);
  }

  createFilter(): (data: Customer, filter: string) => boolean {
    return (data: Customer, filter: string): boolean => {
      const searchTerms = JSON.parse(filter);
      return Object.keys(searchTerms).every(column => {
        const searchValue = searchTerms[column];
        return searchValue ? (data[column] || '').toLowerCase().includes(searchValue.toLowerCase()) : true;
      });
    };
  }

 showCustomerCalls(customerId: number): void {
  this.router.navigate(['/customer', customerId, 'calls']);
}
}
