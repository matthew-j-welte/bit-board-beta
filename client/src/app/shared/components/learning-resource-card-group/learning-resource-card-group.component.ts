import { AfterContentInit, AfterViewInit, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { LearningResourceCard } from '../../models/component-interfaces/interfaces';
import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { BOOTSTRAP_BREAKPOINTS } from '../../constants/breakpoints';

const breakpointCardAmountMap = new Map<string, number>([
  [BOOTSTRAP_BREAKPOINTS.xs, 1],
  [BOOTSTRAP_BREAKPOINTS.sm, 1],
  [BOOTSTRAP_BREAKPOINTS.md, 2],
  [BOOTSTRAP_BREAKPOINTS.lg, 3],
  [BOOTSTRAP_BREAKPOINTS.xl, 4],
  [BOOTSTRAP_BREAKPOINTS.xxl, 4],
]);

@Component({
  selector: 'app-learning-resource-card-group',
  templateUrl: './learning-resource-card-group.component.html',
  styleUrls: ['./learning-resource-card-group.component.scss'],
})
export class LearningResourceCardGroupComponent implements OnInit, OnDestroy {
  @Input() resources: LearningResourceCard[] = [];
  resourceGroupings: LearningResourceCard[][] = [];
  activePageIndex = 0;

  constructor(private breakpointObserver: BreakpointObserver) {}

  ngOnInit(): void {
    this.groupCards(4);
    this.initBreakpointObserver();
  }

  initBreakpointObserver(): void {
    this.breakpointObserver
      .observe(Object.values(BOOTSTRAP_BREAKPOINTS))
      .subscribe((state: BreakpointState) => {
        if (state.matches) {
          this.handleBreakpointChange(state);
        }
      });
  }

  ngOnDestroy(): void {
    this.breakpointObserver.ngOnDestroy();
  }

  updateIndex(increment: 1 | -1): void {
    this.activePageIndex += increment;
  }

  handleBreakpointChange(state: BreakpointState): void {
    for (const breakpoint of Object.keys(state.breakpoints)) {
      if (state.breakpoints[breakpoint] === true) {
        return this.groupCards(breakpointCardAmountMap.get(breakpoint));
      }
    }
  }

  groupCards(cardPerGroup: number): void {
    const chunk = (arr, size) =>
      Array.from({ length: Math.ceil(arr.length / size) }, (v, i) =>
        arr.slice(i * size, i * size + size)
      );
    if (this.resources != null) {
      this.resourceGroupings = chunk(this.resources, cardPerGroup);
    }
  }
}
