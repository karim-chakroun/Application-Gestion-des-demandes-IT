import { Component, OnInit } from '@angular/core';
import { TicketService } from '../shared/ticket.service';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-my-ticket',
  templateUrl: './my-ticket.component.html',
  styleUrls: ['./my-ticket.component.css']
})
export class MyTicketComponent implements OnInit {

  Usdetails;
  comments;
  requests;

  constructor(private service:TicketService,private Uservice:UserService) { }

  ngOnInit() {

    this.Uservice.getUserProfile().subscribe(
      res =>{
        this.Usdetails = res;
      },
      err =>{
        console.log(err);
      }

    );
    this.service.getTickets().subscribe(
      res =>{
        this.requests = res;
      },
      err =>{
        console.log(err);
      }

    );
    this.service.getComments().subscribe(
      res =>{
        this.comments = res;
      },
      err =>{
        console.log(err);
      }

    );
  }

}
