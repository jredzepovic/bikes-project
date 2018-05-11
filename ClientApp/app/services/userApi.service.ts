import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpModule } from '@angular/http';
import 'rxjs/add/operator/map';

import { AuthService } from './auth.service';

@Injectable()
export class UserApiService {

    constructor(private http: Http,
        private authService: AuthService) { }

    getProfile() {
        let headers = new Headers();
        this.authService.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authService.authToken);
        return this.http.get('api/user/profile', { headers: headers }).map(res => res.json());
    }
}
