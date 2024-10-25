# Xəstəxana Randevu Sistemi 🏥 
Bu layihə, xəstələrin randevu alması, randevularını izləməsi 
və həkimlərlə rahat əlaqə qurması üçün hazırlanmış, istifadəçi dostu bir sistemdir.
Bu sistem, CodeAcademy Advanced Backend təliminin bitmə layihəsidir.

#### GEREKSİNİMLER 🛠   
  ![Asp.NET Web API](https://img.shields.io/badge/asp.net%20web%20api-%231BA3E8.svg?style=for-the-badge&logo=dotnet&logoColor=white)

#### Verilənlər Bazası:
- ![MsSQL Server](https://img.shields.io/badge/mssql%20server-%23CC2927.svg?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
- ![MongoDB](https://img.shields.io/badge/mongodb-%2347A248.svg?style=for-the-badge&logo=mongodb&logoColor=white)

#### Dokumentasiya üçün:
- ![Postman](https://img.shields.io/badge/postman-%23FF6C37.svg?style=for-the-badge&logo=postman&logoColor=white)
- ![Swagger](https://img.shields.io/badge/swagger-%2385EA2D.svg?style=for-the-badge&logo=swagger&logoColor=black)

#### Arxitektura:
- ![Onion Arxitektura](https://img.shields.io/badge/onion%20arxitektura-%237D7D7D.svg?style=for-the-badge&logo=generic&logoColor=white)

#### İstifadə olunan Design Pattern:
- ![MediatR](https://img.shields.io/badge/mediatr-%238B008B.svg?style=for-the-badge&logo=generic&logoColor=white)
- ![CQRS](https://img.shields.io/badge/cqrs-%23121011.svg?style=for-the-badge&logo=generic&logoColor=white)
- ![Repository Pattern](https://img.shields.io/badge/repository%20pattern-%2300BFFF.svg?style=for-the-badge&logo=generic&logoColor=white)

    #### LAYİHƏDƏ İSTİFADƏ OLUNAN TEXNOLOGİYALAR VƏ KİTABXANALAR 🛠️
<p>
  <img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white" />
  <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" />
  <img alt="Entity Framework" src="https://img.shields.io/badge/entity%20framework-%2358B9C9.svg?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="JWT" src="https://img.shields.io/badge/jwt-%23FFA500.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="AutoMapper" src="https://img.shields.io/badge/automapper-%23228B22.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="FluentValidation" src="https://img.shields.io/badge/fluentvalidation-%23563D7C.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="MailKit" src="https://img.shields.io/badge/mailkit-%234ABDAC.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="SMTP" src="https://img.shields.io/badge/smtp-%2300C7B7.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="Visual Studio" src="https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visualstudio&logoColor=white" />
  <img alt="Github" src="https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white" />
  <img alt="MongoDB" src="https://img.shields.io/badge/mongodb-%2347A248.svg?style=for-the-badge&logo=mongodb&logoColor=white" />
</p>

#### 📫 NECƏ BİR LAYİHƏ YARATDIQ?

<p> 5 tip istifadəçi vardir: </p>

➡️ 1- Admin/Yönetici 
- [x]  İş cədvəlini yeniləyə və ya silə bilər.
- [x] Xəstə məlumatlarını sıralaya, tənzimləyə və silə bilər. Lazım olduqda yeni xəstə əlavə edə bilər.
- [x] Xəstəxanaya həkim təyin edir. Həkim məlumatlarını sıralaya, yeniləyə və silə bilər.
- [x] Mövcud şöbələri sıralaya, tənzimləyə və silə bilər. Xəstəxanaya şöbə əlavə edə bilər.
- [x] Keçmiş və gələcək bütün görüşlərin detalları ilə tanış ola bilər. Yeni görüş yarada bilər.
- [x] Yazılmış hesabatların detalları ilə tanış ola bilər.
- [x] Ümumi görüş sayı, ümumi həkim sayı və ümumi şöbə sayı kimi metrikləri göstərən Statistikaları görüntüləyə bilər.

➡️ 2- Həkim
- [x] Bugünkü Görüşlərim - Yarınki Görüşlərim - İş Cədvim - Xəstə Hesabatları sahələrini əhatə edən Xülasə səhifəsini görüntüləyə bilər.
- [x] Görüşdə olan xəstələrinin məlumatlarını görüntüləyə bilər.
- [x] Onun tərəfindən alınan görüşləri Keçmiş Görüşlər & Gələcək Görüşlər sahəsində görüntüləyə bilər.
- [x] Yaratdığı hesabatların detalları ilə tanış ola bilər.

➡️ 3- Xəstə
- [x]  İstədiyi  həkimə görüş ala bilər. Lazım olduqda ləğv edə bilər.
- [x] Aldığı görüşləri Keçmiş Görüşlər & Gələcək Görüşlər sahəsində görüntüləyə bilər.

➡️ 4- Moderator
- [x] Bugünkü Görüşlərim - Gələcək Görüşlərim - Hesabatlarım - Geri Bildirimlərim sahələrini əhatə edən Xülasə səhifəsini görüntüləyə bilər.
- [x] İstədiyi şöbə və həkimə görüş ala bilər. Lazım olduqda ləğv edə bilər.
- [x] Aldığı görüşləri Keçmiş Görüşlər & Gələcək Görüşlər sahəsində görüntüləyə bilər.
- [x] Həkimin yaratdığı hesabatların detalları ilə tanış ola bilər.

➡️ 5- SuperAdmin
- [x] Hər bir əməliyyata giriş imkanı var.

## PROJE TƏFƏRRÜATLARI📝

Projemiz, .Net texnologiyasını əhatə edən müasir bir veb tətbiqidir. Projemizdə MsSQL istifadə edilmişdir.

Projemizde, **Onion mimarisi**, **Mediatr** **Repository Design Pattern** ve **CQRS (Command Query Responsibility Segregation)** pattern'ləri istifadə olunaraq daha modul və idarəolunan bir struktur təmin edilmişdir. Veritabanı əməliyyatları üçün **Entity Framework** istifadə edilmiş və **Code First** yanaşması qəbul olunmuşdur.

Əlavə olaraq, projede aşağıdakı mühüm kitabxanalar və alətlər istifadə olunur:
- **AutoMapper**: Obje dönüşümlərini asanlaşdırmaq üçün.
- **FluentValidation**: Məlumat doğrulama proseslərini idarə etmək üçün.
- **JWT (JSON Web Token)**: Kimlik doğrulama və icazələndirmə əməliyyatlarını təhlükəsiz bir şəkildə həyata keçirmək üçün.

Bu sayədə, projemiz yüksək performanslı, asan idarəolunan və təhlükəsiz bir mimariyə sahib olmuşdur.

🎯Projede verilənlər bazası bağlantı yolu appsetting.development.json içində yazılmışdır.
Bunu etməklə, tətbiqin içərisində bağlantı kodlarımızı yazmaq yerinə daha ümumi bir yerdə asanlıqla idarə olunmasını təmin etmişik. 
Beləliklə, bir hovuzdakı musluklar kimi, hansından istənilirsə, o muslukdan verilərin çəkilməsi təmin olunmuşdur.

```c#
 "ConnectionStrings": {
  "DockerCS": "Server=.,1433;Database=MyDatabase;User Id=sa;Password=Your_Strong_Password123!;TrustServerCertificate=True;",
  "DefaultConnection": "Server=localhost;Database=MyDatabase;Trusted_Connection=True;TrustServerCertificate=True;"  
  }
```





### 🔒 Proyektin Layihələri

Proyektimizin əsas və əlavə xidmət layihləri aşağıda göstərilmişdir:

### Əsas Layihələr
1. **EHospital.Domain**
   - Proyektin domen (domain) məntiqini əhatə edir. Biznes qaydaları və domen obyektləri bu layihədə müəyyən edilir.

2. **EHospital.Application**
   - Biznes məntiqinin idarə olunduğu layihədir. API ilə məlumat layihəsi arasındakı əlaqə bu layihə vasitəsilə təmin olunur.

3. **EHospital.Persistence**
   - Məlumat bazası ilə əlaqənin və məlumat əməliyyatlarının idarə edildiyi layihədir.

4. **EHospital.API**
   - İstifadəçi sorğularını qəbul edən, tətbiqin məntiqini işə salan və cavab verən API layihəsidir.

### Əlavə Xidmətlər
1. **ImageService**
   - Şəkillərin emalı və saxlanmasını idarə edən xidmət.

2. **Loging.Api**
   - Tətbiqin loglama və qeyd əməliyyatlarını idarə edən xidmət.

3. **NotificationService**
   - İstifadəçilərə bildiriş göndərmək üçün istifadə olunan xidmət.



-----------------------------------------------------------------------
## 🌱 DOMAIN LAYİHƏSİ

✎ Entity-lər Domain layihəsində yaradılmışdır. Aşağıda nümunə olaraq **Branch Entity** faylını görə bilərsiniz. Hər class üçün lazımsız kod təkrarının qarşısını almaq məqsədilə **Entity** adlı base class-dan miras alınır. Digər entity-ləri layihənin daxilində araşdıra bilərsiniz.

### Yaradılan Entity-lər
#### **Common** qovluğu daxilində:
- ⚡**BaseAuditableEntity**: Auditable (izlənə bilən) entity üçün baza sinifi.
- ⚡**BaseEntity**: Entity-lər üçün ümumi baza sinifi.

#### **Entities** qovluğu daxilində:
- ⚡ **Appointment**: Randevu məlumatlarını saxlayır.
- ⚡ **Doctor**: Həkim məlumatlarını saxlayır.
- ⚡ **DoctorSchedule**: Həkimin iş qrafiki məlumatlarını saxlayır.
- ⚡ **Patient**: Xəstə məlumatlarını saxlayır.
- ⚡**ContactInfo**: Əlaqə məlumatları.
- ⚡**Allergy**: Alergiya məlumatları.
- ⚡**ChatHistory**: Söhbət tarixçəsi.
- ⚡**EmergencyContact**: Təcili əlaqə məlumatları.
- ⚡**Hospital**: Xəstəxana məlumatları.
- ⚡**InsuranceDetails**: Sığorta məlumatları.
- ⚡**MedicalHistory**: Tibbi tarixçə.
- ⚡**Patient**: Xəstə məlumatları.
- ⚡**UserDeactivatedSchedule**: İstifadəçinin deaktiv edilmiş cədvəli.

#### **Auth Entity-lər**:
- ⚡**AppRole**: Tətbiqin rol məlumatlarını saxlayır.
- ⚡**AppUser**: Tətbiqin istifadəçi məlumatlarını saxlayır.


-----------------------------------------------------------------------

## 🌱 Persistence LAYİHƏSİ

**Persistence** layihəsi, tətbiqin məlumat bazası ilə olan əlaqəsini tənzimləyərək, məlumatların təhlükəsiz və effektiv şəkildə idarə olunmasını təmin edən bir layihədir.

✎ **Concretes**: Bu qovluq tətbiqdəki konkret (implementation) sinifləri ehtiva edir.

📌 **DAL (Data Access Layer)**: Məlumat bazasına giriş qatıdır. Məlumatların alınması, əlavə edilməsi, yenilənməsi və silinməsi əməliyyatları burada həyata keçirilir.

🖋 **Mappings**: Entity-lərin məlumat bazasında necə xəritələnəcəyini (mapping) təyin edən qovluqdur.

🔧 **Migrations**: Məlumat bazasında struktur dəyişikliklərini idarə etmək üçün istifadə olunur.

🌱 **Seed**: Tətbiqin başlanğıcında məlumat bazasına ilkin məlumatların (məsələn, **Role** əlavə etmək) doldurulması üçün istifadə olunur.

-----------------------------------------------------------------------

## 🌱 Application LAYİHƏSİ

**Application** layihəsi, tətbiqin iş məntiqinin qurulduğu və müxtəlif funksiyaların birləşdirildiyi qovluqları əhatə edir. Aşağıda bu qovluqların qısa izahları verilmişdir:

📂 **Abstractions**: Bu qovluq, tətbiqin müxtəlif xidmətlər və komponentlər üçün interfeyslərini (abstract layer) təmin edir. Bu, xidmətlərin tətbiqdən asılı olmadan istifadəsini təmin edir.

📂 **Behaviors**: Tətbiqin davranışlarını tənzimləyən qovluqdur. Məsələn, istək və cavabların işlənməsi prosesində xüsusi məntiqin icrası üçün istifadə olunur (mediatR davranışları kimi).

📂 **Dtos (Data Transfer Objects)**: Tətbiqdə məlumatların daşınması üçün istifadə olunan obyektlərdir. Məlumatlar üçün sərt struktur təqdim edir və tətbiqin müxtəlif layihləri arasında məlumat ötürülməsini asanlaşdırır.

📂 **Exceptions**: Tətbiqdə yaranan istisnaların idarə olunması üçün istifadə olunan qovluqdur. Hər hansı bir xəta və ya istisna halında xüsusi mesajların və davranışların göstərilməsi üçün işləyir.

📂 **Features**: Tətbiqin xüsusi funksiyalarını (features) idarə edən qovluqdur. Hər bir funksional qrup və ya modul üçün xüsusi məntiq burada təşkil olunur.

📂 **Mappers**: Entity-lərlə DTO-lar arasında məlumatların xəritələnməsini təmin edir. Məlumatların bir formadan digərinə çevrilməsi üçün istifadə olunur.

📂 **Middleware**: Tətbiqə əlavə funksional imkanlar təmin edən aralıq proqram təminatıdır. İstək və cavab axınlarında əlavə məntiq tətbiq etmək üçün istifadə olunur.

📂 **Validators**: Tətbiqdəki məlumatların doğruluğunu yoxlayan siniflər burada yerləşir. Məlumatların düzgün formatda olub-olmadığını və məntiqə uyğunluğunu yoxlamaq üçün istifadə olunur.

-----------------------------------------------------------------------

## 🌱 WEBAPI LAYİHƏSİ

⚓ Bu qat, əməliyyatların həyata keçirildiyi **Controller** siniflərinin yaradıldığı layihədir. API vasitəsilə istəklərin işlənməsi və müvafiq cavabların qaytarılması burada baş verir. Aşağıda **BranchController** faylının kodları nümunə olaraq göstərilmişdir.

Layihədə ümumilikdə 14 ədəd Controller sinfi mövcuddur. Bunlardan bəziləri **Narchgen Code Generator** vasitəsilə avtomatik yaradılmışdır. Aşağıda bu controller-lər göstərilmişdir:

- **AllergyController**
- **AppointmentController**
- **ChatController**
- **ChatHistoryController**
- **DoctorController**
- **DoctorSchedulesController**
- **HospitalController**
- **MedicalHistoryController**
- **NotificationController**
- **PatientController**
- **PatientsDoctorsController**
- **RolesController**
- **UsersController**

⚡ Bu controller-lər layihədə müxtəlif funksional xidmətlər üçün API son nöqtələrini təmin edir.

-----------------------------------------------------------------------



Görüşənədək 🎉
