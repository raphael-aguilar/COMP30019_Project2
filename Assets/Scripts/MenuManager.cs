using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // need to go over to unity, create a new gameobject, and attach the gameobject to the button
    //the, you go to the onCLick() section and choose this method
    public void startGame(){
        //when function is called, start the game
        // at this point it's just single beacuse we want to click scene, go to next scene
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void instructions(){
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }

    public void levels(){
        SceneManager.LoadScene("Levels");
    }

    public void backToMenu(){
        SceneManager.LoadScene("Main Menu");
    }

}
