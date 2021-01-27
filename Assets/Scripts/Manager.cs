using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour

{

    public GameObject spawn;
    public GameObject player;
    public GameObject gem;
    public GameObject currentPlayer;
    public GameObject cam;
    CameraMovement camMov;
    public Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
        camMov = cam.GetComponent<CameraMovement>();
        currentPlayer = Instantiate(player, spawn.transform.position, Quaternion.identity);
        camMov.lookTarget = currentPlayer.transform;
        camMov.camTarget = currentPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn && Input.GetKeyDown(KeyCode.Return) && player)
        {
            if (currentPlayer == null)
            {
                currentPlayer = Instantiate(player, spawn.transform.position, Quaternion.identity);
                camMov.lookTarget = currentPlayer.transform;
                camMov.camTarget = currentPlayer.transform;
            }
        }

        scoreText.text = "Score\n" + ScoreManager.getScore();

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
