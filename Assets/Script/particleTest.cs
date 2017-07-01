using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleTest : MonoBehaviour {
    public ParticleSystem particles;
    public Transform particlesAttractor;
    public float Attractortime = 1;
    public float acc = 10;

    private float time;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((time += Time.deltaTime) > Attractortime)
        {
            ParticleSystem.Particle[] ps = new ParticleSystem.Particle[particles.particleCount];
            particles.GetParticles(ps);
            for (int i = 0; i < ps.Length; i++)
                ps[i].velocity = Vector3.Lerp(ps[i].velocity, (particlesAttractor.position - ps[i].position).normalized, 1f) * acc;
            particles.SetParticles(ps, ps.Length);
        }
    }
}
