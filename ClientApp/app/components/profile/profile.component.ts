import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserApiService } from '../../services/userApi.service';
import { Router } from '@angular/router';

@Component({
    selector: 'profile',
    templateUrl: 'profile.component.html'
})

export class ProfileComponent implements OnInit {
    id: number = 0;
    name: string = "";
    oib: string = "";
    phone: string = "";
    cellPhone: string = "";
    email: string = "";
    address: string = "";
    county: string = "";
    adverts: any = [];
    advertsToShow: any = [];
    index: number = 0;

    constructor(private authService: AuthService,
        private router: Router,
        private userApi: UserApiService) { }

    ngOnInit() {
        this.userApi.getProfile().subscribe(data => {
            this.id = data.id,
            this.name = data.name;
            this.oib = data.oib;
            this.phone = data.phone;
            this.cellPhone = data.cellPhone;
            this.email = data.email;
            this.address = data.address;
            this.county = data.county;
            this.adverts = data.adverts;
            this.advertsToShow = this.adverts.slice(0, 3);
        }, err => {
            console.log(err);
            return false;
        });
    }

    onNext() {
        this.index += 3;
        if (this.index > (this.adverts.length - 3)) {
            this.index = this.adverts.length - 3;
        }
        this.advertsToShow = this.adverts.slice(this.index, this.index + 3);
    }

    onPrev() {
        this.index -= 3;
        if (this.index < 0) {
            this.index = 0;
        }
        this.advertsToShow = this.adverts.slice(this.index, this.index + 3);
    }

    onDetails(id: number) {
        this.router.navigate(['/bike/' + id]);
    }

    onAdd() {
        this.router.navigate(['/advert']);
    }

    onEdit(id: number) {
        this.router.navigate(['/editprofile/' + id]);
    }
}
