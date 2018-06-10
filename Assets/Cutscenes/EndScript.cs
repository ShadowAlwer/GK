using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    public GameObject endCamera;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject portal;
    private GameObject stats;

    private Texture2D blackTex;
    private float alpha = 1;
    private bool fadingIn = false;
    private bool fadingOut = false;
    private bool scaling = false;

    void Start() {
        stats = GameObject.Find("CanvasScaled");
        blackTex = new Texture2D(1, 1);
        blackTex.SetPixel(0, 0, new Color(0, 0, 0, 1));
        blackTex.Apply();

        player.gameObject.GetComponent<Player_motion>().activeMove = false;
        player.gameObject.GetComponent<Animator>().SetFloat("movement", 0f);
        stats.gameObject.GetComponent<Canvas>().enabled = false;

        endCamera.SetActive(true);
        mainCamera.SetActive(false);

        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence() {
        yield return new WaitForSeconds(1);
        player.transform.localPosition = new Vector3(35f, 83.8f, 62.2f);
        player.transform.localEulerAngles = new Vector3(0, 90, 0);

        fadingIn = true;
        gameObject.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(2);
        portal.SetActive(true);
        yield return new WaitForSeconds(1);
        fadingIn = false;
        fadingOut = true;
        yield return new WaitForSeconds(2);
        fadingIn = true;
        fadingOut = false;
        player.gameObject.GetComponent<Animator>().SetFloat("movement", 1f);
        yield return new WaitForSeconds(2);
        player.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        fadingIn = false;
        fadingOut = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }

    void OnGUI() {
        GUI.color = new Color(0, 0, 0, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTex);
    }

    void Update() {
        if (fadingIn) {
            alpha = Mathf.Max(alpha - Mathf.Clamp01(Time.deltaTime / 2), 0);
        }

        if (fadingOut) {
            alpha = Mathf.Min(alpha + Mathf.Clamp01(Time.deltaTime / 2), 1);
        }

        if (scaling) {
            if (player.transform.localScale.x <= 1) {
                player.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            }
        }
    }
}
