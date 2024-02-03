![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/53d62c44-45f4-4e94-8cff-0f7b0eecd9c2)
![image](https://github.com/erdem-abat/UdemyCarBook/assets/28300161/72177712-ca84-4e7f-8e29-dda1e7425820)


Kullanılan Teknolojiler
Backend
C#: Backend tarafında C# dili kullanılmıştır.
MSSQL: Veritabanı olarak Microsoft SQL Server kullanılmıştır.
Swagger: API dokümantasyonu için Swagger kullanılmıştır.
Code First Yaklaşımı
Frontend
HTML: Sayfaların yapılandırılması için HTML kullanılmıştır.
CSS: Stillerin belirlenmesi için CSS kullanılmıştır.
JavaScript: Sayfa etkileşimleri için JavaScript kullanılmıştır.
Proje Yapısı ve Katmanlı Mimarisi

Controllers: API isteklerini karşılayan Controller sınıfları bulunur.
CQRS: Veritabanı işlemlerinin yapıldığı CQRS sınıfları bulunur.
Mediator: Veritabanı işlemlerinin yapıldığı Mediator sınıfları bulunur.
Repositories: Veritabanı işlemlerinin yapıldığı Repository sınıfları bulunur.
DTOs: Gerekli olan verilerin sadece belirli bileşenlerle paylaşıldığı DTO sınıfları bulunur.

API Endpoints
Aşağıda projenin API endpoint'leri bulunmaktadır:(Diğer Tüm Tablolar için Aynı İşlemler Yapıldı)

GET /api/cars: Tüm arabaları getirir.
GET /api/locations/id: Belirli bir lokasyonu ID'ye göre getirir.
POST /api/banners: Yeni bir banner ekler.
PUT /api/abouts/id: Belirli bir hakkımda detayını günceller.
DELETE /api/comments/id: Belirli bir yorumu siler.
