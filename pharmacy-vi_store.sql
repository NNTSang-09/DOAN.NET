CREATE DATABASE pharmacy
USE pharmacy

CREATE TABLE medicine (
    id INT IDENTITY(1,1) PRIMARY KEY,
    medicine_code VARCHAR(50) PRIMARY KEY,      
    medicine_name NVARCHAR(100) UNIQUE, 
    medicine_group NVARCHAR(50),
    unit_type NVARCHAR(100),
    medicine_price DECIMAL(10, 2),
    quantity INT,
    medicine_expire_date DATE,              
    medicine_content NVARCHAR(255)
);


CREATE TABLE sale (
    id INT IDENTITY(1,1) PRIMARY KEY,
    created_at DATETIME,
    amount DECIMAL(10, 2),
    employee NVARCHAR(80)
);
