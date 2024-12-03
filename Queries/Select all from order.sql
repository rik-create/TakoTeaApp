SELECT DISTINCT DATEPART(HOUR, OrderDate) AS OrderHour
FROM OrderModel
WHERE OrderDate >= '2024-12-2' AND OrderDate <= '2024-12-3'
ORDER BY OrderHour;

