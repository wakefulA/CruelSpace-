using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingService : MonoBehaviour
{
    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
