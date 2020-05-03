import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'upland-psa-client',
  templateUrl: './upland-psa-client.html'
})
export class UplandPSAClientComponent {

  public expenseReports: any[];
  constructor(http: HttpClient,
    @Inject('UplandPSA_REST_API') baseUrl: string
  ) {
    let orgname = this.GetValueFromSessionOrQueryString("orgname");
    let token = this.GetValueFromSessionOrQueryString("token");
    if (!(!orgname || orgname === '' || !token || token === '')) {
      let headers: HttpHeaders = new HttpHeaders();
      headers = headers.append('orgname', orgname);
      //headers = headers.append('Content-Type', 'application/json');
      headers = headers.append('token', token);
      headers = headers.append('endpoint', "v2/expensereports");
      headers = headers.append('ApiBaseUrl', "http://10.60.19.210/tenterprise/api/");
      http.get<object[]>(baseUrl, { headers: headers }).subscribe(result => {
        let arr = [];
        for (var i = 0; i < result.length; i++) {
          arr.push(result[i]);
        }
        this.expenseReports = arr;
      }, error => console.error(error));
    }
  }
  private GetQueryStringValue(strKey: string): string {
    var url = window.location.href;
    if (url.indexOf("?") > -1) {
      var querystringArray = url.split("?")[1].split("&");
      for (var i = 0; i < querystringArray.length; i++) {
        var keyValue = querystringArray[i].split("=");
        if (keyValue[0].toUpperCase() === strKey.toUpperCase()) {
          return keyValue[1];
        }
      }
    }
    return '';
  }
  private GetValueFromSessionOrQueryString(strKey: string): string {
    var strValue = this.GetQueryStringValue(strKey);
    if (!strValue || strValue === '') {
      strValue = sessionStorage.getItem(strKey);
    } else {
      strValue = decodeURIComponent(strValue);
    }
    sessionStorage.setItem(strKey, strValue);
    return strValue;
  }

}
