![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/53d62c44-45f4-4e94-8cff-0f7b0eecd9c2)
![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/72177712-ca84-4e7f-8e29-dda1e7425820)
![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/d2a802f8-632a-4105-a1b4-a7cc360a53d3)
![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/e01e3d23-7c91-4872-b979-2960d8a434e5)
![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/3f52854f-59b3-44fc-ac17-4961620c863b)
![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/96d025c3-3a27-4c2d-9ffb-3abaaddd8517)


<b>Kullanılan Teknolojiler</b>

<b>Backend</b>

C#: Backend tarafında C# dili kullanılmıştır.

MSSQL: Veritabanı olarak Microsoft SQL Server kullanılmıştır.

Swagger: API dokümantasyonu için Swagger kullanılmıştır.

* Code First Yaklaşımı

<b>Frontend</b>

HTML: Sayfaların yapılandırılması için HTML kullanılmıştır.

CSS: Stillerin belirlenmesi için CSS kullanılmıştır.

JavaScript: Sayfa etkileşimleri için JavaScript kullanılmıştır.

<b>Proje Yapısı ve Katmanlı Mimarisi</b>

Controllers: API isteklerini karşılayan Controller sınıfları bulunur.

CQRS: Veritabanı işlemlerinin yapıldığı CQRS sınıfları bulunur.

Mediator: Veritabanı işlemlerinin yapıldığı Mediator sınıfları bulunur.

Repositories: Veritabanı işlemlerinin yapıldığı Repository sınıfları bulunur.

DTOs: Gerekli olan verilerin sadece belirli bileşenlerle paylaşıldığı DTO sınıfları bulunur.

<b>API Endpoints</b>

Aşağıda projenin API endpoint'leri bulunmaktadır:(Diğer Tüm Tablolar için Aynı İşlemler Yapıldı)

GET /api/cars: Tüm arabaları getirir.

GET /api/locations/id: Belirli bir lokasyonu ID'ye göre getirir.

POST /api/banners: Yeni bir banner ekler.

PUT /api/abouts/id: Belirli bir hakkımda detayını günceller.

DELETE /api/comments/id: Belirli bir yorumu siler.
