

DELIMITER //
DROP PROCEDURE IF EXISTS sp_usuario_login;
 
create procedure sp_usuario_login
(
	in incorreo			varchar(100), 
    in inclave 			varchar(20),
    in inidRol 			int,
    out outidusuario	int,
    out iderror			int,
    out mensaje			varchar(100)
)
sp_tran: begin

	SET iderror 	= 0;
    SET outidusuario = 0;
    
    if(not exists(select idusuario from tbusuario where correo = incorreo )) then	
        set iderror = 1;
        set mensaje = 'El correo no esta registrado.';
		leave sp_tran;
    end if;
    
    if(not exists(select idusuario from tbusuario where correo = incorreo and clave = SHA(inclave))) then	
        set iderror = 2;
        set mensaje = 'El usuario no coincide con la contraseña';
		leave sp_tran;
    end if;
    
    select outidusuario =  idusuario from tbusuario where correo = incorreo and clave = SHA(inclave);
    
    if(not exists(select idusuario from tbrolpersona where idusuario = outidusuario AND idRol = inidRol )) then	
        set iderror = 3;
        set mensaje = 'El usuario no tiene acceso al rol ' ;
		leave sp_tran;
    end if;
    
	SET mensaje = 'Acceso concebido';
    
end //