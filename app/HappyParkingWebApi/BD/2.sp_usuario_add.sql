

DELIMITER //
 DROP PROCEDURE IF EXISTS sp_usuario_add;
 
create procedure sp_usuario_add
(
    in incorreo		varchar(100), 
    in inclave 		varchar(20),
    in inestado 	int,
    out idUsuario	int,
    out iderror		int,
    out mensaje		varchar(100)
)
sp_tran: begin
    
	SET iderror 	= 0;
    SET idUsuario 	= 0;
    
    if(exists(select idusuario from tbusuario where correo = incorreo)) then	
        set iderror = 1;
        set mensaje = 'Correo ya esta registrado.';
		leave sp_tran;
    end if;
    
    if(NOT incorreo REGEXP "^[a-zA-Z0-9][a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]*?[a-zA-Z0-9._-]?@[a-zA-Z0-9][a-zA-Z0-9._-]*?[a-zA-Z0-9]?\\.[a-zA-Z]{2,63}$") then	
        set iderror = 1;
        set mensaje = 'El formato del correo, no es valido???';
		leave sp_tran;
    end if;
    
    insert into tbusuario 
	(correo, clave, fechaCreacion, estado) 
	values 
	(incorreo, SHA(inclave), current_timestamp(), inestado);
    
	SET idUsuario = LAST_INSERT_ID();
	SET mensaje = 'Usuario registrado correctamente...!!!';
    
end //