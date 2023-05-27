

DELIMITER //
 DROP PROCEDURE IF EXISTS sp_usuario_edit;
 
create procedure sp_usuario_edit
(
	in 	inidusuario				int,
    in 	inclave 				varchar(20),
    in 	inidUsuarioModificacion integer,
    in 	inestado 				int,
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
	SET clave 	= SHA(inclave),
		idUsuarioModificacion=inidUsuarioModificacion,
        fechaActualizacion = current_timestamp(),
		estado 	= inestado
	where idusuario = inidusuario;
    
	SET mensaje = 'Usuario modificado correctamente...!!!';
    
end //