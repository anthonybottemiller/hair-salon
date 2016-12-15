#hair-salon

#####This project leverages the power of SQL to provide facilities dealing with stylist and customer data

#####By Anthony J Bottemiller - 12-9-2016

##Description
This project is intended to provide features that a Hair Salon may require.
Tracking Stylist details as well as similar details for customers.
Clients can be added to any particular stylist. All details are updateable
and deletable.

##Technologies Used
* HTML
* CSS
* BOOTSTRAP
* JavaScript
* jQuery
* C#
* Mono
* Nancy
* Razor
* xUnit
* SQL

##Requirements
* Modern Web Browser
* Mono
* DVNM Scripts
* Internet Access
* SQL Server

##Database Setup
Run these commands from PowerShell
* sqlcmd -S "(localdb)\mssqllocaldb"
* CREATE DATABASE hair_salon;
* GO;
* USE hair_salon;
* GO;
* CREATE TABLE stylists (id INT IDENTITY, name varchar(255));
* CREATE TABLE clients (id INT IDENTITY, stylist_id int, name VARCHAR(255));
* GO;
* CREATE DATABASE hair_salon_test
* GO;
* USE hair_salon_test;
* GO;
* CREATE TABLE stylists (id INT IDENTITY, name varchar(255));
* CREATE TABLE clients (id INT IDENTITY, stylist_id int, name VARCHAR(255));
* GO;

##Installation
* Clone repository
* Using command line change working directory to cloned repository
* Execute command "dnu restore" in order to resolve project dependencies
* Run "dnx kestrel" from project root
* Navigate to webserver using your favorite browser

##Legal
Copyright (c) 2016 Anthony J Bottemiller

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.