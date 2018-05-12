using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void onRestart() {
        SceneManager.LoadScene("scena");
    }

    public void onExit() {
        Application.Quit();
    }

    public void onStart() {
        SceneManager.LoadScene("scena");
    }
}
