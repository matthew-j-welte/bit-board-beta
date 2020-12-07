# Forms

<br><br><br>

# Pipes

List of all builtin Angular Pipes: https://angular.io/api?type=pipe

By default pipes only rerender when the value being passed in changes but if you need
the pipe to rerender when ever anything on the page changes you can cgabge pure to false
on the pipe like so:

```ts
@Pipe({
    name: 'filter',
    pure: false
})
```
