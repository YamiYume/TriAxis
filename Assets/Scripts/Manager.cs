using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int Score;
    public GameObject[] Triminos;
    private bool aded;
    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
        Triminos=Resources.LoadAll<GameObject>("Triminos");
        aded=false;
        Application.targetFrameRate=60;
    }

    public void SpawnNewTrimino()
    {
        int I=Random.Range(1,11);
        Instantiate(Triminos[I],new Vector3(9,0,0),Quaternion.identity);
    }
    private void Update() {
         Scene scene = SceneManager.GetActiveScene();
         if(scene.name=="Game Over" & !aded){
            GameObject tex=GameObject.Find("/Base/Image/Score");
            tex.GetComponent<Text>().text+=Score.ToString();
            aded=true;
         }
         if(scene.name=="Game Over" & Input.anyKeyDown)
         {
             Application.Quit(0);
         }
    }
}
