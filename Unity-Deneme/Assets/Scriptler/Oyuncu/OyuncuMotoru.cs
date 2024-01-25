using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuMotoru : MonoBehaviour
{
    private CharacterController denetleyici;
    private Vector3 oyuncuIvmesi;
    private bool kosuyor = false;
    private bool yerde;

    public float hiz = 5f;
    public float maxHiz = 7f;
    public float sifirlayiciHiz = 0.8f;
    public float surtunme = 2f;

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

    // Vektor eger sifirlayiciHiz'a yakinsa sifirla
    private Vector3 Sifirlastir(Vector3 hareketYonu)
    {
        if (Mathf.Abs(hareketYonu.x) + Mathf.Abs(hareketYonu.z) < sifirlayiciHiz)
        {
            hareketYonu.x = 0.0f;
            hareketYonu.z = 0.0f;
        }

        return hareketYonu;
    }

    // Kosma ve yerde olma durumuna gore verilecek vektoru arttir veya azalt.
    private Vector3 Carpila(Vector3 hareketYonu)
    {
        float carpici = 1;
        if (kosuyor)
        {
            carpici *= 1.5f;
        }
        if (!yerde)
        {
            carpici *= 0.5f;
        }
        hareketYonu *= hiz * carpici;

        return hareketYonu;
    }

    // Vektore surtunme uygular.
    private Vector3 Yavaslat(Vector3 hareketYonu)
    {
        hareketYonu.x = Mathf.MoveTowards(hareketYonu.x, 0, surtunme);
        hareketYonu.z = Mathf.MoveTowards(hareketYonu.z, 0, surtunme);

        return hareketYonu;
    }

    // Vektor degeri cok fazla ise limitler.
    private Vector3 Limitle(Vector3 hareketYonu)
    {
        if (hareketYonu.x > 0)
        {
            if (kosuyor && hareketYonu.x > maxHiz * 1.5f)
            {
                hareketYonu.x = maxHiz * 1.5f;
            }
            else if (!kosuyor && hareketYonu.x > maxHiz)
            {
                hareketYonu.x = maxHiz;
            }
            
        }
        else if (hareketYonu.x < 0 && hareketYonu.x < -maxHiz)
        {
            hareketYonu.x = -maxHiz;
        }

        if (hareketYonu.z > 0 && hareketYonu.z > maxHiz)
        {
            hareketYonu.z = maxHiz;
        }
        else if (hareketYonu.z < 0 && hareketYonu.z < -maxHiz)
        {
            hareketYonu.z = -maxHiz;
        }

        return hareketYonu;
    }

    // GirdiYöneticisi.cs'den girdi al ve onu denetleyiciye uygula
    public void HareketIsle(Vector2 girdi)
    {
        Vector3 hareketYonu = Vector3.zero;
        hareketYonu.x = girdi.x;
        hareketYonu.z = girdi.y;

        hareketYonu = Carpila(hareketYonu);

        oyuncuIvmesi = Yavaslat(oyuncuIvmesi);

        oyuncuIvmesi = Sifirlastir(oyuncuIvmesi);

        oyuncuIvmesi = Limitle(oyuncuIvmesi);

        oyuncuIvmesi += transform.TransformDirection(hareketYonu);


        oyuncuIvmesi.y += yercekimi * Time.deltaTime;

        if (yerde && oyuncuIvmesi.y < 0)
        {
            oyuncuIvmesi.y = -2f;
        }

        Debug.Log(oyuncuIvmesi);

        denetleyici.Move(oyuncuIvmesi * Time.deltaTime);
    }


    public void Zipla()
    { 
        if(yerde)
        {
            oyuncuIvmesi.y = Mathf.Sqrt(ziplamaYuksekligi * yercekimi * -1.0f);
        }
    }

    public void Kos()
    {
        kosuyor = true;
    }

    public void KosmayiBirak()
    { 
        kosuyor = false; 
    }

}
