using UnityEngine;
using UnityEngine.UI;

public class ExitBoatManager : MonoBehaviour
{

    GameObject exit;
    void Start() {
        exit = GameObject.Find("GoToNextSceneZone");
        exit.SetActive(false);
    }

    public void desactivateExit() {
        exit.SetActive(false);
    }

    public void activateExit() {

        //GameObject.Find("Zone").GetComponent<Renderer>().enabled = true;
        exit.SetActive(true);

        //PRINTING CANVA
        GameObject GoToNextSceneText;
        Text text;
        RectTransform rectTransform;

        // Canva
        Canvas UICanva = GameObject.Find("UICanva").GetComponent<Canvas>();

        // Text
        GoToNextSceneText = new GameObject();
        GoToNextSceneText.transform.parent = UICanva.transform;
        GoToNextSceneText.name = "GoToNextScene";

        text = GoToNextSceneText.AddComponent<Text>();
        text.text = "Vous avez la rame ! Rejoignez la zone indiquée pour quitter le bateau !";
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.fontSize = 30;
        text.color = Color.white;

        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -250, 0);
        rectTransform.sizeDelta = new Vector2(600, 100);
        rectTransform.localScale = new Vector3(1,1,1);

        GoToNextSceneText.AddComponent<SelfDestroyAfterXSec>();
    }
}
