# Test-IOMundo

Hey, this is a small repo that I have created with the intention of completing the IOMundo test for the Junior Developer position.

#Note

This project is based on C# ASP.NET MVC Framework, whilst the database configuration was based on PostgreSQL.
If you want to check the seeding of the database, you must be in the 'Test-IOMundo' directory and run the command `dotnet run seeddata`.
If you want to run the seeding whenever buidling the project, remove the if statement around the `Seed.SeedData(app)` line.

#Assignment Information

- The Seed file contains all the logic that should satisfy point 1.C
- The migrations and the model for the Offer should satisfy point 1.A
- The controllers (AccountController and OfferController) should satisfy point 2
