using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTurretButton : MonoBehaviour {

    public GameObject ToCreateOnClick; //Turret Object
    public GameObject GhostTurretSprite; //Transparent thingy
    private GameObject SpriteThatFollowsTheMouse;
    private bool InPlacingMode = false;
    private bool DropIsValid = false;
    private GameObject CurrentlyPointedTile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && InPlacingMode && DropIsValid)
        {

            var instancePosition = new Vector3(SpriteThatFollowsTheMouse.transform.position.x, SpriteThatFollowsTheMouse.transform.position.y, SpriteThatFollowsTheMouse.transform.position.y);
            Instantiate(ToCreateOnClick, instancePosition, Quaternion.identity);
            Destroy(CurrentlyPointedTile);
            CurrentlyPointedTile = null;
            DropOutOfPlacingMode();
        }
        if (Input.GetMouseButtonDown(1) && InPlacingMode) DropOutOfPlacingMode();
    }

    private void DropOutOfPlacingMode()
    {
        Destroy(SpriteThatFollowsTheMouse);
        SpriteThatFollowsTheMouse = null;
        InPlacingMode = false;
        DropIsValid = false;
    }

    private bool IsValidDropLocation()
    {
        return (IsOnATile() != new Vector2(0, 0));
    }

    private Vector2 IsOnATile()
    {
        RaycastHit2D hit = Physics2D.Raycast(Helpers.GetMousePosition(), -Vector3.forward);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Node")
                {
                    DropIsValid = true;
                CurrentlyPointedTile = hit.collider.gameObject;
                    return new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y);
                }
            }
        CurrentlyPointedTile = null;
        DropIsValid = false;
        return new Vector2(0,0);
    }

    private void OnGUI()
    {
        if (InPlacingMode)
        {
            SpriteThatFollowsTheMouse.transform.position = new Vector3(Helpers.GetMousePosition().x, Helpers.GetMousePosition().y, -2);
            var tempPosition = IsOnATile();
            if (tempPosition != new Vector2(0, 0)) SpriteThatFollowsTheMouse.transform.position = new Vector3(tempPosition.x, tempPosition.y, -2);
        }
    }

    public void OnMouseDown()
    {
        if (!InPlacingMode)
        {
            SpriteThatFollowsTheMouse = Instantiate(GhostTurretSprite);
            InPlacingMode = true;
        }
    }
}
