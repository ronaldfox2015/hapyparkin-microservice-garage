


delimiter ;
call sp_usuario_add ('franklin23@gmail.com.pe', '12345678',1, @idUsuario,@iderror,@mensaje);
select @idUsuario,@iderror,@mensaje;

delimiter ;
call sp_usuario_edit (1, '12345679', NULL ,1 ,@iderror,@mensaje);
select @iderror, @mensaje;

delimiter ;
call sp_usuario_get (0, 0, '' ,'' );
select @iderror, @mensaje;

delimiter ;
call sp_usuario_login ('franklin23@gmail.com.pe', '12345678',1, @idUsuario,@iderror,@mensaje);
select @idUsuario,@iderror,@mensaje;

select * from tbusuario;
-- truncate table tbusuario;
select current_timestamp();  