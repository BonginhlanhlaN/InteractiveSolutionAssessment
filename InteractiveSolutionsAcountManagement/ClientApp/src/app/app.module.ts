import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatTableModule, MatDialogModule } from '@angular/material';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/layouts/nav-menu/nav-menu.component';
import { HomeComponent } from './components/pages/home/home.component';
import { ContactComponent } from './components/pages/contact/contact.component';
import { AboutComponent } from './components/pages/about/about.component';
import { PersonListComponent } from './components/pages/person-list/person-list.component';
import { PersonComponent } from './components/person/person.component';
import { PersonDetailsComponent } from './components/pages/person-details/person-details.component';
import { AccountComponent } from './components/account/account.component';
import { AccountDetailsComponent } from './components/pages/account-details/account-details.component';
import { TransactionComponent } from './components/transaction/transaction.component';
import { TransactionDetailsComponent } from './components/pages/transaction-details/transaction-details.component';
import { AddPersonComponent } from './components/pages/add-person/add-person.component';
import { EditPersonComponent } from './components/pages/edit-person/edit-person.component';
import { AddAccountComponent } from './components/pages/add-account/add-account.component';
import { EditAccountComponent } from './components/pages/edit-account/edit-account.component';
import { AddTransactionComponent } from './components/pages/add-transaction/add-transaction.component';
import { EditTransactionComponent } from './components/pages/edit-transaction/edit-transaction.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ContactComponent,
    AboutComponent,
    PersonListComponent,
    PersonComponent,
    PersonDetailsComponent,
    AccountComponent,
    AccountDetailsComponent,
    TransactionComponent,
    TransactionDetailsComponent,
    AddPersonComponent,
    EditPersonComponent,
    AddAccountComponent,
    EditAccountComponent,
    AddTransactionComponent,
    EditTransactionComponent,
   
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatTableModule,
    MatDialogModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
