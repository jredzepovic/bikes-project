import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AdditionalEquipmentApiService } from '../../services/additionalEquipmentApi.service';

@Component({
    selector: 'editequipment',
    templateUrl: 'editequipment.component.html'
})

export class EditEquipmentComponent implements OnInit {
    id: number = 0;
    name: string = "";
    description: string = "";
    amount: number = 0;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private eqApi: AdditionalEquipmentApiService) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];
        });
        this.eqApi.details(this.id).subscribe(data => {
            this.name = data.data.name;
            this.description = data.data.description;
            this.amount = data.data.amount;
        });
    }

    onEdit() {
        const eq = {
            id: this.id,
            name: this.name,
            description: this.description,
            amount: this.amount
        }

        this.eqApi.editEq(eq).subscribe(data => {
            //
            this.router.navigate(['/profile']);
        });
    }
}
