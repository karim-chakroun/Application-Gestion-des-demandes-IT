import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotifService {

  constructor(private http: HttpClient) { }

  readonly BaseURI = 'https://localhost:44319/api';

  getNotifications(){
    
    return this.http.get(this.BaseURI+ '/notifications');
  }

  PostNotif(data,user) {
    
    var body = {
      titre: data,
      username: user

    };
    return this.http.post(this.BaseURI + '/notifications', body);
  }
}
