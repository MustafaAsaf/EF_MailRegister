# MailRegister

MailRegister, kullanıcıların e-posta doğrulaması yaparak kayıt olmasını sağlayan bir C# Windows Forms uygulamasıdır. 
Proje, Entity Framework (Database First) ile veritabanına bağlanır ve MailKit kütüphanesi kullanılarak e-posta doğrulama işlemi gerçekleştirilir.

## Proje Özellikleri

* Kullanıcı kayıt (SignUp) formu

* Kullanıcıya 6 haneli doğrulama kodu gönderimi

* Kullanıcının doğrulama kodunu gireceği MailConfirm formu

* Doğrulama başarılı olursa UserIsConfirm alanının true olarak güncellenmesi

* Entity Framework (Database First) ile veritabanı yönetimi

* MailKit kütüphanesi ile e-posta gönderimi

## Kullanılan Teknolojiler

* C# (Windows Forms - WinForms)

* Entity Framework (Database First)

* MailKit (SMTP üzerinden e-posta gönderimi için)

* SQL Server (Veritabanı yönetimi için)

## Proje Yapısı
![image](https://github.com/user-attachments/assets/f39d491f-4b55-46f6-8abc-76c27eb2ef70)


## 📌 Projeyi Çalıştırma Adımları

### 1️⃣ Projeyi Klonlayın

Öncelikle projeyi GitHub üzerinden klonlayın:

![image](https://github.com/user-attachments/assets/ab8dbc8d-cb7f-4bbf-ac26-6c92ed2b9659)

### 2️⃣ Bağımlılıkları Yükleyin

Bu proje Entity Framework ve MailKit gibi bağımlılıkları kullanır. Aşağıdaki adımları takip edin:
#### 📦 NuGet Bağımlılıklarını Yükleyin
1. Visual Studio'yu açın.

2. Tools > NuGet Package Manager > Manage NuGet Packages for Solution seçeneğine gidin.

3. MailKit paketinin yüklü olduğundan emin olun. Eğer yüklü değilse, şu komutu çalıştırarak yükleyebilirsiniz:

4. Entity Framework paketinin yüklü olup olmadığını kontrol edin. Eğer yüklü değilse:
   
![image](https://github.com/user-attachments/assets/2dc73c3d-3612-433f-9c10-370c3661dc6d)

### 3️⃣ SQL Server Veritabanını Ayarlayın

1. Veri Tabanın Yedek Dosyasını Yükleyin
   
Projenin veri tabanın yedek dosyasını SQL Server Management Studio üzerinden entegre edebilirsiniz.

2. Connection String'i Güncelleyin
   
![image](https://github.com/user-attachments/assets/e2c6d668-f6de-4355-87c3-df520e2380a2)

Önemli!

YOUR_SERVER_NAME kısmını kendi SQL Server isminizle değiştirin.


### 4️⃣ Projeyi Çalıştırın

Visual Studio’da MailRegister.sln dosyasını açın.

Program.cs dosyasını çalıştırarak uygulamayı başlatın.


## Ekran Görüntüleri
![image](https://github.com/user-attachments/assets/3616648a-4073-4329-bd21-f752a0eac38d)

![image](https://github.com/user-attachments/assets/f18f3f8e-f8b9-4e2f-9863-6fd1d3c06a6c)

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasını inceleyebilirsiniz.



