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
*Use if trying to pass html into a custom made component (like children in react)*

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