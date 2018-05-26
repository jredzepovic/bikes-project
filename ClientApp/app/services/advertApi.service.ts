import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpModule } from '@angular/http';
import 'rxjs/add/operator/map';

import { AuthService } from './auth.service';

@Injectable()
export class AdvertApiService {

    constructor(private http: Http,
        private authService: AuthService) { }

    addAdvert(advert: any) {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.post('api/advert/addadvert', advert, { headers: headers }).map(res => res.json());
    }

    getDetails(id: number) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.get('api/advert/details?id=' + id, { headers: headers }).map(res => res.json());
    }

    deleteAdvert(id: number) {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.post('api/advert/deleteadvert?id=' + id, { headers: headers }).map(res => res.json());
    }

    editAdvert(advert: any) {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.post('api/advert/editadvert', advert, { headers: headers }).map(res => res.json());
    }

    getAll() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.get('api/advert/getalladverts', { headers: headers }).map(res => res.json());
    }
}
