--tabla dueños de mascotas
CREATE TABLE propietarios (
    id_propietario SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100),
    direccion VARCHAR(200)
);
--tabla de mascotas
CREATE TABLE mascotas (
    id_mascota SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    especie VARCHAR(50)  NOT NULL,
    raza VARCHAR(50),
    edad INT,
    id_propietario INT NOT NULL,

    CONSTRAINT fk_mascotas_propietarios
        FOREIGN KEY (id_propietario)
        REFERENCES propietarios(id_propietario)
        ON DELETE CASCADE
);

--tabla veterianarios
CREATE TABLE veterinarios (
    id_veterinario SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    especialidad VARCHAR(100),
    telefono VARCHAR(20)
);

--tabla citas
CREATE TABLE citas (
    id_cita SERIAL PRIMARY KEY,
    id_mascota INT NOT NULL,
    id_veterinario INT,
    fecha TIMESTAMP NOT NULL,
    estado VARCHAR(20)  NOT NULL DEFAULT 'programada',

    CONSTRAINT fk_citas_mascotas
        FOREIGN KEY (id_mascota)
        REFERENCES mascotas(id_mascota)
        ON DELETE RESTRICT,

    CONSTRAINT fk_citas_veterinarios
        FOREIGN KEY (id_veterinario)
        REFERENCES veterinarios(id_veterinario)
        ON DELETE SET NULL
);

--tabla historial de antenciones
CREATE TABLE historial_atenciones (
    id_historial SERIAL PRIMARY KEY,
    id_cita INT NOT NULL,
    diagnostico TEXT DEFAULT 'Pendiente de detalle',
    fecha_registro TIMESTAMP DEFAULT NOW(),

    CONSTRAINT fk_historial_citas
        FOREIGN KEY (id_cita)
        REFERENCES citas(id_cita)
        ON DELETE CASCADE
);