import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'https://localhost:44319/api';

  getTickets(){
    
    return this.http.get(this.BaseURI+ '/requests');
  }

  getTicketsById(id){
    
    return this.http.get(this.BaseURI+ '/requests/' + id);
  }

  


  formModel = this.fb.group({
    Requestid: [''],
    NameT: [''],
    DateT: [''],
    Status: [''],
    Agent:[''],
    Description:[''],
    customer:[''],
    Priorite:['']
  });
  
  StatusTicket(id,nom,dt,st,c,ds) {
    var body = {
      RequestsId: id,
      NameT: nom,
      DateT: dt,
      Status: st,
      customer: c,
      description: ds

    };
    return this.http.put(this.BaseURI + '/requests/' + id, body);
  }


  

  PostTicket(data,myDate = new Date()) {
    var body = {
      NameT: this.formModel.value.NameT,
      DateT: myDate,
      Status: 'waiting',
      customer: data,
      Description:this.formModel.value.Description,
      Priorite:this.formModel.value.Priorite
    };
    return this.http.post(this.BaseURI + '/requests', body);
  }
}
