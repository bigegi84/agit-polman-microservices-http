# agit-polman-microservices-http


-cara membuat service

-buat folder service-something, buka foldernya

dotnet new webapi

-install library nya

dotnet add package Microsoft.EntityFrameworkCore.Sqlite (kalo memakai sql server ganti dengan lib sql server)

dotnet add package Microsoft.EntityFrameworkCore.Design

-setelah koding modelnya kalian bisa buat db nya denga cara (ini auto, tekniknya di namakan code first yaitu kalian coding dulu baru nanti db nya nyesuain kode kalian)

dotnet ef migrations add InitialCreate

dotnet ef database update

-untuk run servicenya

dotnet run (run biasa)

dotnet watch (run dengan hot reload, jalanin sambil coding)
