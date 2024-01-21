using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Etkilesimli : MonoBehaviour
{
    // Oyuncu etkilesimliye baktiginda cikacak yazi
    public string gozukecekYazi;

    // Oyuncu tarafindan cagirilacak.
    public void ErisTemel()
    {
        Eris();
    }

    public virtual void Eris() { }
}
