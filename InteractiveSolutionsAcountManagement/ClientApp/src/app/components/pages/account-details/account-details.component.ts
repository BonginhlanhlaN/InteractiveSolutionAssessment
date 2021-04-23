import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Transaction } from '../../../models/Transaction';
import { TransactionServiceService } from '../../../services/transaction/transaction-service.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent implements OnInit {

  //Field
  account_code!: number;
  transactions!: Transaction[];

  constructor(private activatedRoute: ActivatedRoute, private transactionService: TransactionServiceService) { }

  ngOnInit() {

    this.account_code = this.activatedRoute.snapshot.params['account_code'];

    this.transactionService.getAccountTransactions(this.account_code).subscribe(transactions => { this.transactions = transactions });
    
  }

}
