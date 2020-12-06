# Components and Databinding

## _Data Binding Basics_

Can assign an alias to Input() to make the input make more sense from an external point of view, for ex:

- `@Input('cardIconName') icon: string;`

When you need a parent component to change state when something happens in the child component
you can use an EventEmitter from the child component, for ex:

**From the child component**

```ts
export class ResourceCardComponent implements OnInit {
  @Output() resourceCreated = new EventEmitter<LearningResource>();
  resourceName = "";
  resourceContent = "";

  onCreateResource() {
    this.resourceCreated.emit({
      name: this.resourceName,
      content: this.resourceContent,
    });
  }
}
```

**From the parent template**

```html
<div>
  <app-resource-card (resourceCreated)="onResourceCreated($event)">
  </app-resource-card>
</div>
```

**From the parent component**

```ts
  onResourceCreated(event) {
    console.log('Do something with event' + event);
  }
```

## _Styling encapsulation_

If you want to enable some global styling you can make modifications to a particular
components @Component config, for ex:

```ts
@Component({
    selector: 'app-element',
    templateUrl: './element.html',
    encapsulation: ViewEncapsulation.None
})
```

## _ngModel_

If you want to avoid implementing the full form functionality you can use ngModel to bind
a template element to the component's typescript file like so:

```html
<input type="text" [(ngModel)]="serverName" />
```

```ts
serverName: string;
```

## (**Alternative to ngModel**) _Local template refs_

_This keeps you from having to define variables in typescript all together_

If you want to easily access the value of one element from another within the template you
can use local template referenecs by doing something like:

```html
<input type="text" #username />
<button (click)="postUserName(username)"></button>
```

## (**Alternative to local refs**) _@ViewChild_

_This is similar to above but keeps you from having to pass values into functions_

_Should only be used on elements you dont plan on modifying through the viewchild_

```html
<input type="text" #username />
```

```ts
@ViewChild('username') username: ElementRef

onAddUser() {
    console.log("Users name is: " + this.username.nativeElement.value);
}
```

## _ng-content_

_Use if trying to pass html into a custom made component (like children in react)_

For ex,

```html
<app-element>
  <p>Some content</p>
</app-element>
```

```html
<div>
  <ng-content></ng-content>
</div>
```

## _Lifecycle Hooks_

- **ngOnChanges** - Called whenever any @Input() property changes on that component
- **ngOnInit** - Called once the component is initialized
- **ngDoCheck** - Called whenever angular checks for changes (even if no changes were made) - for example a button click or obsevable resolution.
- **ngAfterContentInit** - Called after ng-content has been projected into the view.
- **ngAfterContentChecked** - Called every time the project content has been checked
- **ngAfterViewInit** - Called after the component's view and child views have been initialized.

## _@ContentChild_

_If you need to access the `<ng-content>` that is passed in to your component then from your typescript you can
do the following:_

```ts
@ContentChild('contentParagraph') paragraph: ElementRef;
```

This can then be accessed during `ngAfterContentInit()` lifecycle hook

# Directives
*To make your own angular directive: `ng g directive`*

An example of a custom **attribute** directive for changing background color on highlight:
```ts
@Directive({
  selector: '[appBetterHighlight]'
})
export class BetterHighlightDirective implements OnInit {
  @Input() defaultColor: string = 'transparent';
  @Input('appBetterHighlight') highlightColor: string = 'blue';
  @HostBinding('style.backgroundColor') backgroundColor: string;

  constructor(private elRef: ElementRef, private renderer: Renderer2) { }

  ngOnInit() {
    this.backgroundColor = this.defaultColor;
  }

  @HostListener('mouseenter') mouseover(eventData: Event) {
    this.backgroundColor = this.highlightColor;
  }

  @HostListener('mouseleave') mouseleave(eventData: Event) {
    this.backgroundColor = this.defaultColor;
  }

}
```

```html
<p [appBetterHighlight]="'red'" [defaultColor]="'yellow'">Style me with a better directive!</p>
```
>**Idea:** Create a directive that accepts a number of css classes to apply when that component is highlighted
to avoid having to create a ton of ::hover properties in our style sheets.