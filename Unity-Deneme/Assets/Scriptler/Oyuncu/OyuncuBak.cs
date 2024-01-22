using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuBak : MonoBehaviour
{
    public Camera kamera;
    private float xRotasyonu = 0.0f;

    public float xHassasiyeti = 30.0f;
    public float yHassasiyeti = 30.0f;

    public void BakIsle(Vector2 girdi)
    {
        float fareX = girdi.x;
        float fareY = girdi.y;

        // Kameranin yukari ve saga sola bakmasinin hesaplanmasi.
        xRotasyonu -= (fareY * Time.deltaTime) * yHassasiyeti;
        xRotasyonu = Mathf.Clamp(xRotasyonu, -80f, 80f);

        // Hesaplamalarin kameranin transform'una uygulanmasi.
        kamera.transform.localRotation = Quaternion.Euler(xRotasyonu, 0, 0);

        // Hesaplamalarin oyuncuya uygulanmasi.
        transform.Rotate(Vector3.up * (fareX * Time.deltaTime) * xHassasiyeti);
    }
}
