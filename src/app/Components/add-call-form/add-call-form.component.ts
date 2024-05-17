import { Component, OnInit, Output, EventEmitter, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CustomerCallService } from '../../Customer/customer-call.service';

@Component({
  selector: 'app-add-call-form',
  templateUrl: './add-call-form.component.html',
  styleUrls: ['./add-call-form.component.css']
})
export class AddCallFormComponent implements OnInit {
  customerId!: number;
  formData: any = {};
  @Output() callAdded: EventEmitter<any> = new EventEmitter();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { customerId: number },
    private dialogRef: MatDialogRef<AddCallFormComponent>,
    private customerCallService: CustomerCallService
  ) { }

  ngOnInit(): void {
    this.customerId = this.data.customerId;
  }

  submitForm() {
    this.formData.customerId = this.customerId;
    this.customerCallService.addCustomerCall(this.formData).subscribe(
      (response) => {
        console.log('Call added successfully:', response);
        this.callAdded.emit(); // Emit event to notify parent component
        this.dialogRef.close(true);
      },
      (error) => {
        console.error('Error adding call:', error);
        // Handle error, such as displaying an error message
      }
    );
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }
}
