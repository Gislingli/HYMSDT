using HYGIS.Livelihood.Extends;
using HYGIS.Livelihood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HYGIS.Livelihood.Controllers
{
    public class DataController : Controller
    {
        #region 休闲旅游

        //获取列表
        private IEnumerable<LeisureTourism> _GetLeisureTourismList(string Type)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            var list = context.T_LeisureTourism.Where(i => i.LT_Type.Contains(Type)).ToList();
            if (list.Count() > 0)
            {

                var lst = from l in list
                          select new LeisureTourism
                          {
                              LT_Guid = l.LT_Guid,
                              LT_Name = l.LT_Name,
                              LT_Type = l.LT_Type,
                              LT_Address = l.LT_Address,
                              LT_QH = l.LT_QH,
                              LT_Grade = l.LT_Grade,
                              LT_Introduce = l.LT_Introduce,
                              LT_PhotoList = l.LT_PhotoList,
                              LT_Geo = GeoUtils.ToGeoJson(l.LT_Geo)
                          };
                return lst;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据名字获取数据
        /// </summary>
        /// <param name="Name">名字（允许为空，返回全部）</param>
        /// <param name="Type">类型（允许为空，返回全部类型）</param>
        /// <param name="Pageindex"></param>
        /// <param name="Listnum"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetLeisureTourismByName(string Name, string Type, int Pageindex, int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            var list = _GetLeisureTourismList(Type);

            if (list!=null)
            {
                int startRow = (Pageindex - 1) * Listnum;
                list = list.Where(i => i.LT_Name.Contains(Name)).Skip(startRow).Take(Listnum).ToList();
                reModel.Add("List", list);
                reModel.Add("Total", _GetLeisureTourismList(Type).Count());
            }
            else
            {
                reModel.ErrorMessage = "暂无数据";
            }

            return Json(reModel);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetLeisureTourismById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();

            Guid Id = new Guid(guid);
            var model = context.T_LeisureTourism.First(i => i.LT_Guid == Id);
            return Json(model);
        }

        /// <summary>
        /// 根据街道获取数据
        /// </summary>
        /// <param name="QH"></param>
        /// <param name="Type"></param>
        /// <param name="Pageindex"></param>
        /// <param name="Listnum"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetLeisureTourismByQH(string QH,string Type,int Pageindex,int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            if (!string.IsNullOrEmpty(QH))
            {
                var list = _GetLeisureTourismList(Type);

                if (list != null)
                {
                    int startRow = (Pageindex - 1) * Listnum;
                    list = list.Where(i => i.LT_QH == QH).Skip(startRow).Take(Listnum).ToList();
                    if (list.Count() > 0)
                    {
                        reModel.Add("List", list);
                        reModel.Add("Total", _GetLeisureTourismList(Type).Count());
                    }
                    else
                    {
                        reModel.ErrorMessage = "查询结果为空";
                    }

                }
                else
                {
                    reModel.ErrorMessage = "暂无数据";
                }
            }
            else
            {
                reModel.ErrorMessage = "缺少参数：行政区划";
            }
            
            return Json(reModel);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="lt">LT_Geo字段格式为（120.xxx 30.xxx）</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddLeisureTourism(LeisureTourism LT)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                T_LeisureTourism model = new T_LeisureTourism();
                model.LT_Guid = Guid.NewGuid();
                model.LT_Address = LT.LT_Address;
                model.LT_Grade = LT.LT_Grade;
                model.LT_Introduce = LT.LT_Introduce;
                model.LT_Name = LT.LT_Name;
                //model.LT_PhotoList = LT.LT_PhotoList;
                model.LT_QH = LT.LT_QH;
                model.LT_Time = LT.LT_Time;
                model.LT_Type = LT.LT_Type;

                //转WKT
                string wktStr = string.Format("POINT ({0})", LT.LT_Geo);
                model.LT_Geo = GeoUtils.FromWkt("point", wktStr, 0);

                context.T_LeisureTourism.Add(model);
                context.SaveChanges();

                reModel.status = true;
            }
            catch (Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="guid">ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveLeisureTourismById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                Guid Id = new Guid(guid);
                var obj = context.T_LeisureTourism.First(i => i.LT_Guid == Id);
                context.T_LeisureTourism.Remove(obj);
                context.SaveChanges();

                reModel.status = true;
            }
            catch(Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="LT">LT_Geo字段格式为（120.xxx 30.xxx）</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditLeisureTourism(LeisureTourism LT)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                var model = context.T_LeisureTourism.First(i => i.LT_Guid == LT.LT_Guid);
                model.LT_Address = LT.LT_Address;
                model.LT_Grade = LT.LT_Geo;
                model.LT_Introduce = LT.LT_Introduce;
                model.LT_Name = LT.LT_Name;
                model.LT_QH = LT.LT_QH;
                model.LT_Time = LT.LT_Time;
                model.LT_Type = LT.LT_Type;

                //转WKT
                if (!string.IsNullOrEmpty(LT.LT_Geo))
                {
                    string wktStr = string.Format("POINT ({0})", LT.LT_Geo);
                    model.LT_Geo = GeoUtils.FromWkt("point", wktStr, 0);
                }
                
                context.SaveChanges();

                reModel.status = true;
            }
            catch (Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }
        #endregion

        #region 生活服务

        //获取列表
        public IEnumerable<Service> _GetServiceList(string Type)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            var list = context.T_Service.Where(i => i.S_Type.Contains(Type)).ToList();
            if (list.Count() > 0)
            {
                var lst = from s in list
                          select new Service
                          {
                              S_Address = s.S_Address,
                              S_Cost = s.S_Cost,
                              S_Type = s.S_Type,
                              S_Geo = GeoUtils.ToGeoJson(s.S_Geo),
                              S_Guid = s.S_Guid,
                              S_Introduce = s.S_Introduce,
                              S_Name = s.S_Name,
                              S_PhotoList = s.S_PhotoList,
                              S_QH = s.S_QH,
                              S_Star = s.S_Star
                          };
                return lst;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据名字获取数据
        /// </summary>
        /// <param name="Name">名字（允许为空，返回全部）</param>
        /// <param name="Type">类型（允许为空，返回全部类型）</param>
        /// <param name="Pageindex"></param>
        /// <param name="Listnum"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetServiceByName(string Name,string Type, int Pageindex, int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            var list = _GetServiceList(Type);

            if (list != null)
            {
                int startRow = (Pageindex - 1) * Listnum;
                list = list.Where(i => i.S_Name.Contains(Name)).Skip(startRow).Take(Listnum).ToList();
                reModel.Add("List", list);
                reModel.Add("Total", _GetServiceList(Type).Count());
            }
            else
            {
                reModel.ErrorMessage = "暂无数据";
            }

            return Json(reModel);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetServiceById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();

            Guid Id = new Guid(guid);
            var model = context.T_Service.First(i => i.S_Guid == Id);
            return Json(model);
        }

        [HttpPost]
        public ActionResult GetServiceByQH(string QH, string Type, int Pageindex, int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            if (!string.IsNullOrEmpty(QH))
            {
                var list = _GetServiceList(Type);

                if (list != null)
                {
                    int startRow = (Pageindex - 1) * Listnum;
                    list = list.Where(i => i.S_QH == QH).Skip(startRow).Take(Listnum).ToList();
                    if (list.Count() > 0)
                    {
                        reModel.Add("List", list);
                        reModel.Add("Total", _GetServiceList(Type).Count());
                    }
                    else
                    {
                        reModel.ErrorMessage = "查询结果为空";
                    }

                }
                else
                {
                    reModel.ErrorMessage = "暂无数据";
                }
            }
            else
            {
                reModel.ErrorMessage = "缺少参数：行政区划";
            }

            return Json(reModel);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="lt">S_Geo字段格式为（120.xxx 30.xxx）</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddLeisureTourism(Service SV)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                T_Service model = new T_Service();
                model.S_Guid = Guid.NewGuid();
                model.S_Address = SV.S_Address;
                model.S_Cost = SV.S_Cost;
                model.S_Introduce = SV.S_Introduce;
                model.S_Name = SV.S_Name;
                model.S_PhotoList = SV.S_PhotoList;
                model.S_QH = SV.S_QH;
                model.S_Star = SV.S_Star;
                model.S_Type = SV.S_Type;

                //转WKT
                string wktStr = string.Format("POINT ({0})", SV.S_Geo);
                model.S_Geo = GeoUtils.FromWkt("point", wktStr, 0);

                context.T_Service.Add(model);
                context.SaveChanges();

                reModel.status = true;
            }
            catch (Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="guid">ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveServiceById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                Guid Id = new Guid(guid);
                var obj = context.T_Service.First(i => i.S_Guid == Id);
                context.T_Service.Remove(obj);
                context.SaveChanges();

                reModel.status = true;
            }
            catch (Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="LT">LT_Geo字段格式为（120.xxx 30.xxx）</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditService(Service SV)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                var model = context.T_Service.First(i => i.S_Guid == SV.S_Guid);
                model.S_Address = SV.S_Address;
                model.S_Cost = SV.S_Cost;
                model.S_Introduce = SV.S_Introduce;
                model.S_Name = SV.S_Name;
                //model.S_PhotoList = SV.S_PhotoList;
                model.S_QH = SV.S_QH;
                model.S_Star = SV.S_Star;
                model.S_Type = SV.S_Type;

                //转WKT
                if (!string.IsNullOrEmpty(SV.S_Geo))
                {
                    string wktStr = string.Format("POINT ({0})", SV.S_Geo);
                    model.S_Geo = GeoUtils.FromWkt("point", wktStr, 0);
                }

                context.SaveChanges();

                reModel.status = true;
            }
            catch (Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }
        #endregion

        #region 交通出行

        //获取列表
        public IEnumerable<Traffic> _GetTrafficList(string Type)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            var list = context.T_Traffic.Where(i => i.T_Type.Contains(Type)).ToList();
            if (list.Count() > 0)
            {
                var lst = from t in list
                          select new Traffic
                          {
                              T_Address = t.T_Address,
                              T_Guid = t.T_Guid,
                              T_Type = t.T_Type,
                              T_Geo = GeoUtils.ToGeoJson(t.T_Geo),
                              T_Introduce = t.T_Introduce,
                              T_Name = t.T_Name,
                              T_Number = t.T_Number,
                              T_PhotoList = t.T_PhotoList,
                              T_QH = t.T_QH
                          };

                return lst;
            }
            else
            {
                return null;
            }
        }

        //获取列表
        public IEnumerable<BusStation> _GetStationList()
        {
            HYMSDTEntities context = new HYMSDTEntities();
            var list = from bs in context.T_BusLine_Station
                       join s in context.T_Station
                       on bs.Sta_Id equals s.Sta_Id
                       join b in context.T_BusLine
                       on bs.BL_Id equals b.BL_Id
                       select new BusStation
                       {
                           Sta_Guid = s.Sta_Guid,
                           Sta_Geo = GeoUtils.ToGeoJson(s.Sta_Geo),
                           Sta_Name = s.Sta_Name,
                           BL_Name = b.BL_Name,
                           BL_Geo = GeoUtils.ToGeoJson(b.BL_Geo),
                           BL_S_Guid = bs.BL_S_Guid,
                           BL_DownEndTime = b.BL_DownEndTime,
                           BL_DownStartTime = b.BL_DownStartTime,
                           BL_UpEndTime = b.BL_UpEndTime,
                           BL_UpStartTime = b.BL_UpStartTime
                       };

            return list;
        }

        /// <summary>
        /// 根据名字获取数据
        /// </summary>
        /// <param name="Name">名字（允许为空，返回全部）</param>
        /// <param name="Type">类型（允许为空，返回全部类型）</param>
        /// <param name="Pageindex"></param>
        /// <param name="Listnum"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetTrafficByName(string Name, string Type, int Pageindex, int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            int startRow = (Pageindex - 1) * Listnum;

            if (Type != "公交站点")
            {
                var list = _GetTrafficList(Type);

                if (list != null)
                {
                    list=list.Where(i=>i.T_Name.Contains(Name)).Skip(startRow).Take(Listnum).ToList();
                    reModel.Add("List", list);
                    reModel.Add("Total", _GetTrafficList(Type).Count());
                }
                else
                {
                    reModel.ErrorMessage = "暂无数据";
                }
            }
            else
            {
                var list = _GetStationList();

                if (list != null)
                {
                    list=list.Where(i=>i.Sta_Name.Contains(Name)).Skip(startRow).Take(Listnum).ToList();
                    reModel.Add("List", list);
                    reModel.Add("Total", _GetStationList().Count());
                }
                else
                {
                    reModel.ErrorMessage = "暂无数据";
                }
            }

            return Json(reModel);
        }

        /// <summary>
        /// 根据ID获取数据-公共交通
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetTrafficById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();

            Guid Id = new Guid(guid);
            var model = context.T_Service.First(i => i.S_Guid == Id);
            return Json(model);
        }

        /// <summary>
        /// 根据ID获取数据-公交站点
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetStationById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();

            Guid Id = new Guid(guid);
            var model = _GetStationList().First(i => i.Sta_Guid == Id);
            return Json(model);
        }

        /// <summary>
        /// 根据ID获取数据-公交线路
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetBusLineById(string guid)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            Guid Id = new Guid(guid);
            var model = context.T_BusLine.First(i => i.BL_Guid == Id);
            reModel.Add("BusLine", model);
            var sList = from bs in context.T_BusLine_Station.Where(i => i.BL_Id == model.BL_Id)
                        join s in context.T_Station
                        on bs.Sta_Id equals s.Sta_Id
                        select new
                        {
                            Sta_Id = s.Sta_Id,
                            Sta_Name = s.Sta_Name,
                            Sta_Geo = s.Sta_Geo,
                            Sta_Guid = s.Sta_Guid,
                            Bl_Id = bs.BL_Id
                        };
            reModel.Add("BusLineStation", sList.ToList());
            return Json(reModel);
        }

        [HttpPost]
        public ActionResult AddBusSta(Station STA)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel1 reModel = new ReturnModel1();

            reModel.status = false;
            try
            {
                T_Station model = new T_Station();
                model.Sta_Guid = Guid.NewGuid();
                model.Sta_Id = STA.Sta_Id;
                string wktStr = string.Format("POINT ({0})", STA.Sta_Geo);
                model.Sta_Geo = GeoUtils.FromWkt("point", wktStr, 0);
                model.Sta_Name = STA.Sta_Name;

                context.T_Station.Add(model);
                context.SaveChanges();

                reModel.status = true;
            }
            catch (Exception ex)
            {
                reModel.message = ex.ToString();
            }

            return Json(reModel);
        }
        #endregion

        /// <summary>
        /// 全局搜索（根据名字）
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult QueryData(string Name)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            if (!string.IsNullOrEmpty(Name))
            {
                //休闲旅游
                var lList = _GetLeisureTourismList("").Where(i => i.LT_Name.Contains(Name));
                if (lList.Count() > 0)
                {
                    reModel.Add("LeisureTourism", lList);
                }

                //生活服务
                var sList = _GetServiceList("").Where(i => i.S_Name.Contains(Name));
                if (sList.Count() > 0)
                {
                    reModel.Add("Service", sList);
                }

                //公共交通
                var tList = _GetTrafficList("").Where(i => i.T_Name.Contains(Name));
                if (tList.Count() > 0)
                {
                    reModel.Add("Traffic", tList);
                }
                var staList = _GetStationList().Where(i => i.Sta_Name.Contains(Name));
                if (staList.Count() > 0)
                {
                    reModel.Add("Station", staList);
                }


            }
            else
            {
                reModel.ErrorMessage = "请输入搜索的名字";
            }

            return Json(reModel);
        }
        

        //文化教育
        [HttpPost]
        public ActionResult GetCulture(string Name, string Type, int Pageindex, int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            var list = context.T_Culture.Where(i => i.C_Name.Contains(Name) && i.C_Type == Type).ToList();

            if (list.Count() > 0)
            {
                int startRow = (Pageindex - 1) * Listnum;

                reModel.Add("List", list.Skip(startRow).Take(Listnum));
                reModel.Add("Total", list.Count());
            }
            else
            {
                reModel.ErrorMessage = "暂无数据";
            }

            return Json(reModel);
        }

        //医疗卫生
        [HttpPost]
        public ActionResult GetHealth(string Name, string Type, int Pageindex, int Listnum)
        {
            HYMSDTEntities context = new HYMSDTEntities();
            ReturnModel2 reModel = new ReturnModel2();

            var list = context.T_Health.Where(i => i.H_Name.Contains(Name) && i.H_Type == Type).ToList();

            if (list.Count() > 0)
            {
                int startRow = (Pageindex - 1) * Listnum;

                reModel.Add("List", list.Skip(startRow).Take(Listnum));
                reModel.Add("Total", list.Count());
            }
            else
            {
                reModel.ErrorMessage = "暂无数据";
            }

            return Json(reModel);
        }

        
    }
}