import { Component, EventEmitter, Output } from '@angular/core';
import { MatListModule } from '@angular/material/list'; // Import MatListModule here

@Component({
  selector: 'app-filter-menu',
  templateUrl: './filter-menu.component.html',
  styleUrls: ['./filter-menu.component.css']
})
export class FilterMenuComponent {
  columns = [
    { name: 'name', display: 'Name' },
    { name: 'address', display: 'Address' },
    { name: 'district', display: 'District' },
    { name: 'email', display: 'Email' },
    { name: 'gender', display: 'Gender' },
    { name: 'description', display: 'Description' }
  ];
  selectedColumns = this.columns.map(c => c.name);

  @Output() columnsChange = new EventEmitter<string[]>();

  updateSelectedColumns() {
    this.columnsChange.emit(this.selectedColumns);
  }
}
