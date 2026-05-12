-- ============================================================
-- HEMOSCAN DATABASE SETUP
-- Script ini menambahkan fitur dari 3 Modul Referensi:
--   Modul 8  : DataSet & DataAdapter
--   Modul 9  : Advanced Database Security (VIEW)
--   Modul 10 : Stored Procedures
-- Jalankan script ini di SSMS sebelum menjalankan aplikasi
-- ============================================================

USE HEMOSCAN;
GO

-- ============================================================
-- MODUL 9: MEMBUAT VIEW (Keamanan Data)
-- Tujuan: Membatasi kolom yang boleh tampil ke client
--         sehingga data sensitif tidak bocor
-- ============================================================

-- VIEW stok darah publik (tanpa kolom sensitif)
IF OBJECT_ID('vw_StokDarahPublik', 'V') IS NOT NULL
    DROP VIEW vw_StokDarahPublik;
GO

CREATE VIEW vw_StokDarahPublik AS
    SELECT 
        K.ID_Kantong,
        K.Gol_Darah,
        K.Rhesus,
        K.Tgl_Kadaluwarsa,
        K.Status,
        U.Nama_Unit AS Unit_PMI
    FROM Tabel_Kantong_Darah K
    INNER JOIN Tabel_Unit_Medis U ON K.ID_Unit = U.ID_Unit
    WHERE K.Status = 'Tersedia';
GO

-- VIEW laporan permintaan (untuk Manajer — read-only)
IF OBJECT_ID('vw_LaporanPermintaan', 'V') IS NOT NULL
    DROP VIEW vw_LaporanPermintaan;
GO

CREATE VIEW vw_LaporanPermintaan AS
    SELECT 
        R.ID_Request,
        R.Golongan_Darah,
        R.Status_Permintaan,
        R.Tanggal_Request,
        U.Nama_Unit AS Nama_Rumah_Sakit,
        U.Alamat    AS Alamat_RS
    FROM Tabel_Request R
    INNER JOIN Tabel_Unit_Medis U ON R.ID_Unit_Peminta = U.ID_Unit;
GO

-- VIEW khusus permintaan pending (untuk AdminPMI)
IF OBJECT_ID('vw_RequestPending', 'V') IS NOT NULL
    DROP VIEW vw_RequestPending;
GO

CREATE VIEW vw_RequestPending AS
    SELECT 
        R.ID_Request,
        R.Golongan_Darah,
        R.Status_Permintaan,
        R.Tanggal_Request,
        U.Nama_Unit AS Nama_Rumah_Sakit
    FROM Tabel_Request R
    INNER JOIN Tabel_Unit_Medis U ON R.ID_Unit_Peminta = U.ID_Unit
    WHERE R.Status_Permintaan = 'Pending';
GO

PRINT 'VIEW berhasil dibuat.';
GO

-- ============================================================
-- MODUL 10: STORED PROCEDURES
-- ============================================================

-- SP 1: SELECT semua stok darah (dengan JOIN Unit)
IF OBJECT_ID('sp_GetAllStokDarah', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllStokDarah;
GO

CREATE PROCEDURE sp_GetAllStokDarah
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        K.ID_Kantong,
        K.Gol_Darah,
        K.Rhesus,
        K.Tgl_Kadaluwarsa,
        K.Status,
        U.Nama_Unit AS [Unit PMI]
    FROM Tabel_Kantong_Darah K
    INNER JOIN Tabel_Unit_Medis U ON K.ID_Unit = U.ID_Unit
    ORDER BY K.ID_Kantong;
END;
GO

-- SP 2: SELECT stok dengan filter golongan dan rhesus
IF OBJECT_ID('sp_CariStokDarah', 'P') IS NOT NULL
    DROP PROCEDURE sp_CariStokDarah;
GO

CREATE PROCEDURE sp_CariStokDarah
    @Gol_Darah NVARCHAR(5),
    @Rhesus    NVARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        K.ID_Kantong,
        K.Gol_Darah,
        K.Rhesus,
        K.Tgl_Kadaluwarsa,
        K.Status,
        U.Nama_Unit AS [Unit PMI]
    FROM Tabel_Kantong_Darah K
    INNER JOIN Tabel_Unit_Medis U ON K.ID_Unit = U.ID_Unit
    WHERE (K.Gol_Darah = @Gol_Darah OR @Gol_Darah = 'Semua')
      AND (K.Rhesus   = @Rhesus    OR @Rhesus    = 'Semua')
    ORDER BY K.ID_Kantong;
END;
GO

-- SP 3: INSERT kantong darah baru
IF OBJECT_ID('sp_InsertKantongDarah', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertKantongDarah;
GO

CREATE PROCEDURE sp_InsertKantongDarah
    @Gol_Darah NVARCHAR(5),
    @Rhesus    NVARCHAR(2),
    @ID_Unit   INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Tabel_Kantong_Darah (Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit)
    VALUES (@Gol_Darah, @Rhesus, DATEADD(DAY, 35, GETDATE()), 'Tersedia', @ID_Unit);
END;
GO

-- SP 4: UPDATE golongan dan rhesus kantong darah
IF OBJECT_ID('sp_UpdateKantongDarah', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateKantongDarah;
GO

CREATE PROCEDURE sp_UpdateKantongDarah
    @ID_Kantong INT,
    @Gol_Darah  NVARCHAR(5),
    @Rhesus     NVARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Tabel_Kantong_Darah
    SET Gol_Darah = @Gol_Darah,
        Rhesus    = @Rhesus
    WHERE ID_Kantong = @ID_Kantong;
END;
GO

-- SP 5: DELETE kantong darah
IF OBJECT_ID('sp_DeleteKantongDarah', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteKantongDarah;
GO

CREATE PROCEDURE sp_DeleteKantongDarah
    @ID_Kantong INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Tabel_Kantong_Darah WHERE ID_Kantong = @ID_Kantong;
END;
GO

-- SP 6: COUNT stok tersedia (OUTPUT Parameter — Modul 10 Langkah 6)
IF OBJECT_ID('sp_CountStokTersedia', 'P') IS NOT NULL
    DROP PROCEDURE sp_CountStokTersedia;
GO

CREATE PROCEDURE sp_CountStokTersedia
    @TotalStok INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @TotalStok = COUNT(*) 
    FROM Tabel_Kantong_Darah 
    WHERE Status = 'Tersedia';
END;
GO

-- SP 7: COUNT permintaan pending (OUTPUT Parameter)
IF OBJECT_ID('sp_CountRequestPending', 'P') IS NOT NULL
    DROP PROCEDURE sp_CountRequestPending;
GO

CREATE PROCEDURE sp_CountRequestPending
    @TotalPending INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @TotalPending = COUNT(*) 
    FROM Tabel_Request 
    WHERE Status_Permintaan = 'Pending';
END;
GO

-- SP 8: GET semua permintaan pending (untuk Admin PMI)
IF OBJECT_ID('sp_GetRequestPending', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRequestPending;
GO

CREATE PROCEDURE sp_GetRequestPending
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        R.ID_Request,
        R.Golongan_Darah,
        R.Status_Permintaan,
        R.Tanggal_Request,
        U.Nama_Unit AS [Nama Rumah Sakit]
    FROM Tabel_Request R
    INNER JOIN Tabel_Unit_Medis U ON R.ID_Unit_Peminta = U.ID_Unit
    WHERE R.Status_Permintaan = 'Pending'
    ORDER BY R.Tanggal_Request DESC;
END;
GO

-- SP 9: GET laporan semua permintaan (untuk Manajer)
IF OBJECT_ID('sp_GetLaporanPermintaan', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetLaporanPermintaan;
GO

CREATE PROCEDURE sp_GetLaporanPermintaan
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        R.ID_Request,
        R.Golongan_Darah    AS [Gol. Darah],
        R.Status_Permintaan AS [Status],
        R.Tanggal_Request   AS [Tgl. Request],
        U.Nama_Unit         AS [Nama Rumah Sakit],
        U.Alamat            AS [Alamat RS]
    FROM Tabel_Request R
    INNER JOIN Tabel_Unit_Medis U ON R.ID_Unit_Peminta = U.ID_Unit
    ORDER BY R.Tanggal_Request DESC;
END;
GO

-- SP 10: INSERT permintaan darah (dari Staf RS)
IF OBJECT_ID('sp_InsertRequest', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertRequest;
GO

CREATE PROCEDURE sp_InsertRequest
    @Golongan_Darah NVARCHAR(10),
    @ID_Unit_Peminta INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Tabel_Request (Golongan_Darah, Status_Permintaan, Tanggal_Request, ID_Unit_Peminta)
    VALUES (@Golongan_Darah, 'Pending', GETDATE(), @ID_Unit_Peminta);
END;
GO

-- SP 11: PROSES REQUEST (Admin PMI — update stok + request sekaligus)
IF OBJECT_ID('sp_ProsesRequest', 'P') IS NOT NULL
    DROP PROCEDURE sp_ProsesRequest;
GO

CREATE PROCEDURE sp_ProsesRequest
    @ID_Request      INT,
    @Gol_Darah       NVARCHAR(5),
    @Rhesus          NVARCHAR(2),
    @Berhasil        BIT OUTPUT,
    @PesanHasil      NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ID_Kantong INT;

    -- Cek stok tersedia
    SELECT TOP 1 @ID_Kantong = ID_Kantong
    FROM Tabel_Kantong_Darah
    WHERE Gol_Darah = @Gol_Darah AND Rhesus = @Rhesus AND Status = 'Tersedia';

    IF @ID_Kantong IS NULL
    BEGIN
        SET @Berhasil   = 0;
        SET @PesanHasil = 'Stok darah ' + @Gol_Darah + @Rhesus + ' tidak tersedia.';
        RETURN;
    END

    -- Update status kantong → Dikirim
    UPDATE Tabel_Kantong_Darah
    SET Status = 'Dikirim'
    WHERE ID_Kantong = @ID_Kantong;

    -- Update status request → Dikirim
    UPDATE Tabel_Request
    SET Status_Permintaan = 'Dikirim'
    WHERE ID_Request = @ID_Request;

    SET @Berhasil   = 1;
    SET @PesanHasil = '1 kantong darah berhasil dikirim.';
END;
GO

-- ============================================================
-- MODUL 9: BACKUP TABLE (untuk fitur Reset Data)
-- Buat sekali saja sebelum demo
-- ============================================================

-- Buat backup tabel stok darah jika belum ada
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Backup_Kantong_Darah')
BEGIN
    SELECT * INTO Backup_Kantong_Darah FROM Tabel_Kantong_Darah;
    PRINT 'Backup_Kantong_Darah berhasil dibuat dari data saat ini.';
END
ELSE
BEGIN
    PRINT 'Backup_Kantong_Darah sudah ada. Skip.';
END
GO

PRINT '============================================================';
PRINT 'SETUP HEMOSCAN SELESAI:';
PRINT '  3 VIEW telah dibuat (vw_StokDarahPublik, vw_LaporanPermintaan, vw_RequestPending)';
PRINT '  11 Stored Procedures telah dibuat';
PRINT '  1 Backup Table disiapkan untuk fitur Reset Data';
PRINT '============================================================';
GO
