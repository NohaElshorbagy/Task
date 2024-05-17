import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerTableComponent } from './Components/customer-table/customer-table.component';
import { AddCustomerComponent } from './Components/add-customer/add-customer.component';
import { CustomerCallsComponent } from './Components/customer-calls/customer-calls.component';

const routes: Routes = [
  { path: '', redirectTo: '/customer-table', pathMatch: 'full' }, // Default route
  { path: 'customer-table', component: CustomerTableComponent },
  { path: 'add-customer', component: AddCustomerComponent },
 { path: 'customer/:customerId/calls', component: CustomerCallsComponent },
  // Add more routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
