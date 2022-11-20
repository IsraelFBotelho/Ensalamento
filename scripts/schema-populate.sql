USE es_class_control_db;

INSERT
    IGNORE INTO role (name)
VALUES
    ('Discente'),
    ('Docente'),
    ('Coordenação'),
    ('Secretaria');

INSERT
    IGNORE INTO desk_type (name)
VALUES
    ('Comum');

INSERT
    IGNORE INTO subject (id, name)
VALUES
    ('1MAT177', 'Cálculo 1'),
    ('1STA005', 'Estatística'),
    ('1COP016', 'Engenharia de Software 1'),
    ('1COP022', 'Engenharia de Software 2'),
    ('1COP029', 'Compiladores 2');

INSERT
    IGNORE INTO center (name, acronym)
VALUES
    ('Centro de Ciências Exatas', 'CCE'),
    ('Centro de Ciências Agrárias', 'CCA');

INSERT
    IGNORE INTO department (name, acronym, center_id)
VALUES
    ('Departamento de Computação', 'DC', 1);

INSERT
    IGNORE INTO user (
        registration,
        first_name,
        last_name,
        role_id,
        department_id
    )
VALUES
    (
        '20201',
        'Pedro Henrique',
        'Medeiros Hermes',
        1,
        1
    ),
    ('20202', 'Jennifer', 'do Prado da Silva', 1, 1),
    ('20203', 'Isabela', 'Hara Bando', 1, 1),
    (
        '20204',
        'Pedro Eduardo',
        'Garbossa de Almeida',
        1,
        1
    ),
    ('20205', 'Denise', 'Rezende', 1, 1),
    (
        '20206',
        'Israel',
        'Faustino Botelho Junior',
        1,
        1
    ),
    ('20207', 'Jandira', 'Guenka Palma', 2, 1),
    ('20208', 'Wesley', 'Attrot', 2, 1);

INSERT
    IGNORE INTO auth (user_registration, login, password)
VALUES
    ('20201', 'Hermes', '1'),
    ('20202', 'Jennifer', '1'),
    ('20203', 'Isabela', '1'),
    ('20204', 'Eduardo', '1'),
    ('20205', 'Denise', '1'),
    ('20206', 'Israel', '1'),
    ('20207', 'Jandira', '1');

INSERT
    IGNORE INTO class (
        id,
        type,
        capacity,
        acessible,
        desk_type_id,
        department_id
    )
VALUES
    ('MDC-1', 0, 20, FALSE, 1, 1),
    ('MDC-2', 0, 20, FALSE, 1, 1);

INSERT
    IGNORE INTO subject_history (
        start_date,
        end_date,
        subject_id,
        student_id,
        teacher_id
    )
VALUES
    (
        '2022-01-23',
        '2022-06-30',
        '1COP022',
        20201,
        20207
    );

INSERT
    IGNORE INTO class_reservation (requester_id, subject_id, class_id, start_date, end_date)
VALUES
    (
        20207,
        '1COP022',
        'MDC-1',
        '2022-11-01 08:20:00',
        '2022-11-01 10:00:00'
    ),
    (
        20207,
        '1COP016',
        'MDC-2',
        '2022-11-01 10:15:00',
        '2022-11-01 11:55:00'
    ),
    (
        20208,
        '1COP029',
        'MDC-2',
        '2022-11-03 08:20:00',
        '2022-11-03 11:55:00'
    ),
    (
        20207,
        '1COP016',
        'MDC-2',
        '2022-11-04 14:00:00',
        '2022-11-05 17:35:00'
    );