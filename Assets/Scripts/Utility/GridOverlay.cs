 using UnityEngine;

 public class GridOverlay : MonoBehaviour
 {
     public bool showMain = true;
     public bool showSub = false;
 
     public int gridSizeX;
     public int gridSizeY;
     public int gridSizeZ;
 
     public float smallStep;
     public float largeStep;
 
     public float startX;
     public float startY;
     public float startZ;
 
     private Material lineMaterial;
 
     public  Color mainColor = new Color(0f, 1f, 0f, 1f);
     public Color subColor = new Color(0f, 0.5f, 0f, 1f);
     
     private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
     private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
     private static readonly int Cull = Shader.PropertyToID("_Cull");
     private static readonly int ZWrite = Shader.PropertyToID("_ZWrite");

     void CreateLineMaterial()
     {
         if (!lineMaterial)
         {
             // Unity built-in shader for drawing simple colored things.
             Shader shader = Shader.Find("Hidden/Internal-Colored");
             lineMaterial = new Material(shader)
             {
                 hideFlags = HideFlags.HideAndDontSave
             };
             // Turn on alpha blending
             lineMaterial.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
             lineMaterial.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
             // Turn backface culling off
             lineMaterial.SetInt(Cull, (int)UnityEngine.Rendering.CullMode.Off);
             // Turn off depth writes
             lineMaterial.SetInt(ZWrite, 0);
         }
     }
 
     void OnPostRender()
     {
         CreateLineMaterial();
         // set the current material
         lineMaterial.SetPass(0);
 
         GL.Begin(GL.LINES);
 
         if (showSub)
         {
             GL.Color(subColor);
 
             //Layers
             for (float j = 0; j <= gridSizeY; j += smallStep)
             {
                 //X axis lines
                 for (float i = 0; i <= gridSizeZ; i += smallStep)
                 {
                     GL.Vertex3(startX, startY + j , startZ + i);
                     GL.Vertex3(startX + gridSizeX, startY + j , startZ + i);
                 }
 
                 //Z axis lines
                 for (float i = 0; i <= gridSizeX; i += smallStep)
                 {
                     GL.Vertex3(startX + i, startY + j , startZ);
                     GL.Vertex3(startX + i, startY + j , startZ + gridSizeZ);
                 }
             }
 
             //Y axis lines
             for (float i = 0; i <= gridSizeZ; i += smallStep)
             {
                 for (float k = 0; k <= gridSizeX; k += smallStep)
                 {
                     GL.Vertex3(startX + k, startY , startZ + i);
                     GL.Vertex3(startX + k, startY + gridSizeY , startZ + i);
                 }
             }
         }
 
         if (showMain)
         {
             GL.Color(mainColor);
 
             //Layers
             for (float j = 0; j <= gridSizeY; j += largeStep)
             {
                 //X axis lines
                 for (float i = 0; i <= gridSizeZ; i += largeStep)
                 {
                     GL.Vertex3(startX, startY + j, startZ + i);
                     GL.Vertex3(startX + gridSizeX, startY + j , startZ + i);
                 }
 
                 //Z axis lines
                 for (float i = 0; i <= gridSizeX; i += largeStep)
                 {
                     GL.Vertex3(startX + i, startY + j , startZ);
                     GL.Vertex3(startX + i, startY + j , startZ + gridSizeZ);
                 }
             }
 
             //Y axis lines
             for (float i = 0; i <= gridSizeZ; i += largeStep)
             {
                 for (float k = 0; k <= gridSizeX; k += largeStep)
                 {
                     GL.Vertex3(startX + k, startY , startZ + i);
                     GL.Vertex3(startX + k, startY + gridSizeY , startZ + i);
                 }
             }
         }
 
 
         GL.End();
     }
 }