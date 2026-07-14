--consulta sin indice
EXPLAIN ANALYZE
SELECT * FROM citas
WHERE id_mascota = 1 AND estado = 'programada';

--creacion de indice
CREATE INDEX idx_citas_mascota_estado
    ON citas (id_mascota, estado);

--consulta con indice
EXPLAIN ANALYZE
SELECT * FROM citas
WHERE id_mascota = 1 AND estado = 'programada';

