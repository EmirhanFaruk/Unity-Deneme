using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirdiYoneticisi : MonoBehaviour
{
    private OyuncuGirdisi oyuncuGirdisi;
    private OyuncuGirdisi.AyaktaActions ayakta;
    private OyuncuMotoru motor;

    // Start is called before the first frame update
    void Awake()
    {
        oyuncuGirdisi = new OyuncuGirdisi();
        ayakta = oyuncuGirdisi.Ayakta;
        motor = GetComponent<OyuncuMotoru>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Oyuncu motorunu oyuncu girdisine bakarak hareket ettirt.
        motor.HareketIsle(ayakta.Hareket.ReadValue<Vector2>());

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
