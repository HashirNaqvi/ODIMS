using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DIMS.BAL.Manager
{
    public static class DisasterInformationBAL
    {
        public static List<DisasterInformation> GetAllDisasterInformation()
        {
            using (var context = new DIMSContainer())
            {
                var DisasterInformation = (from i in context.DisasterInformation.AsNoTracking()
                                  orderby i.DisasterInformationID ascending
                                  select i
                                  ).ToList();

                return DisasterInformation;
            }
        }

        public static List<DisasterInformation> GetAllDisasterInformationForNDMA(int NDMAID)
        {
            using (var context = new DIMSContainer())
            {
                var DisasterInformation = (from i in context.DisasterInformation.AsNoTracking()
                                           where i.NDMAUserId == NDMAID
                                           orderby i.DisasterInformationID ascending
                                           select i
                                  ).ToList();

                return DisasterInformation;
            }
        }

        public static List<DisasterInformation> GetAllDisasterInformationForInstitute(int InstituteID)
        {
            using (var context = new DIMSContainer())
            {
                var DisasterInformation = (from i in context.DisasterInformation.AsNoTracking()
                                           where i.RehabilitationInstituteID == InstituteID
                                           orderby i.DisasterInformationID ascending
                                           select i
                                  ).ToList();

                return DisasterInformation;
            }
        }

        public static DisasterInformation GetDisasterInformationByID(int DisasterInformationID)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.DisasterInformation.AsNoTracking()
                                  where i.DisasterInformationID == DisasterInformationID
                                  select i
                                  ).FirstOrDefault();

                return info;
            }
        }

        public static void AddDisasterInformation(DisasterInformation disasterInformation)
        {
            using (var context = new DIMSContainer())
            {
                context.DisasterInformation.Add(disasterInformation);
                context.SaveChanges();
            }
        }

        public static void UpdateDisasterInformation(DisasterInformation disasterInformation)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.DisasterInformation
                                 where i.DisasterInformationID == disasterInformation.DisasterInformationID
                                 select i).FirstOrDefault();
                if (info != null)
                {
                    info.Address = disasterInformation.Address;
                    info.DisasterDate = disasterInformation.DisasterDate;
                    info.Description = disasterInformation.Description;
                    info.LatLong = disasterInformation.LatLong;
                    info.Address = disasterInformation.Address;
                }
                context.SaveChanges();
            }
        }

        public static void DeleteDisasterInformation(int DisasterInformationID)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.DisasterInformation
                            where i.DisasterInformationID == DisasterInformationID
                            select i);
                if (info != null)
                {
                    context.DisasterInformation.RemoveRange(info);
                }
                context.SaveChanges();
            }
        }


    }
}