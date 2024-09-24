import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './appcomponents/login/login.component';
import { NotfoundComponent } from './appcomponents/notfound/notfound.component';
import { LandingComponent } from './appcomponents/landing/landing.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { RegisterComponent } from './appcomponents/register/register.component';
import { authorizeInterceptor } from './interceptors/authorize.interceptor';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotfoundComponent,
    LandingComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    provideHttpClient(withInterceptors([authorizeInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
