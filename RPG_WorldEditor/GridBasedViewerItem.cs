using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using RolePlayingGame.World.GridBased.Templates;
using RolePlayingGame.World.GridBased.Objects;
using RolePlayingGame.World.GridBased;
using System.ComponentModel;

namespace RolePlayingGame.WorldEditor
{
    public partial class GridBasedViewerItem : Component, IDisposable, ICloneable
    {
        private GridBasedObject gridBasedObject;

        public GridBasedViewerItem()
        {
            gridBasedObject = new GridBasedObject("");
            PreviewImage = null;
            Visibility = true;
            InitializeComponent();
        }

        public GridBasedViewerItem(GridBasedObject obj, Image previewImage)
        {
            gridBasedObject = obj;
            PreviewImage = previewImage;
            Visibility = true;
        }

        private Image previewImage;
        public Image PreviewImage
        {
            get { return previewImage; }
            set { previewImage = value; }
        }

        private bool visibility;
        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        public void Rotate(RotationTypes rotationType)
        {
            gridBasedObject.Rotation = (RotationTypes)(((int)gridBasedObject.Rotation + (int)rotationType) % 4);
            RotateFlipType type = RotateFlipType.RotateNoneFlipNone;
            switch (rotationType)
            {
                case RotationTypes.Rotate_0:
                    break;
                case RotationTypes.Rotate_90:
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
                case RotationTypes.Rotate_180:
                    type = RotateFlipType.Rotate180FlipNone;
                    break;
                case RotationTypes.Rotate_270:
                    type = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    break;
            }
            previewImage.RotateFlip(type);
        }

        public void Move(int x, int y)
        {
            gridBasedObject.Position.X += x;
            gridBasedObject.Position.Y += y;
        }

        public Grid GetPosition()
        {
            return gridBasedObject.Position;
        }

        public RotationTypes GetRotation()
        {
            return gridBasedObject.Rotation;
        }

        public float GetScaleFactor()
        {
            return gridBasedObject.ScaleFactor;
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            PreviewImage.Dispose();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            GridBasedObject obj = new GridBasedObject("");
            obj.Position.X = GetPosition().X;
            obj.Position.Y = GetPosition().Y;
            obj.Rotation = GetRotation();
            obj.ScaleFactor = GetScaleFactor();
            Image image = (Image)previewImage.Clone();
            GridBasedViewerItem item = new GridBasedViewerItem(obj, image);
            return item;
        }

        #endregion
    }
}

