# Problem: Categorize trades in a bank´s portfolio

A bank has a portfolio of thousands of trades and they need to be categorized. A trade is a commercial negotiation 
between a bank and a client.

Currently, there are three categories (in order of precedence):

1. EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will 
be given.
2. HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.

Question 1: Write a C# console application using object oriented design that classifies all trades in a given portfolio.
Keep in mind that the real application may have dozens of categories, so your design must be extensible allowing those
categories to be easily added/removed/modified in the future. The code can be sent in a GitHub link.

Input
The first line of the input is the reference date. The second line contains an integer n, the number of trades in 
the portfolio. The next n lines contain 3 elements each (separated by a space). First a double that represents 
trade amount, second a string that represents the client’s sector and third a date that represents the next 
pending payment. All dates are in the format mm/dd/yyyy.

Output
N lines with the category of each one of the n trades.

Sample input

12/11/2020 <br />
4 <br />
2000000 Private 12/29/2025 <br />
400000 Public 07/01/2020 <br />
5000000 Public 01/02/2024 <br />
3000000 Public 10/26/2023 <br />

Sample output

HIGHRISK <br />
EXPIRED <br />
MEDIUMRISK <br />
MEDIUMRISK
