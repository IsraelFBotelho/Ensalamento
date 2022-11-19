DROP SCHEMA IF EXISTS es_class_control_db;

CREATE SCHEMA es_class_control_db DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

USE es_class_control_db;

CREATE TABLE role (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(64) NOT NULL
);

CREATE TABLE desk_type (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(32) NOT NULL
);

CREATE TABLE subject (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(64) NOT NULL
);

CREATE TABLE auth (
    user_registration INT PRIMARY KEY,
    login VARCHAR(64) NOT NULL,
    password VARCHAR(40) NOT NULL
);

CREATE TABLE center (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(64) NOT NULL,
    acronym VARCHAR(16) NOT NULL
);

CREATE TABLE department (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(64) NOT NULL,
    acronym VARCHAR(16) NOT NULL,
    center_id INT,
    CONSTRAINT fk_department_center_id FOREIGN KEY (center_id) REFERENCES center (id)
);

CREATE TABLE class (
    id VARCHAR(16) PRIMARY KEY,
    type INT NOT NULL,
    capacity INT NOT NULL,
    acessible BOOLEAN NOT NULL,
    desk_type_id INT NOT NULL,
    department_id INT NOT NULL,
    CONSTRAINT fk_class_desk_type_id FOREIGN KEY (desk_type_id) REFERENCES desk_type (id),
    CONSTRAINT fk_class_department_id FOREIGN KEY (department_id) REFERENCES department (id)
);

CREATE TABLE user (
    registration INT PRIMARY KEY,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    role_id INT NOT NULL,
    department_id INT NOT NULL,
    CONSTRAINT fk_user_role_id FOREIGN KEY (role_id) REFERENCES role (id),
    CONSTRAINT fk_user_department_id FOREIGN KEY (department_id) REFERENCES department (id)
);

CREATE TABLE subject_history (
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    user_registration INT NOT NULL,
    subject_id INT NOT NULL,
    CONSTRAINT fk_subject_history_user_registration FOREIGN KEY (user_registration) REFERENCES user (registration),
    CONSTRAINT fk_subject_history_subject_id FOREIGN KEY (subject_id) REFERENCES subject (id)
);