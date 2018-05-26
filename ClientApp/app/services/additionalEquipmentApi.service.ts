import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpModule } from '@angular/http';
import 'rxjs/add/operator/map';

import { AuthService } from './auth.service';

@Injectable()
export class AdditionalEquipmentApiService {

    constructor(private http: Http,
        private authService: AuthService) { }

    deleteAdditionalEquipment(id: number) {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.post('api/additionalequipment/deleteadditionalequipment?id=' + id, { headers: headers }).
            map(res => res.json());
    }

    details(id: number) {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.get('api/additionalequipment/details?id=' + id, { headers: headers }).
            map(res => res.json());
    }

    editEq(eq: any) {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.post('api/additionalequipment/editadditionalequipment', eq, { headers: headers }).
            map(res => res.json());
    }
}
