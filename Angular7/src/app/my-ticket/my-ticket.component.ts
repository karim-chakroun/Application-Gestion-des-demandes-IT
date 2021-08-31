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
  TicketDetails;

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

  onDelete(d) {
    this.service.deleteTicket(d).subscribe(
      res =>{
        
        location.reload();
        
      },
      err =>{
        console.log(err);
      }

    );
  }
  onComment(d,e) {
    this.service.commentTicket(d,e).subscribe(
      (res: any) => {
        
          this.service.formModel.reset();
          this.service.getComments().subscribe(
            res =>{
              this.comments = res;
            },
            err =>{
              console.log(err);
            }
      
          );
          //this.toastr.success('New user created!', 'Registration successful.');
        },
          err => {
            console.log(err);
          }
        
      
      
    );
  }

}
