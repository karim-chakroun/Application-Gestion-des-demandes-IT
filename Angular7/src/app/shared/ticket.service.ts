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

  deleteTicket(id){
    
    return this.http.delete(this.BaseURI+ '/requests/' + id);
  }

  getComments(){
    
    return this.http.get(this.BaseURI+ '/comments');
  }

  

  


  formModel = this.fb.group({
    Requestid: [''],
    NameT: [''],
    DateT: [''],
    Status: [''],
    Agent:[''],
    Description:[''],
    customer:[''],
    Priorite:[''],
    content:['']
  });
  
  StatusTicket(id,nom,dt,st,c,ds,De,p) {
    var body = {
      RequestsId: id,
      NameT: nom,
      DateT: dt,
      Status: st,
      uEmail: De,
      Priorite:p,
      customer: c,
      description: ds

    };
    return this.http.put(this.BaseURI + '/requests/' + id, body);
  }


  

  PostTicket(data,De,myDate = new Date()) {
    var body = {
      NameT: this.formModel.value.NameT,
      DateT: myDate,
      Status: 'waiting',
      customer: data,
      Description:this.formModel.value.Description,
      Priorite:this.formModel.value.Priorite,
      uEmail: De
    };
    return this.http.post(this.BaseURI + '/requests', body);
  }

  EmailNotif(toId,toName,sub,eBody){
    var body = {
    EmailToId:toId,
    EmailToName:toName,
    EmailSubject:sub,
    EmailBody:eBody
    };
    return this.http.post(this.BaseURI + '/Email', body);
  }

  commentModel = this.fb.group({
    content: ['']
  });

  commentTicket(nom,rqId) {
    var body = {
      content:this.formModel.value.content,
      userName:nom,
      requestsId:rqId
    };
    return this.http.post(this.BaseURI + '/comments', body);
  }
}
