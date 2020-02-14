﻿using BH.Engine.Environment;

using SAM.Geometry.BHoM;
using System.Collections.Generic;

namespace SAM.Analytical.BHoM
{
    public static partial class Convert
    {
        public static BH.oM.Environment.Elements.Panel ToBHoM(this Panel panel)
        {
            PlanarBoundary3D planarBoundary3D = panel.PlanarBoundary3D;
            Geometry.Spatial.Face3D face3D = planarBoundary3D.GetFace3D();
            Geometry.Spatial.Polygon3D polygon3D = face3D.GetExternalEdge() as Geometry.Spatial.Polygon3D;

            return new BH.oM.Environment.Elements.Panel
            {
                ExternalEdges = polygon3D.ToBHoM().ToEdges(),
                Type = panel.PanelType.ToBHoM(),
            };
        }

        public static BH.oM.Environment.Elements.Panel ToBHoM(this Panel panel, List<string> connectedSpaces)
        {
            PlanarBoundary3D planarBoundary3D = panel.PlanarBoundary3D;
            Geometry.Spatial.Face3D face3D = planarBoundary3D.GetFace3D();
            Geometry.Spatial.Polygon3D polygon3D = face3D.GetExternalEdge() as Geometry.Spatial.Polygon3D;

            return new BH.oM.Environment.Elements.Panel
            {
                ExternalEdges = polygon3D.ToBHoM().ToEdges(),
                Type = panel.PanelType.ToBHoM(),
                ConnectedSpaces = connectedSpaces,
            };
        }
    }
}
