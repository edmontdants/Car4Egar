import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListCarDialogComponent } from './list-car-dialog/list-car-dialog.component';

@Component({
  selector: 'list-car',
  templateUrl: './list-car.component.html',
  styleUrls: ['./list-car.component.css']
})
export class ListCarComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  openDialog() {
    this.dialog.open(ListCarDialogComponent)
  }
  ngOnInit() {
  }

}
