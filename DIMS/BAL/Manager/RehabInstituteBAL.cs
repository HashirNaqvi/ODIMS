using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DIMS.BAL.Manager
{
    public static class RehabInstituteBAL
    {
        public static List<RehabilitationInstitutes> GetAllInstitutes()
        {
            using (var context = new DIMSContainer())
            {
                var institutes = (from i in context.RehabilitationInstitutes.AsNoTracking()
                                  orderby i.InstituteName ascending
                                  select i
                                  ).ToList();

                return institutes;
            }
        }

        public static RehabilitationInstitutes GetInstituteByID(int RehabilitationInstituteID)
        {
            using (var context = new DIMSContainer())
            {
                var institute = (from i in context.RehabilitationInstitutes.AsNoTracking()
                                  where i.RehabilitationInstituteID == RehabilitationInstituteID
                                  select i
                                  ).FirstOrDefault();

                return institute;
            }
        }

        public static void AddInstitute(RehabilitationInstitutes rehabInstitute)
        {
            using (var context = new DIMSContainer())
            {
                context.RehabilitationInstitutes.Add(rehabInstitute);
                context.SaveChanges();
            }
        }

        public static void UpdateInstitute(RehabilitationInstitutes rehabInstitute)
        {
            using (var context = new DIMSContainer())
            {
                var institute = (from i in context.RehabilitationInstitutes
                                 where i.RehabilitationInstituteID == rehabInstitute.RehabilitationInstituteID
                                 select i).FirstOrDefault();
                if (institute != null)
                {
                    institute.InstituteName = rehabInstitute.InstituteName;
                    institute.Email = rehabInstitute.Email;
                    institute.Password = rehabInstitute.Password;
                    institute.Phone = rehabInstitute.Phone;
                    institute.Address = rehabInstitute.Address;
                    institute.Active = rehabInstitute.Active;
                }
                context.SaveChanges();
            }
        }

        public static RehabilitationInstitutes AuthenticateInstitute(RehabilitationInstitutes rehabInstitute)
        {
            using (var context = new DIMSContainer())
            {
                return (from i in context.RehabilitationInstitutes
                                 where i.Email == rehabInstitute.Email && i.Password == rehabInstitute.Password && i.Active==true
                                 select i).FirstOrDefault();
                

            }
        }

        public static void DeleteRehabilitationInstitutes(int RehabilitationInstituteID)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.RehabilitationInstitutes
                            where i.RehabilitationInstituteID == RehabilitationInstituteID
                            select i);
                if (info != null)
                {
                    context.RehabilitationInstitutes.RemoveRange(info);
                }
                context.SaveChanges();
            }
        }


    }
}