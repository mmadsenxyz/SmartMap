using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using System.Text;
using Axiom.Core;
using Axiom.Math;
using Axiom.Overlays;
using Axiom.Graphics;

namespace SmartMap
{
    /// <summary>
    /// Code sample provided by Andris from Axiom3D Wiki
    /// ====================================
    /// Displays an object using ortographic camera projection so that it exactly fits into the given viewport.
    /// Demonstrates how orthographic view can be controlled using <see cref="Camera.FieldOfView"/> (camera's field of view angle)
    /// with conjunction of <see cref="Camera.Near"/> (camera's near clipping plane distance).
    /// Can be eventually useful for taking snapshots of objects for thumbnails, icons and alike.
    /// </summary>
    /// <remarks>
    /// In Axiom, both the distance of near clipping plane <see cref="Camera.Near"/> 
    /// and the field of view angle <see cref="Camera.FieldOfView"/> decide what the rendered area will be. 
    /// The required height of that area (talking parallel to the viewport, i.e. size along the camera's y-axis) 
    /// is for us the height (y dimension) of the displayed object, presuming the object is set up aligned to world axes.
    /// The formula to calculate the near clipping plane distance from a known FOV and object height is as follows:
    ///
    /// nearClippingDistance = (objectHeight * 0.5) / tan(FOV * 0.5);
    ///
    /// That's some trigonometry, the FOV angle at observers point, the near clipping plane and it's distance from that point 
    /// define a triangle belonging to the camera's z/y plane. We calculated the near clipping plane distance, 
    /// which is the triangle's height from observers point to the near clipping plane.
    /// 
    /// The implementation uses the y size of the meshe's bounding box to get object height. 
    /// We are also considering the case where the object would be wider then Viewport when rendered, 
    /// then the retrieved height needs to be adjusted accordingly.
    ///
    /// Controls: 
    ///        'F' : turn overlays on/off
    ///
    ///        'P' : take screenshot
    ///        
    /// numpad 1,2 : modify the FOV of the camera. That doesn't affect the visible results, 
    ///              but you can observe what is the influence on the near clipping distance in the debug text.
    ///
    /// numpad 4,5 : modify the required visible area height. That affects visible results 
    ///              and the near clipping distance too.
    /// </remarks>
    public class OrthoSnapper : Draw3D, IDisposable
    {
        Entity _entity;

        SceneNode _node;

        /// <summary>
        /// Recalculated bounding box.
        /// A bounding box of a mesh is often retrieved from the binary mesh format and doesn't necessarily
        /// need to be exactly matching vertex positions extents. Then the displayed object would not be visualy 
        /// fitting into the viewport as expected. Therefore we recalculate the bounding box from the vertex positions for our purpose.
        /// </summary>
        AxisAlignedBox _boundingBox;

        /// <summary>
        /// Field of view for the camera (frustrum) to be tweaked to demonstrate influence on the required near clipping plane distance.
        /// </summary>
        float _fov;

        /// <summary>
        /// The height along camera's y-axis of the displayed area
        /// </summary>
        float _areaHeight;

        protected override void CreateScene()
        {
            Viewport.BackgroundColor = ColorEx.Magenta;

            _node = SceneManager.RootSceneNode.CreateChildSceneNode();
            _entity = SceneManager.CreateEntity("object", "dragon.mesh"); //dragon.mesh, cube.mesh, razor.mesh, knot.mesh, teapot.mesh, sphere.mesh, robot.mesh, ...
            _boundingBox = RetrieveBoundingBoxFromVertices(_entity); // ensure a proper bounding box
            _node.Position = -_boundingBox.Center;
            _node.AttachObject(_entity);

            // get visible area height, that is either the height of the object
            // or it needs to be adjusted if the object would be wider than the viewport when rendered
            float objectWidth = _boundingBox.Size.x;
            float objectHeight = _boundingBox.Size.y;

            if (objectWidth / Camera.AspectRatio > objectHeight)
                _areaHeight = objectWidth / Camera.AspectRatio;
            else
                _areaHeight = objectHeight;

            // position the camera: the distance of the camera from the object doesn't 
            // influence it's visible size in orthographic mode, but LOD and texture mipmap 
            // effects can appear. So the camera should be positioned as close to the object 
            // as possible, i.e. just as close that near clipping doesn't take effect yet.
            // Here we adjust a bit yet so user value tweaking that is part of the demo 
            // doesn't clip the object immediately
            float nearDist = GetNearClippingDistance(_areaHeight, Camera.FieldOfView);
            
            Camera.Position = Vector3.UnitZ * (nearDist + 300);
            Camera.LookAt(Vector3.Zero);
            Camera.ProjectionType = Axiom.Graphics.Projection.Orthographic;

            // init variable
            _fov = Utility.RadiansToDegrees(Camera.FieldOfView);        
        }

        protected override bool OnFrameStarted(object source, FrameEventArgs e)
        {
            Input.Capture();

            // numpad 1,2 modify the FOV of the camera
            if (Input.IsKeyPressed(Axiom.Input.KeyCodes.NumPad1))
                _fov -= e.TimeSinceLastFrame * 10f;

            else if (Input.IsKeyPressed(Axiom.Input.KeyCodes.NumPad2))
                _fov += e.TimeSinceLastFrame * 10f;

            // numpad 4,5 modify the required visible area height
            if (Input.IsKeyPressed(Axiom.Input.KeyCodes.NumPad4))
                _areaHeight -= e.TimeSinceLastFrame * 10f;

            else if (Input.IsKeyPressed(Axiom.Input.KeyCodes.NumPad5))
                _areaHeight += e.TimeSinceLastFrame * 10f;

            // set the FOV angle in degrees. But the property will return radians, 
            // which is what we need for the next calculation
            Camera.FieldOfView = _fov;

            // do the magic
            Camera.Near = GetNearClippingDistance(_areaHeight, Camera.FieldOfView);

            debugText = "FOV=" + _fov + " Near=" + Camera.Near + " AreaHeight=" + _areaHeight;

            return base.OnFrameStarted(source, e);
        }

        private float GetNearClippingDistance(float areaHeight, float fovInRadians)
        {
            return (areaHeight * 0.5f) / (float)System.Math.Tan(fovInRadians * 0.5f);
        }

        private AxisAlignedBox RetrieveBoundingBoxFromVertices(Entity ent)
        {
            AxisAlignedBox aabb = new AxisAlignedBox(Vector3.Zero, Vector3.Zero);
            TriangleListBuilder builder = new TriangleListBuilder();
            builder.AddObject(ent.Mesh, 0);
            List<TriangleVertices> vertices = (List<TriangleVertices>)builder.Build();

            foreach (TriangleVertices tv in vertices)
            {
                foreach (Vector3 v in tv.Vertices)
                    aabb.Merge(v);
            }

            return aabb;
        }
        
        [STAThread]
        public static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            try {
                using (Draw3D d3d = new Draw3D()) {
                    d3d.Run();
                }
            }
            catch (Exception ex) {
                Debug.Assert(false, ex.ToString(), Environment.StackTrace.ToString());
            }
        }
    }
}