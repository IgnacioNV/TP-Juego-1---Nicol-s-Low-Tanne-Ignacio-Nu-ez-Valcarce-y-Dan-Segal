using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productoScript : MonoBehaviour
{
    public GameObject[] arrayProducto;
    Vector3 positionProduct1 = new Vector3(-4, 1, 0);
    Vector3 positionProduct2 = new Vector3(4.8f, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The game has started!");
        foreach (GameObject producto in arrayProducto)
        {
            producto.SetActive(false);
        }
        crearRandom(positionProduct1);
        crearRandom(positionProduct2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void crearRandom(Vector3 position)
    {
        int aleatorio = Random.Range(0, arrayProducto.Length - 1);
        arrayProducto[aleatorio].SetActive(true);
        arrayProducto[aleatorio].transform.position = position;
    }
}
