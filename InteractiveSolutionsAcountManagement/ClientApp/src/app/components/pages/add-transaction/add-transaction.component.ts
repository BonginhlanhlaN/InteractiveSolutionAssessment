import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionServiceService } from '../../../services/transaction/transaction-service.service';

@Component({
  selector: 'app-add-transaction',
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.css']
})
export class AddTransactionComponent implements OnInit {

  today: Date = new Date();
  date: string = this.today.getFullYear() + '-' + ('0' + (this.today.getMonth() + 1)).slice(-2) + '-' + ('0' + this.today.getDate()).slice(-2);
  time: string = ('0' + this.today.getHours()).slice(-2) + ":" + ('0' + this.today.getMinutes()).slice(-2) + ":" + ('0' + this.today.getSeconds()).slice(-2);
  dateTime:string  = this.date + 'T' + this.time;

  addTransactionForm = new FormGroup({

    accountCode: new FormControl(parseInt(this.activatedRoute.snapshot.params['account_code'])),
    transactionDate: new FormControl(this.dateTime),
    captureDate: new FormControl(this.dateTime),
    amount: new FormControl('', [Validators.required, Validators.pattern('^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$')]),
    description: new FormControl('Charge Off Amount', Validators.required),
  
  });

  constructor(private transactionService: TransactionServiceService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    

  }

  onFormSubmit() {

    console.log(this.dateTime);
    
    this.transactionService.addTransaction(this.addTransactionForm.value).subscribe(

      result => {
        // Handle result
        console.log(result);
      },
      error => {
        // Handle Error

        console.log(error);
      },
      () => {
        this.router.navigate(['/account-details/' + this.activatedRoute.snapshot.params['account_code']])
      }


    );
    

  }

}
