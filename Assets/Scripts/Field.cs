using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<GameObject> InField;

    private void Awake() {
        InField=new List<GameObject>();
    }

    public bool Verification(Vector3 Candidate)
    {
        Localization();
        bool R=true;
        foreach (var item in InField)
        {
            if(Vector3Int.Distance(Vector3Int.RoundToInt(Candidate),Vector3Int.RoundToInt(item.transform.position))<1){
                R=false;
            }
        }
        return R;
    }

    private void Localization()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++){
            InField.Add(this.gameObject.transform.GetChild(i).transform.gameObject);
        }
    }
    public void Elimination()
    {
        Debug.Log("here");
        Localization();
        for (int i = 0; i < this.gameObject.transform.lossyScale.x; i++)
        {
            int M=0;
            List<GameObject> eliminable= new List<GameObject>();
            foreach (var item in InField)
            {
                if((int)-(this.transform.lossyScale.y-1)/2+i==Vector3Int.RoundToInt(item.gameObject.transform.position).x)
                {
                    eliminable.Add(item);
                }
            }
            if(eliminable.Count==25)
            {
                M+=1;
                foreach (var item in eliminable)
                {
                    Destroy(item);
                }
            }
            if(M>0)
            {
                Localization();
                foreach (var item in eliminable)
                {
                    item.GetComponent<Monomin>().Fall(M);
                }
            }
        }
    }
}
