import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PessoaService } from './pessoa.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal'

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClient,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ],
  providers: [
    provideClientHydration(withEventReplay()),
    HttpClient,
    PessoaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
