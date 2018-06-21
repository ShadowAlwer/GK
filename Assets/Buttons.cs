using UnityEngine;
using UnityEngine.SceneManagement;

/// Class defining behavior of buttons.
public class Buttons : MonoBehaviour {

    /// Defines behavior of the restart button in menu.
	public void onRestart() {
        SceneManager.LoadScene("scena");
    }

    /// Defines behavior of the exit button in menu.
    public void onExit() {
        Application.Quit();
    }

    /// Defines behavior of the start button in menu.
    public void onStart() {
        SceneManager.LoadScene("scena");
    }
}
