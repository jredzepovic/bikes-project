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
import { AdvertComponent } from './components/advert/advert.component';
import { BikeComponent } from './components/bike/bike.component';
import { EditAdvertComponent } from './components/editadvert/editadvert.component';
import { EditProfileComponent } from './components/editprofile/editprofile.component';
import { EditEquipmentComponent } from './components/editequipment/editequipment.component';

import { ValidateService } from './services/validate.service';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AuthService } from './services/auth.service';
import { UserApiService } from './services/userApi.service';
import { AdvertApiService } from './services/advertApi.service';
import { AdditionalEquipmentApiService } from './services/additionalEquipmentApi.service';
import { AuthGuard } from './guards/auth.guard';
import { AnonymousGuard } from './guards/anonymous.guard';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        RegisterComponent,
        LoginComponent,
        ProfileComponent,
        AdvertComponent,
        BikeComponent,
        EditAdvertComponent,
        EditEquipmentComponent,
        EditProfileComponent
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
            { path: 'advert', component: AdvertComponent, canActivate: [AuthGuard] },
            { path: 'bike/:id', component: BikeComponent },
            { path: 'editprofile/:id', component: EditProfileComponent, canActivate: [AuthGuard] },
            { path: 'editadvert/:id', component: EditAdvertComponent, canActivate: [AuthGuard] },
            { path: 'editequipment/:id', component: EditEquipmentComponent, canActivate: [AuthGuard] },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ValidateService,
        FlashMessagesService,
        AuthService,
        UserApiService,
        AdvertApiService,
        AdditionalEquipmentApiService,
        AuthGuard,
        AnonymousGuard
    ]
})
export class AppModuleShared {
}
