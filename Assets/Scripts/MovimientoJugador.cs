using UnityEngine;
using UnityEngine.InputSystem;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSalto = GetComponent<AudioSource>();
    }

    void Update()
    {
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

        NotificarCambioUI();
    }

    private void OnCollisionEnter(Collision collision) {
        Rigidbody rbImpactado = collision.gameObject.GetComponent<Rigidbody>();

        if (rbImpactado != null)
        {
            Vector3 direccionFuerza = collision.gameObject.transform.position - transform.position;
            rbImpactado.AddForce(direccionFuerza.normalized * 2f, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Suelo"))
        {
            puedeSaltar = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Moneda")) {
            Debug.Log("Moneda recogida.");
            monedasTotales++;
            Debug.Log(salud + "-" + monedasTotales + "-" + vidasRestantes);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("QuitarSalud"))
        {
            Debug.Log("-20 de salud");
            salud -= 20;
            Debug.Log(salud + "-" + monedasTotales + "-" + vidasRestantes);
            Destroy(other.gameObject);
        }
    }

    // NOTIFICAR CAMBIOS EN LA UI
    private void NotificarCambioUI()
    {
        uiManager.ActualizarHUD(salud, 100, monedasTotales, vidasRestantes);
    }

}