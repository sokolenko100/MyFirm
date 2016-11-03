CREATE DATABASE MyFirm 
COLLATE Cyrillic_General_CI_AS
GO
CREATE TABLE Employees
(emp_id       int          NOT NULL IDENTITY,
emp_login     varchar (30) NOT NULL,
emp_password  varchar (30) NOT NULL,
emp_name      varchar (20) NOT NULL,
emp_surName   varchar (20) NOT NULL,
emp_phone     varchar (12) NOT NULL,
emp_email     varchar (30)     NULL,
emp_dateBirth date  NULL
CONSTRAINT PK_Emplloyees PRIMARY KEY (emp_id)
)
GO
CREATE TABLE Tasks
(task_id int               NOT  NULL IDENTITY,
emp_id int                 NULL,
task_name varchar (20) NOT NULL,
task_dateils varchar (150) NULL,
task_status varchar (20)   NULL,
task_date date         NOT NULL DEFAULT GETDATE()
)
GO
CREATE TABLE Customers
(emp_id int                   NULL,
cust_id int               NOT NULL IDENTITY,
cust_name varchar (20)    NOT NULL,
cust_surName varchar (20) NOT NULL,
cust_address varchar (30)     NULL,
cust_phone varchar (12)   NOT NULL,
cust_email varchar (30)       NULL,
cust_dateBirth date           NULL
)
GO
CREATE TABLE CustomersOrders
(
customersOrders_id int  NOT NULL IDENTITY,
order_id int        NULL,
cust_id  int        NULL, 
CONSTRAINT PK_CustomersOrders PRIMARY KEY (customersOrders_id),
CONSTRAINT FK_OrdersCustomer_id FOREIGN KEY(cust_id) REFERENCES Customers(cust_id)ON DELETE SET NULL,
CONSTRAINT FK_CustomersOrder_id FOREIGN KEY(order_id) REFERENCES Orders(order_id)ON DELETE SET NULL
)
CREATE TABLE Orders
(order_id int               NOT  NULL IDENTITY,
order_prodCount int              NULL,
order_dateils varchar (100)      NULL,
order_status varchar  (20)       NULL,
order_date date             NOT  NULL DEFAULT GETDATE()
)
GO
CREATE TABLE OrdersProducts
(ordersProducts_id int  NOT NULL IDENTITY,
order_id int       NULL,
prod_id int        NULL,
CONSTRAINT PK_OrdersProducts PRIMARY KEY (ordersProducts_id),
CONSTRAINT FK_OrdersProduct_id FOREIGN KEY(prod_id) REFERENCES Products(prod_id) ON DELETE SET NULL,
CONSTRAINT FK_ProductsOrder_id FOREIGN KEY(order_id) REFERENCES Orders(order_id) ON DELETE SET NULL
)
CREATE TABLE Products
(prod_id       int             NOT NULL IDENTITY, 
prod_name      varchar(20)     NOT NULL,
prod_dump      varchar (20)        NULL,
prod_litter    varchar (12)        NULL,
prod_oilness   varchar (12)        NULL,
prod_density   varchar (12)        NULL,
prod_bit       varchar (12)        NULL,
prod_kernelImpurety   varchar (12) NULL,
prod_protein   varchar (12)        NULL,
prod_Price     money               NULL,
prod_Qty        int                NULL,
)
GO

ALTER TABLE Tasks
ADD
CONSTRAINT PK_Tasks PRIMARY KEY (task_id)
GO
ALTER TABLE Customers
ADD
CONSTRAINT PK_Customer PRIMARY KEY (cust_id)
GO
ALTER TABLE Orders
ADD
CONSTRAINT PK_Orders PRIMARY KEY (order_id)
GO
ALTER TABLE Products
ADD
CONSTRAINT PK_Products PRIMARY KEY (prod_id)
GO
ALTER TABLE Customers
ADD 
CONSTRAINT FK_Customer_Employees FOREIGN KEY(emp_id) REFERENCES Employees(emp_id)
ON DELETE SET NULL
GO
ALTER TABLE Tasks
ADD
CONSTRAINT FK_Tasks_Employees FOREIGN KEY(emp_id) REFERENCES Employees(emp_id) 
ON DELETE CASCADE
GO
ALTER TABLE Employees
ADD
CONSTRAINT EN_Employees_Phone
CHECK (emp_phone LIKE'([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO
ALTER TABLE Customers
ADD
CONSTRAINT EN_Customers_Phone
CHECK (cust_phone LIKE'([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO

INSERT INTO Products (prod_name,prod_litter,prod_oilness,prod_density,prod_bit,prod_kernelImpurety,prod_protein,prod_Price,prod_Qty)
VALUES('kernel seeds','10','30','700','6','12','-',400,5000),
('kernel seeds','10','30','700','6','12','-',400,5000),
('kernel seeds','10','30','700','6','12','-',400,5000)
GO
SELECT *FROM Products
GO

INSERT INTO Employees(emp_name,emp_surName,emp_phone,emp_email, emp_dateBirth,emp_login,emp_password)
VALUES  ('Roman','Romanenko','(098)5874626','romanenko@mail.ru',CAST('1992-05-09' as date),'roma','roma'),
('Dima','Petrenko','(098)0891326','petrenko@mail.ru',CAST('1994-06-09' as date),'dima','dima'),
('Andru','Petrenko','(098)0891326','petrenko@mail.ru',CAST('1998-07-09' as date),'andru','andru'),
('Slava','Petrenko','(098)0891326','petrenko@mail.ru',CAST('1998-03-09' as date),'slava','slava')
GO

SELECT *FROM Employees
Go


INSERT INTO Customers(emp_id,cust_name,cust_surName,cust_phone,cust_email, cust_dateBirth,cust_address)
VALUES  (1,'Roman','Romanenko','(098)5874626','romanenko@mail.ru',CAST('1992-05-09' as date),'Petrova str.'),
(2,'Dima','Petrenko','(098)0891326','petrenko@mail.ru',CAST('1994-06-09' as date),'Tokarnaay str'),
(3,'Andru','Petrenko','(098)0891326','petrenko@mail.ru',CAST('1998-07-09' as date),'Shevchenko str')
--(31,'Slava','Petrenko','(098)0891326','petrenko@mail.ru',CAST('1998-03-09' as date),'Nagirna str')
GO

SELECT *FROM Customers
GO
INSERT INTO Orders(order_dateils,order_date,order_status)
VALUES
('Deteils',CAST('1992-05-09' as date),'Stat'),
('Deteils',CAST('1992-05-09' as date),'Stat'),
('Deteils',CAST('1992-05-09' as date),'Stat')
GO

SELECT *FROM Orders
GO

INSERT INTO Tasks(task_name,task_dateils,task_date,task_status,emp_id)
VALUES
('Hello','Deteils',CAST('2000-05-09' as date),'Status',1),
('World','Deteils',CAST('2000-05-09' as date),'Status',2),
('Hello','Deteils',CAST('2000-05-09' as date),'Status',3)
GO
SELECT *FROM Tasks
GO
