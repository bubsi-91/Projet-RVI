using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTheBoat : MonoBehaviour
{

    void OnTriggerEnter(Collider other) {
        if (other.name == "XR Rig") {
            SceneManager.LoadScene("boat");
        }
    }

}
