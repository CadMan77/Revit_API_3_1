//Создайте приложение, которое выбирает несколько стен по граням
//и выводит в окне общий объём выбранных стен.

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_API_3_1
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            uidoc.RefreshActiveView();

            IList<Reference> selectedElementRefList = uidoc.Selection.PickObjects(ObjectType.Element, new WallFilter(), "Выберите стены:");

            var wallList = new List<Element>();
            double totVolume = 0;

            foreach (var selectedRef in selectedElementRefList)
            {
                Wall oWall = doc.GetElement(selectedRef) as Wall;
                wallList.Add(oWall);
                //totVolume += oWall.LookupParameter("Volume").AsDouble();
                totVolume += oWall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED).AsDouble();                
            }

            double totVolCubM = UnitUtils.ConvertFromInternalUnits(totVolume, UnitTypeId.CubicMeters);
            TaskDialog.Show("Результат", $"Стен выбрано - {wallList.Count}{Environment.NewLine}Общий объем - {totVolCubM} м^3");
            return Result.Succeeded;
        }
    }
}
