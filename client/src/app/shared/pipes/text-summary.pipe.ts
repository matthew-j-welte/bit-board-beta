import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'textSummary',
})
export class TextSummaryPipe implements PipeTransform {
  transform(value: string, upperLimit: number): string {
    if (value.length && value.length < upperLimit) {
      return value;
    }
    return `${value.substr(0, upperLimit)}...`;
  }
}
