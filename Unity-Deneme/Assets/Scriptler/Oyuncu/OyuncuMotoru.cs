using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuMotoru : MonoBehaviour
{
    private CharacterController denetleyici;
    private Vector3 oyuncuIvmesi;
    private bool yerde;

    public float hiz = 5f;
    public float yercekimi = -9.8f;
    public float ziplamaYuksekligi = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        denetleyici = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        yerde = denetleyici.isGrounded;
    }

    // GirdiYöneticisi.cs'den girdi al ve onu denetleyiciye uygula
    public void HareketIsle(Vector2 girdi)
    {
        Vector3 hareketYonu = Vector3.zero;
        hareketYonu.x = girdi.x;
        hareketYonu.z = girdi.y;
        denetleyici.Move(transform.TransformDirection(hareketYonu) * hiz * Time.deltaTime);

        oyuncuIvmesi.y += yercekimi * Time.deltaTime;

        if (yerde && oyuncuIvmesi.y < 0)
        {
            oyuncuIvmesi.y = -2f;
        }

        denetleyici.Move(oyuncuIvmesi * Time.deltaTime);
    }


    public void Zipla()
    { 
        if(yerde)
        {
            oyuncuIvmesi.y = Mathf.Sqrt(ziplamaYuksekligi * yercekimi * -1.0f);
        }
    }
}
