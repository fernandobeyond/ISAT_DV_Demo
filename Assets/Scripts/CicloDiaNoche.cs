using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Header("Configuración del Ciclo")]
    [Tooltip("Cantidad de minutos reales que toma completar un día entero de 24 horas (360 grados).")]
    public float minutosPorDia = 1.0f;

    private float gradosPorSegundo;

    void Start()
    {
        if (minutosPorDia <= 0) minutosPorDia = 1f;
        gradosPorSegundo = 360f / (minutosPorDia * 60f);
    }

    void Update()
    {
        transform.Rotate(Vector3.right * gradosPorSegundo * Time.deltaTime);
    }
}
