using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollitionDetect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {

        if (other.name == "XR Rig") {

            Debug.Log("Player detected");

            GameOver();
        }
    }

    private void GameOver() {
        StartCoroutine(GameOverRoutine());
    }


    private IEnumerator GameOverRoutine() 
    {
        
        //PRINTING CANVA
        GameObject GameOverText;
        Text text;
        RectTransform rectTransform;

        // Canva
        Canvas UICanva = GameObject.Find("UICanva").GetComponent<Canvas>();

        // Text
        GameOverText = new GameObject();
        GameOverText.transform.parent = UICanva.transform;
        GameOverText.name = "Game Over";

        text = GameOverText.AddComponent<Text>();
        text.text = "Un fugitif ! Attrapez le !";
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.fontSize = 30;
        text.color = Color.white;

        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(10, -250, 0);
        rectTransform.sizeDelta = new Vector2(600, 100);
        rectTransform.localScale = new Vector3(1,1,1);

        //STOP THE CHARACTER ANIMATION
        GameObject.Find("Character_A_Full_Leather_4").GetComponent<Animator>().SetBool("isIdle", true);
        GameObject.Find("Character_A_Full_Leather_4").GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();

        //WAIT AND RELOAD SCENE
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
