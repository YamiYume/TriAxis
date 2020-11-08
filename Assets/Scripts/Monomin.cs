using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monomin : MonoBehaviour
{
    private void Awake() {
        if (this.gameObject.transform.parent==null){
            this.gameObject.transform.parent=GameObject.Find("/Tablero/Cube").transform;
        }
    }

    public void Fall(int N)
    {
        if(this.gameObject.transform.position.x>-(this.transform.lossyScale.x-1)/2)
        this.gameObject.transform.Translate(new Vector3(-N,0,0),Space.World);
    }
}
