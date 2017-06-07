# Restaurant

#### A program that allows users to input information about their favorite restaurants and it's details.  Trying to replicate Yelp!

#### By **Jun Fritz and Anabel Ramirez**

## Description

A website created with C#, SQL, and HTML where a user can input data into an "restaurant" database.

### Specs
| Spec | Input(action) | Output(display) |
| :-------------     | :------------- | :------------- |
| **Only owners can add restaurant to the cuisine database.** | add Hank's Hot Dogs & Josie's Tavern | Hank's Hot Dog, Josie's Tavern|
| **Only owners can delete an restaurant listing.** | delete Hank's Hot Dogs | Josie's Tavern |
| **User can query the cuisine type list.** | list all restaurants in "Italian" | list all Italian cuisine restaurants |
| **Multiple owners can add multiple restaurants to a cuisine.** | form add name, availability | name, date of admittance, gender, breed |

## Setup/Installation Requirements

1. To run this program, you must have a C# compiler. I use [Mono](http://www.mono-project.com).
2. Install the [Nancy](http://nancyfx.org/) framework to use the view engine. Follow the link for installation instructions.
3. Clone this repository.
4. Open the command line--I use PowerShell--and navigate into the repository. Use the command "dnx kestrel" to start the server.
5. On your browser, navigate to "localhost:5004" and enjoy!

## Known Bugs
* No known bugs at this time.

## Technologies Used
  * C#
  * Nancy framework
  * Razor View Engine
  * ASP.NET Kestrel HTTP server
  * xUnit
  * SQL
  * HTML

## Support and contact details

_Email us with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Jun Fritz, Anabel Ramirez}_**
