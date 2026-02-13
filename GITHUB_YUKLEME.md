# Projeyi GitHub'a Yükleme

## 1. GitHub'da yeni repo aç (henüz yoksa)

1. https://github.com adresine git, giriş yap.
2. Sağ üst **"+"** → **"New repository"**.
3. **Repository name:** `CarServiceTracking` (veya istediğin isim).
4. **Public** seç.
5. **"Add a README"** işaretleme (proje zaten var).
6. **Create repository** tıkla.

---

## 2. Bilgisayarındaki projeyi GitHub’a bağla

Proje klasöründe **Terminal** veya **PowerShell** aç (`C:\Users\zeyne\source\repos\CarServiceTracking`).

**Eğer bu proje için ilk kez GitHub’a atıyorsan:**

```bash
git remote add origin https://github.com/KULLANICI_ADIN/CarServiceTracking.git
```

`KULLANICI_ADIN` yerine kendi GitHub kullanıcı adını yaz.  
(Zaten `origin` varsa ve farklı bir repoya atmak istiyorsan:  
`git remote set-url origin https://github.com/KULLANICI_ADIN/CarServiceTracking.git`)

---

## 3. Tüm değişiklikleri ekle ve commit at

```bash
git add .
git commit -m "Proje teslime hazır"
```

---

## 4. GitHub’a gönder (push)

```bash
git push -u origin master
```

(Branch adın `main` ise: `git push -u origin main`)

---

## Özet (tek seferde)

```bash
cd C:\Users\zeyne\source\repos\CarServiceTracking
git remote set-url origin https://github.com/KULLANICI_ADIN/CarServiceTracking.git
git add .
git commit -m "Proje teslime hazır"
git push -u origin master
```

GitHub kullanıcı adı ve şifre (veya token) isterse gir; push’tan sonra proje GitHub’da görünür.
