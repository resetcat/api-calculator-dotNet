# api-calculator-dotNet
---
### Project Description
1. C# .NET project that takes API calls and makes calculations depending on the input type.
2. authorization is done through header api key
3. all returns are in json format
4. Also has a country list in alphabetical order

---

### Requirements:
Copy this project: `git@github.com:resetcat/api-calculator-dotNet.git`

---
### Launch from console
1. Have .NET installed on your system. You can download it here https://dotnet.microsoft.com/download
3. Navigate to the project directory in the console and open folder `api-calc-net`<br />
4. Run the project using the command:
```
    dotnet run
```
---
### Launch from your IDE
You can also run the .NET application from an IDE that supports it, such as Visual Studio,
Visual studio code, or Rider.
1. Open solution file in your compiler
2. Press f5 to compile project and Swagger will automatically open in working port

---
### Endpoint description
1. `http://localhost:7286/api/calculator/task1` send a get request with your `json` body <br /> example:
```json
[
   {
      "x": 4,
      "y": 5,
      "operation": "*"
   }
]
 ``` 
return should be like this:
```json
[
   20
]
```
2. `http://localhost:7286/api/calculator/task2` send a get request with your `json` body <br /> example:
```json
[
   "1+1+1+1","5+5","1*2*3*4*5"
]
```
return would be:
```json
[
   4,
   10,
   120
]
```
3. `http://localhost:7286/api/calculator/task3` send a get request with your `json` body <br /> example:
```json
[
   [1,2,3,5,4],[2,6,3],[2,-4,10,11,2]
]
```
return:
```json
[
  {
    "biggest": 5,
    "smallest": 1
  },
  {
    "biggest": 6,
    "smallest": 2
  },
  {
    "biggest": 11,
    "smallest": -4
  }
]
```
4. `http://localhost:7286/api/countries` send a get request, and you will receive a list of countries in alphabetical order:
```json
{
   "countries": [
      "Afghanistan",
      "Albania",
      "Algeria",
      ...
   ]
}
```