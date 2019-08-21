using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation
{
    private float fadeTime = 0.4f;
    private Vector3 destination = new Vector3(0, 0.01f, 0.07f);
    private float scaleFactor = 1.0005f;

    public FadeAnimation(Transform transform, MonoBehaviour mono)
    {
        StartFade(transform, mono);
    }

    public void StartFade(Transform transform, MonoBehaviour mono)
    {
        var temp = Object.Instantiate(transform.parent.gameObject, transform.parent.transform.position, Quaternion.identity);
        var tempMar = new Material(temp.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial);

        for (int i = 0; i < temp.transform.childCount; i++)
        {
            var tempDet = temp.transform.GetChild(i).GetComponent<CollisionDetector>();
            if (tempDet != null) Object.Destroy(tempDet);

            var tempRig = temp.transform.GetChild(i).GetComponent<Rigidbody>();
            if (tempRig != null) Object.Destroy(tempRig);

            var tempColl = temp.transform.GetChild(i).GetComponent<Collider>();
            if (tempColl != null) Object.Destroy(tempColl);

            temp.transform.GetChild(i).GetComponent<Renderer>().material = tempMar;

            float fadeTime = 0.5f;
            iTween.FadeTo(temp.transform.GetChild(i).gameObject, 0, fadeTime);
            mono.StartCoroutine(AnimatePass(temp.transform, fadeTime));
        }
    }

    IEnumerator AnimatePass(Transform obj, float time)
    {
        for (int i = 0; i < time / Time.deltaTime; i++)
        {
            obj.Translate(destination);
            obj.transform.localScale *= scaleFactor;
            yield return new WaitForSeconds(Time.deltaTime / 2f);
        }

        Object.Destroy(obj.gameObject);
    }
}
