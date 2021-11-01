using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintbrush : GrabbableObject
{
    public GameObject paintPrefab;
    public GameObject spawnedPaint;
    public GameObject lastSpawnedPaint;

    private PaintbrushTip paintbrushTip;
    private bool undoRedo = false;
    private void Start()
    {
        paintbrushTip = GetComponentInChildren<PaintbrushTip>();

    }

    private void Update()
    {
        
    }

    public override void OnInteraction()
    {
        spawnedPaint = Instantiate(paintPrefab, paintbrushTip.transform.position, paintbrushTip.transform.rotation);
        TrailRenderer paintTrail = spawnedPaint.GetComponent<TrailRenderer>();
        paintTrail.material = paintbrushTip.paint;
    }
    public override void OnUpdateInteraction()
    {
        if (spawnedPaint)
        {
            spawnedPaint.transform.position = paintbrushTip.transform.position;
        }
        
    }

    public override void OnStopInteraction()
    {
        lastSpawnedPaint = spawnedPaint;
        spawnedPaint = null;
    }
    public override void OnAButtonDown()
    {
        undoRedo = !undoRedo;
        if(undoRedo == true)
        {
            Destroy(lastSpawnedPaint);
        }
    }
}
