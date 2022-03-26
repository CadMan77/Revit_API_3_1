using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_API_3_1
{
    public class WallFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            //if (elem is Wall) return true;

            //if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_WallsDefault) return true;
            //if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_WallsStructure) return true;
            //if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_WallsInsulation) return true;

            //return false;

            return elem is Wall;
        }

        public bool AllowReference(Reference refer, XYZ pos)
        {
            //if (refer.GeometryObject == null) return false;

            //if (refer.GeometryObject is Face) return true;
            //if (refer.GeometryObject is Edge) return true;

            //return false;

            return true;
        }
    }
}
