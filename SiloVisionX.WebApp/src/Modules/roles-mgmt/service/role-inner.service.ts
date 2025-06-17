import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleInnerService {

  constructor() { }

  $deleteModalState = new BehaviorSubject<{
    visible: boolean,
    data?: any
  }>({
    visible: false
  })

  $ModalState = new BehaviorSubject<{
    visible: boolean,
    data?: any
    isEdit: boolean
  }>({
    visible: false,
    isEdit: false
  })

  $refreshTableData = new Subject<void>()


}
