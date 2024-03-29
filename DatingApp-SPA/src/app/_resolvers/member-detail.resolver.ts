import { Injectable } from "@angular/core";
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberDetailResolver implements Resolve<User>{
    constructor(private userService: UserService, private route: Router, private alertify: AlertifyService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<User>{
        return this.userService.getUser(route.params['id']).pipe(
            catchError(error=>{
                this.alertify.error('Problem retrieving data');
                this.route.navigate(['/members']);
                return of(null);
            })
        );
    }
}