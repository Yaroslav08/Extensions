[![NuGet](https://img.shields.io/nuget/v/Yaroslav08.Extensions.svg)](https://www.nuget.org/packages/Yaroslav08.Extensions)
# Extensions
 This is a small library for work with basic functions
## Download
For install this library paste next code to your PMC
```csharp
Install-Package Yaroslav08.Extensions -Version 1.3.0
```
or select in Nuget "Yaroslav08.Extensions"

 ## Usage IP Geolocation
 ### First scenario
 ```csharp
 IpAPIClient ipclient = new IpAPIClient();
 ```
 For getting info we need call a next method:
 ```csharp
 var info = await ipclient.GetFullInfo("13.107.246.10");
 ```
 Or this method
 ```csharp
 var info = await ipclient.GetShortInfo("13.107.246.10");
 ```
 ### Second scenario
  ```csharp
 IpAPIClient ipclient = new IpAPIClient("13.107.246.10");
 var info = await ipclient.GetFullInfo();
 ```
 
  ## Usage Date Extension
  ### Get full date
```csharp
new DateTime(2020, 3, 12, 20, 20, 20);
Console.WriteLine(date.GetBasic(false)); // print "20:20"
```

### Get string date in English
```csharp
DateExtension date = new DateExtension(Language.English, DateTime instance); //Init English language

new DateTime(2020, 3, 12, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "Today at 20:20"

new DateTime(2020, 3, 11, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "Yesterday at 20:20"

new DateTime(2020, 3, 10, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "10 march at 20:20"

new DateTime(2019, 3, 10, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "10 march 2019 at 20:20"
```

### Отримати строкову дату українською мовою
```csharp
DateExtension date = new DateExtension(DateExt.Language.Ukrainian, DateTime instance); //Init Ukrainian language

new DateTime(2020, 3, 12, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "Сьогодні о 20:20"

new DateTime(2020, 3, 11, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "Учора о 20:20"

new DateTime(2020, 3, 10, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "10 березня о 20:20"

new DateTime(2019, 3, 10, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "10 березня 2019 о 20:20"
```

### Получить строковую дату на русском языке
```csharp
DateExtension date = new DateExtension(DateExt.Language.Russian, DateTime instance); //Init Russian language

new DateTime(2020, 3, 12, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "Сегодня в 20:20"

new DateTime(2020, 3, 11, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "Вчера в 20:20"

new DateTime(2020, 3, 10, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "10 марта в 20:20"

new DateTime(2019, 3, 10, 20, 20, 20);
Console.WriteLine(date.GetBasic(true)); // print "10 марта 2019 в 20:20"
```
### Get Unix time
```csharp
Console.WriteLine(DateExtension.ConvertDateTimeToUnix(DateTime.Now)); //print 1584645300
```
### Get DateTime
```csharp
Console.WriteLine(DateExtension.ConvertUnixToDateTime(1584645300).Day); //print 19
```
