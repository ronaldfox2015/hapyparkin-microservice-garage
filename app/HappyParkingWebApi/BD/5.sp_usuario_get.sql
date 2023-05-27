

DELIMITER //
 DROP PROCEDURE IF EXISTS sp_usuario_get;
 
create procedure sp_usuario_get
(
	in 	inidusuario				int,
    in 	inidUsuarioModificacion integer,
    in infechainicio			varchar(12),
    in infechafin				varchar(12)
)
begin
    
	SELECT idusuario, 
			correo, 
            clave, 
            DATE_FORMAT(fechaCreacion,'%Y-%m-%d %H:%i:%s') AS fechaCreacion,
            -- idUsuarioModificacion,
            coalesce(idUsuarioModificacion, 0) AS idUsuarioModificacion,
            coalesce(DATE_FORMAT(fechaActualizacion,'%Y-%m-%d %H:%i:%s'),'') AS fechaActualizacion, 
            estado 
	FROM tbusuario
    where (idusuario = inidusuario OR inidusuario = 0)
		AND (idUsuarioModificacion = inidUsuarioModificacion OR inidUsuarioModificacion = 0)
        AND (fechaCreacion >= infechainicio OR infechainicio = '')
        AND (fechaCreacion <= infechafin OR infechafin = '');
    
end //