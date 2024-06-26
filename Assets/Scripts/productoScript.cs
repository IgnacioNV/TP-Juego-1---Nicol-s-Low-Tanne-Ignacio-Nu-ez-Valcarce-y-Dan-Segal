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

    // Start is called before the first frame update
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject crearRandom(Vector3 position)
    {
        int aleatorio = Random.Range(0, arrayProducto.Length);
        arrayProducto[aleatorio].SetActive(true);
        arrayProducto[aleatorio].transform.position = position;
        return arrayProducto[aleatorio];
    }
}

