import { Component, OnInit } from '@angular/core';
import { AdvertApiService } from '../../services/advertApi.service';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
    adverts: any[] = [];
    advertsToShow: any[] = [];
    counties: string[] = [];
    types: string[] = [];
    typesAd: string[] = ["Prodaja", "Iznajmljivanje"];
    conditions: string[] = [];
    county: string = "Grad Zagreb";
    condition: string = "Novo";
    type: string = "BMX";
    typeAd: string = "Prodaja";

    constructor(private http: Http,
        private advertApi: AdvertApiService,
        private router: Router) { }

    ngOnInit() {
        this.advertApi.getAll().subscribe(data => {
            this.adverts = data.data;
            this.advertsToShow = data.data;
        });
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

    onDetails(id: number) {
        this.router.navigate(['/bike/' + id]);
    }

    onFilter() {
        // this.advertsToShow = this.adverts.filter(ad => ad.county)
    }
}
