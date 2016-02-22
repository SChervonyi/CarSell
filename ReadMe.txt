How to Run
1) Create db, tables and test data from scripts in 'db' folder.
2) Correct connectionString in Web.Config to your DB.
3) Install packages from NuGet.
4) Ensure you have .Net 4.6 and C#6 compiller.

My examples:
1) On "Car" view you can delete items.
2) "Car Info" demonstrate simple cross apply
3) On "Manufacturer" you can edit and add new items.
4) ManufacturerController Index action demonstrate left join and groupBy queries.
5) ManufacturerController ShowCheap (show manufacturer where average car price less than 45 000) action demonstrate having query.