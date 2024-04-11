using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;

    private int _currentNumber = 0;
    private Coroutine _countingCoroutine;

    private void Start()
    {
        _text.text = "";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCounting();
        }
        if (Input.GetMouseButtonDown(1))
        {
            StopCounting();
        }
    }

    private void StartCounting()
    {
        if (_countingCoroutine == null)
        {
            _countingCoroutine = StartCoroutine(IncrementCounter(_delay));
        }
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator IncrementCounter(float delay)
    {
        while (true)
        {
            _currentNumber++;
            DisplayCount(_currentNumber);
            yield return new WaitForSeconds(delay);
        }
    }

    private void DisplayCount(int count)
    {
        _text.text = count.ToString();
    }
}
