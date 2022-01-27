import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppComponent } from './app.component';
import { AgGridModule } from 'ag-grid-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { LayoutComponent } from './layout/layout.component';
import { HomeComponent } from './home/home.component';
import { RoutingModule } from './routing/routing.module';
import { HeaderComponent } from './navigation/header/header.component';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { FormsModule } from '@angular/forms';

import { authInterceptorProviders } from './_helper/auth.interceptor';
import { ImageFormatterComponent } from "./_helper/ImageFormatterComponent";


@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HomeComponent,
    HeaderComponent,
    SigninComponent,
    SignupComponent,
    SidenavListComponent,
    ImageFormatterComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    RoutingModule,
    HttpClientModule,
    FormsModule,
    AgGridModule.withComponents([]),
    AgGridModule.withComponents([ImageFormatterComponent])
  ],  
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
