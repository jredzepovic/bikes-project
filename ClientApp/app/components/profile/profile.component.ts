import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserApiService } from '../../services/userApi.service';
import { Router } from '@angular/router';

@Component({
    selector: 'profile',
    templateUrl: 'profile.component.html'
})

export class ProfileComponent implements OnInit {
    email: string = "";

    constructor(private authService: AuthService,
        private router: Router,
        private userApi: UserApiService) { }

    ngOnInit() {
        this.userApi.getProfile().subscribe(data => {
            this.email = data.email;
        }, err => {
            console.log(err);
            return false;
        });
    }
}
