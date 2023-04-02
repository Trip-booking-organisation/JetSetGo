import { Component, OnInit } from '@angular/core';
import { UsersTicketResult } from 'src/app/shared/model/UsersTicketResult';
import { TicketsService } from 'src/app/shared/services/ticketService';
import { TokenStorageService } from 'src/app/shared/services/tokenStorage.service';
import * as Aos from "aos";



@Component({
  selector: 'app-users-tickets',
  templateUrl: './users-tickets.component.html',
  styleUrls: ['./users-tickets.component.scss']
})
export class UsersTicketsComponent implements OnInit {
  userId =  "1"
  duration = 1000
  public usersTickets: UsersTicketResult[] = [];
  constructor(private tokenStorageService: TokenStorageService, private ticketService: TicketsService){
    Aos.init({duration: 2000})
  }
  ngOnInit(): void {
   this.userId = this.tokenStorageService.getUser().id
   this.ticketService.getAllTicketsByPassenger(this.userId).subscribe(res => {
    this.usersTickets = res;
    console.log(this.usersTickets)
  })

   //console.log(this.tokenStorageService.getUser().id)

  }

  convertDateTimetoTime(bookingTime:Date){
    var myTime = new Date (0,0,0,bookingTime.getHours(),bookingTime.getMinutes(), bookingTime.getSeconds())
    console.log(myTime)

    return myTime

  }

  getAnimationDuration() {
    this.duration = this.duration + 200
    return this.duration
  }
}
