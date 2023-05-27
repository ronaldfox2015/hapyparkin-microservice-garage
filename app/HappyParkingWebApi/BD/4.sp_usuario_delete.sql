

DELIMITER //
 DROP PROCEDURE IF EXISTS sp_usuario_delete;
 
create procedure sp_usuario_delete
(
	in 	inidusuario				int,
    in 	inidUsuarioModificacion integer,
    out iderror					int,
    out mensaje					varchar(100)
)
sp_tran: begin
    
	SET iderror 	= 0;
    
    if(not exists(select idusuario from tbusuario where idusuario = inidusuario )) then	
        set iderror = 1;
        set mensaje = 'El usuario no esta registrado.';
		leave sp_tran;
    end if;
    
    if (not inidUsuarioModificacion is null) AND (not exists(select idusuario from tbusuario where idusuario = inidUsuarioModificacion )) then	
        set iderror = 1;
        set mensaje = 'El usuario de modificación no esta registrado.';
		leave sp_tran;
    end if;
    
    update tbusuario 
	SET idUsuarioModificacion=inidUsuarioModificacion,
        fechaActualizacion = current_timestamp(),
		estado 	= 0
	where idusuario = inidusuario;
    
	SET mensaje = 'Usuario eliminado correctamente...!!!';
    
end //