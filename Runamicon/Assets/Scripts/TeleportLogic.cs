using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        SceneManager.LoadScene(2);
    }
}
