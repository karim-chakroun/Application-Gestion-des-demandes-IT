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
  myTicket;
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
        
          this.myTicket = res;
          this.service.formModel.reset();
          //this.toastr.success('New user created!', 'Registration successful.');
      },
          err => {
            console.log(err);
          }
        
      
      
    );
  }

}
