import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerCall, CustomerCallService } from '../../Customer/customer-call.service';
import { MatDialog } from '@angular/material/dialog';
import { AddCallFormComponent } from '../add-call-form/add-call-form.component';

@Component({
  selector: 'app-customer-calls',
  templateUrl: './customer-calls.component.html',
  styleUrls: ['./customer-calls.component.css']
})
export class CustomerCallsComponent implements OnInit {
  customerCalls: CustomerCall[] = [];
  displayedColumns: string[] = ['description', 'call_Address', 'date', 'employee', 'isDone', 'call_Type'];

  constructor(private route: ActivatedRoute, private customerCallService: CustomerCallService,private dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const customerId = params['customerId'];
      this.customerCallService.getCustomerCalls(customerId).subscribe(calls => {
        this.customerCalls = calls;
      });
    });
  }

  openAddCallForm(): void {
    const customerId = this.route.snapshot.params['customerId']; 
    const dialogRef = this.dialog.open(AddCallFormComponent, {
      width: '400px',
      data: { customerId: customerId } 
    });
  
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  
}
