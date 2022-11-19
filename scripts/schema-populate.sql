USE es_class_control_db;

INSERT
    IGNORE INTO role (name)
VALUES
    ('Discente'),
    ('Docente'),
    ('Coordenação');

INSERT
    IGNORE INTO subject (id, name)
VALUES
    ('1MAT177', 'Cálculo 1'),
    ('1STA005', 'Estatística'),
    ('1COP016', 'Engenharia de Software 1'),
    ('1COP022', 'Engenharia de Software 2'),
    ('1COP029', 'Compiladores 2');

INSERT
    IGNORE INTO auth (user_registration, login, password)
VALUES
    ('202000560227', 'Hermes', '1'),
    ('1', 'Jennifer', '2'),
    ('2', 'Isabela', '3'),
    ('3', 'Jandira G Palma', '4');

INSERT
    IGNORE INTO center (name, acronym)
VALUES
    ('Centro de Ciências Exatas', 'CCE'),
    ('Centro de Ciências Agrárias', 'CCA');