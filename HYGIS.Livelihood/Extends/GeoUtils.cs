using alatas.GeoJSON4EntityFramework;
using System;
using System.Data.Entity.Spatial;
using System.Text.RegularExpressions;

namespace HYGIS.Livelihood.Extends
{
    public static class GeoUtils
    {
        public static DbGeometry FromWkt(string type,string wkt, int systemid)
        {
            type = type.ToUpper();
            switch (type)
            {
                case "POINT":
                    return DbGeometry.PointFromText(wkt, systemid);
                case "POLYGON":
                    return DbGeometry.PolygonFromText(wkt, systemid);
                case "LINE":
                    return DbGeometry.LineFromText(wkt, systemid);
                case "MULTIPOINT":
                    return DbGeometry.MultiPointFromText(wkt, systemid);
                case "MULTIPOLYGON":
                    return DbGeometry.MultiPolygonFromText(wkt, systemid);
                case "MULTILINE":
                    return DbGeometry.MultiLineFromText(wkt, systemid);
                default:
                    return null;
            }
        }

        public static string ToWkt(DbGeometry geom)
        {
            return geom.AsText();
        }

        public static string ToGeoJson(DbGeometry geom)
        {
            FeatureCollection features = new FeatureCollection(geom);
            return Regex.Replace(features.Serialize(prettyPrint: true), @"\s", "");
        }
    }
}