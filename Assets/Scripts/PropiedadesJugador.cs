using UnityEngine;

public class PropiedadesJugador : MonoBehaviour
{
    [SerializeField] private int vida;
    public string nombreJugador = "Fernando";
    [SerializeField] private float velocidad = 5.5f;

    void Start() {
        //Debug.Log("Bienvenido al juego " + nombreJugador + " !");
        //Debug.Log("START ejecutado en: " + gameObject.name);
        //EstandarizarVelocidad();

        Vida = 150;
        //Debug.Log("La salud es: " + vida);
    }

    void Update() {
        //Debug.Log("Velocidad:" + velocidad + " - Salud: " + vida);
        //ControlarEstado();
    }

    public int Vida{
        get { return vida; }
        set {
            if (value < 0) {
                vida = 0;
            } else if (value > 100) {
                vida = 100;
            } else {
                vida = value;
            }
        }
    }

    private void ControlarEstado() {
        if (vida <= 0) {
            //Debug.Log("Game Over");
        }
        else if (vida < 25){
            //Debug.Log("ADVERTENCIA: Salud baja.");
        }
        else {
            //Debug.Log("Salud del jugador estable:" + vida);
        }
    }

    private void EstandarizarVelocidad(){
        if (velocidad > 10.0f) {
            velocidad = 10.0f;
        }
    }

    private void Awake(){
        //Debug.Log("AWAKE ejecutado en: " + gameObject.name);
    }

    private void FixedUpdate(){
        if (velocidad >= 10.0f)
        {
            //Debug.Log("Velocidad máxima alcanzada.");
        }
    }
}
