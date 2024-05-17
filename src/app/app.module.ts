import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';

import { AppComponent } from './app.component';
import { CustomerTableComponent } from './Components/customer-table/customer-table.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCustomerComponent } from './Components/add-customer/add-customer.component';
import { AppRoutingModule } from './routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CustomerCallsComponent } from './Components/customer-calls/customer-calls.component';
import { AddCallFormComponent } from './Components/add-call-form/add-call-form.component';


@NgModule({
  declarations: [
    AppComponent,
    CustomerTableComponent,
    AddCustomerComponent,
    CustomerCallsComponent,
    AddCallFormComponent

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    MatTooltipModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule,
    MatSidenavModule,
    MatCheckboxModule,
    MatToolbarModule ,
    FormsModule,
    MatListModule,

  ],
  providers: [
    provideAnimationsAsync()
  ],
 
  bootstrap: [AppComponent]
})
export class AppModule { }

