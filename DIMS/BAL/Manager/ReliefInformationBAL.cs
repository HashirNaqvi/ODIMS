using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DIMS.BAL.Manager
{
    public static class ReliefInformationBAL
    {
        public static List<ReliefInformation> GetAllReliefInformation()
        {
            using (var context = new DIMSContainer())
            {
                var ReliefInformation = (from i in context.ReliefInformation.AsNoTracking()
                                  orderby i.ReliefInformationID ascending
                                  select i
                                  ).ToList();

                return ReliefInformation;
            }
        }
        public static List<ReliefInformation> GetAllReliefInformationForNDMA(int NDMAID)
        {
            using (var context = new DIMSContainer())
            {
                var ReliefInformation = (from i in context.ReliefInformation.AsNoTracking()
                                           where i.NDMAUserId == NDMAID
                                           orderby i.ReliefInformationID ascending
                                           select i
                                  ).ToList();

                return ReliefInformation;
            }
        }
        public static ReliefInformation GetReliefInformationByID(int ReliefInformationID)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.ReliefInformation.AsNoTracking()
                                  where i.ReliefInformationID == ReliefInformationID
                            select i
                                  ).FirstOrDefault();

                return info;
            }
        }
        public static List<ReliefInformation> GetAllReliefInformationForInstitute(int InstituteID)
        {
            using (var context = new DIMSContainer())
            {
                var ReliefInformation = (from i in context.ReliefInformation.AsNoTracking()
                                           where i.RehabilitationInstituteID == InstituteID
                                           orderby i.ReliefInformationID ascending
                                           select i
                                  ).ToList();

                return ReliefInformation;
            }
        }
        public static void AddReliefInformation(ReliefInformation ReliefInformation)
        {
            using (var context = new DIMSContainer())
            {
                context.ReliefInformation.Add(ReliefInformation);
                context.SaveChanges();
            }
        }

        public static void UpdateReliefInformation(ReliefInformation ReliefInformation)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.ReliefInformation
                            where i.ReliefInformationID == ReliefInformation.ReliefInformationID
                            select i).FirstOrDefault();
                if (info != null)
                {
                    info.Description = ReliefInformation.Description;
                    info.DateGranted = ReliefInformation.DateGranted;
                    info.Amount = ReliefInformation.Amount;
                }
                context.SaveChanges();
            }
        }
        public static void DeleteReliefInformation(int ReliefInformationID)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.ReliefInformation
                            where i.ReliefInformationID == ReliefInformationID
                            select i);
                if (info != null)
                {
                    context.ReliefInformation.RemoveRange(info);
                }
                context.SaveChanges();
            }
        }

    }
}