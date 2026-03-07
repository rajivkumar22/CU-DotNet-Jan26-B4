--Level 1: The Join Foundation
--Focus: Inner Joins and basic multi-table connections.
--1.	Basic Linking: List all Product Names along with their Category Names.
--2.	Order Details: Display every Order ID alongside the Company Name of the customer who placed it.
--3.	Supplier Tracking: Show all Product Names and the Company Name of their respective suppliers.
--4.	Employee Sales: List all Orders (ID and Date) and the First/Last Name of the employee who processed them.
--5.	International Logistics: Find all Orders shipped to "France," showing the Order ID and the Company Name of the Shipper (from the Shippers table).

select p.ProductName, c.CategoryName
from Products p
inner join 
Categories c on c.CategoryID = p.CategoryID;

select o.OrderID, c.CompanyName
from Orders o
inner join 
Customers c on c.CustomerID = o.CustomerID;


select p.ProductName, s.CompanyName
from Products p
inner join 
Suppliers s on s.SupplierID = p.SupplierID;

select o.OrderID,o.OrderDate, (e.FirstName + ' '+ e.LastName) as FullName
from Orders o 
inner join Employees e
on e.EmployeeID = o.EmployeeID;

select o.OrderID,s.CompanyName
from Orders o
inner join Shippers s 
on s.ShipperID = o.ShipVia
where o.ShipCountry = 'France';


--Level 2: Aggregations with Joins
--Focus: Using GROUP BY across multiple tables.
--6.	Category Stock: Show the Category Name and the total number of units in stock for that category.
--7.	Customer Spend: List the Company Name and the total amount of money (Price $\times$ Quantity) they have spent across all orders.
--8.	Employee Performance: Display the Last Name of each employee and the total number of orders they have taken.
--9.	Shipping Costs: Find the total Freight charges paid to each Shipper company.
--10.	Top Products: List the top 5 Product Names based on total quantity sold.

select c.CategoryName,count(p.UnitsInStock) as TotalUnits
from Categories c
inner join Products p
on p.CategoryID = c.CategoryID
group by c.CategoryName;

select s.CompanyName,Sum(p.UnitPrice * p.UnitsInStock) as TotalUnits
from Suppliers s
inner join Products p
on p.SupplierID = s.SupplierID
group by s.CompanyName;

select e.LastName,Count(o.OrderID)
from Employees e
inner join Orders o
on o.EmployeeID = e.EmployeeID
group by e.LastName;

select s.CompanyName,sum(o.Freight)
from Orders o 
inner join Shippers s
on s.ShipperID = o.ShipVia
group by s.CompanyName;

select top 5
p.ProductName , sum(o.Quantity) as Total
from Products p
inner join [Order Details] o
on o.ProductID = p.ProductID
group by p.ProductName
order by total desc;


--Level 3: Subqueries & Self-Joins
--Focus: Nested queries and tables referencing themselves.
--11.	Above Average: List all Product Names whose UnitPrice is greater than the average price of all products.
--12.	The Bosses: Use a Self-Join on the Employees table to show each employee's name and their manager's name.
--13.	No Orders: Find all Customers (Company Name) who have never placed an order (Use NOT IN or NOT EXISTS).
--14.	High-Value Orders: Identify Order IDs where the total order value is higher than the average order value of the entire database.
--15.	Late Bloomers: Select Product Names that have never been ordered after the year 1997.
   
SELECT ProductName 
FROM Products 
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);  
  
  
SELECT e.FirstName AS Employee, m.FirstName AS Manager 
FROM Employees e 
LEFT JOIN Employees m 
ON e.ReportsTo = m.EmployeeID;  

  
SELECT CompanyName 
FROM Customers 
WHERE CustomerID NOT IN 
(SELECT CustomerID FROM Orders);  
  
SELECT OrderID 
FROM [Order Details] 
GROUP BY OrderID 
HAVING SUM(UnitPrice * Quantity) > 
(SELECT AVG(TotalValue) 
FROM (SELECT SUM(UnitPrice * Quantity) AS TotalValue 
FROM [Order Details]
GROUP BY OrderID) AS AvgTable);  


SELECT ProductName 
FROM Products 
WHERE ProductID NOT IN 
(SELECT ProductID FROM [Order Details] od 
JOIN Orders o ON od.OrderID = o.OrderID 
WHERE YEAR(o.OrderDate) > 1997);  


--Level 4: Complex Logic & Advanced Joins
--Focus: Multiple joins, HAVING clauses, and correlated subqueries.
--16.	Territory Coverage: List all Employees and the names of the Regions they cover (requires joining Employees, EmployeeTerritories, Territories, and Region).
--17.	Duplicate Cities: Find Customers and Suppliers who are located in the same city.
--18.	Multi-Category Customers: List Customers who have purchased products from more than 3 different categories.
--19.	Discontinued Sales: Calculate the total revenue generated only by products that are currently Discontinued.
--20.	Correlated Subquery: For each Category, list the most expensive product name and its price.

  

SELECT e.FirstName, e.LastName, r.RegionDescription 
FROM Employees e JOIN EmployeeTerritories et 
ON e.EmployeeID = et.EmployeeID JOIN Territories t 
ON et.TerritoryID = t.TerritoryID JOIN Region r 
ON t.RegionID = r.RegionID;  
  
  
SELECT c.CompanyName, s.CompanyName, c.City 
FROM Customers c JOIN Suppliers s 
ON c.City = s.City;  
  
SELECT c.CompanyName 
FROM Customers c 
JOIN Orders o 
ON c.CustomerID = o.CustomerID 
JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID GROUP BY c.CompanyName HAVING COUNT(DISTINCT p.CategoryID) > 3;  
 
 
SELECT SUM(od.UnitPrice * od.Quantity) 
FROM [Order Details] od 
JOIN Products p 
ON od.ProductID = p.ProductID 
WHERE p.Discontinued = 1;  
  
-- Correlated Subquery:    
SELECT CategoryID, ProductName, UnitPrice 
FROM Products p1 
WHERE UnitPrice = (SELECT MAX(UnitPrice) FROM Products p2 WHERE p2.CategoryID = p1.CategoryID);