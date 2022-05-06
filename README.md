# Dojo.Net


[![NuGet](https://img.shields.io/nuget/v/dojo.net.svg)](https://www.nuget.org/packages/Dojo.net/)


The official [Dojo][dojo] .NET library, supporting .NET Standard 2.0+, .NET Core 2.0+, and .NET Framework 4.6.1+.

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package Dojo.Net
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install Dojo.Net
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package Dojo.Net
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Dojo.Net".
5. Click on the Dojo.Net package, select the appropriate version in the
   right-tab and click *Install*.

## Documentation

For a comprehensive list of examples, check out the [API
documentation][api-docs].

## Usage

```c#
Dojo.Net.PaymentIntentsClient client = new PaymentIntentsClient(
    new HttpClient(),
    new ApiKeyClientAuthorization(apiKey));
```

### Use it as .net service

```c#
builder.Services.AddSingleton<IClientAuthorization>(new ApiKeyClientAuthorization(apiKey));
builder.Services.AddHttpClient<IPaymentIntentsClient, PaymentIntentsClient>();
```

### Automatic retries

The library does not automatically retries requests on intermittent failures like on a
connection error. We suggest you use [Polly][polly] library to setup retry policy.

```c#
builder.Services
    .AddHttpClient<IPaymentIntentsClient, PaymentIntentsClient>()
    .AddTransientHttpErrorPolicy(
        x => x.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt))));
```

For any requests, bug or comments, please [open an issue][issues] or [submit a
pull request][pulls].

[api-docs]: https://docs.dojo.tech
[api-keys]: https://portal.dojo.tech/apikeys
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[dotnet-format]: https://github.com/dotnet/format
[issues]: https://github.com/dojo-engineering/Dojo.Net/issues
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[pulls]: https://github.com/dojo-engineering/Dojo.Net/pulls
[dojo]: https://dojo.tech
[configure-http-client]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.httpclientfactoryservicecollectionextensions.addhttpclient?view=dotnet-plat-ext-6.0
[polly]: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly
