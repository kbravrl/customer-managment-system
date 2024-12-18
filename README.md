# customer-managment-system

Bu proje, ASP.NET Core Razor Pages ve MySQL kullanılarak oluşturulmuş basit bir Müşteri Yönetim Sistemidir. Kullanıcıların müşteri kayıtlarını oluşturmasına, okumasına, güncellemesine ve silmesine olanak tanır.

## Özellikler
- **Müşterileri Listele**: Tüm müşterileri tablo biçiminde görüntüleyin.
- **Müşteri Oluştur**: Yeni müşteri ayrıntıları ekleyin.
- **Müşteriyi Düzenle**: Mevcut müşteri bilgilerini güncelleyin.
- **Müşteriyi Sil**: Bir müşteri kaydını kaldırın.

## Kullanılan Teknolojiler
- ASP.NET Core
- Razor Pages
- MySQL

## Önkoşullar
- .NET SDK
- MySQL Server
- MySQL Workbench

## Veritabanı  
- CREATE TABLE customers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    firstname VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone VARCHAR(20),
    address VARCHAR(255),
    company VARCHAR(100),
    notes TEXT,
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
  );

https://github.com/user-attachments/assets/bfd9cdee-9366-451f-8973-f9c96cd028ec
