using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    [SerializeField] private LayerMask explosionMask;
    void Start()
    {
        StartCoroutine(BombExplosion());
    }
    IEnumerator BombExplosion()
    {
        var sequence = DOTween.Sequence()
            .Append(transform.DOScale(Vector3.one * 0.7f, 0.3f))
            .Append(transform.DOScale(Vector3.one, 0.3f));
        
        sequence.SetLoops(-1, LoopType.Yoyo);
        yield return new WaitForSeconds(2);
        Debug.Log("2sec");
        
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, explosionMask);
        foreach (var cldr in colliders)
        {
            Destroy(cldr.gameObject);
            Debug.Log("des");
            if (cldr.CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
            }
            
        }
        
        //
        // Debug.Log("hi");
        // var hitL = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, raycastMask);
        // var hitR = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, raycastMask);
        // var hitU = Physics2D.Raycast(transform.position, Vector2.up, 1.5f, raycastMask);
        // var hitD = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, raycastMask);
        // List<RaycastHit2D> hits = new List<RaycastHit2D>();
        // hits.Add(hitL);
        // hits.Add(hitR);
        // hits.Add(hitU);
        // hits.Add(hitD);
        // foreach (var hit in hits)
        // {
        //     
        //     Destroy(hit.transform.gameObject);
        // }
        
        Destroy(gameObject);
        
    }
    
}
