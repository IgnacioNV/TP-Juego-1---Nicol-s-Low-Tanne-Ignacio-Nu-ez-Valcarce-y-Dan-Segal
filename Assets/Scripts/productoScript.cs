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
    public float suma;
    public Text textoNotificacion;
    // Start is called before the first frame update
    void Start()
    {
        SecuenciaObjetoRandom();
        textoNotificacion.text = "";
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
            float valorIngresado;
            bool esNumero = float.TryParse(inputPrecio.text, out valorIngresado);

            if (esNumero)
            {
                if (valorIngresado == suma)
                {
                    MostrarNotificacion("Resultado correcto");
                }
                else
                {
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
}

