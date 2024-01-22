using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dugme : Etkilesimli
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Eris()
    {
        Debug.Log(gameObject.name + " ile etkilesime girildi.");
    }

}
