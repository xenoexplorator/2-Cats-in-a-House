using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScreenManager : MonoBehaviour {

    public FadeFromBlack year;
    public FadeFromBlack story;
    public FadeFromBlack title;
    public FadeFromBlack continueButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        year.isStarted = true;
        if (year == null)
            story.isStarted = true;
        if (story == null)
            title.isStarted = true;
        if (title == null)
            continueButton.isStarted = true;
	}
}
