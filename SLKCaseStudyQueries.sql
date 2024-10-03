CREATE TABLE [FoodApp808].[dbo].[Menus] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [FoodId] INT NOT NULL, 
    [EmailId] NVARCHAR(255) NOT NULL, 
    [FoodName] NVARCHAR(255) NOT NULL, 
    [FoodPrice] DECIMAL(10, 2) NOT NULL 
);


CREATE TABLE [FoodApp808].[dbo].[Orders] (
    [CustomerId] INT IDENTITY(1,1) PRIMARY KEY, 
    [RestroEmailID] NVARCHAR(255) NOT NULL, 
    [CustEmailID] NVARCHAR(255) NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [TotalAmt] DECIMAL(10, 2) NOT NULL, 
    [CustomerAddress] NVARCHAR(500) NULL, 
    [OrderDateTime] DATETIME NOT NULL 
);


CREATE TABLE [FoodApp808].[dbo].[Registeration] (
    [EmailID] NVARCHAR(255) PRIMARY KEY, 
    [RestaurantName] NVARCHAR(255) NOT NULL, 
    [SellerName] NVARCHAR(255) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL, 
    [ConfirmPassword] NVARCHAR(255) NOT NULL, 
    [RestaurantAddress] NVARCHAR(500) NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [State] NVARCHAR(100) NOT NULL,
    [Pincode] NVARCHAR(10) NOT NULL 
);

CREATE TABLE [FoodApp808].[dbo].[Signup] (
    [CustomerId] INT IDENTITY(1,1) PRIMARY KEY, 
    [CustomerName] NVARCHAR(255) NOT NULL, 
    [EmailID] NVARCHAR(255) UNIQUE NOT NULL,
    [Password] NVARCHAR(255) NOT NULL, 
    [ConfirmPassword] NVARCHAR(255) NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [CustomerAddress] NVARCHAR(500) NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [State] NVARCHAR(100) NOT NULL, 
    [Pincode] NVARCHAR(10) NOT NULL 
);


CREATE TABLE [FoodApp808].[dbo].[Status] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [CustomerEmail] NVARCHAR(255) NOT NULL,
    [RestaurantEmail] NVARCHAR(255) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL 
);
