import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { LearningResourceModel } from '../+models/learning_resource_model';
import { LearningResourcesService } from '../+services/learning-resources.service';

@Injectable({
    providedIn: 'root'
})
export class LearningResourceDetailedResolver implements Resolve<LearningResourceModel> {

    constructor(private learningResourceService: LearningResourcesService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<LearningResourceModel> {
        return this.learningResourceService.getLearningResourceModel(route.paramMap.get('id'));
    }
}
