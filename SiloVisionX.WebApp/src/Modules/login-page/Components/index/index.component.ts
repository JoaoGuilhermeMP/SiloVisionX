import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthApiService } from '../../../../api/AuthApi/auth-api.service';
import { Router } from '@angular/router';

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
  constructor(private fb: FormBuilder, private api: AuthApiService, private router: Router) {
    
    
  }
 

  erroAoLogar: boolean = false

  form!: FormGroup

  authToken!: FormGroup

  token: any

  email: string = ''

  isTokenPage: boolean = false

  createTokenData: any 

  userData: any

  confirmedToken: boolean = true

  ngOnInit(): void {
    this.form = this.fb.group({
      Email: ['', Validators.required]
    })

    this.authToken = this.fb.group({
      Token: ['', Validators.required]
    })

  }

   ngOnDestroy(): void {
    this.isTokenPage = false
    this.erroAoLogar = false
  }

  auth(form: any) {
    this.email = form.value

    const result = this.api.createToken(this.email)

    if (result != null) {
      this.isTokenPage = true
      this.createTokenData = result
    } else {
      this.erroAoLogar = true
    }

  }

  async confirmToken(form: any) {
  this.token = form.value;

  try {
    const result = await this.api.getToken(this.email, this.token);

    if (result && result.length > 0) {
      const usuario = result[0].user;

      localStorage.setItem('usuarioAutenticado', JSON.stringify(usuario));
      this.router.navigate(['home']);
    } else {
      this.confirmedToken = false;
    }
  } catch (error) {
    console.error('Erro ao confirmar token:', error);
    this.confirmedToken = false;
  }
}

  

}
