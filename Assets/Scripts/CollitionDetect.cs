using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollitionDetect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {


        Debug.Log("Player detected");

        GameOver();
    }

    private void GameOver() {
        StartCoroutine(GameOverRoutine());
    }


    private IEnumerator GameOverRoutine() 
    {
        
        //PRINTING CANVA

        GameObject myGO;
        GameObject myText;
        Canvas myCanvas;
        Text text;
        RectTransform rectTransform;

        // Canvas
        myGO = new GameObject();
        myGO.name = "GameOverCanva";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        // Text
        myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = "Game Over";

        text = myText.AddComponent<Text>();
        text.text = "Un fugitif ! Attrapez le !";
        text.fontSize = 50;
        text.color = Color.white;

        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(6000, 150);


        //STOP THE CHARACTER ANIMATION
        GameObject.Find("Character_A_Full_Leather_4").GetComponent<Animator>().SetBool("isIdle", true);
        GameObject.Find("Character_A_Full_Leather_4").GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();

        //WAIT AND RELOAD SCENE
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}