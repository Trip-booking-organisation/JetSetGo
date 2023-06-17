import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {FormControl} from "@angular/forms";
import {CreateTicketsRequest} from "../../model/CreateTicketsRequest";
import {TicketsService} from "../../../../shared/services/ticketService";
import {CurrentTicketsService} from "../../../../shared/services/current-tickets.service";
import {Router, RouterEvent} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-provide-api-key',
  templateUrl: './provide-api-key.component.html',
  styleUrls: ['./provide-api-key.component.scss']
})
export class ProvideApiKeyComponent implements OnInit{
  apiKey  = new FormControl();
  tickets : CreateTicketsRequest
  constructor(public dialogRef: MatDialogRef<ProvideApiKeyComponent>,
              private ticketService: TicketsService,
              private ticketsSave: CurrentTicketsService,
              private router :Router,
              private toasterService : ToastrService,
              @Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(this.data.tickets)
    this.tickets = this.data.tickets
  }
  ngOnInit(): void {
  }

  OnBuy() {
    console.log(this.apiKey.value)

    if(this.apiKey.value !== null && this.apiKey.value !== undefined)
      this.tickets.apiKey = this.apiKey.value
    console.log(this.tickets)
    this.ticketService.createTickets(this.tickets).subscribe({
      next: _ =>{
        this.ticketsSave.setCurrentTickets(this.tickets);
        this.router.navigate(['your-tickets']).then()
        this.dialogRef.close()
      },
      error: err => {
        this.toasterService.error(err.errors, "Error")
        this.dialogRef.close()
      }
    })
  }
}
