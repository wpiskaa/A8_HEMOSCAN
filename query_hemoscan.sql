-- ============================================================
-- HEMOSCAN - Script Database Lengkap
-- Dengan Foreign Key dan Relasi Tabel yang Benar
-- ============================================================

-- Buat Database
CREATE DATABASE HEMOSCAN;
GO

USE HEMOSCAN;
GO

-- ============================================================
-- TABEL 1: Tabel_Unit_Medis (Tabel Induk/Parent)
-- Menyimpan data semua unit medis: PMI dan Rumah Sakit
-- ============================================================
CREATE TABLE Tabel_Unit_Medis (
    ID_Unit     INT PRIMARY KEY IDENTITY(1,1),
    Nama_Unit   VARCHAR(100)  NOT NULL,
    Alamat      VARCHAR(255),
    Kategori    VARCHAR(20)   CHECK (Kategori IN ('PMI', 'RumahSakit'))
);
GO

-- ============================================================
-- TABEL 2: Tabel_Kantong_Darah (Tabel Anak/Child)
-- Berelasi ke Tabel_Unit_Medis via FOREIGN KEY ID_Unit
-- ============================================================
CREATE TABLE Tabel_Kantong_Darah (
    ID_Kantong      INT PRIMARY KEY IDENTITY(1,1),
    Gol_Darah       VARCHAR(2)  NOT NULL CHECK (Gol_Darah IN ('A', 'B', 'AB', 'O')),
    Rhesus          VARCHAR(3)  NOT NULL CHECK (Rhesus IN ('+', '-')),
    Tgl_Kadaluwarsa DATE        NOT NULL,
    Status          VARCHAR(20) NOT NULL DEFAULT 'Tersedia',
    ID_Unit         INT         NOT NULL,

    -- Deklarasi FOREIGN KEY yang menghubungkan ke Tabel_Unit_Medis
    CONSTRAINT FK_KantongDarah_UnitMedis
        FOREIGN KEY (ID_Unit) REFERENCES Tabel_Unit_Medis(ID_Unit)
);
GO

-- ============================================================
-- TABEL 3: Tabel_User
-- Menyimpan akun login. Role berisi: adminPMI, stafRS, Manajer
-- ============================================================
CREATE TABLE Tabel_User (
    Username    VARCHAR(50) PRIMARY KEY,
    Password    VARCHAR(50) NOT NULL,
    Role        VARCHAR(20) NOT NULL CHECK (Role IN ('adminPMI', 'stafRS', 'Manajer'))
);
GO

-- ============================================================
-- TABEL 4: Tabel_Request (Tabel Anak/Child)
-- Permintaan darah dari RS ke PMI.
-- Berelasi ke Tabel_Unit_Medis via FOREIGN KEY ID_Unit_Peminta
-- ============================================================
CREATE TABLE Tabel_Request (
    ID_Request          INT PRIMARY KEY IDENTITY(1,1),
    Golongan_Darah      VARCHAR(5)  NOT NULL,
    Status_Permintaan   VARCHAR(20) NOT NULL DEFAULT 'Pending',
    Tanggal_Request     DATETIME    NOT NULL DEFAULT GETDATE(),
    ID_Unit_Peminta     INT         NOT NULL,

    -- Deklarasi FOREIGN KEY yang menghubungkan Request ke Unit Medis (RS peminta)
    CONSTRAINT FK_Request_UnitMedis
        FOREIGN KEY (ID_Unit_Peminta) REFERENCES Tabel_Unit_Medis(ID_Unit)
);
GO

-- ============================================================
-- INSERT DATA AWAL (Seed Data)
-- ============================================================

-- Data Unit Medis (1 PMI + 3 Rumah Sakit)
INSERT INTO Tabel_Unit_Medis (Nama_Unit, Alamat, Kategori) VALUES
('PMI Kota Yogyakarta',      'Jl. Lempuyangan No.1, Yogyakarta',         'PMI'),
('RS Bethesda Yogyakarta',   'Jl. Jend. Sudirman No.70, Yogyakarta',     'RumahSakit'),
('RS PKU Muhammadiyah',      'Jl. KH. Ahmad Dahlan No.20, Yogyakarta',   'RumahSakit'),
('RSUP Dr. Sardjito',        'Jl. Kesehatan No.1, Sleman',               'RumahSakit');
GO

-- Data User Login
INSERT INTO Tabel_User (Username, Password, Role) VALUES
('admin1',   'admin123',   'adminPMI'),
('staf1',    'staf123',    'stafRS'),
('bos1',     'manajer123', 'Manajer');
GO

-- Data Kantong Darah (ID_Unit=1 = PMI Yogyakarta)
INSERT INTO Tabel_Kantong_Darah (Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit) VALUES
('A',  '+', DATEADD(DAY, 35, GETDATE()), 'Tersedia', 1),
('A',  '-', DATEADD(DAY, 30, GETDATE()), 'Tersedia', 1),
('B',  '+', DATEADD(DAY, 28, GETDATE()), 'Tersedia', 1),
('B',  '+', DATEADD(DAY, 40, GETDATE()), 'Tersedia', 1),
('AB', '+', DATEADD(DAY, 20, GETDATE()), 'Tersedia', 1),
('O',  '+', DATEADD(DAY, 15, GETDATE()), 'Tersedia', 1),
('O',  '-', DATEADD(DAY, 10, GETDATE()), 'Tersedia', 1),
('O',  '+', DATEADD(DAY, 25, GETDATE()), 'Tersedia', 1);
GO

-- Data Request Awal (ID_Unit_Peminta=2 = RS Bethesda, ID_Unit_Peminta=3 = RS PKU)
INSERT INTO Tabel_Request (Golongan_Darah, Status_Permintaan, Tanggal_Request, ID_Unit_Peminta) VALUES
('A',  'Pending', GETDATE(), 2),
('O',  'Pending', GETDATE(), 3),
('AB', 'Dikirim', DATEADD(DAY, -1, GETDATE()), 2);
GO

-- ============================================================
-- VERIFIKASI: Query JOIN untuk mengecek relasi sudah benar
-- ============================================================
-- Cek relasi Kantong Darah dengan Nama Unit PMI:
SELECT K.ID_Kantong, K.Gol_Darah, K.Rhesus, K.Status, U.Nama_Unit
FROM Tabel_Kantong_Darah K
INNER JOIN Tabel_Unit_Medis U ON K.ID_Unit = U.ID_Unit;

-- Cek relasi Request dengan Nama Rumah Sakit Peminta:
SELECT R.ID_Request, R.Golongan_Darah, R.Status_Permintaan, R.Tanggal_Request, U.Nama_Unit AS Nama_RS
FROM Tabel_Request R
INNER JOIN Tabel_Unit_Medis U ON R.ID_Unit_Peminta = U.ID_Unit
ORDER BY R.Tanggal_Request DESC;