import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor (private authService: AuthService, private alertifyService: AlertifyService, private router: Router) {}

  canActivate(): boolean {

    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertifyService.error('Impossible de continuer vous devez vous connecter');
    this.router.navigate(['/home']);
    return false;
  }
}
