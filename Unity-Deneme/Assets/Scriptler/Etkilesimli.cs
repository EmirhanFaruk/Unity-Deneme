using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Etkilesimli : MonoBehaviour
{
    // Oyuncu etkilesimliye baktiginda cikacak yazi
    public string bilgiYazisi;

    // Oyuncu tarafindan cagirilacak.
    public void ErisTemel()
    {
        Eris();
    }

    protected virtual void Eris() { }
}
