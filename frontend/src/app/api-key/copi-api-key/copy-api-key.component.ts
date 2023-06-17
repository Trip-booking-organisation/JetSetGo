import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {ConfirmDialogData} from "../../components/modal-dialog/modal-dialog.component";

@Component({
  selector: 'app-copi-api-key',
  templateUrl: './copy-api-key.component.html',
  styleUrls: ['./copy-api-key.component.scss']
})
export class CopyApiKeyComponent implements OnInit{
  apikey = new FormControl('');
constructor(public dialogRef: MatDialogRef<CopyApiKeyComponent>,
            @Inject(MAT_DIALOG_DATA) public data: any) {
  this.apikey.patchValue(this.data.apiKey)
}
  ngOnInit(): void {
  }
}
