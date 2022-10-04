[Fluent Api - Mapping an index over more than one column across entity types.](https://github.com/dotnet/efcore/issues/11336)

1. 透過 Docker 運行 MySql
```
docker run -itd --name mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root mysql:5.7
```

2. 調整 ExampleDbContext.OnModelCreating 建立 Account(Aggregate).Username + Email(ValueObject).Value 的複合索引

3. 使用 dotnet ef tools 進行 migrations
```
dotnet ef migrations add AddCompositeIndex
```