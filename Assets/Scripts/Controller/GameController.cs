using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using TMPro;
public class TOPICNAME
{
    public const string ENEMY_DIE = "Enemy_Die";
    public const string NEW_WAVE = "New_Wave";
}

public class GameController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txtScore, txtWave;

    int score = 0;
    int waveNum = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        DataManager.Instance.LoadData();
    }
    void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMY_DIE, OnEnemyDie);
        Observer.Instance.AddObserver(TOPICNAME.NEW_WAVE, OnNewWaveSpawned);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnemyDie(object data)
    {
        score++;
        txtScore.text = "Score: " + score.ToString();
    }

    void OnNewWaveSpawned(object data)
    {
        waveNum++;
        txtWave.text = "Wave " + waveNum.ToString();
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(TOPICNAME.ENEMY_DIE, OnEnemyDie);
    }
}
