import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TransactionServiceService } from '../../../services/transaction/transaction-service.service';

@Component({
  selector: 'app-edit-transaction',
  templateUrl: './edit-transaction.component.html',
  styleUrls: ['./edit-transaction.component.css']
})
export class EditTransactionComponent implements OnInit {

  transactionCode!: number;

  editTransactionForm = new FormGroup({

    code: new FormControl(this.transactionCode),
    accountCode: new FormControl(''),
    transactionDate: new FormControl(''),
    capturedDate: new FormControl(''),
    amount: new FormControl('')

  })

  constructor(private transactionService: TransactionServiceService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {

    this.transactionCode = this.activatedRoute.snapshot.params['transaction_code'];

    this.transactionService.getTransaction(this.transactionCode).subscribe(

      result => {
        // Handle result
        this.editTransactionForm = new FormGroup({

          code: new FormControl(this.transactionCode),
          accountCode: new FormControl(result.accountCode),
          transactionDate: new FormControl(result.transactionDate),
          capturedDate: new FormControl(result.captureDate),
          amount: new FormControl(result.amount)

        })

      },
      error => {
        // Handle Error
        console.log(error);
      },
      () => {
        //Redirect to another component
      }

    );

  }

  onEditTransaction() {

    console.log('Clicked Baby');
    

  }

}
