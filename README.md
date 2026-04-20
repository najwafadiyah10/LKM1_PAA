Nama : Najwa Dzakirah Fadiyah

NIM  : 242410102034

Kelas : PAA A

---

API Manajemen Pesanan Makanan adalah aplikasi berbasis **ASP.NET Core Web API** yang digunakan untuk mengelola data pelanggan, menu, dan pesanan. API ini mendukung operasi CRUD (Create, Read, Update, Delete) serta menerapkan relasi antar tabel untuk menjaga integritas 

--- 

Teknologi yang Digunakan
- ASP.NET Core Web API  
- PostgreSQL  
- Entity Framework Core  
- Swagger  
- SQL Query

---

Cara menjalankan project 

1. Clone Repository

    git clone https://github.com/najwafadiyah10/LKM1_PAA
  
2. Import Database

  - Buka PostgreSQL
  - Buat database dengan nama PAA_LKM1
  - Copy paste query yang ada di file database.sql lalu run

3. Buka file ```sqlDBHelper```
   Sesuaikan connection string: ```Host=127.0.0.1; port=5432; Database=PAA_LKM1; Username=postgres; Password=jungkook```

4. Buka Visual Studio lalu run project

---

Struktur Database

Pembeli
- id
- nama
- no_telp
- alamat
- created_at
- updated_at
- deleted_ad

Menu
- id
- nama_menu
- harga
- created_at
- updated_at
- deleted_at

Pesanan
- id
- pembeli_id
- menu_id
- quantity
- status
- created_at
- updated_at
- deleted_at

---

Endpoint API

Pembeli
| Method  | URL                  | Keterangan                              |
|---------|----------------------|-----------------------------------------|
| GET     | /api/pembeli         | Ambil semua data pembeli                |
| GET     | /api/pembeli/{id}    | Ambil detail pembeli berdasarkan ID     |
| POST    | /api/pembeli         | Tambah pembeli baru                     |
| PUT     | /api/pembeli/{id}    | Update data pembeli                     |
| DELETE  | /api/pembeli/{id}    | Hapus pembeli                           |

Menu
| Method  | URL                  | Keterangan                              |
|---------|----------------------|-----------------------------------------|
| GET     | /api/menus           | Ambil semua menu makanan                |
| GET     | /api/menus/{id}      | Ambil detail menu berdasarkan ID        |
| POST    | /api/menus           | Tambah menu baru                        |
| PUT     | /api/menus/{id}      | Update menu                             |
| DELETE  | /api/menus/{id}      | Hapus menu                              |

Pesanan
| Method  | URL                  | Keterangan                              |
|---------|----------------------|-----------------------------------------|
| GET     | /api/orders          | Ambil semua pesanan                     |
| GET     | /api/orders/{id}     | Ambil detail pesanan berdasarkan ID     |
| POST    | /api/orders          | Buat pesanan baru                       |
| PUT     | /api/orders/{id}     | Update pesanan                          |
| DELETE  | /api/orders/{id}     | Hapus pesanan                           |

---

Fitur Utama
- Implementasi RESTful API  
- Operasi CRUD pada seluruh entitas   
- Relasi antar tabel menggunakan foreign key  
- Dokumentasi dan pengujian API menggunakan Swagger

---

Contoh Request (Post Pembeli)
```bash
{
"nama": "Najwa",
"no_telp": "084567876545",
"alamat": "Jember"
}
```

Contoh response
```
{
  "status": "success",
  "message": "Pembeli berhasil ditambahkan"
}
```

---

Video Presentasi ```https://youtu.be/LfY-IEWsgYI```
