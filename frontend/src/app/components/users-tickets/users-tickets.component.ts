import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/app/shared/services/tokenStorage.service';

@Component({
  selector: 'app-users-tickets',
  templateUrl: './users-tickets.component.html',
  styleUrls: ['./users-tickets.component.scss']
})
export class UsersTicketsComponent implements OnInit {
  userId =  "1"
  constructor(private tokenStorageService: TokenStorageService){}
  ngOnInit(): void {
   this.userId = this.tokenStorageService.getUser().id
   //console.log(this.tokenStorageService.getUser().id)
    
  }

}
