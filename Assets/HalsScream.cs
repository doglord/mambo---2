using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(AudioSource))]
public class HalsScream : MonoBehaviour
{
    SphereCollider collider;
    AudioSource source;
    void Start()
    { 
        collider = GetComponent<SphereCollider>();
        source = GetComponent<AudioSource>();
    }
    void OnTriggerStay(Collider coll)
    {
        Debug.Log("init");
        if(coll.transform.tag == "AudioModifierBody")
        {
            var modifiers = coll.transform.GetComponent<AudioModifier>();

            var position = coll.transform.position;
            var distance = Vector3.Distance(position, transform.position);
            var normalizedDistance = distance / collider.radius;

            Debug.Log(normalizedDistance);
            
            source.volume = normalizedDistance;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if(coll.transform.tag == "AudioModifierBody")
            source.volume = 1f;
    }
}
