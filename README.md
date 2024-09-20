Emlak Yönetim Sistemi

Bu proje, emlak ilanlarının yönetimi ve kullanıcı yönetimi için geliştirilmiş bir Emlak Yönetim Sistemi'dir. Sistem, ölçeklenebilirlik, güvenlik ve modern yazılım geliştirme ilkelerine odaklanarak tasarlanmıştır.
Özellikler

    Emlak İlanları: Yeni emlak ilanları oluşturabilir, düzenleyebilir ve silebilir. Her ilan, konum, fiyat ve açıklama gibi detayları içerir.
    İlan Onaylama: Admin kullanıcılar, ilanları onaylayabilir veya silebilir.
    Mülk Detay Görünümü: Kullanıcılar, mülk detaylarına erişip daha fazla bilgi alabilirler.

Kullanılan Teknolojiler

    .NET Core 8: Projenin backend API'si, ölçeklenebilirlik ve dayanıklılık sağlamak amacıyla .NET Core 8 framework kullanılarak inşa edilmiştir.
    ASP.NET MVC: Frontend kısmı ASP.NET MVC ile inşa edilmiştir, bu yapı düzenli bir yapıyı ve verimli routing’i sağlar.
    Entity Framework Core: Veritabanı yönetimi için Entity Framework Core kullanılmış olup, SQL Server veritabanı ile sorunsuz entegrasyon sağlar.
    FluentValidation: Kullanıcı girdilerini ve form verilerini doğrulamak için güçlü tipte doğrulama kuralları oluşturan bir kütüphane kullanılmıştır.
    SQL Server: Emlak detayları, kullanıcı bilgileri ve diğer verilerin depolanması için SQL Server kullanılmıştır.
    Bootstrap: Frontend tasarımı için Bootstrap kullanılarak modern ve duyarlı bir arayüz sağlanmıştır.
    AutoMapper: Entityler ve DTO'lar (Data Transfer Object) arasındaki dönüşümleri yönetmek için kullanılmıştır, bu sayede veri modelleri daha temiz bir şekilde işlenir.
    CQRS (Command Query Responsibility Segregation): Veri okuma ve yazma işlemlerini ayıran bu pattern, sistemin performansını ve bakımını artırmak için kullanılmıştır.
    MediatR: Uygulama içindeki istekleri ve komutları merkezileştiren bir yapıdır. CQRS ile entegre olarak, işlemlerin işlenmesini sağlar ve sınıflar arası bağımlılıkları minimize eder.

Kullanılan Design Pattern'ler

    Repository Pattern: Veritabanı işlemlerinin soyutlanması ve daha temiz bir kod yapısı için kullanılmıştır.
    Unit of Work Pattern: Birden fazla repository ile çalışırken, işlemlerin tek bir bağlamda yönetilmesi sağlanarak veri tutarlılığı garanti altına alınmıştır.
    Dependency Injection: Bağımlılıkların gevşek bağlanması için kullanılmıştır, böylece sınıflar arası bağımlılıklar enjekte edilerek modüler bir yapı oluşturulmuştur.
    Singleton Pattern: Özellikle konfigürasyon ve loglama gibi sınırlı sayıda örneği olan nesnelerin yönetiminde kullanılmıştır.
    CQRS Pattern: Veri okuma ve yazma işlemlerinin ayrılması için kullanılmıştır.
    Mediator Pattern (MediatR): Komutlar ve sorgular arasındaki etkileşimi yöneterek, kodun daha düzenli ve genişletilebilir olmasını sağlar.

Kurulum

    Depoyu klonlayın:

    bash

git clone https://github.com/sumeyyesabirli/RealEstateCase.git

Proje dizinine gidin ve bağımlılıkları yükleyin:

bash

cd RealEstateCase
dotnet restore

Veritabanı güncellemelerini uygulayın:

bash

dotnet ef database update
update-database

Uygulamayı çalıştırın:

bash

    dotnet run

Kullanım

Uygulama çalıştırıldığında şunları yapabilirsiniz:

    Emlak ilanı oluşturun: Detaylı bilgilerle yeni emlak ilanları oluşturabilir.
    İlanları yönetin: İlanları onaylayabilir veya silebilir.
