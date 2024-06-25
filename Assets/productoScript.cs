using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productoScript : MonoBehaviour
{
    public GameObject[] arrayProducto;
    Vector3 positionProduct1 = new Vector3(-3.77f, 0.8f, -0.1f);
    Vector3 positionProduct2 = new Vector3(3.89f, 0.8f, -0.1f);
    // Start is called before the first frame update
    void Start()
    {
        crearRandom1(positionProduct1);
        crearRandom1(positionProduct2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void crearRandom1(Vector3 position)
    {
        int aleatorio = Random.Range(0, arrayProducto.Length - 1);
        arrayProducto[aleatorio].SetActive(true);
        arrayProducto[aleatorio].transform.position = position;
    }
}
