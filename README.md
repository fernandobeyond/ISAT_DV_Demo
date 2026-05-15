# ISAT DV Demo - Proyecto de Laboratorio 🎮

¡Bienvenidos al proyecto de demostración para la asignatura Desarrollo de Videojuegos 2026-1! 
Este repositorio es un entorno de pruebas y aprendizaje creado para que los estudiantes de desarrollo de videojuegos puedan analizar, comprender y reutilizar mecánicas fundamentales programadas en **Unity** y **C#**.

---

## 🎯 ¿En qué consiste el proyecto?

Es un prototipo jugable diseñado para ilustrar la interacción entre distintos sistemas de Unity. El proyecto no busca ser un juego completo, sino un **laboratorio de mecánicas** donde se resuelven problemas comunes que todo desarrollador enfrenta: control de personajes, físicas vs. inteligencia artificial (IA), interfaces de usuario (UI), y mecánicas de disparo.

---

## 🚀 Avances actuales (Hasta el Sprint 13)

Durante los sprints anteriores se han implementado y perfeccionado las siguientes características:

1. **Nuevo Input System de Unity:** Migración y uso correcto del sistema de inputs moderno para teclado y ratón.
2. **Cámara Libre y Fluida:** Corrección de la sensibilidad del mouse. Se eliminó el `Time.deltaTime` en la lectura del delta del mouse, logrando que la cámara responda de forma exacta sin verse afectada por las caídas de fotogramas (FPS).
3. **Físicas y Movimiento del Jugador:** Uso de `Rigidbody` para saltos y colisiones, aplicando `freezeRotation` para evitar giros descontrolados al interactuar con el entorno.
4. **Inteligencia Artificial (NavMesh):** 
   - Enemigos que navegan por el mapa detectando obstáculos.
   - Resolución del clásico conflicto entre **NavMeshAgent** y **Rigidbody** (utilizando Rigidbody cinemático para la navegación).
5. **Comportamientos Enemigos Diferenciados:**
   - **Tirador:** Persigue hasta cierta distancia, se detiene, apunta bloqueando el eje Y (para no mirar al suelo) y dispara proyectiles.
   - **Saltador:** Persigue implacablemente usando Off-Mesh Links para saltar obstáculos, y hace daño cuerpo a cuerpo empujando al jugador mediante manipulación de velocidades directas en el NavMesh.
6. **Ciclo Día/Noche:** Un script optimizado para rotar la iluminación global dinámicamente y de forma segura (previniendo divisiones por cero).
7. **Sistema de Salud y Monedas:** Detección de colisiones (Triggers y Collisions) para recoger items, recibir daño, y actualizar un HUD en pantalla.

---

## 📂 Contenido del Proyecto (Scripts principales para estudiar)

Si quieres entender cómo funciona algo, te recomendamos leer los siguientes scripts dentro de la carpeta `Assets/Scripts/`:

* `MovimientoJugador.cs`: El núcleo del jugador. Muestra cómo usar `InputSystem` para moverse, saltar usando fuerzas (`AddForce`), detectar cuándo toca el suelo, y gestionar su vida/monedas.
* `ControlCamara.cs`: Te enseña cómo leer el movimiento del mouse y aplicarlo para rotar la cámara verticalmente (con límites, usando `Mathf.Clamp`) y rotar el cuerpo del personaje horizontalmente.
* `EnemigoTirador.cs` / `EnemigoSaltador.cs`: Ideales para aprender **Máquinas de Estado simples** y cómo utilizar `NavMeshAgent` en conjunto con detecciones de distancia (`Vector3.Distance`).
* `BalaEnemiga.cs`: Ejemplo práctico de cómo instanciar objetos, moverlos hacia adelante y auto-destruirlos (`Destroy`) después de un tiempo para no saturar la memoria RAM.
* `CicloDiaNoche.cs`: Un script muy corto e ideal para principiantes, mostrando cómo rotar un `Transform` a lo largo del tiempo.

---

## 🛠️ ¿Cómo usar y leer este proyecto? (Guía para Estudiantes)

Para sacar el máximo provecho a este repositorio, sigue estos pasos:

1. **Abre la escena principal:** Ve a `Assets/Scenes/` y abre `SampleScene`.
2. **Revisa la Pestaña Navigation:** Ve a `Window > AI > Navigation`. Observa las áreas horneadas (en azul) por donde pueden caminar los enemigos. Esto es esencial para que la IA funcione.
3. **Inspecciona al Jugador:** Selecciona el objeto del Jugador en la jerarquía. Fíjate en los componentes adjuntos (`Rigidbody`, `CapsuleCollider`, `MovimientoJugador`). Juega con los valores expuestos (como `velocidad` o `fuerzaSalto`).
4. **Analiza el Inspector en Modo Play (Play Mode):** Dale al botón de Play. Pausa el juego y selecciona a los enemigos. Podrás ver en tiempo real cómo cambia su destino (`SetDestination`) en el `NavMeshAgent`.
5. **Lee los comentarios en el código:** Los scripts han sido comentados explicando **por qué** se toman ciertas decisiones (ej. por qué un Rigidbody debe ser *cinemático* al usar NavMeshAgent).

> **💡 Consejo de Estudio:** Intenta modificar la velocidad de disparo del Enemigo Tirador, o crea un nuevo tipo de enemigo mezclando las lógicas del tirador y del saltador. ¡Romper cosas es la mejor forma de aprender!
