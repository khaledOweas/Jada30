import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { LoginService } from '../../../../../../Services/login.service';

@Component({
  standalone: true,
  templateUrl: './company-profile.component.html',
  imports: [CommonModule, HttpClientModule],
})
export class CompanyProfileComponent implements OnInit {
  username = 'newuser';
  password = 'P@ssw0rd';

  constructor(private authService: LoginService) {}


  ngOnInit() {
    this.login();
  }

  login() {
    this.authService.login(this.username, this.password).subscribe({
      next: (response) => {
        console.log('Login successful:', response);
        // Handle token or navigate
      },
      error: (error) => {
        console.error('Login failed:', error);
        // Display error message
      },
    });
  }
}
