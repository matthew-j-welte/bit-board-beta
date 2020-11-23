import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { LearningResource } from '../+models/dtos/learning_resource_dto';
import { LearningResourcesService } from '../+services/learning-resources.service';

@Injectable({
    providedIn: 'root'
})
export class LearningResourceDetailedResolver implements Resolve<LearningResource> {

    constructor(private learningResourceService: LearningResourcesService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<LearningResource> {
        return this.learningResourceService.getLearningResource(route.paramMap.get('id'));
    }

}