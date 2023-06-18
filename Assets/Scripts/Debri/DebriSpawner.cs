using UnityEngine;
using UnscriptedLogic.MathUtils;
using UnscriptedLogic.WaveSystems.Sequential.PointBased;

public class DebriSpawner : MonoBehaviour
{
    public enum SpawnDirection
    {
        UP, DOWN, LEFT, RIGHT
    }

    [SerializeField] private Vector2 spawnArea;

    [Tooltip("This makes the asteroids move at a slanted angle")]
    [SerializeField] private Vector2 randomAngleOffset;
    [SerializeField] private SpawnDirection spawnDirection;
    [SerializeField] private SpawnerSettings settings;

    private PointBasedWaveSystem spawnSystem;

    private void Start()
    {
        spawnSystem = new PointBasedWaveSystem(settings, WhenSpawn, OnComplete, true);

        Debug.Log(settings.isInfinite);
    }

    private void Update()
    {
        spawnSystem.UpdateSpawner();
    }

    private void WhenSpawn(GameObject objectToSpawn)
    {
        Vector2 randomPos = RandomLogic.InArea2D(spawnArea);
        GameObject spawnable = Instantiate(objectToSpawn, (Vector2)transform.position + randomPos, Quaternion.identity, transform);

        Vector3 direction = Vector3.up;
        switch (spawnDirection)
        {
            case SpawnDirection.DOWN:
                direction = Vector3.down;
                break;
            case SpawnDirection.LEFT:
                direction = Vector3.left;
                break;
            case SpawnDirection.RIGHT:
                direction = Vector3.right;
                break;
            default:
                direction = Vector3.up;
                break;
        }

        //Random angle offset: https://gamedev.stackexchange.com/questions/151840/random-direction-vector-relative-to-current-direction
        float angle = RandomLogic.BetFloats(randomAngleOffset);
        Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
        Vector3 newDir = quaternion * direction;
        spawnable.transform.right = newDir;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea.x, spawnArea.y, 0f));        
    }

    //This function technically shouldn't be ran at all since it's going to go on for infinity
    private void OnComplete() {}
}
