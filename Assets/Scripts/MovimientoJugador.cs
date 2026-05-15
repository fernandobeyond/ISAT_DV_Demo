using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 4f;
    [SerializeField] private float fuerzaSalto = 2f;
    private AudioSource audioSalto;
    [SerializeField] private bool puedeSaltar = true;
    private Rigidbody rb;

    public UIManager uiManager;
    [SerializeField] private int salud = 100;
    private int monedasTotales = 0;
    [SerializeField] private int vidasRestantes = 3;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        audioSalto = GetComponent<AudioSource>();

        NotificarCambioUI();
    }

    void Update() {
        // MOVIMIENTO BASICO
        Vector2 inputMovimiento = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) inputMovimiento.y = 1;
        if (Keyboard.current.sKey.isPressed) inputMovimiento.y = -1;
        if (Keyboard.current.aKey.isPressed) inputMovimiento.x = -1;
        if (Keyboard.current.dKey.isPressed) inputMovimiento.x = 1;

        Vector3 movimiento = (transform.right * inputMovimiento.x) + (transform.forward * inputMovimiento.y);
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

        // SALTO
        if (Keyboard.current.spaceKey.wasPressedThisFrame && puedeSaltar) {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            audioSalto.PlayOneShot(audioSalto.clip);
            puedeSaltar = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Rigidbody rbImpactado = collision.gameObject.GetComponent<Rigidbody>();

        if (rbImpactado != null) {
            Vector3 direccionFuerza = collision.gameObject.transform.position - transform.position;
            rbImpactado.AddForce(direccionFuerza.normalized * 2f, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Suelo")) {
            puedeSaltar = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Moneda")) {
            monedasTotales++;
            Destroy(other.gameObject);

            NotificarCambioUI();
        }

        if (other.CompareTag("QuitarSalud")) {
            RecibirDanio(20);
            Destroy(other.gameObject);
        }
    }

    public void RecibirDanio(int cantidad) {
        salud -= cantidad;
        Debug.Log("Salud actual: " + salud);
        NotificarCambioUI();

        if (salud <= 0) {
            Debug.Log("GAME OVER: Sin vidas.");
        }
    }

    private void NotificarCambioUI() {
        if (uiManager != null) {
            uiManager.ActualizarHUD(salud, 100, monedasTotales, vidasRestantes);
        }
    }
}