import { Component, Inject } from '@angular/core';
import { NgControlStatus } from '@angular/forms';
import { Http, Headers, RequestOptions } from '@angular/http';
import { NgIf } from '@angular/common';
import { Response } from '../../Models/Response';
import { Git, GitResponse } from '../../Models/Git';

@Component({
    selector: 'git',
    templateUrl: './git.component.html'
})
export class GitComponent {
    model: Git;
    response: Response<GitResponse> = new Response<GitResponse>();
    baseUrl:string;
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
     
        this.model = new Git();
    }

    commit(){
        console.log(this.model);
        let headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=UTF-8');
        headers.append('Access-Control-Allow-Origin', '*');

        let options = new RequestOptions({ headers: headers });
        this.http.post(this.baseUrl + 'api/Git/Commit', JSON.stringify(this.model), options).subscribe(result => {
            console.log(result.json());
            this.response = result.json() as Response<GitResponse>;
        }, error => console.error(error));
    }
}
