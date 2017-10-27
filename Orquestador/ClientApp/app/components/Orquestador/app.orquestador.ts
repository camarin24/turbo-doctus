import { Component, Inject } from '@angular/core';
import { NgControlStatus } from '@angular/forms';
import { Http, Headers, RequestOptions } from '@angular/http';
import { NgIf } from '@angular/common';
import { Response } from '../../Models/Response';

@Component({
    selector: 'Orquestador',
    templateUrl: './app.orquestador.html'
})
export class OrquestadorComponent {
    baseUrl: string;
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;

    }
    clickSearch() {
        console.log("prueba -----");
    }
}
