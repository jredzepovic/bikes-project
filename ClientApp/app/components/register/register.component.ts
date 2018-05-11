import { Component, OnInit } from '@angular/core';
import { ValidateService } from '../../services/validate.service';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Component({
    selector: 'register',
    templateUrl: 'register.component.html'
})

export class RegisterComponent implements OnInit {
    firstName: string = "";
    lastName: string = "";
    oib: string = "";
    phone: string = "";
    cellPhone: string = "";
    email: string = "";
    address: string = "";
    password: string = "";
    counties: string[] = [];
    county: string = "Grad Zagreb";

    constructor(private validateService: ValidateService,
        private flashMessage: FlashMessagesService,
        private router: Router,
        private authService: AuthService,
        private http: Http) { }

    ngOnInit() {
        this.http.get('api/county').subscribe(res => {
            res.json().counties.forEach((county: any) => {
                this.counties.push(county.name);
            });
        });
    }

    onRegisterSubmit() {
        const User = {
            FirstName: this.firstName,
            LastName: this.lastName,
            Oib: this.oib,
            Phone: this.phone,
            CellPhone: this.cellPhone,
            Email: this.email,
            Address: this.address,
            Password: this.password,
            County: this.county
        }

        if (!this.validateService.validateRegister(User)) {
            this.flashMessage.show('Unesite sva polja!', { cssClass: 'alert-danger', timeout: 3000 });
            return false;
        }
        if (!this.validateService.validateEmail(User.Email)) {
            this.flashMessage.show('Unesite ispravan email!', { cssClass: 'alert-danger', timeout: 3000 });
            return false;
        }

        this.authService.registerUser(User).subscribe(data => {
            if (data.success) {
                this.flashMessage.show('Uspješna registracija! Možete se ulogirati!', { cssClass: 'alert-success', timeout: 3000 });
                this.router.navigate(['/login']);
            } else {
                this.flashMessage.show('Ups, nešto je pošlo po krivu hehe.', { cssClass: 'alert-danger', timeout: 3000 });
                this.router.navigate(['/register']);
            }
        });
    }
}
