import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, firstValueFrom } from 'rxjs';
import { Environment } from '../../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportApiService {

  constructor(private http: HttpClient) { }


  getReportData(initialDate: any, finalDate: any) {
    const apiUrl = `${Environment.apiUrl}/Report/GetReportData?initialDate=${initialDate}&finalDate=${finalDate}`
    
        const observableReq = this.http.get(apiUrl)
          .pipe(
            map((response: any) => {
      
              if(response.statusCode != 200) throw {error: response}
      
              return response.data ?? []
      
            })
          )
      
          return firstValueFrom(observableReq)
  }

}
