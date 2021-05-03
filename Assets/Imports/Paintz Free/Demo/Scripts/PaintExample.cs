using UnityEngine;

public class PaintExample : MonoBehaviour
{
    public Brush brush;
    public bool RandomChannel = false;
    public bool SingleShotClick = false;
    public bool ClearOnClick = false;
    public bool IndexBrush = false;


    private bool HoldingButtonDown = false;



    private void Start()
    {




        if (brush.splatTexture == null)
        {
            brush.splatTexture = Resources.Load<Texture2D>("splats");
            brush.splatsX = 4;
            brush.splatsY = 4;
        }
    }

    private void Update()
    {



        if (RandomChannel) brush.splatChannel = Random.Range(0, 2);

        if (true)
        {
            if (!SingleShotClick || (SingleShotClick && !HoldingButtonDown))
            {
                PaintTarget.PaintCursor(brush);
                if (IndexBrush) brush.splatIndex++;
            }
            HoldingButtonDown = true;
        }
        else
        {
            //HoldingButtonDown = false;
        }
    }


 




    
}