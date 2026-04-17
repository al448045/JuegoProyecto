using System.Collections;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Vector2 startPos;
    public Vector2 endPos;
    public float showTime;
    public float duration;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        startPos = new Vector2(0f, - spriteRenderer.bounds.size.y);
        endPos = Vector2.zero;

        showTime = 2f;
        duration = 1f;

        Debug.Log("Coroutine started");

        StartCoroutine(MoveUpAndDown(startPos, endPos));

        Debug.Log("Coroutine ended");
    }

    void Update()
    {
        
    }

    private IEnumerator MoveUpAndDown(Vector2 start, Vector2 end)
    {
        float elapsedTime = 0f;
        transform.localPosition = start;

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;

        yield return new WaitForSeconds(5f);

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = start;
    }
}
