import {
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LearningResource } from '../+models/dtos/learning_resource_dto';

interface LearningResourceCard extends LearningResource {
  showLogos: boolean;
  progressPercent?: number;
}

@Component({
  selector: 'app-learning-resource-card-group',
  templateUrl: './learning-resource-card-group.component.html',
  styleUrls: ['./learning-resource-card-group.component.css'],
})
export class LearningResourceCardGroupComponent implements OnInit {
  private inputData = new BehaviorSubject<LearningResourceCard[]>([]);
  resources: LearningResourceCard[];

  @Input() set data(value) {
    this.inputData.next(value);
  }

  get data(): LearningResourceCard[] {
    return this.inputData.getValue();
  }

  activeResources: LearningResourceCard[];
  resourceIndex = 0;
  resourcePageCount = 3;
  pages: number[] = [];

  constructor() { }

  ngOnInit(): void {
    this.inputData.subscribe((x) => {
      this.resources = this.data;
      this.setActiveResources();
      for (
        let index = 0;
        index < this.resources?.length / this.resourcePageCount;
        index++
      ) {
        this.pages.push(index + 1);
      }
    });
  }

  setActiveResources(): void {
    this.activeResources = this.resources?.slice(
      this.resourceIndex * this.resourcePageCount,
      this.resourceIndex * this.resourcePageCount + 3
    );
  }

  graphicalSkillsView(resource: LearningResourceCard): void {
    resource.showLogos = true;
  }

  textualSkillsView(resource: LearningResourceCard): void {
    resource.showLogos = false;
  }

  nextKeepWorkingPage(): void {
    if (
      this.resourceIndex <
      this.resources.length / this.resourcePageCount - 1
    ) {
      this.resourceIndex += 1;
    } else {
      this.resourceIndex = 0;
    }
    this.setActiveResources();
  }

  previousKeepWorkingPage(): void {
    if (this.resourceIndex > 0) {
      this.resourceIndex -= 1;
    } else {
      this.resourceIndex = this.resources.length / this.resourcePageCount - 1;
    }
    this.setActiveResources();
  }

  setKeepWorkingPage(page: number): void {
    this.resourceIndex = page - 1;
    this.setActiveResources();
  }
}
