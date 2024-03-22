# HTMX For ASP.NET Core Developers Video Guide

This repository holds the sample projects used for my HTMX for ASP.NET Core developer's guide. 

## Getting Started

To get started, you'll need a minimum of .NET 6 SDK installed on your development machine. You can get the
latest SDK from [dot.net](https://dotnet.microsoft.com/download). While this course uses the latest 
version of .NET, the patterns and approaches can be adapted to target ASP.NET Core applications as low as .NET 3.1.

This guide uses [JetBrains Rider](https://jetbrains.com/rider) in its videos, and it is highly recommended, but is not required.

## Repository Structure

There are two logical solutions in this repository: Exercises and JetSwag Store. 
And each project exists in two versions: Start and End. For ease of navigating and following along,
they are included in a single .NET solution.

You can follow along by beginning with the `Start` version of a project. For folks interested in 
seeing the final result, they can look at the `End` version of a project.

```console
|- Exercises (solution folder)
    |- Exercises.Start
    |- Exercises.End
|- JetSwagStore (solution folder)
    |- JetSwagStore.Start
    |- JetSwagStore.End
    |- JetSwagStore.Shared (EF Core SQLite backend)
```

### Samples

Samples will walk you through common patterns you may use when adopting HTMX. This is similar to Kata work.

Your goal is to make every box return an expected result. From the start, no functionality
will be connected.

### JetSwag Store

This is a real-world sample, taking a working ASP.NET Core application and enhancing it with HTMX.

## Videos

[Link to Videos](https://www.jetbrains.com/guide/dotnet/tutorials/htmx-aspnetcore/)

## License

MIT License
