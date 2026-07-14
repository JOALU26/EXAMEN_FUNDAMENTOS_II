--2 join mascotas-propitarios
SELECT 
    m.nombre         AS mascota,
    p.nombre         AS duenio,
    v.nombre         AS veterinario,
    c.fecha
FROM citas c
INNER JOIN mascotas m ON c.id_mascota = m.id_mascota
INNER JOIN propietarios p ON m.id_propietario = p.id_propietario
--mostrar solo citas en estado programada
LEFT JOIN veterinarios v ON c.id_veterinario = v.id_veterinario
WHERE c.estado = 'programada';

