import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'


@Component({
  selector: 'app-root',
  template: `
  <h1>{{title}}</h1>
  <nav>
    <a routerLink="/dashboard" routerLinkActive="active">Dashboard</a>
    <a routerLink="/heroes" routerLinkActive="active">Heroes</a>
  </nav>
  <router-outlet></router-outlet>
`,
styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'Tour of Heroes';
}
