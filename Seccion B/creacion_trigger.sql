--funcion trigger registrar historial
CREATE OR REPLACE FUNCTION fn_registrar_historial()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
--solo crear historial si el nuevo estado es atendida
    IF NEW.estado = 'atendida' THEN
        INSERT INTO historial_atenciones (id_cita, diagnostico)
        VALUES (NEW.id_cita, 'Pendiente de detalle');
    END IF;

    RETURN NEW;
END;
$$;

--ejecucion de trigger - cita cambia de estado
CREATE TRIGGER trg_registrar_historial
    AFTER UPDATE OF estado
    ON citas
    FOR EACH ROW
    EXECUTE FUNCTION fn_registrar_historial();

--cambiar una cita a estado atendido 
UPDATE citas SET estado = 'atendida' WHERE id_cita = 1;

--verificar que se creo el historial
SELECT * FROM historial_atenciones;

