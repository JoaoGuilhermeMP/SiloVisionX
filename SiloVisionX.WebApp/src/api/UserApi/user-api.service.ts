import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Environment } from './../../environment/environment';
import { firstValueFrom, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  constructor(private http: HttpClient) { }


  getAllUsers() {
    const apiUrl = `${Environment.apiUrl}/Users/GetAllUsers`

    const observableReq = this.http.get(apiUrl)
      .pipe(
        map((response: any) => {
  
          if(response.statusCode != 200) throw {error: response}
  
          return response.data ?? []
  
        })
      )
  
      return firstValueFrom(observableReq)
    }

    getUserByEmail(email: string) {
      const apiUrl = `${Environment.apiUrl}/Users/GetUserByEmail?email=${email}`

      const observableReq = this.http.get(apiUrl)
        .pipe(
          map((response: any) => {
    
            if(response.statusCode != 200) throw {error: response}
    
            return response.data ?? []
    
          })
        )
    
        return firstValueFrom(observableReq)
    }

    createUser(user: any) {
      const apiUrl = `${Environment.apiUrl}/Users/CreateUser`

      const observableReq = this.http.post(apiUrl, user)
        .pipe(
          map((response: any) => {
    
            if(response.statusCode != 200) throw {error: response}
    
            return response.data ?? []
    
          })
        )
    
        return firstValueFrom(observableReq)
    }

    editUser(user: any) {
      const apiUrl = `${Environment.apiUrl}/Users/EditUser`

      const observableReq = this.http.put(apiUrl, user)
        .pipe(
          map((response: any) => {
    
            if(response.statusCode != 200) throw {error: response}
    
            return response.data ?? []
    
          })
        )
    
        return firstValueFrom(observableReq)
    }

    deleteUser(email: string){
      const apiUrl = `${Environment.apiUrl}/Users/DeleteUser?email=${email}`

      const observableReq = this.http.delete(apiUrl)
        .pipe(
          map((response: any) => {
    
            if(response.statusCode != 200) throw {error: response}
    
            return response.data ?? []
    
          })
        )
    
        return firstValueFrom(observableReq)
    }

}


