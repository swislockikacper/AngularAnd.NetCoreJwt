import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent {

  constructor(private router: Router) { }

  logOut = (): void => {
    localStorage.removeItem("jwt");
    this.router.navigate(['login']);
  }

}
