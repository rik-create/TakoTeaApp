SELECT DISTINCT CAST(OrderDate AS Date) AS OrderDate
FROM OrderModel
WHERE OrderDate >= '2024-11-26' AND OrderDate <= '2024-12-3'
ORDER BY OrderDate;