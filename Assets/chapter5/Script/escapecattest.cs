using UnityEngine;
using UnityEngine.SceneManagement;

public class escapecattest : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.UnloadSceneAsync("escapecattest");

        Destroy(gameObject);
    }
}
