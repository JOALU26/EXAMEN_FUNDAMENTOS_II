--insertar datos en propietarios
INSERT INTO propietarios (nombre, telefono, email, direccion) VALUES
('Maria Lopez',    '0991234567', 'maria@gmail.com',   'Av. Ecuador 123'),
('Carlos Perez',   '0997654321', 'carlos@gmail.com',  'Calle Larga 456'),
('Ana Ramirez',    '0998887777', 'ana@gmail.com',     'Av. America 789');

--insertar datos en mascotas
INSERT INTO mascotas (nombre, especie, raza, edad, id_propietario) VALUES
('Max',     'Perro',   'Labrador',    3, 1),
('Luna',    'Gato',    'Persa',       2, 1),
('Toby',    'Perro',   'Pastor Aleman', 5, 2),
('Mimi',    'Gato',    'Siames',      1, 3);

--insertar datos en veterinarios
INSERT INTO veterinarios (nombre, especialidad, telefono) VALUES
('Dr. Fernando Diaz',   'Cirugia',      '0991112222'),
('Dra. Carolina Rojas', 'General',      '0993334444');

--insertar datos en citas
INSERT INTO citas (id_mascota, id_veterinario, fecha, estado) VALUES
(1, 1, '2026-07-15 09:00:00', 'programada'),
(2, 2, '2026-07-15 10:30:00', 'programada'),
(3, 1, '2026-07-14 14:00:00', 'atendida'),
(4, NULL, '2026-07-16 11:00:00', 'programada');

--insertar datos en historial-primero debe pasar la cita a esta completado
INSERT INTO historial_atenciones (id_cita, diagnostico) VALUES
(3, 'Vacunacion completada');