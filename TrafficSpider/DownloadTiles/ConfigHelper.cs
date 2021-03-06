﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BruTile.Web;
using BrutileArcGIS.Lib;

namespace DownloadTiles
{
    public class ConfigHelper
    {
        public static IConfig GetTmsConfig(string url, bool overwriteUrls)
        {
            return new ConfigTms(url, overwriteUrls);
        }

        public static IConfig GetConfig(EnumBruTileLayer enumBruTileLayer, string url, bool overwriteUrls)
        {
            IConfig result;

            if (enumBruTileLayer == EnumBruTileLayer.TMS)
            {
                result = new ConfigTms(url, overwriteUrls);
            }
            else if (enumBruTileLayer == EnumBruTileLayer.InvertedTMS)
            {
                result = new ConfigInvertedTMS(url);
            }
            else
            {
                result = new ConfigOsm(OsmMapType.Default);
            }

            return result;
        }

        public static IConfig GetConfig(EnumBruTileLayer enumBruTileLayer)
        {
            IConfig result = new ConfigOsm(OsmMapType.Default);

            if (enumBruTileLayer == EnumBruTileLayer.OSM)
            {
                result = new ConfigOsm(OsmMapType.Default);
            }
            else if (enumBruTileLayer == EnumBruTileLayer.BingRoad)
            {
                result = new ConfigBing(BingMapType.Roads);
            }
            else if (enumBruTileLayer == EnumBruTileLayer.BingHybrid)
            {
                result = new ConfigBing(BingMapType.Hybrid);
            }
            else if (enumBruTileLayer == EnumBruTileLayer.BingAerial)
            {
                result = new ConfigBing(BingMapType.Aerial);
            }
            return result;
        }
    }
}
