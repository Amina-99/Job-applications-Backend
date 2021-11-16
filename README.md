# Job applications  - Backend
In this project I simulated the backend of a Job application system using ASP.NET Core 5.0 and the frontend using Angular. My aim was to comply with SOLID coding principles.

## Installation
1. First of all, you need to open backend solution. 
2. The second step is to modify the database connection string. Change it in appsettings.json -> appsettings.Development.json to your connection string from database.
3. Run ASP.NET Core project with IIS Express.
   * While IIS Express is running, it can select different ports on different computers. Therefore, if the port number localhost:41329 is different, change it in Angular 
   project via environment.ts.
4. If the port number of frontend is different than localhost:4200, change it in Startup.cs in function Configure via app.UseCors. Without this frontend will
not be able to access backend because of CORS policy. 
5. The access data for admin (displaying all received job applications) are Username : HrAdmin and Password: Admin
