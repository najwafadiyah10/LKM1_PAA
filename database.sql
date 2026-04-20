Create table pembeli(
id serial primary key,
nama varchar(255) not null,
no_telp varchar(15) not null,
alamat varchar(255), 
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
deleted_at TIMESTAMP NULL
)

create table menu(
id serial primary key,
nama_menu varchar(255) not null,
harga int not null,
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
deleted_at TIMESTAMP NULL
)

create table pesanan(
id serial primary key,
pembeli_id INT NOT NULL,
    menu_id INT NOT NULL,
    quantity INT NOT NULL,
    status VARCHAR(20) CHECK (status IN ('dibuat','selesai','dibatalkan')) DEFAULT 'dibuat',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	deleted_at TIMESTAMP NULL,
    FOREIGN KEY (pembeli_id) REFERENCES pembeli(id),
    FOREIGN KEY (menu_id) REFERENCES menu(id)
)


insert into pembeli(nama,no_telp, alamat)
values('tia', '0987654523', 'Banyuwangi'),
('najwa', '0987654523', 'Jember'),
('bintang', '0987654523', 'Jember'),
('rossa', '0987654523', 'Banyuwangi'),
('gebby', '0987654523', 'Lamongan')


insert into menu(nama_menu, harga)
values('Teh dandang', '3000'),
('SFC', '10000'),
('Soto Toba', '10000'),
('Es Teler Ikiwawa', '12000'),
('Risol Pitsa', '3000')

insert into pesanan(pembeli_id, menu_id, quantity, status)
values(2, 1, 3, 'dibuat'),
(3, 2, 1, 'selesai'),
(4, 3, 2, 'selesai'),
(5, 4, 5, 'dibatalkan'),
(5, 5, 3, 'dibuat')


select * from pembeli
select * from menu
select * from pesanan