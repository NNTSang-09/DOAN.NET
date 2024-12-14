CREATE DATABASE pharmacy
USE pharmacy

CREATE TABLE medicine (
    medicine_code VARCHAR(50) PRIMARY KEY,      
    medicine_name NVARCHAR(100) UNIQUE, 
    medicine_group NVARCHAR(50),  
    unit_type NVARCHAR(100),
    medicine_price DECIMAL(10, 2),              
    medicine_content NVARCHAR(255)
);

CREATE TABLE repository (
    id INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT,
    medicine_expire_date DATE,           
    medicine_code VARCHAR(50),
    FOREIGN KEY (medicine_code) REFERENCES medicine(medicine_code)
);

CREATE TABLE sale (
    id INT IDENTITY(1,1) PRIMARY KEY,
    created_at DATETIME,
    amount DECIMAL(10, 2),
    employee NVARCHAR(80)
);

INSERT INTO medicine (medicine_code, medicine_name, medicine_group, unit_type, medicine_price, medicine_content)
VALUES 
('MED001', 'Paracetamol', 'Analgesic', 'Viên', 15000.00, 'Sử dụng trị nhức đầu'),
('MED002', 'Amoxicillin', 'Antibiotic', 'Viên con nhộng', 20000.00, 'Used for bacterial infections'),
('MED003', 'Ibuprofen', 'Anti-inflammatory', 'Viên', 18000.00, 'Relieves pain and reduces inflammation'),
('MED004', 'Cetirizine', 'Antihistamine', 'Viên', 12000.00, 'Used for allergies and hay fever'),
('MED005', 'Metformin', 'Antidiabetic', 'Hộp', 25000.00, 'Used to control blood sugar levels');


INSERT INTO repository (quantity, medicine_expire_date, medicine_code)
VALUES
(100, '2025-12-31', 'MED001'),
(200, '2024-06-30', 'MED002'),
(150, '2026-03-15', 'MED003'),
(300, '2025-11-20', 'MED004'),
(50, '2024-08-05', 'MED005');

SELECT * FROM repository
