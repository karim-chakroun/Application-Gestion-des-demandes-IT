import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifService } from '../shared/notif.service';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetails;
  notif;

  constructor(private router:Router,private service:UserService,private notifService:NotifService) { }

  ngOnInit() {
    //this.router.navigate(['/home/acceuil']);
    this.service.getUserProfile().subscribe(
      res =>{
        this.userDetails = res;
      },
      err =>{
        console.log(err);
      }

    );
    this.notifService.getNotifications().subscribe(
      res =>{
        this.notif = res;
      },
      err =>{
        console.log(err);
      }

    );
  }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

}
