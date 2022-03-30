# Umbrella
Create a .net website with skinny controllers, ddd, and mvc, business logic and data layering

## appsettings.json
```
{
    "Environment": "production",
    "ConnectionStrings": {
        "DefaultDNS": "Server=serverdnsname; Database=mydatabase; User ID=myuserid; Password=mypassword; Max Pool Size=1000;",
        "DefaultIP": "Server=serveripaddress; Database=mydatabase; User ID=myuserid; Password=mypassword; Max Pool Size=1000;"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft": "Warning",
            "Microsoft.Hosting.Lifetime": "Information"
        }
    },
    "AllowedHosts": "*"

}
```

## appsettings.development.json
```
{
    "Environment": "production",
    "ConnectionStrings": {
        "DefaultDNS": "Server=serverdnsname; Database=mydatabase; User ID=myuserid; Password=mypassword; Max Pool Size=1000;",
        "DefaultIP": "Server=serveripaddress; Database=mydatabase; User ID=myuserid; Password=mypassword; Max Pool Size=1000;"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft": "Warning",
            "Microsoft.Hosting.Lifetime": "Information"
        }
    },
    "AllowedHosts": "*"

}
```