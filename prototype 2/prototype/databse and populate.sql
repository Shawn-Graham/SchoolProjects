-- 1. Create Categories Table
CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    name VARCHAR(100)
);

-- 2. Create Equipment Table
CREATE TABLE Equipment (
    equipment_id INT PRIMARY KEY,
    category_id INT,
    name VARCHAR(100),
    description TEXT,
    daily_rate DECIMAL(10, 2),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

-- 3. Create Customers Table
CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    last_name VARCHAR(50),
    first_name VARCHAR(50),
    contact_phone VARCHAR(20),
    email VARCHAR(100)
);

-- 4. Create Rentals Table
CREATE TABLE Rentals (
    rental_id INT PRIMARY KEY,
    date DATE,
    customer_id INT,
    equipment_id INT,
    rental_date DATE,
    return_date DATE,
    cost DECIMAL(10, 2),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (equipment_id) REFERENCES Equipment(equipment_id)
);
-- Insert data into Categories Table
INSERT INTO Categories (category_id, name)
VALUES
(10, 'Power tools'),
(20, 'Yard equipment'),
(30, 'Compressors'),
(40, 'Generators'),
(50, 'Air Tools');

-- Insert data into Equipment Table
INSERT INTO Equipment (equipment_id, category_id, name, description, daily_rate)
VALUES
(101, 10, 'Hammer drill', 'Powerful drill for concrete and masonry', 25.99),
(201, 20, 'Chainsaw', 'Gas-powered chainsaw for cutting wood', 49.99),
(202, 20, 'Lawn mower', 'Self-propelled lawn mower with mulching function', 19.99),
(301, 30, 'Small Compressor', '5 Gallon Compressor-Portable', 14.99),
(501, 50, 'Brad Nailer', 'Brad Nailer. Requires 3/4 to 1 1/2 Brad Nails', 10.99);

-- Insert data into Customers Table
INSERT INTO Customers (customer_id, last_name, first_name, contact_phone, email)
VALUES
(1001, 'Doe', 'John', '(555) 555-1212', 'jd@sample.net'),
(1002, 'Smith', 'Jane', '(555) 555-3434', 'js@live.com'),
(1003, 'Lee', 'Michael', '(555) 555-5656', 'ml@sample.net');

-- Insert data into Rentals Table
INSERT INTO Rentals (rental_id, date, customer_id, equipment_id, rental_date, return_date, cost)
VALUES
(1000, '2024-02-15', 1001, 201, '2024-02-20', '2024-02-23', 149.97),
(1001, '2024-02-16', 1002, 501, '2024-02-21', '2024-02-25', 43.96);
