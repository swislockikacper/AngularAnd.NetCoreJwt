import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  constructor(private http: HttpClient, private router: Router) {}
  invalidLogin: boolean;
  data: string;
  ngOnInit() {}

  login(form: NgForm) {
    const credentials = JSON.stringify(form.value);
    this.http
      .post("https://localhost:5000/api/login", credentials, {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      })
      .subscribe(
        response => {
          let token = (response as any).token;
          localStorage.setItem("jwt", token);
          this.invalidLogin = false;
          this.router.navigate(["/"]);
        },
        err => {
          this.invalidLogin = true;
        }
      );
  }
}
