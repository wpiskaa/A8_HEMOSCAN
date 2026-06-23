-- ============================================================
-- HEMOSCAN - INSERT DATA DUMMY LENGKAP
-- Jalankan script ini di SSMS setelah HemoScan_SQL_Setup.sql
-- ============================================================

USE HEMOSCAN;
GO

-- ============================================================
-- BERSIHKAN DATA LAMA (urutan penting karena FK)
-- ============================================================
DELETE FROM Tabel_Request;
DELETE FROM Tabel_Kantong_Darah;
DELETE FROM Backup_Kantong_Darah;
DELETE FROM Tabel_Unit_Medis;
DELETE FROM Tabel_User;
GO

-- Reset identity counter
DBCC CHECKIDENT ('Tabel_Unit_Medis',    RESEED, 0);
DBCC CHECKIDENT ('Tabel_Kantong_Darah', RESEED, 0);
DBCC CHECKIDENT ('Tabel_Request',       RESEED, 0);
GO

-- ============================================================
-- 1. TABEL_USER  (3 akun: AdminPMI, Manajer, StafRS)
-- ============================================================
INSERT INTO Tabel_User (Username, Password, Role) VALUES
    ('admin1',  'admin123',   'adminPMI'),
    ('bos1',    'manajer123', 'Manajer'),
    ('staf1',   'staf123',    'stafRS');
GO

-- ============================================================
-- 2. TABEL_UNIT_MEDIS  (1 PMI + 3 Rumah Sakit)
-- ============================================================
INSERT INTO Tabel_Unit_Medis (Nama_Unit, Alamat, Kategori) VALUES
    ('PMI Kota Yogyakarta',    'Jl. Lempuyangan No.1, Yogyakarta',          'PMI'),
    ('RS Bethesda Yogyakarta', 'Jl. Jend. Sudirman No.70, Yogyakarta',      'RumahSakit'),
    ('RS PKU Muhammadiyah',    'Jl. KH. Ahmad Dahlan No.20, Yogyakarta',    'RumahSakit'),
    ('RSUP Dr. Sardjito',      'Jl. Kesehatan No.1, Sleman',                'RumahSakit');
GO

-- ============================================================
-- 3. TABEL_KANTONG_DARAH  (20 kantong, berbagai gol + rhesus)
-- ============================================================
INSERT INTO Tabel_Kantong_Darah (Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit) VALUES
    -- Golongan A
    ('A',  '+', DATEADD(DAY, 30, GETDATE()), 'Tersedia', 1),
    ('A',  '+', DATEADD(DAY, 25, GETDATE()), 'Tersedia', 1),
    ('A',  '-', DATEADD(DAY, 20, GETDATE()), 'Tersedia', 1),
    -- Golongan B
    ('B',  '+', DATEADD(DAY, 28, GETDATE()), 'Tersedia', 1),
    ('B',  '+', DATEADD(DAY, 15, GETDATE()), 'Tersedia', 1),
    ('B',  '-', DATEADD(DAY, 10, GETDATE()), 'Tersedia', 1),
    -- Golongan AB
    ('AB', '+', DATEADD(DAY, 35, GETDATE()), 'Tersedia', 1),
    ('AB', '+', DATEADD(DAY, 12, GETDATE()), 'Tersedia', 1),
    ('AB', '-', DATEADD(DAY, 18, GETDATE()), 'Tersedia', 1),
    -- Golongan O
    ('O',  '+', DATEADD(DAY, 32, GETDATE()), 'Tersedia', 1),
    ('O',  '+', DATEADD(DAY, 22, GETDATE()), 'Tersedia', 1),
    ('O',  '+', DATEADD(DAY,  8, GETDATE()), 'Tersedia', 1),
    ('O',  '-', DATEADD(DAY, 14, GETDATE()), 'Tersedia', 1),
    -- Kantong sudah Dikirim (tidak muncul di stok tersedia)
    ('A',  '+', DATEADD(DAY,  5, GETDATE()), 'Dikirim',  1),
    ('B',  '+', DATEADD(DAY,  3, GETDATE()), 'Dikirim',  1),
    ('O',  '-', DATEADD(DAY,  7, GETDATE()), 'Dikirim',  1),
    -- Kantong hampir kadaluwarsa (≤ 5 hari → kritis di UI)
    ('A',  '+', DATEADD(DAY,  2, GETDATE()), 'Tersedia', 1),
    ('AB', '+', DATEADD(DAY,  4, GETDATE()), 'Tersedia', 1),
    ('O',  '+', DATEADD(DAY,  1, GETDATE()), 'Tersedia', 1),
    ('B',  '-', DATEADD(DAY,  3, GETDATE()), 'Tersedia', 1);
GO

-- ============================================================
-- 4. TABEL_REQUEST  (10 permintaan: berbagai status)
-- ============================================================
INSERT INTO Tabel_Request (Golongan_Darah, Status_Permintaan, Tanggal_Request, ID_Unit_Peminta) VALUES
    -- Sudah Dikirim (riwayat)
    ('A+',  'Dikirim', DATEADD(DAY, -10, GETDATE()), 2),
    ('O+',  'Dikirim', DATEADD(DAY,  -9, GETDATE()), 3),
    ('AB+', 'Dikirim', DATEADD(DAY,  -8, GETDATE()), 2),
    ('B+',  'Dikirim', DATEADD(DAY,  -7, GETDATE()), 4),
    ('O-',  'Dikirim', DATEADD(DAY,  -6, GETDATE()), 3),
    ('A-',  'Dikirim', DATEADD(DAY,  -5, GETDATE()), 4),
    -- Masih Pending (antrian Admin PMI)
    ('O+',  'Pending', DATEADD(DAY,  -3, GETDATE()), 2),
    ('AB+', 'Pending', DATEADD(DAY,  -2, GETDATE()), 3),
    ('B-',  'Pending', DATEADD(DAY,  -1, GETDATE()), 4),
    ('A+',  'Pending', GETDATE(),                    2);
GO

-- ============================================================
-- 5. BACKUP TABEL KANTONG DARAH (ambil semua data yang baru di-insert)
-- ============================================================
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Backup_Kantong_Darah')
    TRUNCATE TABLE Backup_Kantong_Darah;

INSERT INTO Backup_Kantong_Darah
    SELECT ID_Kantong, Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit
    FROM Tabel_Kantong_Darah;
GO

-- ============================================================
-- VERIFIKASI DATA
-- ============================================================
PRINT '============================================================';
PRINT 'DATA DUMMY BERHASIL DIINSERT:';
SELECT 'Tabel_User'          AS Tabel, COUNT(*) AS Jumlah FROM Tabel_User
UNION ALL
SELECT 'Tabel_Unit_Medis',    COUNT(*) FROM Tabel_Unit_Medis
UNION ALL
SELECT 'Tabel_Kantong_Darah', COUNT(*) FROM Tabel_Kantong_Darah
UNION ALL
SELECT 'Tabel_Request',       COUNT(*) FROM Tabel_Request
UNION ALL
SELECT 'Backup_Kantong_Darah',COUNT(*) FROM Backup_Kantong_Darah;
GO

PRINT '';
PRINT 'TEST VIEW vw_LaporanPermintaan:';
SELECT * FROM vw_LaporanPermintaan ORDER BY Tanggal_Request DESC;
GO

PRINT '';
PRINT 'TEST VIEW vw_StokDarahPublik:';
SELECT * FROM vw_StokDarahPublik ORDER BY ID_Kantong;
GO

PRINT '';
PRINT 'TEST VIEW vw_RequestPending:';
SELECT * FROM vw_RequestPending ORDER BY Tanggal_Request DESC;
GO
PRINT '============================================================';
GO
