// ▼ The "using" Keyword 
//      → defines the "Namespace" Directive 
//      → that "Contains" a "Class Used" in the "Code" ▼
using UnityEngine;
using UnityEngine.SceneManagement; // ◄◄ "SceneManagement" Namespace ◄◄


public class FinishLine : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f; 
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();

            GetComponent<AudioSource>().Play();

            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level2");
    }
}
