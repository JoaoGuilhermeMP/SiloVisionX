import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Environment } from '../../environment/environment';
import { firstValueFrom, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  constructor(private http: HttpClient) { }

  createToken(email: any): Promise<any> {
    const apiUrl = `${Environment.apiUrl}/Auth/CreateToken?Email=${email.Email}`

    const observableReq = this.http.get(apiUrl)
    .pipe(
      map((response: any) => {

        if(response.StatusCode != 200) throw {error: response}

        return response.Data ?? []

      })
    )

    return firstValueFrom(observableReq)

  }

  getToken(email: any, token: any) {
    const apiUrl = `${Environment.apiUrl}/Auth/GetToken?Email=${email.Email}&token=${token.Token}`

   

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
