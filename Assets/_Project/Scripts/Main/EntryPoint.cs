using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player1 _player;

    [Header("Resource Count")]
    [SerializeField] private int _oxygenCount;
    [SerializeField] private int _gasCount;
    [SerializeField] private int _trashCount;
    [SerializeField] private int _ufoCount;

    [Header("Prefabs")]
    [SerializeField] private GameObject _satellitePrefab;
    [SerializeField] private GameObject _oxygenPrefab;
    [SerializeField] private GameObject _gasPrefab;
    [SerializeField] private GameObject _trashPrefab;
    [SerializeField] private GameObject _ufoPrefab;
    [SerializeField] private GameObject _blackHolePrefab;
    [SerializeField] private GameObject _endPointPrefab;

    public void Awake()
    {
        GameObject satelitte = _spawner.RandomSpawn(_satellitePrefab, "Satelitte", Random.Range(25, 100));
        GameObject endPoint = _spawner.RandomSpawn(_satellitePrefab, "EndPoint", 0);
        endPoint.transform.position = -satelitte.transform.position;

        Rigidbody rigidbody = _player.GetComponent<Rigidbody>();
        rigidbody.MovePosition(satelitte.transform.position);
        rigidbody.MovePosition(rigidbody.position - rigidbody.position.normalized * 6);

        for (int i = 0; i < _oxygenCount; i++)
        {
            GameObject oxygen = _spawner.RandomSpawn(_oxygenPrefab, $"Oxygen {i}", Random.Range(0, 80));
            oxygen.transform.rotation = Quaternion.Euler(Random.Range(0, 40), 0, Random.Range(0, 40));
        }

        for (int i = 0; i < _gasCount; i++)
        {
            GameObject gas = _spawner.RandomSpawn(_gasPrefab, $"Gas {i}", Random.Range(0, 80));
            gas.transform.rotation = Quaternion.Euler(Random.Range(0, 40), 0, Random.Range(0, 40));
        }

        for (int i = 0; i < _trashCount; i++)
        {
            GameObject trash = _spawner.RandomSpawn(_trashPrefab, $"Trash{i}", Random.Range(0, 80));
            trash.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }

        for (int i = 0; i < _ufoCount; i++)
        {
            GameObject ufo = _spawner.RandomSpawn(_ufoPrefab, $"Ufo{i}", Random.Range(0, 100));
            ufo.GetComponent<UFO>().SetTarget(_player);
        }

        GameObject blackHoleGameObject0 = _spawner.RandomSpawn(_blackHolePrefab, $"Black Hole-0", Random.Range(0, 80));
        GameObject blackHoleGameObject1 = _spawner.RandomSpawn(_blackHolePrefab, $"Black Hole-1", Random.Range(0, 80));

        Blackhole blackHole0 = blackHoleGameObject0.GetComponent<Blackhole>();
        Blackhole blackhole1 = blackHoleGameObject1.GetComponent<Blackhole>();
        blackHole0.LinkedBlackhole(blackhole1);
        blackhole1.LinkedBlackhole(blackHole0);
    }
}
