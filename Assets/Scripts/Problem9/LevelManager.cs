using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void LoadProblem1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadProblem2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadProblem8()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadProblem9()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadProblem10()
    {
        SceneManager.LoadScene(0);
    }
}
