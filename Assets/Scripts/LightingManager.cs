using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    List<Light> directionalLights = new List<Light>();
    List<Light> pointLights = new List<Light>();
    List<Light> spotLights = new List<Light>();
    Dictionary<Light, float> defaultIntensity = 
        new Dictionary<Light, float>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindAllLights();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TurnOffLights(LightType.Point, 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            TurnOnLights(LightType.Point, 1);
        }
    }

    void FindAllLights()
    {
        Light[] allLights = FindObjectsByType<Light>(FindObjectsSortMode.None);

        directionalLights = allLights.Where(l => l.type == LightType.Directional).ToList();
        pointLights = allLights.Where(l => l.type == LightType.Point).ToList();
        spotLights = allLights.Where(l => l.type == LightType.Spot).ToList();
        foreach (Light light in allLights)
        {
            defaultIntensity.Add(light, light.intensity);
        }
    }

    IEnumerator ChangeIntensity(List<Light> lights, float target, float time)
    {
        foreach (Light light in lights)
        {
            StartCoroutine(ChangeIntensity(light, light.intensity, target, time));
        }
        yield return null;
    }
    IEnumerator RestoreIntensity(List<Light> lights, float time)
    {
        foreach (Light light in lights)
        {
            StartCoroutine(ChangeIntensity(light, light.intensity, defaultIntensity[light], time));
        }
        yield return null;
    }
    IEnumerator ChangeIntensity(Light light, float from, float target,float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            light.intensity = Mathf.Lerp(from, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        light.intensity = target;
    }

    public void TurnOffLights(LightType type, float time)
    {
        List<Light> lightsToAffect = directionalLights;
        switch (type)
        {
            case LightType.Directional:
                lightsToAffect = directionalLights;
                break;
            case LightType.Point:
                lightsToAffect = pointLights;
                break;
            case LightType.Spot:
                lightsToAffect = spotLights;
                break;
        }

        StartCoroutine(ChangeIntensity(lightsToAffect, 0, time));
    }
    public void TurnOnLights(LightType type, float time)
    {
        List<Light> lightsToAffect = directionalLights;
        switch (type)
        {
            case LightType.Directional:
                lightsToAffect = directionalLights;
                break;
            case LightType.Point:
                lightsToAffect = pointLights;
                break;
            case LightType.Spot:
                lightsToAffect = spotLights;
                break;
        }

        StartCoroutine(RestoreIntensity(lightsToAffect, time));
    }

    
}
