using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimation : MonoBehaviour {

    public Animator trainAnimator;

    void Start() {
        StartCoroutine(iBump());
    }

    public IEnumerator iBump() {
        float wait = Random.Range(0.5f,2.0f);
        yield return new WaitForSeconds(wait);
        trainAnimator.SetBool("Bump", true);
        yield return new WaitForEndOfFrame();
        trainAnimator.SetBool("Bump", false);
        StartCoroutine(iBump());
    }
	
}
