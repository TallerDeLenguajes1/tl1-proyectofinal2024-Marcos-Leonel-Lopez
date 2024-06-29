# Poke-Batalla

Es un mini juego basado en los personajes de la serie/anime/videojuegos de Pokémon, en el que solo se tienen en cuenta sus stats bases (ataque, ataque especial, defensa, defensa especial y velocidad).

- [Menú](#menú)
- [Nueva Partida](#nueva-partida)
- [Cargar Partida](#cargar-partida)
- [Máximas Puntuaciones](#máximas-puntuaciones)
- [Datos técnicos](#datos-técnicos)
- [Posibles mejoras a implementar](#posibles-mejoras-a-implementar)

## Menú

- Nueva Partida
  - Usar datos guardados
  - Cargar nuevos datos

- Cargar Partida

- Máximas Puntuaciones

## Nueva Partida

Al iniciar por primera vez el juego, es necesario ***Cargar nuevos datos***. Se procederá a verificar si existe conexión a internet:
- Si hay conexión, se observará la leyenda *Cargando nuevos datos desde la API...*.
- Si no hay conexión, o esta falla, se verá una leyenda que indica lo ocurrido.

Esta primera carga de datos creará un _backup_ que luego podrá volver a usarse para iniciar una nueva partida o podrá cargar 10 nuevos personajes si así lo desea. Este proceso puede demorar unos cuantos segundos dependiendo de diversos factores: latencia de la red, procesamiento en el servidor, carga del servidor, etc.

Si la carga de datos es exitosa, obtendrá un listado de 10 Pokes por los que navegará utilizando las flechas del teclado. Podrá ver las estadísticas de cada uno parándose sobre él y presionando ***Enter***. Para realizar la selección del mismo, debe ingresar la letra ***Y*** y luego ***Enter***. Para volver, presione cualquier otra tecla.

Antes de iniciar una batalla, se corrobora que su **Poke** esté vivo (hp>0) y que haya oponentes con los que se pueda enfrentar. Luego se selecciona un oponente al azar. Su **Poke** combatirá contra el oponente hasta que uno de los dos sea derrotado. Al iniciar el combate, atacará el **Poke** que cuente con mayor velocidad.

Al momento de que un **Poke** va a atacar, se tiene en cuenta un factor de suerte. Si el atacante "tiene más suerte" que el que se defiende, este acertará un golpe crítico.

Para el cálculo del daño se utiliza:

Daño = (((2 × nivel / 5) + 2) × poder del golpe × (ataque / defensa) / 100 + 2) × modificador

Donde:
* Nivel: nivel 50 para todo Poke.
* Ataque: Promedio del _ataque_ y _ataque especial_.
* Defensa: Promedio de la _defensa_ y _defensa especial_.
* Poder del Golpe: Simula el poder del golpe que varía entre 80 y 120.
* Modificador: valor que depende si se trata de un golpe crítico (2) o no (1.5).

Si su **Poke** es derrotado, termina el juego.

Si su **Poke** resulta victorioso, este obtendrá una serie de recompensas que serán tenidas en cuenta para la siguiente batalla.

### Recompensas
 1. Puntaje: 100 + % de vida restante.
 2. Vida: recupera el 50% de la vida máxima.
 3. Estadísticas Base: todas las estadísticas pueden aumentar entre 0 - 10 puntos, excepto la velocidad que solo puede aumentar entre 0 y 3.

Al finalizar una batalla y obtener la victoria, podrá elegir si guardar su progreso y salir o continuar con la siguiente batalla.

Si usted derrota a todos los oponentes, podrá ingresar su nombre para guardarlo en el sistema de ***Máximas puntuaciones***.

## Cargar Partida
Solo podrá cargar una partida si usted ***Guardó*** una previamente, caso contrario se indicará que no se pudo realizar la operación y deberá presionar ***Enter*** para volver al menú principal.

Si carga una partida de manera exitosa, esta continuará con su curso normal hasta ganar o volver a ***Guardar y salir***.

En caso de existir una partida guardada e iniciar una ***Nueva partida***, usted perderá la partida guardada.

## Máximas Puntuaciones
Es un apartado en el que podrá observar las 10 mejores puntuaciones indicando orden, jugador, Poke, puntuación y fecha.

## Datos técnicos:
La información de cada personaje se trae desde el sitio [PokeApi](https://pokeapi.co/?ref=apilist.fun).

La persistencia de información se realiza mediante archivos JSON alojados de forma local.

## Posibles mejoras a implementar

- Agregar 4 movimientos que se eligen de forma elatoria y eliminar la aleatoriedad del Poder del Golpe.
- Tener en cuenta los tipos del Poke atacante y defensor al momento de calcular el daño.
- Calculo de eperiencia ganada por combate y subida de nivel.

