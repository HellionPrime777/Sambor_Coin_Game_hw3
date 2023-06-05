using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _score;

    public int Score => _score;

    public event UnityAction<int> CoinPickUp;
    public event UnityAction<int> CoinRemove;

    private List<Coin> _coins;

    private void Start()
    {
        _coins = new List<Coin>(FindObjectsOfType<Coin>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _score += coin.Value;
            _coins.Remove(_coins[_coins.Count - 1]);
            CoinPickUp?.Invoke(_score);
            CoinRemove?.Invoke(_coins.Count);
           
        }
    }
}
