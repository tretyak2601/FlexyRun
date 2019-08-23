using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] FlexyPlayer flexy;
    [SerializeField] FloorManager floorManager;
    [SerializeField] ScoreManager scoring;

    public static GameController Instance;

    private Vector3 startFlexPosition = new Vector3(0, 8, 0);

    bool gameOver;
    public bool GameOver
    {
        get
        {
            return gameOver;
        }
        set
        {
            Instance.flexy.Moving.isMoving = !value;
            Instance.flexy.Size.IsSizing = !value;
            gameOver = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        flexy.Moving.OnLose += () => GameOver = true;
    }

    public void Restart()
    {
        flexy.Restart();
        flexy.transform.position = startFlexPosition;
        flexy.transform.localEulerAngles = Vector3.zero;
        flexy.Size.SetAvarageSize();
        flexy.Jump.Restart();
        floorManager.Restart();
        scoring.ResetScore();
        RageMode.Instance.Restart();
        GameOver = false;
    }
}
