import { Component, Inject, ViewChild } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  //public token: string;
  //public orgname: string;
  //private baseAppUrl: string;
  //@ViewChild('orgnameTextbox', { static: true }) orgnameTextboxElement: any;
  //@ViewChild('tokenTextbox', { static: true }) tokenTextboxElement: any;
  constructor(
    @Inject('BASE_URL') baseUrl: string) {
    //baseAppUrl = baseUrl;
  }
  public getExpenseReports(): void {
    //this.token = this.tokenTextboxElement.nativeElement.value;
    //sessionStorage.setItem('token', this.token);
    //this.orgname = this.orgnameTextboxElement.nativeElement.value;
    //sessionStorage.setItem('orgname', this.orgname);
    //this.ro = this.baseAppUrl + 'upland-psa';
  }
}
