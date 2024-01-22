using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OyuncuArayuzu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI arayuzBilgiYazisi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void YaziGuncelle(string yazi)
    {
        arayuzBilgiYazisi.text = yazi;
    }
}
