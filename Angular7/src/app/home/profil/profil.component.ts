import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styles: []
})
export class ProfilComponent implements OnInit {

  userDetails;

  constructor(private router:Router,private service:UserService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res =>{
        this.userDetails = res;
      },
      err =>{
        console.log(err);
      }

    );
  }

}
