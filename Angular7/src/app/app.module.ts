import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {ReactiveFormsModule,FormsModule} from "@angular/forms"

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { AgentPanelComponent } from './home/agent-panel/agent-panel.component';
import { ForbiddenComponent } from './home/forbidden/forbidden.component';
import { ProfilComponent } from './home/profil/profil.component';
import { AcceuilComponent } from './home/acceuil/acceuil.component';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatRadioModule} from '@angular/material/radio';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';

import {NgxPaginationModule} from 'ngx-pagination';
import {Ng2SearchPipeModule} from 'ng2-search-filter';
import {Ng2OrderModule} from 'ng2-order-pipe';

import { DataTablesModule } from "angular-datatables";

import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MyTicketComponent } from './my-ticket/my-ticket.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    AgentPanelComponent,
    ForbiddenComponent,
    ProfilComponent,
    AcceuilComponent,
    TicketDetailsComponent,
    MyTicketComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    MatRadioModule,
    MatFormFieldModule,
    MatInputModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    MatButtonModule,
    MatIconModule,
    Ng2OrderModule,
    BrowserAnimationsModule,

    DataTablesModule
  ],
  providers: [UserService, {
    provide : HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
