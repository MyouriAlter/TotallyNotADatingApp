import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomepageComponent} from "./homepage/home.component";
import {MemberListComponent} from "./member/member-list/member-list.component";
import {MemberDetailComponent} from "./member/member-detail/member-detail.component";
import {ListComponent} from "./list/list.component";
import {MessagesComponent} from "./messages/messages.component";
import {AuthGuard} from "./_guards/auth.guard";

const routes: Routes = [
  {path: '', component: HomepageComponent},
  {
    path: '', runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent, canActivate: [AuthGuard]},
      {path: 'members/:id', component: MemberDetailComponent},
      {path: 'list', component: ListComponent},
      {path: 'messages', component: MessagesComponent}
    ]
  },
  {path: '**', component: HomepageComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
