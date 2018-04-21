using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public void StartIntro()
    {
        SceneManager.LoadScene("Story");
    }
}
