using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToddlerTulostin : MonoBehaviour
{
    public GameObject toddler;
    public ToddlerPicker picker;
    public string spawnerTag;

    public void spawnChild(LostChild properties, bool forceSpawn = false)
    {
        var freeSpawnPoints = getSpawnPoints(forceSpawn);
        if (freeSpawnPoints.Count == 0) return;
        var index = Random.Range(0, freeSpawnPoints.Count);

        var position = freeSpawnPoints[index].transform.position;

        var newToddler = Instantiate(toddler, position, new Quaternion());
        newToddler.GetComponent<ToddlerInfo>().toddlerInfo = properties;
        setToddlerProperties(newToddler, properties);
    }

    private List<Transform> getSpawnPoints(bool force = false)
    {
        var spawnPoints = GameObject.FindGameObjectsWithTag(spawnerTag);
        var freeSpawnPoints = new List<Transform>();
        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.TryGetComponent<SpawnPoint>(out var component))
            {
                if (component.check() || force == true)
                {
                    freeSpawnPoints.Add(spawnPoint.transform);
                }
            }
        }
        return freeSpawnPoints;
    }

    private void setToddlerProperties(GameObject kid, LostChild properties)
    {
        var renderers = kid.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.material.SetColor("_Color", picker.GetColor(properties.getColor()));
        }

        var size = picker.GetSize(properties.getSize());
        kid.transform.localScale = new Vector3(size, 1, size);

        var positions = kid.GetComponent<ToddlerPositions>();

        var hatParent = positions.hatTransform;
        var hat = Instantiate(picker.GetHat(properties.getHat()));
        hat.transform.position = hatParent.transform.position;
        hat.transform.localScale = new Vector3(size, 1, size);
        hat.transform.parent = hatParent;

        var handParent = positions.handTransform;
        var item = Instantiate(picker.GetItem(properties.getStolenItem()));
        item.transform.position = handParent.transform.position;
        item.transform.parent = handParent;
    }
}
