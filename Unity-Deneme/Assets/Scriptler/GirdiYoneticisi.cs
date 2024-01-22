using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirdiYoneticisi : MonoBehaviour
{
    private OyuncuGirdisi oyuncuGirdisi;
    public OyuncuGirdisi.AyaktaActions ayakta;


    private OyuncuMotoru motor;
    private OyuncuBak bak;

    // Start is called before the first frame update
    void Awake()
    {
        oyuncuGirdisi = new OyuncuGirdisi();
        ayakta = oyuncuGirdisi.Ayakta;

        motor = GetComponent<OyuncuMotoru>();
        bak = GetComponent<OyuncuBak>();

        ayakta.Zipla.performed += ctx => motor.Zipla();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Oyuncu motorunu oyuncu girdisine bakarak hareket ettirt.
        motor.HareketIsle(ayakta.Hareket.ReadValue<Vector2>());

    }

    private void LateUpdate()
    {
        bak.BakIsle(ayakta.Bak.ReadValue<Vector2>());
    }


    private void OnEnable()
    {
        ayakta.Enable();
    }

    private void OnDisable()
    {
        ayakta.Disable();
    }

}
