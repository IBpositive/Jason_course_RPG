// 6d

using UnityEngine;

public class ItemRaycaster : ItemComponent
{
    [SerializeField] private float _delay = 0.1f;
    [SerializeField] private float _range = 10f;
    private RaycastHit[] _results = new RaycastHit[10];
    private int _layermask;

    private void Awake()
    {
        _layermask = LayerMask.GetMask("Default");
    }

    public override void Use()
    {
        _nextUseTime = Time.time + _delay;

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        int hits = Physics.RaycastNonAlloc(ray, _results, _range, _layermask, QueryTriggerInteraction.Collide);

        RaycastHit nearest = new RaycastHit();
        double nearestDistance = double.MaxValue;


        for (int i = 0; i < hits; i++)
        {
            var distance = Vector3.Distance(transform.position, _results[i].point);
            if (distance < nearestDistance)
            {
                nearest = _results[i];
                nearestDistance = distance;
            }
        }

        if (nearest.transform != null)
        {
            Transform hitCube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            hitCube.localScale = Vector3.one * 0.1f;
            hitCube.position = nearest.point;
        }


    }
}