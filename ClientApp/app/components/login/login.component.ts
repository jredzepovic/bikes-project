import { Component, OnInit } from '@angular/core';
import { ValidateService } from '../../services/validate.service';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
    email: string = "";
    password: string = "";

    constructor(private validateService: ValidateService,
        private flashMessage: FlashMessagesService,
        private authService: AuthService,
        private router: Router) { }

    ngOnInit() { }

    onLoginSubmit() {
        const User = {
            Email: this.email,
            Password: this.password
        }

        if (!this.validateService.validateLogin(User)) {
            this.flashMessage.show('Unesite sva polja!', { cssClass: 'alert-danger', timeout: 3000 });
            return false;
        }
        if (!this.validateService.validateEmail(User.Email)) {
            this.flashMessage.show('Unesite ispravan email!', { cssClass: 'alert-danger', timeout: 3000 });
            return false;
        }

        this.authService.authenticateUser(User).subscribe(data => {
            if (data.success) {
                this.authService.storeUserData(data.token, data.user);
                this.flashMessage.show('Sad ste ulogirani!', { cssClass: 'alert-success', timeout: 5000 });
                this.router.navigate(['/profile']);
            } else {
                this.flashMessage.show("Pogrešni podaci za prijavu!", { cssClass: 'alert-danger', timeout: 5000 });
                this.router.navigate(['/login']);
            }
        });
    }
}
