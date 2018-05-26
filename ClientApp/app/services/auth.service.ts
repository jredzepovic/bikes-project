import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpModule } from '@angular/http';
import 'rxjs/add/operator/map';
import { tokenNotExpired } from 'angular2-jwt';

@Injectable()
export class AuthService {
    authToken: string = "";
    user: string = "";

    constructor(private http: Http) { }

    registerUser(user: any) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post('api/auth/register', user, { headers: headers })
            .map(res => res.json());
    }

    authenticateUser(user: any) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post('api/auth/authenticate', user, { headers: headers })
            .map(res => res.json());
    }

    getUserID() {
        let headers = new Headers();
        this.loadToken();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.authToken);
        return this.http.get('api/user/getuserid', { headers: headers })
            .map(res => res.json());
    }

    storeUserData(token: string, user: string) {
        localStorage.setItem('id_token', token);
        localStorage.setItem('user', user);
        this.authToken = token;
        this.user = user;
    }

    loadToken() {
        const token = localStorage.getItem('id_token');
        this.authToken = token !== null ? token : "";
    }

    loggedIn() {
        return tokenNotExpired('id_token');
    }

    logout() {
        this.authToken = "";
        this.user = "";
        localStorage.clear();
    }
}
