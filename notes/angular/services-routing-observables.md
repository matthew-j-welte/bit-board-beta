# Services

_A service doesn't have to be associated with http requests, it can also be some common functionality
that is leverages by multiple components - such as a logging service_

<br><br><br>

# Routing

If you only want arouterlink to be highlighted when its on the exact path use `routerLinkActiveOptions`, for ex:

```html
<li routerLinkActive="active" [routerLinkActiveOptions]="{exact: true}">
  <a routerLink="/"></a>
</li>
```

To inject the current route into a component, use `private route: ActivatedRoute` in any constructor
To navigate programatically relative to the current route, inject the route object and then do the following:

```ts
this.router.navigate(["somePath"], { relativeTo: this.route });
```

If instead of using a resolver for dynamic routes you simply just want to grab query params from the
component itself, you can do the following:

**This is bad practice because it wont rerender after visiting the component a second time**

:x:

```ts
constructor(private route: ActivatedRoute) { }

ngOnInit() {
    this.user = {id: this.route.snapshot.params['id']};
}
```

Coming from a routing declaration similar to this:

```ts
{
    path: 'users/:id',
    component: UserComponent
}
```

If you do just want the params and still dont want a resolver you should do the following instead:

:heavy_check_mark:

```ts
constructor(private route: ActivatedRoute) { }

ngOnInit() {
    this.route.params.subscribe((params: Params) => {
        this.user.id = params['id']
    })
}
```

<br>

## _Query params_

To pass query params programatically:

```ts
onLoadServer(id: number) {
    this.router.navigate(["servers", id, "edit"], {queryParams: { allowEdit: "1" }});
}
```

Then you can subscribe to those params just like you do with `params`, for ex:

```ts
constructor(private route: ActivatedRoute) { }

ngOnInit() {
    this.route.queryParams.subscribe((params) => {
        this.user.allowEdit = params['allowEdit'] === '1'
    })
}
```

<br>

## _Child (**Nested**) Routing_

Instead of a flat list you can split routes up like so:

```ts
const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "servers",
    component: ServersComponent,
    children: [
      { path: ":id", component: ServerComponent },
      { path: ":id/edit", component: EditServerComponent },
    ],
  },
];
```

**Important** - If you do this you need to remember to include another
`<router-outlet></router-outlet>` element inside of your `ServersComponent`.

<br>

## _Wildcard_

```ts
{ path: '**', redirectTo: '/not-found' }
```

## _Auth Guard_

An example of restricting access to a certain route (and its children) using an auth guard:

```ts
const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "servers",
    component: ServersComponent,
    canActivate: [AuthGuard]
    children: [
      { path: ":id", component: ServerComponent },
      { path: ":id/edit", component: EditServerComponent },
    ],
  },
];
```

An example of restricting access to a route's children routes using an auth guard:

```ts
const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "servers",
    component: ServersComponent,
    canActivateChild: [AuthGuard]
    children: [
      { path: ":id", component: ServerComponent },
      { path: ":id/edit", component: EditServerComponent },
    ],
  },
];
```

For both of these above, a sample auth guard can be used:

```ts
@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.authService.isAuthenticated().then((authenticated: boolean) => {
      if (authenticated) {
        return true;
      } else {
        this.router.navigate(["/"]);
      }
    });
  }

  canActivateChild(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.canActivate(route, state);
  }
}
```

<br><br><br>

# Observables

All angular based observables (route queryParams subscription, http etc.) are destroyed/unsubscribed
on their own and you dont have to worry about implementing the OnDestroy interface. But for custom
created observables you do or they will continue to exist in the background.

**Operators** - These are a way of transorming data before they are acted on by the subscription.

**Full observable example**:

```ts
ngOnInit() {
    const customIntervalObservable = Observable.create(observer => {
      let count = 0;
      setInterval(() => {
        observer.next(count);
        if (count === 5) {
          observer.complete();
        }
        if (count > 5) {
          observer.error(new Error('Count skipped 5!'));
        }
        count++;
      }, 1000);
    });

    this.firstObsSubscription = customIntervalObservable.subscribe(
        (data) => {
            console.log(data);
        }, 
        (error) => {
            console.log(error);
        }, 
        () => {
            console.log('Completed!');
        });
  }
```
