import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Environment } from '../../environment/environment';
import { firstValueFrom, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashApiService {

  constructor(private http: HttpClient) { }

  getDashBoardData() {
    const apiUrl = `${Environment.apiUrl}/Dashboard/GetDashboardData`

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

