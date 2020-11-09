using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<GameObject> InField;
    private Manager Manager;

    private void Awake() {
        InField=new List<GameObject>();
        Manager=GameObject.Find("/Manager").GetComponent<Manager>();
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
        InField.Clear();
        for (int i = 0; i < this.gameObject.transform.childCount; i++){
            InField.Add(this.gameObject.transform.GetChild(i).transform.gameObject);
        }
    }
    public void Elimination()
    {
        for (int i = 4; i > -1; i--)
        {
            Localization();
            List<GameObject> eliminable=new List<GameObject>();
            foreach (var item in InField)
            {
                if (Vector3Int.RoundToInt(item.transform.position).x==-2+i)
                {
                    eliminable.Add(item);
                }
                
            }
            if(eliminable.Count==25)
            {
                foreach (var item in eliminable)
                {
                    Destroy(item);
                }
                Localization();
                foreach (var item in InField)
                {
                    item.GetComponent<Monomin>().Fall(i);
                }
                Manager.Score+=1000;
            }
        }
    }
}
