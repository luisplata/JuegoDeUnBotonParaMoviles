# Juego de un botón que no hace nada

Este proyecto nace con la necesidad de implementar todo lo aprendido en el curo de SOLID y Clearn Code que https://thepowerups-learning.com nos a enseñado.
Por lo que voy a tratar de implementar en esta pagina el GDD del juego
Expandiendo con las funcionalidades tecnicas que debe tener.

La aplicación consta de 3 pantallas:
- Inicio del juego: Aqui debe de dar al jugador dos opciones: Jugar, Info
- Info: Es la pantalla de creditos donde estarán todos los participantes del proyecto
- Juego: donde estará el botón.

## Mecanica principal

Presionar el boton grande que esta en la pantalla.
Cuanto mas presione el botón mas puntos acumulará.

## Como lo debe guardar?

Esta puntuación debe guardarse en los datos del usuario en el servidor de PlayFabs que ya esta integrado en el proyecto.

El jugador al presionar el boton, esta puntuación debe guardarse en los PlayerPrefs (UNITY)
Al pasar 2 seg de no presionar el botón, se mandará la petición al servidor para guardar la información.

## Modificador de puntuación

La cantidad de puntos obtenido pueden ser condicionados por alguna metrica del servidor. (Test A/B)
por lo que debe estar abierto a esa operación.

## Spawn de personajes bailando

Se debe colocar personajes bailando el caramelldansen en el juego al ritmo de la música. a medida de que hagan mas puntos, será la cantidad de muñecos baildando en la pantalla.

## TDD

Cada funcionalidad debe estar acompañada de su TDD respectivo, ya sea un archivo nuevo o extendiendo uno ya existente, Respentando siempre SOLID

## GitHub Actions

Este proyecto debe tener un despliegue continuo, donde deben pasar las pruebas de test unitarios que se deben escribir para que sean aceptados en la rama principal.
Esto es importante que haya alguien que verifique el codigo de otro, para asi generar debate y mejorar entre todos. Siempre apoyandonos en los principios SOLID y Clean Code.

## Creditos

Los creditos del trabajo realizado estarán en:
- Pagina de Info del juego
- Pagina de GitHubPage del juego
- PlayStore

## Comantarios

Aqui se estarán agregando las funcionalidades que tendrá el juego.

Si deseas colaborar, puedes contactarme a `gamedev@peryloth.com` y con gusto puedo añadirte como colabor del repositorio para hacer pull request y demas
