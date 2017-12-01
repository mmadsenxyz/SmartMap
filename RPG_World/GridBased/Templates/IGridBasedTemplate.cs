using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayingGame.World.GridBased.Templates
{
    public interface IGridBasedTemplate
    {
        string TemplateName
        {
            get;
            set;
        }

        GridSize TemplateSize
        {
            get;
            set;
        }

        string GetPreviewName();
    }
}
