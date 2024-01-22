using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuEtkilesimi : MonoBehaviour
{
    private Camera kamera;
    [SerializeField]
    private float mesafe = 3f;
    [SerializeField]
    private LayerMask maske;
    private OyuncuArayuzu oyuncuArayuzu;
    private GirdiYoneticisi girdiYoneticisi;

    // Start is called before the first frame update
    void Start()
    {
        kamera = GetComponent<OyuncuBak>().kamera;
        oyuncuArayuzu = GetComponent<OyuncuArayuzu>();
        girdiYoneticisi = GetComponent<GirdiYoneticisi>();
    }

    // Update is called once per frame
    void Update()
    {
        oyuncuArayuzu.YaziGuncelle(string.Empty);
        // Kameranin ortasindan ileriye giden isin olustur.
        Ray isin = new Ray(kamera.transform.position, kamera.transform.forward);
        Debug.DrawRay(isin.origin, isin.direction * mesafe);

        RaycastHit isinSecimi; // Isinin dokundugu sey ve bilgileri.
        if (Physics.Raycast(isin, out isinSecimi, mesafe, maske)) // out 'un anlami fonksiyon bir deger dondurunce buna dondurecek.
        {
            if (isinSecimi.collider.GetComponent<Etkilesimli>() != null)
            {
                Etkilesimli etkilesimli = isinSecimi.collider.GetComponent<Etkilesimli>();
                oyuncuArayuzu.YaziGuncelle(etkilesimli.bilgiYazisi);
                if (girdiYoneticisi.ayakta.Etkiles.triggered)
                {
                    etkilesimli.ErisTemel();
                }
            }
        }
    }
}
