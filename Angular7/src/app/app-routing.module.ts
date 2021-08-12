import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AgentPanelComponent } from './home/agent-panel/agent-panel.component';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './home/forbidden/forbidden.component';
import { AcceuilComponent } from './home/acceuil/acceuil.component';
import { HomeComponent } from './home/home.component';
import { ProfilComponent } from './home/profil/profil.component';

import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path:'user',component:UserComponent,
  children:[
    {path:'registration',component:RegistrationComponent},
    {path:'login',component:LoginComponent}
  ]
},
{path:'home',component:HomeComponent,canActivate:[AuthGuard],
children:[
  {path:'acceuil',component:AcceuilComponent},
  {path:'profil',component:ProfilComponent},
  {path:'agentpanel',component:AgentPanelComponent,canActivate:[AuthGuard],data :{permittedRoles:['Agent']}},
{path:'forbidden',component:ForbiddenComponent}
]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
