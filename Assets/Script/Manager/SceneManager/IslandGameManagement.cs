using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IslandGameManagement : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Wait for a while to let the door open animation complete before switching scenes
            StartCoroutine(WaitAndLoadScene());
        }
    }

    // Coroutine to wait for the animation to finish and load the next scene
    private IEnumerator WaitAndLoadScene()
    {
        // Wait for about 1.5 seconds (or adjust based on your animation length)
        yield return new WaitForSeconds(2f);

        // Load the next scene, replace "NextScene" with your scene name
        SceneManager.LoadScene(sceneName);
    }
}
