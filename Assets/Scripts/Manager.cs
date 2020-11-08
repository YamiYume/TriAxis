using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] Triminos;
    private void Awake() 
    {
        Triminos=Resources.LoadAll<GameObject>("Triminos");
    }

    public void SpawnNewTrimino()
    {
        int I=Random.Range(1,11);
        Instantiate(Triminos[I],new Vector3(9,0,0),Quaternion.identity);
    }
}
