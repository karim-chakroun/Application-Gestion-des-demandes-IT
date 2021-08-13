import { Component, OnInit } from '@angular/core';
import { TicketService } from '../../shared/ticket.service';
import { UserService } from '../../shared/user.service';

@Component({
  selector: 'app-agent-panel',
  templateUrl: './agent-panel.component.html',
  styleUrls: ['./agent-panel.component.css']
})
export class AgentPanelComponent implements OnInit {

  requests;
  TicketDetails;


  constructor(private service:TicketService) { }

  ngOnInit() {
    this.service.getTickets().subscribe(
      res =>{
        this.requests = res;
      },
      err =>{
        console.log(err);
      }

    );
  }

  onSubmit(d) {
    this.service.getTicketsById(d).subscribe(
      res =>{
        this.TicketDetails = res;
      },
      err =>{
        console.log(err);
      }

    );
  }

  Accepter(i,n,d,a,s) {
    this.service.StatusTicket(i,n,d,'Accepté',a,s).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.onSubmit(i);
          //this.toastr.success('New user created!', 'Registration successful.');
        } else {
          err => {
            console.log(err);
          }
        }
      }
      
    );
  }

  toDo(i,n,d,a,s) {
    this.service.StatusTicket(i,n,d,'In queue',a,s).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.onSubmit(i);
          //this.toastr.success('New user created!', 'Registration successful.');
        } else {
          err => {
            console.log(err);
          }
        }
      }
      
    );
  }

  inProg(i,n,d,a,s) {
    this.service.StatusTicket(i,n,d,'In progress',a,s).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.onSubmit(i);
          //this.toastr.success('New user created!', 'Registration successful.');
        } else {
          err => {
            console.log(err);
          }
        }
      }
      
    );
  }

  tDone(i,n,d,a,s) {
    this.service.StatusTicket(i,n,d,'Done',a,s).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.onSubmit(i);
          //this.toastr.success('New user created!', 'Registration successful.');
        } else {
          err => {
            console.log(err);
          }
        }
      }
      
    );
  }

  Refuser(i,n,d,a,s) {
    this.service.StatusTicket(i,n,d,'Refusé',a,s).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.onSubmit(i);
          //this.toastr.success('New user created!', 'Registration successful.');
        } else {
          err => {
            console.log(err);
          }
        }
      }
      
    );
  }

  Search(){}

}
