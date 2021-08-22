import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TicketService } from '../../shared/ticket.service';
import { UserService } from '../../shared/user.service';

@Component({
  selector: 'app-forbidden',
  templateUrl: './forbidden.component.html',
  styles: []
})
export class ForbiddenComponent implements OnInit {

  constructor(public service: TicketService,private router:Router,private Uservice:UserService) { }

  Usdetails;
  ngOnInit() {
    this.Uservice.getUserProfile().subscribe(
      res =>{
        this.Usdetails = res;
      },
      err =>{
        console.log(err);
      }

    );
  }
  onSubmit(d,e) {
    this.service.PostTicket(d,e).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          //this.toastr.success('New user created!', 'Registration successful.');
        } else {
          err => {
            console.log(err);
          }
        }
      }
      
    );
  }

}
