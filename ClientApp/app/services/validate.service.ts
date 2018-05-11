import { Injectable } from '@angular/core';

@Injectable()
export class ValidateService {

    constructor() { }

    validateRegister(user: any) {
        if (user.FirstName == "" || user.LastName == ""
            || user.Oib == "" || user.Phone == ""
            || user.CellPhone == "" || user.Email == ""
            || user.Address == "" || user.Password == "") {
            return false;
        } else {
            return true;
        }
    }

    validateLogin(user: any) {
        if (user.Email == "" || user.Password == "") {
            return false;
        } else {
            return true;
        }
    }

    validateEmail(email: string) {
        const re = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
        return re.test(email);
    }
}
