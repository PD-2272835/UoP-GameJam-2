//The following code snippet was adapted from BMo (youtube, 2022)
//https://www.youtube.com/watch?v=5NViMw-ALAo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject heartPrefab;
    //list of references to each heart
    public List<Heart> hearts = new List<Heart>();
    
    public int health, maxHealth; //max should be a multiple of 4 as each heart is split into quarters

    void Start()
    {
        DrawHearts();
    }
    
    public void TakeDamage(int _damage)
    {
        health -= _damage;
        DrawHearts();

        if (health <= 0)
        {
            return; //TODO: replace to invoke method for when player dies
        }
    }

    public void HealDamage(int _health)
    {
        health = (int)Mathf.Clamp(health + _health, 0f, maxHealth);

    }

    private void DrawHearts()
    {
        ClearHearts();

        for (int i = 0; i < maxHealth/4f; i++)
        {
            CreateHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int _heartStateRemainder = (int)Mathf.Clamp(health - (i * 4), 0, 4);
            hearts[i].SetHeartState((HeartState)_heartStateRemainder);
        }
    }

    private void ClearHearts()
    {
        foreach (Transform _t in transform)
        {
            Destroy(_t.gameObject);
        }
        hearts = new List<Heart>();
    }

    private void CreateHeart()
    {
        GameObject _newHeart = Instantiate(heartPrefab);
        _newHeart.transform.SetParent(transform);

        Heart _heartComponent = _newHeart.GetComponent<Heart>();
        _heartComponent.SetHeartState(HeartState.emptyHeart);
        hearts.Add(_heartComponent);
    }
}
