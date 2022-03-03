# Colliders-Cea - Colliders aplicados a escenas armadas [![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/es)

Octava consigna . curso coderhouse: Collisiones

## Consigna

Se dede realizar una escena que incluya 

- El personaje debe colisionar correctamente con el piso
- Al atravesar el portal, el personaje debe hacerse más pequeño y si vuelve a pasar por el, debe regresar a su tamaño normal
- Se debe crear una pared dorada. Al colisionar por más de 2 segundos con la pared, debe moverse a otra ubicación (al azar o pre establecida), cambiando también su rotación
- Cuando el personaje colisione con algún otro gameobject, debe mostrar su nombre y si tiene o no un componente shrinker

## Desarrollo de actividad

- El personaje detecta colisiones mediante el sistema characterController incluido en unity.
- Se incluyeron dos portales con particulas simples para diferenciarlos de los otros elementos del mapa
- Cada portal funciona de ida y vuelta, tienen puntos de aparición y tienen añadidos el componente TeleportController explicado a continuación.
- Se muestran los nombres de los objetos con los cuales colisiona el personaje
- Se muestra si el personaje ha colisionado con un elemento que contenga el componente TeleportController();
- Se mantiene el comportamiento de las cámaras
- Se mantiene el comportamiento de la música
- Se mantiene el comportamiento de los enemigos

- Los metodos agregados separados por script son: 
   
   - TeleportController: Se encarga de verificar si los objetos que contengan CharacterCollisionController(), por defecto el personaje, han ingresado al trigger y los teleporta a uno de los puntos de aparicion alrededor del otro portal. se pusieron spawn para que el personaje no quede atrapado en un loop entre un portal u otro
   - CharacterCollisionController: Contiene la lógica de teleportación mediante un booleano, para saber si el personaje ya ha sido teleportado o no, de esta forma saber cuando debe hacerse más pequeño o volver a su tamaño real. Se han agregado también los métodos para detectar colisiones y trigger, obtener nombres y componente.
   - Se puede desactivar la función que muestra los nombres, mediante un booleano público llamado isShowingColliderNames
   - WallController: Contiene el comportamiento de la pared al colisionar con un objeto por más de 2 segundos. Se incluyeron dos collider, un trigger que es el que se utiliza para el conteo y un collider convencional para que el personaje no pueda atravesar el elemento.

# Correcciones

- Se han separado los scripts por módulos: personaje, enemigos, entorno.
- Se ha cerrado el nivel para que el personaje no pueda caer y se han modificado los ángulos que el personaje puede escalar.
- Las animaciones están en desarrollo, debido a que no tengo mucho conocimiento con state machines de multiples capas, para animaciones en simultaneo
- Las colisiones para el personaje debieron hacerce mediante OnControllerColliderHit(), chequear en el link [@OnControllerColliderHit](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnControllerColliderHit.html)
## Autor

- [@Josue Cea](https://www.github.com/Nifrith)

