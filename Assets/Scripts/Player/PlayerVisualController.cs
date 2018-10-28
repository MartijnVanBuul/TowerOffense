using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Direction
{
    Down,
    DownLeft,
    DownRight,
    Left,
    Right,
    Up,
    UpLeft,
    UpRight,
    Undetermined
}

public class PlayerVisualController : MonoBehaviour {

    public List<Sprite> PlayerSpritesDown;
    public List<Sprite> PlayerSpritesDownLeft;
    public List<Sprite> PlayerSpritesDownRight;
    public List<Sprite> PlayerSpritesLeft;
    public List<Sprite> PlayerSpritesRight;
    public List<Sprite> PlayerSpritesUp;
    public List<Sprite> PlayerSpritesUpLeft;
    public List<Sprite> PlayerSpritesUpRight;

    private List<List<Sprite>> playerSprites = new List<List<Sprite>>();

    private PlayerController myPlayerController;
    private SpriteRenderer mySpriteRenderer;

    private E_Direction playerDirection;

    private int frameCounter;

    // Use this for initialization
    void Start () {
        myPlayerController = GetComponentInParent<PlayerController>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        playerSprites.AddRange(new List<List<Sprite>>{ PlayerSpritesDown,  PlayerSpritesDownLeft, PlayerSpritesDownRight, PlayerSpritesLeft, PlayerSpritesRight, PlayerSpritesUp, PlayerSpritesUpLeft, PlayerSpritesUpRight });
    }
	
	// Update is called once per frame
	void Update () {
        if (myPlayerController.currentSpeed.magnitude > 1)
            frameCounter += Mathf.RoundToInt(myPlayerController.currentSpeed.magnitude);
        else
            frameCounter = 0;

        playerDirection = Utility.DetermineDirection(myPlayerController.DirectionVector);

        if(playerDirection != E_Direction.Undetermined)
            mySpriteRenderer.sprite = playerSprites[(int)playerDirection][(frameCounter / 50) % 4];
	}
}
