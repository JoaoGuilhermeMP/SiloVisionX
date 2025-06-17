import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { faSignOut } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-index',
  standalone: false,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent implements OnInit, OnDestroy{

  /**
   *
   */
  constructor(private fb: FormBuilder, private router: Router) {
        
  }
  
  iconLogout = faSignOut

  form!: FormGroup

  roles: any

  ngOnInit(): void {
  this.form = this.fb.group({
    Name: [''],
    Email: [''],
    CPF: [''],
    Telefone: [''],
    Role: [''],
  });

  const storedUser = localStorage.getItem('usuarioAutenticado'); 
  if (storedUser) {
    const userData = JSON.parse(storedUser);
    this.form.patchValue({
      Name: userData.nome || '',
      Email: userData.email || '',
      CPF: userData.cpf || '',
      Telefone: userData.telefone || '',
      Role: userData.role || '',
    });
  }
}
  ngOnDestroy(): void {
    
  }

  logout() {
    localStorage.removeItem('usuarioAutenticado');
    this.router.navigate(['/login']);
  }

}
