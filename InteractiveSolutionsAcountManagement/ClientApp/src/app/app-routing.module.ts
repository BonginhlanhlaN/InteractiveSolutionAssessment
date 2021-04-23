import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { HomeComponent } from './components/pages/home/home.component';
import { ContactComponent } from './components/pages/contact/contact.component';
import { AboutComponent } from './components/pages/about/about.component';
import { PersonListComponent } from './components/pages/person-list/person-list.component';
import { PersonDetailsComponent } from './components/pages/person-details/person-details.component';
import { AccountDetailsComponent } from './components/pages/account-details/account-details.component';
import { TransactionDetailsComponent } from './components/pages/transaction-details/transaction-details.component';
import { AddPersonComponent } from './components/pages/add-person/add-person.component';
import { EditPersonComponent } from './components/pages/edit-person/edit-person.component';
import { AddAccountComponent } from './components/pages/add-account/add-account.component';
import { EditAccountComponent } from './components/pages/edit-account/edit-account.component';
import { AddTransactionComponent } from './components/pages/add-transaction/add-transaction.component';
import { EditTransactionComponent } from './components/pages/edit-transaction/edit-transaction.component';

const routes: Routes = [

  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'person-list', component: PersonListComponent },
  { path: 'person-details/:person_code', component: PersonDetailsComponent },
  { path: 'account-details/:account_code', component: AccountDetailsComponent },
  { path: 'transaction-details/:code', component: TransactionDetailsComponent },
  { path: 'add-person', component: AddPersonComponent },
  { path: 'edit-person/:code', component: EditPersonComponent },
  { path: 'add-account/:person_code', component: AddAccountComponent },
  { path: 'edit-account/:code', component: EditAccountComponent },
  { path: 'add-transaction/:account_code', component: AddTransactionComponent },
  { path: 'edit-transaction/:transaction_code', component: EditTransactionComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
