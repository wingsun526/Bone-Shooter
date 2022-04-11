using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem enemySpawnParticle;

    private List<ParticleSystem> particleSystemList = new List<ParticleSystem>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private ParticleSystem getParticleSystem()
    {
        ParticleSystem ps = particleSystemList.Find(t => !t.gameObject.activeSelf); // particle auto disable when finished
        if (ps == null)
        {
            ps = Instantiate(enemySpawnParticle);
            particleSystemList.Add(ps);
        }

        return ps;
    }

    public void FireEnemySpawnParticle(Vector3 newLocation)
    {
        ParticleSystem ps = getParticleSystem();
        ps.transform.position = newLocation;
        ps.gameObject.SetActive(true);
        ps.Play();
    }
}
