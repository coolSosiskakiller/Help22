using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject RandomSpawn(GameObject prefab, string name, float radius)
    {
        GameObject gameObject = Instantiate(prefab);

        Vector3 position = new Vector3();
        position.x = Random.Range(0, 1000);
        position.y = Random.Range(0, 1000);
        position.z = Random.Range(0, 1000);
        position = position.normalized * radius;

        gameObject.transform.position = position;
        gameObject.name = name;

        return gameObject;
    }
}
