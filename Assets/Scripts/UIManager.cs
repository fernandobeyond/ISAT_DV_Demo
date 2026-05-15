using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Referencias de UI")]
    public Image barraSalud;
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoVidas;

    public void ActualizarHUD(int saludActual, int saludMax, int monedas, int vidas)
    {
        float porcentaje = (float)saludActual / saludMax;
        barraSalud.fillAmount = porcentaje;
        
        textoMonedas.text = monedas.ToString();
        textoVidas.text = vidas.ToString();
    }
}