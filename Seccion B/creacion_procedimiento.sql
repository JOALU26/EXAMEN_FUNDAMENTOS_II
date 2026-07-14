--procedimienot para registrar cita
CREATE OR REPLACE PROCEDURE registrar_cita(
    p_id_mascota    INT,
    p_id_veterinario INT,
    p_fecha         TIMESTAMP
)
LANGUAGE plpgsql
AS $$
DECLARE
--variables para guardar los resultados de las validaciones
    mascota_existe  INT;
    vet_existe      INT;
    mensaje_error   TEXT;
BEGIN
--verificar que la mascota exista
    SELECT COUNT(*) INTO mascota_existe
    FROM mascotas
    WHERE id_mascota = p_id_mascota;

    IF mascota_existe = 0 THEN
        RAISE EXCEPTION 'La mascota con id % no existe', p_id_mascota;
    END IF;

--verificar que el veterinario exista
    SELECT COUNT(*) INTO vet_existe
    FROM veterinarios
    WHERE id_veterinario = p_id_veterinario;

    IF vet_existe = 0 THEN
        RAISE EXCEPTION 'El veterinario con id % no existe', p_id_veterinario;
    END IF;

--si todo esta bien, insertar la cita
    INSERT INTO citas (id_mascota, id_veterinario, fecha, estado)
    VALUES (p_id_mascota, p_id_veterinario, p_fecha, 'programada');

    RAISE NOTICE 'Cita creada exitosamente para la mascota %', p_id_mascota;

EXCEPTION
    WHEN OTHERS THEN
--capturar el error en una variable intermedia
        GET STACKED DIAGNOSTICS mensaje_error = MESSAGE_TEXT;
        RAISE NOTICE 'Error al crear la cita: %', mensaje_error;
END;
$$;

--ejecucion normal
CALL registrar_cita(1, 2, '2026-07-20 08:00:00');

--ejecucion error mascota
CALL registrar_cita(99, 1, '2026-07-20 09:00:00');

--ejecucion error veterinario
CALL registrar_cita(1, 99, '2026-07-20 10:00:00');