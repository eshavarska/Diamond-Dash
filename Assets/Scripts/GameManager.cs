using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GenderName
    {
        Girl,
        Boy
    }
    public static GameManager Instance { get; private set; }
    public static GenderName Gender { get; set; }
    public static int CurrentLevel { get; set; }

    public static int[] HighScores;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Gender = GenderName.Boy;
        HighScores = new int[8];
    }

}
