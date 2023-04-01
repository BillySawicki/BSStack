using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//User Interface namespace
using UnityEngine.UI;
//scene management namespace
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Current cube game object
    [Header("Cube Object")]
    public GameObject currentCube;
    //last cube game object
    [Header("Last Cube Object")]
    public GameObject lastCube;
    //Text object
    [Header("Text object")]
    public Text text;
    //Level number interger
    [Header("Current Level")]
    public int Level;
    //Boolean determining if game 
    //is over
    [Header("Boolean")]
    public bool Done;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //New Block function to create new blocks for the game 
    void Newblock(){
        //If the last cube is not destroyed
        if(lastCube != null){
            //The current cube position equals to all 3 axis positions
            //to the nearest interger 
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x), 
            currentCube.transform.position.y, Mathf.Round(currentCube.transform.position.z));
            //current cubes size equals to the last cube size
            currentCube.transform.localScale = new Vector3(lastCube.transform.localScale.x - Mathf.Abs(currentCube.transform.position.x 
            - lastCube.transform.position.x), lastCube.transform.localScale.y, lastCube.transform.localScale.z - Mathf.Abs(currentCube.transform.position.z
            - lastCube.transform.position.z));
            //current cubes positions equals to the current cubes x position
            //last cubes y postion
            //z axis position of 0.5
            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;

            //is less than or equal to 0 or if the 
            //current cube size on the x axis is less 
            //than or equal to 0
            if(currentCube.transform.localScale.x <= 0f || 
            currentCube.transform.localScale.z <=0f)
            {
                //Done equals to true
                Done = true;
                //text is visible 
                text.gameObject.SetActive(true);
                //Text equalks to the text of the final score
                //and which level is played 
                text.text = "Final Score: " + Level;
                //Start Corountine function X
                StartCoroutine(X());
                //returns value
                return;
            }
        }
        //Last cube equals to the current cube
        lastCube = currentCube;
        //Current cube equals to the spawned last cube
        currentCube = Instantiate(lastCube);
        //current cubes name equals to the level number. 
    }
}
