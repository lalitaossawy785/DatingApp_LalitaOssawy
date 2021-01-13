import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({ //This in an angular module
  declarations: [ //components available in our application - can import more
    AppComponent
  ],
  imports: [
    BrowserModule, //Single page application - so our code can be displayed in our browser
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent] //Components added when our application is bootstrapped
})
export class AppModule { }
