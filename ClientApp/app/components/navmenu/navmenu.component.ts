import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    constructor(private flashMessage: FlashMessagesService,
        private authService: AuthService,
        private router: Router) { }

    ngOnInit() { }

    onLogoutClick() {
        this.authService.logout();
        this.flashMessage.show('Odjavljeni ste!', { cssClass: 'alert-success', timeout: 3000});
        this.router.navigate(['/login']);
        return false;
    }
}
