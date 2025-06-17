import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeralInnerService {

  constructor() { }


  $apiData = new BehaviorSubject<{
    data: any,
  }>({
    data: null
  })

}
