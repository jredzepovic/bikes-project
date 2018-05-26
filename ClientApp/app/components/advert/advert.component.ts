import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { AdvertApiService } from '../../services/advertApi.service';
import { Router } from '@angular/router';
import { ValidateService } from '../../services/validate.service';

@Component({
    selector: 'advert',
    templateUrl: 'advert.component.html'
})

export class AdvertComponent implements OnInit {
    name: string = "";
    tireSize: number = 0;
    speeds: number = 0;
    weight: number = 0;
    color: string = "";
    description: string = "";
    price: number = 0;
    image: string = "";
    county: string = "Grad Zagreb";
    condition: string = "Novo";
    type: string = "BMX";
    counties: string[] = [];
    types: string[] = [];
    conditions: string[] = [];
    sale: boolean = false;
    rent: boolean = false;
    addEqName: string = "";
    addEqDesc: string = "";
    addEqAmount: number = 0;
    addEq: any[] = [];

    constructor(private http: Http,
        private advertApi: AdvertApiService,
        private router: Router,
        private validateService: ValidateService) { }

    ngOnInit() {
        this.http.get('api/county').subscribe(res => {
            res.json().counties.forEach((county: any) => {
                this.counties.push(county.name);
            });
        });
        this.http.get('api/biketype').subscribe(res => {
            res.json().bikeTypes.forEach((type: any) => {
                this.types.push(type.name);
            });
        });
        this.http.get('api/bikecondition').subscribe(res => {
            res.json().bikeConditions.forEach((condition: any) => {
                this.conditions.push(condition.name);
            });
        });
    }

    onAddSubmit() {
        let advertTypes = [];
        if (this.sale) {
            advertTypes.push({ name: 'Prodaja' });
        }
        if (this.rent) {
            advertTypes.push({ name: 'Iznajmljivanje' });
        }
        const advert = {
            name: this.name,
            tireSize: this.tireSize,
            speeds: this.speeds,
            weight: this.weight,
            color: this.color,
            description: this.description,
            price: this.price,
            county: this.county,
            condition: this.condition,
            type: this.type,
            additionalEquipment: this.addEq,
            advertTypes: advertTypes
        }

        if (!this.validateService.validateAdvert(advert)) {
            return false;
        }

        this.advertApi.addAdvert(advert).subscribe(data => {
            if (data.success) {
                this.router.navigate(['/profile']);
            }
        }, err => {
            console.log(err);
            return false;
        });
    }

    addEqSubmit() {
        let eq = {
            name: this.addEqName,
            description: this.addEqDesc,
            amount: this.addEqAmount
        }

        this.addEq.push(eq);
    }

    rmAddEq(id: number) {
        this.addEq.splice(id, 1);
    }
}
