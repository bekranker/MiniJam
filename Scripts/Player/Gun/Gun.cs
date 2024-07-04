using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gun : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _playerSprites;
    [SerializeField] private Transform _parentSprites;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _playerSpriteT;
    Vector3 _mousePosition;
    Vector2 _direction;
    Vector3 _pivotStartPos;
    Vector3 __playerSpriteTStartPos;


    void Start()
    {
        _pivotStartPos = _pivot.localPosition;
        __playerSpriteTStartPos = _playerSpriteT.localPosition;
    }   

    void Update()
    {
        
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        _direction = new Vector2(
            _mousePosition.x - transform.position.x,
            _mousePosition.y - transform.position.y
        );

        _pivot.right = _direction;
        TurnSprites();
        Shoot();
    }
    void TurnSprites()
    {
        if (_mousePosition.x >= _pivot.position.x)
            {
                _parentSprites.transform.localScale = new Vector3(1, 1, 1);
                _pivot.transform.localScale = new Vector3(1, 1, 1);
                _playerSprites.ForEach(x => x.flipY = false);

            }
            else
            {
                _parentSprites.transform.localScale = new Vector3(-1, 1, 1);
                _pivot.transform.localScale = new Vector3(-1, 1, 1);
                _playerSprites.ForEach(x => x.flipY = true);
            }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunEffect();
            PlayerEffect();
            Bullet tempB = Instantiate(_bullet, transform.position, Quaternion.identity);
            tempB.Init(_direction);
        }
    }
    void GunEffect()
    {
        DOTween.Kill(_pivot);
        _pivot.localPosition -= (Vector3.right) * 0.1f;
        _pivot.DOLocalMove(_pivotStartPos, 0.1f);
    }
    void PlayerEffect()
    {
        DOTween.Kill(_playerSpriteT);
        _playerSpriteT.localPosition -= (Vector3.right) * 0.1f;
        _playerSpriteT.DOLocalMove(__playerSpriteTStartPos, 0.1f);
    }
}
