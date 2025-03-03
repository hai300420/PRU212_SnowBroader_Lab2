using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f; 
    [SerializeField] ParticleSystem finishEffect;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();

            GetComponent<AudioSource>().Play();

            Invoke("ReloadScene", loadDelay);
        }
    }

    /// <summary>
    /// Reload the Scene to Level 2
    /// </summary>
    void ReloadScene()
    {
        SceneManager.LoadScene("Level2");
    }
}
