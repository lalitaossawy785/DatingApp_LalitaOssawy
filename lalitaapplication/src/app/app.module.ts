import { BrowserModule } from '@angular/platform-browser';
// import { HomeComponent } from './home/home.component';
import { HomeComponent } from '../app/home/home.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from '../app/pages/register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationComponent } from './navigation/navigation.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({ //This in an angular module
  declarations: [	 //components available in our application - can import more
    AppComponent, 
    NavigationComponent,
      HomeComponent,
      RegisterComponent
   ],
  imports: [
    BrowserModule, //Single page application - so our code can be displayed in our browser
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent] //Components added when our application is bootstrapped
})
export class AppModule { }
