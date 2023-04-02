import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

export interface ConfirmDialogData {
  title: string;
  message: string;
}

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html',
  styleUrls: ['./modal-dialog.component.scss']
})
export class ModalDialogComponent {

  constructor(public dialogRef: MatDialogRef<ModalDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: ConfirmDialogData) {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
