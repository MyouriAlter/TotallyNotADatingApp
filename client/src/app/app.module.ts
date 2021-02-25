import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from "./app-routing.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NavComponent } from './nav/nav.component';
import { FormsModule } from "@angular/forms";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { HomepageComponent } from "./homepage/home.component";
import { RegisterComponent } from './registeraccount/register.component';
import { MemberListComponent } from './member/member-list/member-list.component';
import { MemberDetailComponent } from './member/member-detail/member-detail.component';
import { ListComponent } from './list/list.component';
import { MessagesComponent } from './messages/messages.component';
import { ToastrModule } from "ngx-toastr";
import {SharedModule} from "./_modules/shared.module";

@NgModule({
    declarations: [
        AppComponent,
        NavComponent,
        HomepageComponent,
        RegisterComponent,
        MemberListComponent,
        MemberDetailComponent,
        ListComponent,
        MessagesComponent,
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
