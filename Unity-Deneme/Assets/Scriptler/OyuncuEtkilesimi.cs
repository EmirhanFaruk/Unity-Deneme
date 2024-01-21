using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuEtkilesimi : MonoBehaviour
{
    private Camera kamera;
    [SerializeField]
    private float mesafe = 3f;

    // Start is called before the first frame update
    void Start()
    {
        kamera = GetComponent<OyuncuBak>().kamera;
    }

    // Update is called once per frame
    void Update()
    {
        // Kameranin ortasindan ileriye giden isin olustur.
        Ray isin = new Ray(kamera.transform.position, kamera.transform.forward);
        Debug.DrawRay(isin.origin, isin.direction * mesafe);
    }
}
