using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWave : MonoBehaviour {

    public Text thisText;

    [SerializeField]
    private GameState state;

    public void StartWaveNow()
    {
        state.Dancer.ToggleBuildPhase(false);

        foreach(GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
        {
            tower.GetComponent<CircleCollider2D>().enabled = true;
        }
        GameObject.FindObjectOfType<Spawner>().IsSpawning = true;
        GameObject.FindGameObjectWithTag("InputField").SendMessage("StartMusic");
        GameObject.FindObjectOfType<boardScript>().IsMoving = true;
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
        {
            button.GetComponent<Button>().interactable = false;
        }
        thisText.color = Color.black;
    }
}
