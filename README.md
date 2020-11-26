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

 ## Usage Tracker
 ```csharp
 public class Person
 {
    public int Id { get; set; }
    public string Name { get; set; }
    public string About { get; set; }
 }
 ```
 ### For create Tracker instance
 ```csharp
Tracker<Person> tracker = new Tracker<Person>(); //create instance
 ```
 ### If first record we must to call next method
 
 ```csharp
            Tracker<Person> tracker = new Tracker<Person>();
            tracker.Add(new Object<Person>
            {
                CreatedAt = DateTime.Now,
                OldState = new Person(),
                NewState = new Person(),
                ObjectId = "1",
                Objs = new List<Obj>
                {
                    new Obj
                    {
                        NameField = "Name",
                        OldValueField = "Yarik",
                        NewValueField = "Yaroslav"
                    },
                    new Obj
                    {
                        NameField = "About",
                        OldValueField = "Dev",
                        NewValueField = "Developer"
                    },
                }
            });
 ```
 
 ### If we already have JSON content in other entity we can upload string json via next method
 
 ```csharp
Tracker<Person> tracker = new Tracker<Person>({json_schema_in_string});
 ```
 or
  ```csharp
 tracker.Upload("{json_schema_in_string}");
  ```
 ### If we already have list, call next method for get content in JSON format as string
 ```csharp
 string content = tracker.Save();
 ```
 
 ## Also we can work with files
 
 ### We call method ImportFromFileAsync for upload content
 ```csharp
tracker.ImportFromFile("{path_to_file}");
 ```
 
 ### We call method ExportToFile for download content to file
 ```csharp
 tracker.ExportToFile("{path_to_file}", "{fileName.json}");
 ```
 ## Getting items
 
 ### For get last item we call GetLastItem method
 ```csharp
 var item = tracker.GetLastElement();
 ```
 
  ### For get first item we call GetFirstItem method
 ```csharp
 var item = tracker.GetFirstElement();
 ```
 ### For clear all items call Clear() method
 ```csharp
 tracker.Clear();
 ```
 ### For remove some element call Remove() method
 
 ```csharp
 tracker.Remove(tracker.GetLastElement()); // remove last element
 ```
 
 ### And last method, if we want get all items call GetCurrentObjects property
 ```csharp
 var allItems = tracker.GetAllElements();
 ```

