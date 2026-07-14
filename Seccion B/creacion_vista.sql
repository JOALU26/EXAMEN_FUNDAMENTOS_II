--vista citas programadas-primero probar si el join es correcto
CREATE OR REPLACE VIEW vista_citas_programadas AS
SELECT 
    m.nombre         AS mascota,
    p.nombre         AS duenio,
    v.nombre         AS veterinario,
    c.fecha
FROM citas c
INNER JOIN mascotas m ON c.id_mascota = m.id_mascota
INNER JOIN propietarios p ON m.id_propietario = p.id_propietario
LEFT JOIN veterinarios v ON c.id_veterinario = v.id_veterinario
WHERE c.estado = 'programada';

SELECT * FROM vista_citas_programadas;