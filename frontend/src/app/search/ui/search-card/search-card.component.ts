import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Router} from '@angular/router';
import {FlightResult} from "../../../shared/model/FlightResult";
import {CurrentFlightService} from "../../../shared/services/current-flight.service";
import {TokenStorageService} from "../../../shared/services/tokenStorage.service";
import {MatDialog} from "@angular/material/dialog";
import {ConfirmDialogData, ModalDialogComponent} from "../../../components/modal-dialog/modal-dialog.component";

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.scss']
})
export class SearchCardComponent {
  @Input() flight!: FlightResult;
  @Input() numberOfTravelers=1;
  userRole: string = ''
  @Output() deletedFlight = new EventEmitter<string>()

  constructor(private flightSave: CurrentFlightService, private router: Router
    , private storageService: TokenStorageService, private dialog: MatDialog) {
    storageService.isAuthenticated.subscribe({
      next: value => {
        if (value) {
          this.userRole = this.storageService.getUser().role
        }
      }
    })
  }

  public filterSeats(classValue: string): number {
    const bs = this.flight.seats.filter(value => value.class.includes(classValue))
    if (bs.length === 0) {
      return 0
    }
    return bs.map(value => value.price)[0]
  }

  navigateToBook() {
    this.flightSave.setCurrentFlight(this.flight)
    this.flightSave.setNumberOfTravelers(this.numberOfTravelers);
    this.router.navigate(['flight/seats']).then()
  }

  deleteFlight() {
    const data: ConfirmDialogData = {
      title: 'Are you sure?',
      message: 'This action cannot be undone and flight will be deleted.',
    };

    const dialogRef = this.dialog.open(ModalDialogComponent, {
      width: '500px',
      data: data,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deletedFlight.emit(this.flight.id)
      }
    });
  }
}
