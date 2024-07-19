INSERT INTO [GraduationProject].[dbo].[SalesSummaryByDay] 
    ([Date], [ProductId], [ProductName], [NumberOfSales], [NumberOfProductSold], [RowGuid],[IsNotDeleted])
SELECT 
    CONVERT(date, so.OrderDate) AS [Date],
    p.Id AS [ProductId],      
    p.Name AS [ProductName],
    COUNT(soi.Id) AS [NumberOfSales],
    SUM(soi.Quantity) AS [NumberOfProductSold],
    NEWID() AS [RowGuid],
	 1 AS [IsNotDeleted]
FROM 
    [GraduationProject].[dbo].[SalesOrder] so
JOIN 
    [GraduationProject].[dbo].[SalesOrderItem] soi ON so.Id = soi.SalesOrderId
JOIN 
    [GraduationProject].[dbo].[Product] p ON soi.ProductId = p.Id
WHERE 
    so.IsNotDeleted = 1 AND soi.IsNotDeleted = 1
GROUP BY 
    CONVERT(date, so.OrderDate), p.Id, p.Name
ORDER BY 
    [Date], [ProductId];
