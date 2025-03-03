using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crushEffect;
    [SerializeField] AudioClip crushSFX;
    public GameObject scoreUI;

    // "Has Crushed" Boolean
    bool hasCrushed = false; 


    /// <summary>
    /// Find Any Object By Type
    /// </summary>
    /// <param name="other"></param>
   void OnTriggerEnter2D(Collider2D other) 
   {

       // If the "Player" "Hits" the "Ground"
       if (other.tag == "Ground" && !hasCrushed)
        {

            // Set "Has Crushed" to "True"
            hasCrushed = true;

            // Find the "Player Controller" Object
            FindAnyObjectByType<PlayerController>().DisableControls();

           //  "Play" the "Crush Effect"
            crushEffect.Play();

            // "Play" the "Crush Sound Effect"
            GetComponent<AudioSource>().PlayOneShot(crushSFX);

            // "Invoke" the "ReloadScene()" Method
            Invoke("ReloadScene", loadDelay);
        }

        if(other.tag == "SnowTree")
        {
            Debug.Log("Snow Tree Hit");
            scoreUI.GetComponent<Score>().RemoveScore(10);
        }

        if (other.tag == "SnowRock")
        {
            Debug.Log("Snow Rock Hit");
            scoreUI.GetComponent<Score>().RemoveScore(10);
        }

        if (other.tag == "SnowFlakes")
        {
            Debug.Log("Snow Flake Hit");
            scoreUI.GetComponent<Score>().AddScore(10);
        }
    }
   
   /// <summary>
   /// Find Any Object By Type
   /// </summary>
   void ReloadScene()
   {
        SceneManager.LoadScene(0);
   }
}
