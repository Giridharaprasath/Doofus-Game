using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void IncreaseScore()
    {
        Score++;
    }
}
