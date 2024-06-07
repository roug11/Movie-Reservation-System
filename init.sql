CREATE TABLE "user"
(
    id       INT GENERATED ALWAYS AS IDENTITY,
    username VARCHAR NOT NULL,
    password VARCHAR NOT NULL,
    role     VARCHAR NOT NULL,
    iban     VARCHAR,

    PRIMARY KEY (id)
);

CREATE TABLE theater
(
    id      INT GENERATED ALWAYS AS IDENTITY,
    name    VARCHAR NOT NULL,
    address VARCHAR,

    PRIMARY KEY (id)
);

CREATE TABLE movie
(
    id          INT GENERATED ALWAYS AS IDENTITY,
    name        VARCHAR NOT NULL,
    description VARCHAR,

    PRIMARY KEY (id)
);

CREATE TABLE schedule
(
    id          INT GENERATED ALWAYS AS IDENTITY,
    theater_id  INT       NOT NULL,
    movie_id    INT       NOT NULL,
    time        TIMESTAMP NOT NULL,
    price       FLOAT     NOT NULL,
    total_seats INT       NOT NULL,

    PRIMARY KEY (id),
    FOREIGN KEY (theater_id) REFERENCES theater (id),
    FOREIGN KEY (movie_id) REFERENCES movie (id)
);

CREATE TABLE reservation
(
    id           INT GENERATED ALWAYS AS IDENTITY,
    schedule_id  INT       NOT NULL,
    user_id      INT       NOT NULL,
    seats        VARCHAR   NOT NULL,
    create_time  TIMESTAMP NOT NULL,
    total_amount FLOAT     NOT NULL,
    paid         BOOLEAN   NOT NULL,

    PRIMARY KEY (id),
    FOREIGN KEY (schedule_id) REFERENCES schedule (id),
    FOREIGN KEY (user_id) REFERENCES "user" (id)
);