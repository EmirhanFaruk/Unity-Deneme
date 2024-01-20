using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuMotoru : MonoBehaviour
{
    private CharacterController denetleyici;
    private Vector3 oyuncuIvmesi;
    public float hiz = 5f;

    // Start is called before the first frame update
    void Start()
    {
        denetleyici = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // GirdiYöneticisi.cs'den girdi al ve onu denetleyiciye uygula
    public void HareketIsle(Vector2 girdi)
    {
        Vector3 hareketYonu = Vector3.zero;
        hareketYonu.x = girdi.x;
        hareketYonu.z = girdi.y;
        denetleyici.Move(transform.TransformDirection(hareketYonu) * hiz * Time.deltaTime);
    }
}
