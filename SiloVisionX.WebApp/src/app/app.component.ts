import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from "../Core/footer/footer.component";
import { HeaderComponent } from "../Core/header/header.component";
import { AsideComponent } from "../Core/aside/aside.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, AsideComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SiloVisionX.WebApp';
}
