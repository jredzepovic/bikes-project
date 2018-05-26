import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

import { AdvertApiService } from '../../services/advertApi.service';
import { AdditionalEquipmentApiService } from '../../services/additionalEquipmentApi.service';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'bike',
    templateUrl: 'bike.component.html'
})

export class BikeComponent implements OnInit {
    id: number = 0;
    name: string = "";
    tireSize: number = 0;
    speeds: number = 0;
    weight: number = 0;
    color: string = "";
    description: string = "";
    price: number = 0;
    image: string = "";
    county: string = "";
    condition: string = "";
    type: string = "";
    addEq: any[] = [];
    adTypes: any[] = [];
    user: any = "";
    editable: boolean = false;

    constructor(private http: Http,
        private router: Router,
        private route: ActivatedRoute,
        private advertApi: AdvertApiService,
        private authService: AuthService,
        private addEqApi: AdditionalEquipmentApiService) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];
        });
        this.advertApi.getDetails(this.id).subscribe(data => {
            this.id = data.bike.id;
            this.name = data.bike.name;
            this.tireSize = data.bike.tireSize;
            this.speeds = data.bike.speeds;
            this.weight = data.bike.weight;
            this.color = data.bike.color;
            this.description = data.bike.description;
            this.price = data.bike.price;
            this.image = data.bike.image;
            this.county = data.bike.county;
            this.condition = data.bike.condition;
            this.type = data.bike.type;
            this.addEq = data.bike.additionalEquipment;
            this.adTypes = data.bike.advertTypes;
            this.user = data.bike.user;

            this.authService.getUserID().subscribe(data => {
                if (data.id == this.user.id) {
                    this.editable = true;
                }
            });
        }, err => {
            console.log(err);
            return false;
        });
    }

    onDelete() {
        this.advertApi.deleteAdvert(this.id).subscribe(data => {
            //
        });
        this.router.navigate(['/profile']);
    }

    onEdit(id: number) {
        this.router.navigate(['/editadvert/' + id]);
    }

    onEditAddEq(id: number) {
        this.router.navigate(['/editequipment/' + id]);
    }

    onDeleteAddEq(id: number) {
        this.addEqApi.deleteAdditionalEquipment(id).subscribe(data => {
            //
        });
        this.router.navigate(['/profile']);
    }
}
