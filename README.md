# SanctionScanner



#  Sanction Scanner .Net BackEnd Case
## _Sanction Scanner Library Managementr_

## Contents

- .NET Core 6 Web API
- HTTP Verbs
- MSSQL
- Swagger UI
- Entity Framework Code First - EF Core
- Repository Design Pattern (AsyncGenericRepositroy and GenericRepository)
- IoC
- Business Rules (Comprehensive Business)
- CRUD Operations (CRUD Operations)
- Logger NLOG
- CSV - JSON - XML Data Output
- Pagging (Comprehensive Pagging Properties - Page Size, Page)
- Exceptions (Detailed Error Throwing) - Middleware
- BaseEntity 
- SOLID
- N-Tier Architecture
- Json Web Token
- Postman
- AutoMapper
- Validation
- Search
- Sort
- Data Shaper

Merhabalar.
<br/>
Veriler için database scripti oluşturuldu. Sadece data çıktısı mevcut. Bu işlemden önce appsettings.json dosyasından DB yolunu verip Update-Migration ( Manager Console ) komutunu çalıştırın. 
DataBase scripti dizin de rar'ın içinde bulunmakta. Db'i güncelledikten sonra bu dosyayı açıp f5'e basmanız yeterli olacaktır.
<br/>
<br/>
Uygulamayı test edebilmeniz için postman tarafında bir koleksiyon oluşturuldu. Lütfen bu koleksiyonu kullanarak testinizi yapınız. Test yaparken Account/Login servisinden token almayı unutmayın.
Oluşturulan koleksiyon dizin de rar'ın içinde bulunmakta. Koleksiyonu postman üzerinden import etmeniz yeterli olacaktır.
<br/>
<br/>
Uygulama içerisinde Book controlleri üzerinde çalışmalar gerçekleştirildi. İsterler yerine getirildi. Params'ları kullanarak istediğiniz dataya ulaşabilirsiniz. Örnek isteklerin hepsi koleksiyonda mevcut. 
Projenin bütün yapıları Books controlleri altında kullanıldı. Data Shaper, Sort, Search, Validation, AutoMapper gibi bir çok teknolojiyi orada kullandım. 
<br/>
<br/>
Proje içerisinde genel log ve hata yakalama çalışmaktadır. 
<br/>
<br/>
Vaka uygulamasında sorunu iki tablo kullanarak çözdüm. Books tablosunda bir kitabın kiralanıp kiralanmadığını bool değişkeninde tuttum. Book nesnesi ilk oluştuğunda yani create edildiğinde bu field false olarak geliyor. 
İkinci tabloda da bu kitabı kimin kiraladığını ve ne zamana kadar kiralık kalacağının datasını tuttum. Eğer book listelemesinde o field true dönerse kiralanmış anlamına gelmekte. Detay listesinde de 
kimin kiraladığını görebiliyoruz.
<br/>
<br/>


