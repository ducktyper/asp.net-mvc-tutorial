# asp.net-mvc-tutorial
The goal of this project is to provide a quick way to find how to do things in ASP.NET MVC

so we can focus on solving the real problems.

This repository contains branch based tutorials. Each small task is represented in few commits in a branch.

## Environments
- Visual studio 2013
- ASP.NET MVC 5.2.2
- .NET 4.5
- EntityFramework 6.1.1

## Tutorials
#### 1. [Create a new MVC project](https://github.com/ducktyper/asp.net-mvc-tutorial/commits/mvc-init)

Create a default MVC project.

#### 2. [Scaffolding](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/mvc-init...scaffold-products)

Create a Product model and scaffold it which automatically generates a controller and views providing
CRUD operations for that model.

#### 3. [Use migrations](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/scaffold-products...code-first-migrations)

Default MVC project creates the database once automatically based on models but there is no way to update the structure since then.
Using migrations can solve this issue.

#### 4. [Add a new field to a model](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/code-first-migrations...add-field)

Create a new field to a model and update the controller and views.

#### 5. [Test a scaffolded controller](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/scaffold-products...test-scaffold)

Test general and edge cases of each action from a scaffolded controller.

#### 6. [Add a validation](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/test-scaffold...add-validation)

Add `[Required]` validation to a field and test.

#### 7. [Customize validation messages](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/add-validation...validation-custom-message)

Customize the field name and error message to `[Required]` validation

#### 8. [Use native validations](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/mvc-init...native-validations)

Create a House model and add fields having many types of native validations.

#### 9. [Add custom validations](https://github.com/ducktyper/asp.net-mvc-tutorial/compare/mvc-init...custom-validation)

Create a Product model and add different types of custom validations.

1. Custom validation to a field
2. Custom validation to a field having a parameter
3. Custom validation to a class
