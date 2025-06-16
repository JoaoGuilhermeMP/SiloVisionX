import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserInnerService {

  constructor() { }

  $modalState = new BehaviorSubject<{
    visible: boolean,
    data?: any,
    isEdit?: boolean,
  }>({
    visible: false,
    data: null,
    isEdit: false
  })

  $deleteModalState = new BehaviorSubject<{
    visible: boolean,
    data?: any,
  }>({
    visible: false,
    data: null
  })

}
