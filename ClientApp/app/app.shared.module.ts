import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FlashMessagesModule } from 'angular2-flash-messages';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';

import { ValidateService } from './services/validate.service';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AuthService } from './services/auth.service';
import { UserApiService } from './services/userApi.service';
import { AuthGuard } from './guards/auth.guard';
import { AnonymousGuard } from './guards/anonymous.guard';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        RegisterComponent,
        LoginComponent,
        ProfileComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        FlashMessagesModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'register', component: RegisterComponent, canActivate: [AnonymousGuard] },
            { path: 'login', component: LoginComponent, canActivate: [AnonymousGuard] },
            { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ValidateService,
        FlashMessagesService,
        AuthService,
        UserApiService,
        AuthGuard,
        AnonymousGuard
    ]
})
export class AppModuleShared {
}
