# Vectores-Cea - Pequeña escena con vectores [![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/es)

Sexta consigna . curso coderhouse: Desarrollo de videojuegos, clase Condiciones, operadores y matemática vectorial

## Consigna

Se dede realizar una escena que incluya 

- 3 enemigos:
   - Uno que mire al jugador constantemente
   - Uno que siga al jugador constantemente pero se detenga al estar a menos de 2 unidades
   - Uno que se comporte de una u otra manera según logica de switch mediante enum.

- Un player que se mueva mediante inputs y rote sobre si mismo.

## Desarrollo de actividad

- El movimiento del jugador está basado en rotaciones y no movimientos laterales.
- Se incluyeron 3 modelos nuevos de enemigo para cada tipo de comportamiento.
   - Un slime para que mire al jugador
   - Una pinchuga (pincho tortuga) para seguir al jugador
   - Una pinchuga escalada (pincho tortuga jefe) para que se comporte de una manera u otra dependiendo del enum seleccionado (looker, follower)
- Todos los personajes en la escena contienen animaciones mediante state machines, pero no están controladas.
- Se mantiene el comportamiento de las cámaras
- Se mantiene el comportamiento de la música

- Los metodos agregados separados por script son: 
   
   - EnemyController: Contiene el método LookRotation que recibe un parámetro de entrada tipo transform y se encarga de realizar la rotación suave hacia el jugador mediante Quaternions utilizando lerp.
   - EnemyFollow: Contiene el método MoveTowardsPlayer que recibe un parámetro de entrada tipo transform y se encarga de realizar el movimiento del monstruo en dirección al personaje, considerando distancia mínima y máxima.
   - EnemyControllerEnum: permite seleccionar entre dos comportamientos: looker o follower, looker solo mira al personaje y follower hace el seguimiento del personaje, se tomaron de base los dos scrips anteriores para generar métodos correspondientes

- Las animaciones están en desarrollo, debido a que no tengo mucho conocimiento con state machines de multiples capas, para animaciones en simultaneo
## Autor

- [@Josue Cea](https://www.github.com/Nifrith)

