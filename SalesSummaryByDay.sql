CREATE TABLE [GraduationProject].[dbo].[SalesSummaryByDay] (
    [Date] DATE,
    [Product] NVARCHAR(255),
    [NumberOfSales] INT,
    [NumberOfProductSold] INT
);

INSERT INTO [GraduationProject].[dbo].[SalesSummaryByDay] ([Date], [Product], [NumberOfSales], [NumberOfProductSold])
SELECT 
    CONVERT(date, so.OrderDate) AS [Date],
    p.Name AS [Product],
    COUNT(soi.Id) AS [Number of Sales],
    SUM(soi.Quantity) AS [Number of Product Sold]
FROM 
    [GraduationProject].[dbo].[SalesOrder] so
JOIN 
    [GraduationProject].[dbo].[SalesOrderItem] soi ON so.Id = soi.SalesOrderId
JOIN 
    [GraduationProject].[dbo].[Product] p ON soi.ProductId = p.Id
WHERE 
    so.IsNotDeleted = 1 AND soi.IsNotDeleted = 1
GROUP BY 
    CONVERT(date, so.OrderDate), p.Name
ORDER BY 
    [Date], [Product];
