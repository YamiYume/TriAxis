using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<GameObject> InField;

    private void Awake() {
        InField=new List<GameObject>();
    }

    private void Update() {

    }

    public bool Verification(Vector3 Candidate)
    {
        Localization();
        bool R=true;
        foreach (var item in InField)
        {
            if((int)item.transform.position.x==(int)Candidate.x & (int)item.transform.position.y==(int)Candidate.y & (int)item.transform.position.z==(int)Candidate.z){
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
    private void Elimination()
    {
        Localization();
        int M=0;
        for (int i = (int)-(this.transform.lossyScale.x-1)/2; i < (int)(this.transform.lossyScale.x-1)/2;i++)
        {
            List<GameObject> eliminable=new List<GameObject>();
            Vector3 P=new Vector3(i,(this.transform.lossyScale.y-1)/2,-(this.transform.lossyScale.z-1)/2);
            Vector3 n=new Vector3(1,0,0);
            foreach (var item in InField)
            {
                Vector3 variable=item.transform.position;
                if(variable.x*n.x+variable.y*n.y+variable.y*n.y==(P.x*n.x+P.y*n.y+P.z*n.z))
                {
                    eliminable.Add(item);
                }
            }
            if(eliminable.Count==81)
            {
                foreach (var item in eliminable)
                {
                    Destroy(item);
                }
                M+=1;
            }

        }
        if(M>0)
        {
            Localization();
            foreach (var item in InField)
            {
                item.GetComponent<Monomin>().Fall(M);
            }
        }
    }
}
