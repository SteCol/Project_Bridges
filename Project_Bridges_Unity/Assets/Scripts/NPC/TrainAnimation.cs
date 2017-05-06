using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimation : MonoBehaviour {

    public Animator trainAnimator;

    public List<GameObject> carts;

    void Start() {
        StartCoroutine(iBump());
    }

    public IEnumerator iBump() {
        float wait = Random.Range(2.0f,5.0f);
        yield return new WaitForSeconds(wait);
        trainAnimator.SetBool("Bump", true);
        for (int i = 0; i < carts.Count; i++)
        {
            StartCoroutine(iBumpCart(carts[i], i));
        }
        yield return new WaitForEndOfFrame();
        trainAnimator.SetBool("Bump", false);
        StartCoroutine(iBump());
    }

    public IEnumerator iBumpCart(GameObject _g, float _i) {
        float wait = (_i + 1) * 0.3f;
        yield return new WaitForSeconds(wait);
        _g.GetComponent<Animator>().SetBool("Bump", true);
        yield return new WaitForEndOfFrame();
        _g.GetComponent<Animator>().SetBool("Bump", false);
    }

}
