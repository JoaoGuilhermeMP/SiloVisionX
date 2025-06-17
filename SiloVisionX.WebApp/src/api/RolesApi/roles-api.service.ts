import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, firstValueFrom } from 'rxjs';
import { Environment } from '../../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RolesApiService {

  constructor(private http: HttpClient) { }

  getRoles() {
    const apiUrl = `${Environment.apiUrl}/Roles/GetAllRoles`
    
        const observableReq = this.http.get(apiUrl)
          .pipe(
            map((response: any) => {
      
              if(response.statusCode != 200) throw {error: response}
      
              return response.data ?? []
      
            })
          )
      
          return firstValueFrom(observableReq)
  }

  createRole(role: any) {
    const apiUrl = `${Environment.apiUrl}/Roles/CreateRole`
    
        const observableReq = this.http.post(apiUrl, role)
          .pipe(
            map((response: any) => {
      
              if(response.statusCode != 200) throw {error: response}
      
              return response.data ?? []
      
            })
          )
      
          return firstValueFrom(observableReq)
  }

  editRole(role: any) {
    const apiUrl = `${Environment.apiUrl}/Roles/UpdateRole`
    
        const observableReq = this.http.put(apiUrl, role)
          .pipe(
            map((response: any) => {
      
              if(response.statusCode != 200) throw {error: response}
      
              return response.data ?? []
      
            })
          )
      
          return firstValueFrom(observableReq)
  }

  deleteRole(role: any) {
    const apiUrl = `${Environment.apiUrl}/Roles/DeleteRole`
    
        const observableReq = this.http.delete(apiUrl, { body: role })
          .pipe(
            map((response: any) => {
      
              if(response.statusCode != 200) throw {error: response}
      
              return response.data ?? []
      
            })
          )
      
          return firstValueFrom(observableReq)
  }



}
