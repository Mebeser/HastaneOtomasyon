# HastaneOtomasyon

**HastaneOtomasyon**, hastane iş süreçlerini dijitalleştiren, ASP.NET Core ile geliştirilmiş RESTful bir Web API projesidir. Katmanlı mimari prensiplerine göre yapılandırılmış olup Docker üzerinde çalışan MS SQL Server ile entegre edilmiştir.

---

## 🏗️ Mimari

Proje, sorumlulukları birbirinden ayıran klasik katmanlı (Layered) mimari ile geliştirilmiştir:

```
HastaneOtomasyon/
├── Controllers/      # HTTP isteklerini karşılar, yönlendirir
├── Service/          # İş mantığı katmanı
├── DataAccess/       # Veritabanı erişim katmanı (EF Core)
├── Models/           # Entity'ler ve DTO'lar
└── Core/ReturnTypes/ # Ortak dönüş tipleri
```

---

## ⚙️ Teknoloji Stack

| Katman | Teknoloji |
|---|---|
| Framework | ASP.NET Core |
| ORM | Entity Framework Core |
| Veritabanı | MS SQL Server (Docker) |
| Migration | EF Core Migrations |
| API Dokümantasyonu | OpenAPI / Swagger |

---

## 🏥 Domain — Entity'ler

Sistem aşağıdaki temel hastane varlıklarını kapsamaktadır:

| Entity | Açıklama |
|---|---|
| `Doctor` | Doktor bilgileri ve departman ilişkisi |
| `Patient` | Hasta kayıt ve bilgi yönetimi |
| `Appointment` | Randevu oluşturma ve takibi |
| `MedicalRecord` | Tıbbi kayıt yönetimi |
| `Prescription` | Reçete oluşturma |
| `PrescriptionItem` | Reçete kalemleri ve ilaç ilişkisi |
| `Medicine` | İlaç bilgi yönetimi |
| `Department` | Hastane departmanları |
| `Room` | Oda ve yatak yönetimi |
| `Billing` | Faturalama ve ödeme takibi |

---

## 🚀 Kurulum

### Gereksinimler
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

### 1. Veritabanını Başlat (Docker)

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Password" \
  -p 1433:1433 --name hastane-sql \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Bağlantı Dizesini Ayarla

`appsettings.json` dosyasını düzenle:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=HastaneOtomasyonDb;User Id=sa;Password=YourStrong!Password;TrustServerCertificate=True"
  }
}
```

### 3. Migration'ları Uygula

```bash
dotnet ef database update
```

### 4. Uygulamayı Çalıştır

```bash
dotnet run
```

API endpoints Postman ile test edilmiştir.

---

## 📄 Lisans

MIT
