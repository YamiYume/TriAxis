# TriAxis
A Weird 3D version of Tetris Style Game in Unity

## Introducción

Este proyecto está basado en la api para  video juegos Unity 
y se fundamenta en las capacidades de representación vectorial de
la versión 3D del motor.

El proyecto presenta un juego de estilo tetrix basado en triminus y 
en un  "tablero" cúbico de 5 fichas de lado, la representación de objetos
dentro de la aplicación  esta enfocado en cuatro objetos centrales 
que a su vez, se sostienen en los múltiples modelos prefabricados por el desarrollador
y los componentes propios de unity.

## Representación

La representación de los objetos dentro del juego, esta representada en las clases 
campo, monomimo, trimino y manager.

La clase monomino  representa la unidad básica de las piezas de los poliominos  y están
contenidas tanto en los campos como en los triminos, tambien tienen capacidades de 
movimientos individuales.

La clase trimino se compone del conjunto de tres monominos y son las piezas controladas
por el jugador, tienen la capacidad de recibir inputs del usuario y en base a ello realizar
operaciones de traslación y rotación, puede valiar su correcto posicionamiento en el campo
y puede determinar cuando instanciar un monomino dentro del campo cuando su próximo movimiento
ya no es válido.

La clase campo comprende el "tablero" del juego, funciona como contenedor de los monominos una 
vez estos son fijados por un trimino; tienen capacidades de leer el vector posición de los monominos
hijos,dar información a los triminos para que estos puedan validar su siguiente movimiento
e identificar capas completas, eliminarlas y dar la orden de traslación a los monominos necesarios

La clase manager: controla el spam de los nuevo triminos una vez el anterior trimino ha sido fijado
controla el flujo de juego, indicando en que casos se pierde la partida.

## Funciones
Las funciones de esta aplicación estan en su mayoría basadas en el vector posición de los diferentes
componentes que estan en la escena.
Se usa la comparación de instancias, los limites definidos por la escala de los objetos y las
comparación de vectores para dar sentido al funcionamiento del juego.

En otra medida se usan las rotaciones especificamente para el cambio de rotación de las fichas.

Se intento usar formulas propias de planos y vectores para regular el funcionamiento del juego,
pero se encontro que podria sobrecomplicar la programacion, era innecesario y podria aumentra la complejidad computacional del juego

## Conclusiones

Despúes del desarrollo se concluye que las traslación de las mecánicas del tetris a un entorno
3D no es una  buena idea, porque el control es engorroso, el juego es suceptible a problemas de cámara
y en general la experiencia de juego, es poco gratificante.
Por otro lado el manejo de vectores como la base de estos juegos simplifica en gran medida la logica y programacion del mismo,
con algo de practica puede haber una adaptación a los controles.


