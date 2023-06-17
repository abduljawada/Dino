using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    [Header("Speed Management")]
    [SerializeField] public float speed = 1f;
    [SerializeField] private float speedIncrease = 90f;
    [SerializeField] private float initialRoundTime = 10f;
    private float _roundDistance;
    private float _currentRoundDistance;

    [Header("Spawning")] 
    [SerializeField] private GameObject[] obstaclesPrefabs;

    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float spawnDistanceDelta = 2f;
    private float _distanceSinceSpawn;
    private float _nextSpawnDistance;

    [Header("Score")] 
    [SerializeField] private TMP_Text scoreText;
    private float _distanceTraveled;
    
    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _roundDistance = speed * initialRoundTime;
        _nextSpawnDistance = spawnDistance;
    }

    private void Update()
    {
        var deltaDistance = speed * Time.deltaTime;
        _currentRoundDistance += deltaDistance;
        _distanceSinceSpawn += deltaDistance;
        _distanceTraveled += deltaDistance;
        scoreText.text = ((int) _distanceTraveled).ToString();

        if (_currentRoundDistance >= _roundDistance)
        {
            _currentRoundDistance = 0f;
            speed += _roundDistance / speedIncrease;
        }

        if (_distanceSinceSpawn >= _nextSpawnDistance)
        {
            _distanceSinceSpawn = 0;
            _nextSpawnDistance = Random.Range(spawnDistance - spawnDistanceDelta, spawnDistance + spawnDistanceDelta);
            Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length - 1)]);
        }
    }
}
