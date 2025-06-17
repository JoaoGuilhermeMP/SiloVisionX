import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Environment } from '../../environment/environment';
import { firstValueFrom, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  constructor(private http: HttpClient) { }

  createToken(email: string): Promise<any> {
    const apiUrl = `${Environment.apiUrl}/Auth/CreateToken?Email=${email}`

    const observableReq = this.http.get(apiUrl)
    .pipe(
      map((response: any) => {

        if(response.StatusCode != 200) throw {error: response}

        return response.Data ?? []

      })
    )

    return firstValueFrom(observableReq)

  }

  getToken(email: string, token: string) {
    const apiUrl = `${Environment.apiUrl}/Auth/GetToken?Email=${email}&token=${token}`

    const observableReq = this.http.get(apiUrl)
    .pipe(
      map((response: any) => {

        if(response.StatusCode != 200) throw {error: response}

        return response.Data ?? []

      })
    )

    return firstValueFrom(observableReq)
  }

}
