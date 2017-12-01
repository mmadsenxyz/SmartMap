using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayingGame.World.GridBased.Templates
{
    public class GridBasedTemplateFloor : GridMatrix<Grid>, IGridBasedTemplate
    {
        public GridBasedTemplateFloor(string templateName)
            : base()
        {
            TemplateName = templateName;
        }

        #region IGridBasedTemplate Members

        private string templateName;
        public string TemplateName
        {
            get { return templateName; }
            set { templateName = value; }
        }

        private GridSize templateSize;
        public GridSize TemplateSize
        {
            get { return templateSize; }
            set { templateSize = value; }
        }

        public string GetPreviewName()
        {
            return templateName + GridBasedWorld.PREVIEW_IMAGE_EXTENSION;
        }

        #endregion

        public string GetMaterialName()
        {
            return templateName + GridBasedWorld.MATERIAL_EXTENSION;
        }
    }
}
