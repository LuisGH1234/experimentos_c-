Feature: Gestionar Videoteca
	Como usuario necesito actualizar mi videoteca

#Actualizar Videoteca
#criterio 1
Scenario: Mover Playlist A
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el boton de Mover Playlist 
	And coloco el indice del item Playlist que quiero mover como 2
	Then el sistema actualiza la lista con el orden especificado exitosamente
	
#criterio 2
Scenario: Mover Playlist B
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el boton de Mover Playlist 
	And coloco el indice del item Playlist que quiero mover como menos 1
	Then el sistema no actualiza la lista con el orden especificado
  
#criterio 3
Scenario: Mover Playlist C
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el boton de Mover Playlist 
	And coloco el indice del item Playlist que quiero mover como 4
	Then el sistema no actualiza la lista con el orden especificado
  
#criterio 4
Scenario: Eliminar Playlist A
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el boton de Eliminar Playlist
	And hago click en el boton de Esta seguro
	Then el sistema me mostrara el mensaje Playlist de "Se elimino correctamente la Playlist"
	
#criterio 5
Scenario: Eliminar Playlist B
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el boton de Eliminar Playlist
	And hago click en el boton Cancelar Eliminacion
	Then el sistema muestra la playlist nuevamente
	
#Marcar como favorito
#criterio 1
Scenario: Marcar como favorito A
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el icono Marcar como favorito durante 1 segundo
	Then el sistema no me mostrara ningun mensaje con respecto a la Playlist
	
#criterio 2
Scenario: Marcar como favorito B
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And busco el producto "Playlist 1234" para seleccionarla de la tabla de Playlist
	And hago click en el icono Marcar como favorito durante 1.5 segundos
	Then el sistema me mostrara el mensaje Playlist de "Se marco como favorito la Playlist"
	
#Registrar playlist
#criterio 1
Scenario: Registrar Playlist A
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And luego hago click en el boton de Registrar Playlist
	And en la nueva pantalla escribo en el campo Nombre Playlist con el valor de ""
	And en la nueva pantalla escribo en el campo Descripcion Producto el valor de "mi descripcion 1234"
	And presiono el boton de Guardar Playlist
	Then el sistema me mostrara el mensaje Playlist de "Se guardo correctamente la Playlist"
	
#criterio 2
Scenario: Registrar Playlist B
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And luego hago click en el boton de Registrar Playlist
	And en la nueva pantalla escribo en el campo Nombre Playlist con el valor de " name"
	And en la nueva pantalla escribo en el campo Descripcion Producto el valor de "mi descripcion 1234"
	And presiono el boton de Guardar Playlist
	Then el sistema me mostrara el mensaje Playlist de "Se debe insertar un nombre que comience con un caracter"
	
#criterio 3
Scenario: Registrar Playlist C
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And luego hago click en el boton de Registrar Playlist
	And en la nueva pantalla escribo en el campo Nombre Playlist con el valor de "name "
	And en la nueva pantalla escribo en el campo Descripcion Producto el valor de "mi descripcion 1234"
	And presiono el boton de Guardar Playlist
	Then el sistema me mostrara el mensaje Playlist de "Se guardo correctamente la Playlist"
	
#criterio 4
Scenario: Registrar Playlist D
	Given despues de iniciar sesion en la aplicacion
	When hago click en el enlace de Gestionar Videoteca
	And luego hago click en el boton de Registrar Playlist
	And en la nueva pantalla escribo en el campo Nombre Playlist con el valor de "name"
	And en la nueva pantalla escribo en el campo Descripcion Producto el valor de "mi descripcion 1234"
	And presiono el boton de Guardar Playlist
	Then el sistema me mostrara el mensaje Playlist de "Se guardo correctamente la Playlist"
