using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class productoScript : MonoBehaviour
{
    public GameObject[] arrayProducto;
    Vector3 positionProduct1 = new Vector3(-4, 1, 0);
    Vector3 positionProduct2 = new Vector3(4.8f, 1, 0);

    public Text precioProducto1;
    public Text precioProducto2;
    public InputField inputPrecio;
    private float suma;
    public Text textoNotificacion;
    public GameObject PanelMain;
    public GameObject selectorJuego;
    public GameObject BTNIncorrecto;
    public GameObject BTNCorrecto;

    // Start is called before the first frame update
    void Start()
    {
        SecuenciaObjetoRandom();
        textoNotificacion.text = "";
        PanelMain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SecuenciaObjetoRandom()

    {
        Debug.Log("The game has started!");
        foreach (GameObject producto in arrayProducto)
        {
            producto.SetActive(false);
        }
        GameObject producto1 = crearRandom(positionProduct1);
        GameObject producto2 = crearRandom(positionProduct2);

        precioProducto1.text = "$" + producto1.GetComponent<precioScript>().precio.ToString();
        precioProducto2.text = "$" + producto2.GetComponent<precioScript>().precio.ToString();

        suma = producto1.GetComponent<precioScript>().precio + producto2.GetComponent<precioScript>().precio;

    }

    GameObject crearRandom(Vector3 position)
    {
        int aleatorio = Random.Range(0, arrayProducto.Length);
        arrayProducto[aleatorio].SetActive(true);
        arrayProducto[aleatorio].transform.position = position;
        return arrayProducto[aleatorio];
    }



    //
    public void ValidarSuma()
    {
        if (string.IsNullOrEmpty(inputPrecio.text))
        {
            MostrarNotificacion("Debes ingresar un resultado");
           

        }
        else
        {
            float valorIngresado = float.Parse (inputPrecio.text);
            bool esNumero = float.TryParse(inputPrecio.text, out valorIngresado);

            if (esNumero)
            {
                if (valorIngresado == suma)
                {
                    PanelMain.SetActive(true);
                    BTNIncorrecto.SetActive(false);
                    BTNCorrecto.SetActive(true);
                    MostrarNotificacion("Resultado correcto");
                }
                else
                {
                    PanelMain.SetActive(true);
                    BTNCorrecto.SetActive(false);
                    BTNIncorrecto.SetActive(true);
                    MostrarNotificacion("Resultado incorrecto");
                }
            }
            else
            {
                MostrarNotificacion("Ingresa un valor numérico válido");
            }
        }
    }

    // Método para mostrar notificaciones
    void MostrarNotificacion(string mensaje)
    {
        textoNotificacion.text = mensaje;

    }


    public void volverajugar()
    {  
        selectorJuego.SetActive(false);
        PanelMain.SetActive(false);
        textoNotificacion.text = "";
        inputPrecio.text = "";

    }
    public void reiniciarJuego()
    {
        
            selectorJuego.SetActive(false);
            PanelMain.SetActive(false);
            SecuenciaObjetoRandom();
            textoNotificacion.text = "";
            inputPrecio.text = "";
        

    }
    public void salirJuego()
    {
        selectorJuego.SetActive(true);
        textoNotificacion.text = "";
        inputPrecio.text = "";
    }
}

