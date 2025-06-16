import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterModule, RouterOutlet } from '@angular/router';
import { FooterComponent } from "../Core/footer/footer.component";
import { HeaderComponent } from "../Core/header/header.component";
import { AsideComponent } from "../Core/aside/aside.component";
import { CommonModule } from '@angular/common';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, AsideComponent, HeaderComponent, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'SiloVisionX.WebApp';
  isLogin: boolean = true;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd)
      )
      .subscribe(event => {
        const navEnd = event as NavigationEnd; 
        const currentUrl = navEnd.urlAfterRedirects;

        this.isLogin = currentUrl.includes('/login');
      });
  }
}
