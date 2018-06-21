using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for start cutsecene
 */
public class StartScript : MonoBehaviour {

    /**
     * Reference to start camera
     */
    public GameObject startCamera;

    /**
     * Reference to main camera
     */
    public GameObject mainCamera;

    /**
     * Reference to player
     */
    public GameObject player;

    /**
     * Reference to statistic canvas
     */
    private GameObject stats;

    /**
     * Black texture
     */
    private Texture2D blackTex;

    /**
     * Alpha of black texture
     */
    private float alpha = 1;

    /**
     * Fading in flag
     */
    private bool fadingIn = false;

    /**
     * Fading out flag
     */
    private bool fadingOut = false;

    /**
     * Player scaling flag
     */
    private bool scaling = false;

    /**
     * Initialize black screen and set player position. Start Coroutine for last cutscene
     */
    void Start () {
        stats = GameObject.Find("CanvasScaled");
        blackTex = new Texture2D(1, 1);
        blackTex.SetPixel(0, 0, new Color(0, 0, 0, 1));
        blackTex.Apply();

        player.SetActive(false);
        player.gameObject.GetComponent<Player_motion>().activeMove = false;
        player.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        stats.gameObject.GetComponent<Canvas>().enabled = false;

        StartCoroutine(TheSequence());
    }

    /**
     * Coroutine responsible for cutscene
     */
    IEnumerator TheSequence() {
        yield return new WaitForSeconds(2);
        fadingIn = true;

        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(1);
        player.SetActive(true);
        scaling = true;

        yield return new WaitForSeconds(8);
        fadingIn = false;
        fadingOut = true;
        yield return new WaitForSeconds(2);
        mainCamera.SetActive(true);
        startCamera.SetActive(false);
        player.gameObject.GetComponent<Player_motion>().activeMove = true;
        stats.gameObject.GetComponent<Canvas>().enabled = true;
    }

    /**
     * Sets foreground color
     */
    void OnGUI() {
        GUI.color = new Color(0, 0, 0, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTex);
    }

    /**
     * Changes foreground alpha and player scale
     */
    void Update () {
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