using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimin : MonoBehaviour
{
    private Vector3[] Cubes;
    public GameObject Mono;
    private GameObject Field;
    private float time;
    private const float timeC=4/2;
    private Manager Manager;
    private bool InRotation;
    private Vector3 Rotation;
    private int Count;

    private void Awake() {
        Cubes=new Vector3[3];
        Field=GameObject.Find("/Tablero/Cube");
        time=timeC;
        Manager=GameObject.Find("/Manager").GetComponent<Manager>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.W) & !InRotation){
            if(Rotable()){
                Rotation=new Vector3(0,0,1);
                InRotation=true;
                Count=0;
            }
        }
        if(Input.GetKeyDown(KeyCode.S)& !InRotation){
            if(Rotable()){
                Rotation=new Vector3(0,0,-1);
                InRotation=true;
                Count=0;
            }
        }
        if(Input.GetKeyDown(KeyCode.A)& !InRotation){
            if(Rotable()){
                Rotation=new Vector3(-1,0,0);           
                InRotation=true;
                Count=0;
            }
        }
        if(Input.GetKeyDown(KeyCode.D)& !InRotation){
            if(Rotable()){
                Rotation=new Vector3(1,0,0);            
                InRotation=true;
                Count=0;
            }
        }
        if(Count<90)
        {
            this.gameObject.transform.Rotate(Rotation,Space.Self);
            Count+=1;   
        }
        else
        {
            InRotation=false;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) & !InRotation){
            if(Valid(Vector3.up)){
                this.gameObject.transform.Translate(Vector3.up,Space.World);
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) & !InRotation){
            if(Valid(Vector3.down)){
                this.gameObject.transform.Translate(Vector3.down,Space.World);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) & !InRotation){
            if(Valid(new Vector3 (0,0,1))){
                this.gameObject.transform.Translate(new Vector3 (0,0,1),Space.World);
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) & !InRotation){
            if(Valid(new Vector3 (0,0,-1))){
                this.gameObject.transform.Translate(new Vector3 (0,0,-1),Space.World);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) & !InRotation){
            if(Valid(new Vector3 (-1,0,0))){
                this.gameObject.transform.Translate(new Vector3 (-1,0,0),Space.World);
            }
        }
        if (time<=0 & !InRotation)
        {
            if(Valid(new Vector3 (-1,0,0)))
            {
                this.gameObject.transform.Translate(new Vector3 (-1,0,0),Space.World);
                time=timeC;
            }
            else
            {
                Localize();
                foreach (var item in Cubes){
                    Instantiate(Mono,item,Quaternion.identity);
                }
                Manager.SpawnNewTrimino();
                Destroy(this.gameObject);
            }
        }
        else
        {
            time-=Time.deltaTime;
        }
    }

    private bool Valid(Vector3 Movement)
    {
        bool R=true;
        Localize();
        for (int i = 0; i < Cubes.Length; i++)
        {
            if(Movement==Vector3.up)
            {
                R=R&(Cubes[i].y<(Field.transform.lossyScale.y-1)/2)&Field.GetComponent<Field>().Verification(Cubes[i]+Movement);
            }
            if(Movement==Vector3.down)
            {
                R=R&(Cubes[i].y>-(Field.transform.lossyScale.y-1)/2)&Field.GetComponent<Field>().Verification(Cubes[i]+Movement);
            }
            if(Movement==new Vector3 (0,0,1))
            {
                R=R&(Cubes[i].z<(Field.transform.lossyScale.z-1)/2)&Field.GetComponent<Field>().Verification(Cubes[i]+Movement);
            }
            if(Movement==new Vector3 (0,0,-1))
            {
                R=R&(Cubes[i].z>-(Field.transform.lossyScale.z-1)/2)&Field.GetComponent<Field>().Verification(Cubes[i]+Movement);
            }
            if(Movement==new Vector3 (-1,0,0))
            {
                R=R&(Cubes[i].x>-(Field.transform.lossyScale.x-1)/2)&Field.GetComponent<Field>().Verification(Cubes[i]+Movement);
            }
            if(Movement==new Vector3 (1,0,0))
            {
                R=R&Field.GetComponent<Field>().Verification(Cubes[i]+Movement);
            }
        }
        return R;
    }
    private void Localize()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++){
            Cubes.SetValue(this.gameObject.transform.GetChild(i).position,i);
        }
    }
    private bool Rotable()
    {
        bool R=true;
        R&=this.gameObject.transform.position.x>-(Field.transform.lossyScale.x-1)/2;
        R&=this.gameObject.transform.position.y>-(Field.transform.lossyScale.y-1)/2;
        R&=this.gameObject.transform.position.y<(Field.transform.lossyScale.y-1)/2;
        R&=this.gameObject.transform.position.z>-(Field.transform.lossyScale.z-1)/2;
        R&=this.gameObject.transform.position.z<(Field.transform.lossyScale.z-1)/2;
        R&=Valid(Vector3.up);
        R&=Valid(Vector3.down);
        R&=Valid(new Vector3 (0,0,1));
        R&=Valid(new Vector3 (0,0,-1));
        R&=Valid(new Vector3 (-1,0,0));
        R&=Valid(new Vector3 (1,0,0));
        return R;
    }

}
