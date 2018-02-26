import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// Componentes
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import {AlertComponent} from './alert/alert.component';
// Componentes del bootstrap
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AppRoutingModule } from './/app-routing.module';

// Servicios
import { AuthenticationService } from './Service/authentication.service';
import { AlertService } from './Service/alert.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent ,
    RegistroComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    TooltipModule.forRoot(),
    AppRoutingModule
  ],
  providers: [
    AuthenticationService,
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
