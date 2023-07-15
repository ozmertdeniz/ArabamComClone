
# Arabam.com Clone API

Bu proje, bir mobil uygulama geliştirmesi için araç ilanlarını toplayan ve yayınlayan bir web API'sini içerir. Bu API, mobil uygulama geliştiricilerinin araç ilanlarına sorgu yapmasını, ilan detaylarını almasını ve ilanları ziyaret eden IP adreslerini kaydetmesini sağlar.

## Gereksinimler

- .NET 7.0 SDK
- Docker ve Docker Compose (veritabanı için)

```bash
https://github.com/ozmertdeniz/ArabamComClone.git
```

## Kurulum

Projeyi klonlayın 

```bash
https://github.com/ozmertdeniz/ArabamComClone.git
```
Veritabanı bilgilerinizi 'appsettings.json' dosyasından değiştirin.

Veritabanını ayağa kaldırmak için aşağıdaki komutu çalıştırın.
```bash
docker-compose up -d
```

## Kullanım

İlan Sorgulama
```bash
GET /advert/all?categoryId=1&price=50000&gear=Manuel&page=1
```
Bu uç nokta, araç ilanlarını filtrelemek ve sayfalama yapmak için kullanılabilir. İstenilen kriterlere göre ilanları filtreleyebilirsiniz.

İlan Detayları
```bash
GET /advert/get?id=15763767
Bu uç nokta, verilen id parametresine göre ilan detaylarını döndürür.
```
İlana Ziyaret Ekleme
```bash
POST /advert/visit
```
JSON istek gövdesinde aşağıdaki gibi advertId değerini göndererek ilana ziyaret ekleyebilirsiniz:

```bash
{
  "advertId": 15763767
}
```
